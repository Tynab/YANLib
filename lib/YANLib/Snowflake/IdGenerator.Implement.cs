using System.Diagnostics;
using System.Runtime.InteropServices;
using static System.DateTimeOffset;

namespace YANLib.Snowflake;

/// <summary>
/// Provides a distributed unique ID generator implementation based on the Snowflake algorithm.
/// </summary>
/// <remarks>
/// This partial class contains the implementation of the Snowflake ID generation algorithm.
/// The Snowflake algorithm generates 64-bit IDs composed of:
/// - 41 bits for timestamp (milliseconds since epoch)
/// - Configurable bits for datacenter ID
/// - Configurable bits for worker ID
/// - Configurable bits for sequence number
/// 
/// This implementation also provides methods for generating IDs in alphabetic and alphanumeric formats,
/// as well as methods for extracting the components from an existing ID.
/// </remarks>
public partial class IdGenerator
{
    #region Private

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static long GetCurrentTimestamp() => UtcNow.ToUnixTimeMilliseconds();

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static long WaitForNextMillisecond(long lastTimestamp)
    {
        // SpinWait backs off (it pauses, then yields and sleeps) instead of burning a core at 100% while the lock is held; a sleep can end
        // a fraction of a millisecond after the clock has moved on
        var spinner = new SpinWait();
        var currentTimestamp = GetCurrentTimestamp();

        while (currentTimestamp <= lastTimestamp)
        {
            spinner.SpinOnce();
            currentTimestamp = GetCurrentTimestamp();
        }

        return currentTimestamp;
    }

    // A negative ID (its timestamp reaches the sign bit 2^40 ms, about 34.8 years, after timestampEpoch; 8.3.3 also generated one for an
    // epoch later than the current time) is encoded as its unsigned 64-bit two's complement value, so the string only uses the alphabet
    // and FromBase returns the same ID.
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static string ToBase(long value, string alphabet)
    {
        var remaining = unchecked((ulong)value);
        var radix = (ulong)alphabet.Length;
        Span<char> buffer = stackalloc char[64];
        var position = buffer.Length;

        do
        {
            buffer[--position] = alphabet[(int)(remaining % radix)];
            remaining /= radix;
        } while (remaining > 0);

        return new string(buffer[position..]);
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static long FromBase(string value, string alphabet, string alphabetName, string paramName)
    {
        ArgumentNullException.ThrowIfNull(value, paramName);

        if (value.Length is 0)
        {
            throw new ArgumentException("The ID must not be empty.", paramName);
        }

        var radix = (ulong)alphabet.Length;
        var result = 0UL;

        for (var i = 0; i < value.Length; i++)
        {
            var digit = alphabet.IndexOf(value[i]);

            if (digit < 0)
            {
                throw new ArgumentException($"The ID contains '{value[i]}' at position {i}; only the characters {alphabetName} are allowed.", paramName);
            }

            if (result > (ulong.MaxValue - (ulong)digit) / radix)
            {
                throw new ArgumentException($"The ID \"{value}\" is larger than a 64-bit ID.", paramName);
            }

            result = (result * radix) + (ulong)digit;
        }

        return unchecked((long)result);
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static string ToBaseAlphabetic(long value) => ToBase(value, BASE_ALPHABETIC_CHARS);

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static long FromBaseAlphabetic(string value, string paramName) => FromBase(value, BASE_ALPHABETIC_CHARS, "A-Z (upper case)", paramName);

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static string ToBaseAlphanumeric(long value) => ToBase(value, BASE_ALPHANUMERIC_CHARS);

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static long FromBaseAlphanumeric(string value, string paramName) => FromBase(value, BASE_ALPHANUMERIC_CHARS, "0-9 and A-Z (upper case)", paramName);

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static (int WorkerIdBits, int DatacenterIdBits, int SequenceBits) GetBitAllocationForStrategy(BitAllocationStrategy strategy) => strategy switch
    {
        BitAllocationStrategy.MoreDistributed => (MORE_DISTRIBUTED_WORKER_ID_BITS, MORE_DISTRIBUTED_DATACENTER_ID_BITS, MORE_DISTRIBUTED_SEQUENCE_BITS),
        BitAllocationStrategy.HighVolume => (HIGH_VOLUME_WORKER_ID_BITS, HIGH_VOLUME_DATACENTER_ID_BITS, HIGH_VOLUME_SEQUENCE_BITS),
        BitAllocationStrategy.Balanced => (BALANCED_WORKER_ID_BITS, BALANCED_DATACENTER_ID_BITS, BALANCED_SEQUENCE_BITS),
        _ => (DEFAULT_WORKER_ID_BITS, DEFAULT_DATACENTER_ID_BITS, DEFAULT_SEQUENCE_BITS)
    };

    #endregion

    /// <summary>
    /// Generates a new unique ID based on the Snowflake algorithm.
    /// </summary>
    /// <param name="timestampEpoch">
    /// The epoch timestamp in milliseconds. Defaults to <see cref="TIMESTAMP_EPOCH"/>. It must not be later than the current time, nor
    /// 2^41 ms (about 69.7 years) or more before it, so that the time since the epoch fits the 41-bit timestamp field.
    /// </param>
    /// <returns>
    /// A unique 64-bit ID. From 2^40 ms (about 34.8 years) after <paramref name="timestampEpoch"/> on, the timestamp reaches the sign bit
    /// and the ID is negative; <see cref="ExtractIdComponents(long, long, long, int, int, int)"/> reads its timestamp correctly (unsigned).
    /// </returns>
    /// <exception cref="InvalidOperationException">Thrown when the system clock moves backwards (it derives from <see cref="Exception"/>, so existing <c>catch (Exception)</c> blocks still catch it).</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="timestampEpoch"/> is later than the current time, or 2^41 ms or more before it (8.3.3 returned a negative or
    /// wrapped ID instead). The failing call changes nothing: it uses up no sequence number.
    /// </exception>
    /// <remarks>
    /// The generated ID is composed of:
    /// - 41 bits for timestamp (milliseconds since epoch)
    /// - Configurable bits for datacenter ID
    /// - Configurable bits for worker ID
    /// - Configurable bits for sequence number
    /// 
    /// This method is thread-safe and can generate multiple unique IDs per millisecond based on the sequence bit allocation.
    /// The first ID uses the sequence passed to the constructor (0 by default).
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public long NextId(long timestampEpoch = TIMESTAMP_EPOCH)
    {
        lock (_lock)
        {
            var currentTimestamp = GetCurrentTimestamp();

            if (currentTimestamp < _lastTimestamp)
            {
                throw new InvalidOperationException("Clock moved backwards. Refusing to generate ID for timestamp earlier than last timestamp.");
            }

            var sequence = Sequence;

            if (currentTimestamp == _lastTimestamp)
            {
                sequence = (sequence + 1) & MaxSequence;

                if (sequence is 0)
                {
                    currentTimestamp = WaitForNextMillisecond(_lastTimestamp);
                }
            }
            else if (_hasGeneratedId)
            {
                sequence = default;
            }

            // Validated before the state changes, so a failing call uses up no sequence number. The subtraction wraps to a negative value
            // only when the true difference is 2^63 or more.
            var timestamp = unchecked(currentTimestamp - timestampEpoch);

            if (timestamp is < 0 or > MAX_TIMESTAMP)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(timestampEpoch),
                    timestampEpoch,
                    $"The epoch must not be later than the current time ({currentTimestamp}) nor {MAX_TIMESTAMP + 1} ms or more before it, so that the time since the epoch fits the 41-bit timestamp field.");
            }

            // The first ID keeps the sequence passed to the constructor.
            Sequence = sequence;
            _hasGeneratedId = true;
            _lastTimestamp = currentTimestamp;

            return (timestamp << _timestampLeftShift) | (DatacenterId << _datacenterIdShift) | (WorkerId << _workerIdShift) | (sequence & MaxSequence);
        }
    }

    /// <summary>
    /// Generates a new unique ID in base-26 alphabetic format (A-Z).
    /// </summary>
    /// <param name="timestampEpoch">The epoch timestamp in milliseconds. Defaults to <see cref="TIMESTAMP_EPOCH"/>.</param>
    /// <returns>A unique ID as a base-26 alphabetic string (upper-case letters only, 'A' = 0).</returns>
    /// <exception cref="InvalidOperationException">Thrown when the system clock moves backwards.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="timestampEpoch"/> is later than the current time, or 2^41 ms or more before it (see <see cref="NextId(long)"/>).
    /// </exception>
    /// <remarks>
    /// This method generates a Snowflake ID and then converts it to a base-26 alphabetic string.
    /// The resulting string is more compact than the decimal representation of the ID.
    /// A negative ID (from 2^40 ms after <paramref name="timestampEpoch"/> on, see <see cref="NextId(long)"/>) is encoded as its unsigned 64-bit
    /// value, so the string still contains only A-Z and <see cref="ExtractIdAlphabeticComponents(string, long, long, int, int, int)"/> reads the same 64-bit ID from it.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public string NextIdAlphabetic(long timestampEpoch = TIMESTAMP_EPOCH) => ToBaseAlphabetic(NextId(timestampEpoch));

    /// <summary>
    /// Generates a new unique ID in base-36 alphanumeric format (0-9, A-Z).
    /// </summary>
    /// <param name="timestampEpoch">The epoch timestamp in milliseconds. Defaults to <see cref="TIMESTAMP_EPOCH"/>.</param>
    /// <returns>A unique ID as a base-36 alphanumeric string (digits and upper-case letters only).</returns>
    /// <exception cref="InvalidOperationException">Thrown when the system clock moves backwards.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="timestampEpoch"/> is later than the current time, or 2^41 ms or more before it (see <see cref="NextId(long)"/>).
    /// </exception>
    /// <remarks>
    /// This method generates a Snowflake ID and then converts it to a base-36 alphanumeric string.
    /// The resulting string is more compact than both the decimal and alphabetic representations of the ID.
    /// A negative ID (from 2^40 ms after <paramref name="timestampEpoch"/> on, see <see cref="NextId(long)"/>) is encoded as its unsigned 64-bit
    /// value, so the string still contains only 0-9 and A-Z and <see cref="ExtractIdAlphanumericComponents(string, long, long, int, int, int)"/> reads the same 64-bit ID from it.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public string NextIdAlphanumeric(long timestampEpoch = TIMESTAMP_EPOCH) => ToBaseAlphanumeric(NextId(timestampEpoch));

    /// <summary>
    /// Extracts the timestamp, worker ID, and datacenter ID components from a Snowflake ID.
    /// </summary>
    /// <param name="id">The Snowflake ID to extract components from.</param>
    /// <param name="timestampEpoch">The epoch timestamp in milliseconds. Defaults to <see cref="TIMESTAMP_EPOCH"/>.</param>
    /// <param name="sequence">Ignored; kept for compatibility. Earlier versions subtracted it, in milliseconds, from the extracted timestamp.</param>
    /// <param name="workerIdBits">The number of bits allocated for the worker ID. Defaults to 5.</param>
    /// <param name="datacenterIdBits">The number of bits allocated for the datacenter ID. Defaults to 5.</param>
    /// <param name="sequenceBits">The number of bits allocated for the sequence. Defaults to 13.</param>
    /// <returns>A tuple containing the timestamp as a <see cref="DateTime"/>, worker ID, and datacenter ID.</returns>
    /// <exception cref="ArgumentException">Thrown when the total bits allocated exceeds 23.</exception>
    /// <remarks>
    /// This method reverses the ID generation process to extract the original components.
    /// The timestamp is converted to a UTC <see cref="DateTime"/> for easier use.
    /// The bit allocations must match those used to generate the ID for correct extraction.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static (DateTime Timestamp, long WorkerId, long DatacenterId) ExtractIdComponents(
        long id,
        long timestampEpoch = TIMESTAMP_EPOCH,
        long sequence = default,
        int workerIdBits = DEFAULT_WORKER_ID_BITS,
        int datacenterIdBits = DEFAULT_DATACENTER_ID_BITS,
        int sequenceBits = DEFAULT_SEQUENCE_BITS
    )
    {
        // Validate bit allocations
        if (workerIdBits < 0)
        {
            throw new ArgumentException("Worker ID bits must be non-negative.", nameof(workerIdBits));
        }

        if (datacenterIdBits < 0)
        {
            throw new ArgumentException("Datacenter ID bits must be non-negative.", nameof(datacenterIdBits));
        }

        if (sequenceBits < 0)
        {
            throw new ArgumentException("Sequence bits must be non-negative.", nameof(sequenceBits));
        }

        if (workerIdBits + datacenterIdBits + sequenceBits != TOTAL_BITS)
        {
            throw new ArgumentException($"The total bits allocated for worker ID, datacenter ID, and sequence must equal {TOTAL_BITS}.");
        }

        // Calculate shifts
        var workerIdShift = sequenceBits;
        var datacenterIdShift = sequenceBits + workerIdBits;
        var timestampLeftShift = sequenceBits + workerIdBits + datacenterIdBits;

        // Extract components
        // Unsigned shift: the 41-bit timestamp field ends at the sign bit, so an ID made 2^40 ms or more after the epoch is negative.
        var timestamp = FromUnixTimeMilliseconds((long)((ulong)id >> timestampLeftShift) + timestampEpoch).UtcDateTime;
        var workerId = (id >> workerIdShift) & ((1L << workerIdBits) - 1);
        var datacenterId = (id >> datacenterIdShift) & ((1L << datacenterIdBits) - 1);

        return (timestamp, workerId, datacenterId);
    }

    /// <summary>
    /// Extracts the timestamp, worker ID, and datacenter ID components from a Snowflake ID using a predefined bit allocation strategy.
    /// </summary>
    /// <param name="id">The Snowflake ID to extract components from.</param>
    /// <param name="strategy">The bit allocation strategy used when generating the ID.</param>
    /// <param name="timestampEpoch">The epoch timestamp in milliseconds. Defaults to <see cref="TIMESTAMP_EPOCH"/>.</param>
    /// <returns>A tuple containing the timestamp as a <see cref="DateTime"/>, worker ID, and datacenter ID.</returns>
    /// <remarks>
    /// This method simplifies component extraction by using predefined bit allocation strategies.
    /// The strategy must match the one used to generate the ID for correct extraction.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static (DateTime Timestamp, long WorkerId, long DatacenterId) ExtractIdComponents(long id, BitAllocationStrategy strategy, long timestampEpoch = TIMESTAMP_EPOCH)
    {
        var (workerIdBits, datacenterIdBits, sequenceBits) = GetBitAllocationForStrategy(strategy);

        return ExtractIdComponents(id, timestampEpoch, default, workerIdBits, datacenterIdBits, sequenceBits);
    }

    /// <summary>
    /// Extracts the timestamp, worker ID, and datacenter ID components from a Snowflake ID using a predefined bit allocation strategy.
    /// Obsolete: the <paramref name="sequence"/> argument is ignored; use <see cref="ExtractIdComponents(long, BitAllocationStrategy, long)"/>.
    /// </summary>
    /// <param name="id">The Snowflake ID to extract components from.</param>
    /// <param name="strategy">The bit allocation strategy used when generating the ID.</param>
    /// <param name="timestampEpoch">The epoch timestamp in milliseconds. Defaults to <see cref="TIMESTAMP_EPOCH"/>.</param>
    /// <param name="sequence">
    /// Ignored; kept for compatibility. Earlier versions subtracted it, in milliseconds, from the extracted timestamp. Since 8.4.0 this overload
    /// is obsolete and is chosen only when <paramref name="sequence"/> is passed; leave it out to call the overload without it.
    /// </param>
    /// <returns>A tuple containing the timestamp as a <see cref="DateTime"/>, worker ID, and datacenter ID.</returns>
    /// <remarks>
    /// The result is that of <see cref="ExtractIdComponents(long, BitAllocationStrategy, long)"/>. <paramref name="timestampEpoch"/> is still
    /// optional for a call that names <paramref name="sequence"/> (<c>ExtractIdComponents(id, strategy, sequence: 0)</c>).
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    [Obsolete("The sequence argument is ignored. Leave it out to call ExtractIdComponents(long, BitAllocationStrategy, long).")]
    public static (DateTime Timestamp, long WorkerId, long DatacenterId) ExtractIdComponents(
        long id,
        BitAllocationStrategy strategy,
        [Optional, DefaultParameterValue(TIMESTAMP_EPOCH)] long timestampEpoch,
        long sequence
    ) => ExtractIdComponents(id, strategy, timestampEpoch);

    /// <summary>
    /// Extracts the timestamp, worker ID, and datacenter ID components from a base-26 alphabetic Snowflake ID.
    /// </summary>
    /// <param name="id">The base-26 alphabetic Snowflake ID to extract components from.</param>
    /// <param name="timestampEpoch">The epoch timestamp in milliseconds. Defaults to <see cref="TIMESTAMP_EPOCH"/>.</param>
    /// <param name="sequence">Ignored; kept for compatibility. Earlier versions subtracted it, in milliseconds, from the extracted timestamp.</param>
    /// <param name="workerIdBits">The number of bits allocated for the worker ID. Defaults to 5.</param>
    /// <param name="datacenterIdBits">The number of bits allocated for the datacenter ID. Defaults to 5.</param>
    /// <param name="sequenceBits">The number of bits allocated for the sequence. Defaults to 13.</param>
    /// <returns>A tuple containing the timestamp as a <see cref="DateTime"/>, worker ID, and datacenter ID.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="id"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="id"/> is empty, contains a character other than A-Z (lower-case letters are rejected), or is larger than a 64-bit value.</exception>
    /// <remarks>
    /// This method first converts the alphabetic ID to its numeric form and then extracts the components.
    /// The bit allocations must match those used to generate the ID for correct extraction.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static (DateTime Timestamp, long WorkerId, long DatacenterId) ExtractIdAlphabeticComponents(
        string id,
        long timestampEpoch = TIMESTAMP_EPOCH,
        long sequence = default,
        int workerIdBits = DEFAULT_WORKER_ID_BITS,
        int datacenterIdBits = DEFAULT_DATACENTER_ID_BITS,
        int sequenceBits = DEFAULT_SEQUENCE_BITS
    ) => ExtractIdComponents(FromBaseAlphabetic(id, nameof(id)), timestampEpoch, sequence, workerIdBits, datacenterIdBits, sequenceBits);

    /// <summary>
    /// Extracts the timestamp, worker ID, and datacenter ID components from a base-26 alphabetic Snowflake ID using a predefined bit allocation strategy.
    /// </summary>
    /// <param name="id">The base-26 alphabetic Snowflake ID to extract components from.</param>
    /// <param name="strategy">The bit allocation strategy used when generating the ID.</param>
    /// <param name="timestampEpoch">The epoch timestamp in milliseconds. Defaults to <see cref="TIMESTAMP_EPOCH"/>.</param>
    /// <returns>A tuple containing the timestamp as a <see cref="DateTime"/>, worker ID, and datacenter ID.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="id"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="id"/> is empty, contains a character other than A-Z (lower-case letters are rejected), or is larger than a 64-bit value.</exception>
    /// <remarks>
    /// This method simplifies component extraction by using predefined bit allocation strategies.
    /// The strategy must match the one used to generate the ID for correct extraction.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static (DateTime Timestamp, long WorkerId, long DatacenterId) ExtractIdAlphabeticComponents(string id, BitAllocationStrategy strategy, long timestampEpoch = TIMESTAMP_EPOCH)
    {
        var (workerIdBits, datacenterIdBits, sequenceBits) = GetBitAllocationForStrategy(strategy);

        return ExtractIdAlphabeticComponents(id, timestampEpoch, default, workerIdBits, datacenterIdBits, sequenceBits);
    }

    /// <summary>
    /// Extracts the timestamp, worker ID, and datacenter ID components from a base-26 alphabetic Snowflake ID using a predefined bit allocation strategy.
    /// Obsolete: the <paramref name="sequence"/> argument is ignored; use <see cref="ExtractIdAlphabeticComponents(string, BitAllocationStrategy, long)"/>.
    /// </summary>
    /// <param name="id">The base-26 alphabetic Snowflake ID to extract components from.</param>
    /// <param name="strategy">The bit allocation strategy used when generating the ID.</param>
    /// <param name="timestampEpoch">The epoch timestamp in milliseconds. Defaults to <see cref="TIMESTAMP_EPOCH"/>.</param>
    /// <param name="sequence">
    /// Ignored; kept for compatibility. Earlier versions subtracted it, in milliseconds, from the extracted timestamp. Since 8.4.0 this overload
    /// is obsolete and is chosen only when <paramref name="sequence"/> is passed; leave it out to call the overload without it.
    /// </param>
    /// <returns>A tuple containing the timestamp as a <see cref="DateTime"/>, worker ID, and datacenter ID.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="id"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="id"/> is empty, contains a character other than A-Z (lower-case letters are rejected), or is larger than a 64-bit value.</exception>
    /// <remarks>
    /// The result is that of <see cref="ExtractIdAlphabeticComponents(string, BitAllocationStrategy, long)"/>. <paramref name="timestampEpoch"/> is still
    /// optional for a call that names <paramref name="sequence"/> (<c>ExtractIdAlphabeticComponents(id, strategy, sequence: 0)</c>).
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    [Obsolete("The sequence argument is ignored. Leave it out to call ExtractIdAlphabeticComponents(string, BitAllocationStrategy, long).")]
    public static (DateTime Timestamp, long WorkerId, long DatacenterId) ExtractIdAlphabeticComponents(
        string id,
        BitAllocationStrategy strategy,
        [Optional, DefaultParameterValue(TIMESTAMP_EPOCH)] long timestampEpoch,
        long sequence
    ) => ExtractIdAlphabeticComponents(id, strategy, timestampEpoch);

    /// <summary>
    /// Extracts the timestamp, worker ID, and datacenter ID components from a base-36 alphanumeric Snowflake ID.
    /// </summary>
    /// <param name="id">The base-36 alphanumeric Snowflake ID to extract components from.</param>
    /// <param name="timestampEpoch">The epoch timestamp in milliseconds. Defaults to <see cref="TIMESTAMP_EPOCH"/>.</param>
    /// <param name="sequence">Ignored; kept for compatibility. Earlier versions subtracted it, in milliseconds, from the extracted timestamp.</param>
    /// <param name="workerIdBits">The number of bits allocated for the worker ID. Defaults to 5.</param>
    /// <param name="datacenterIdBits">The number of bits allocated for the datacenter ID. Defaults to 5.</param>
    /// <param name="sequenceBits">The number of bits allocated for the sequence. Defaults to 13.</param>
    /// <returns>A tuple containing the timestamp as a <see cref="DateTime"/>, worker ID, and datacenter ID.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="id"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="id"/> is empty, contains a character other than 0-9 and A-Z (lower-case letters are rejected), or is larger than a 64-bit value.</exception>
    /// <remarks>
    /// This method first converts the alphanumeric ID to its numeric form and then extracts the components.
    /// The bit allocations must match those used to generate the ID for correct extraction.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static (DateTime Timestamp, long WorkerId, long DatacenterId) ExtractIdAlphanumericComponents(
        string id,
        long timestampEpoch = TIMESTAMP_EPOCH,
        long sequence = default,
        int workerIdBits = DEFAULT_WORKER_ID_BITS,
        int datacenterIdBits = DEFAULT_DATACENTER_ID_BITS,
        int sequenceBits = DEFAULT_SEQUENCE_BITS
    ) => ExtractIdComponents(FromBaseAlphanumeric(id, nameof(id)), timestampEpoch, sequence, workerIdBits, datacenterIdBits, sequenceBits);

    /// <summary>
    /// Extracts the timestamp, worker ID, and datacenter ID components from a base-36 alphanumeric Snowflake ID using a predefined bit allocation strategy.
    /// </summary>
    /// <param name="id">The base-36 alphanumeric Snowflake ID to extract components from.</param>
    /// <param name="strategy">The bit allocation strategy used when generating the ID.</param>
    /// <param name="timestampEpoch">The epoch timestamp in milliseconds. Defaults to <see cref="TIMESTAMP_EPOCH"/>.</param>
    /// <returns>A tuple containing the timestamp as a <see cref="DateTime"/>, worker ID, and datacenter ID.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="id"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="id"/> is empty, contains a character other than 0-9 and A-Z (lower-case letters are rejected), or is larger than a 64-bit value.</exception>
    /// <remarks>
    /// This method simplifies component extraction by using predefined bit allocation strategies.
    /// The strategy must match the one used to generate the ID for correct extraction.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static (DateTime Timestamp, long WorkerId, long DatacenterId) ExtractIdAlphanumericComponents(string id, BitAllocationStrategy strategy, long timestampEpoch = TIMESTAMP_EPOCH)
    {
        var (workerIdBits, datacenterIdBits, sequenceBits) = GetBitAllocationForStrategy(strategy);

        return ExtractIdAlphanumericComponents(id, timestampEpoch, default, workerIdBits, datacenterIdBits, sequenceBits);
    }

    /// <summary>
    /// Extracts the timestamp, worker ID, and datacenter ID components from a base-36 alphanumeric Snowflake ID using a predefined bit allocation strategy.
    /// Obsolete: the <paramref name="sequence"/> argument is ignored; use <see cref="ExtractIdAlphanumericComponents(string, BitAllocationStrategy, long)"/>.
    /// </summary>
    /// <param name="id">The base-36 alphanumeric Snowflake ID to extract components from.</param>
    /// <param name="strategy">The bit allocation strategy used when generating the ID.</param>
    /// <param name="timestampEpoch">The epoch timestamp in milliseconds. Defaults to <see cref="TIMESTAMP_EPOCH"/>.</param>
    /// <param name="sequence">
    /// Ignored; kept for compatibility. Earlier versions subtracted it, in milliseconds, from the extracted timestamp. Since 8.4.0 this overload
    /// is obsolete and is chosen only when <paramref name="sequence"/> is passed; leave it out to call the overload without it.
    /// </param>
    /// <returns>A tuple containing the timestamp as a <see cref="DateTime"/>, worker ID, and datacenter ID.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="id"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="id"/> is empty, contains a character other than 0-9 and A-Z (lower-case letters are rejected), or is larger than a 64-bit value.</exception>
    /// <remarks>
    /// The result is that of <see cref="ExtractIdAlphanumericComponents(string, BitAllocationStrategy, long)"/>. <paramref name="timestampEpoch"/> is still
    /// optional for a call that names <paramref name="sequence"/> (<c>ExtractIdAlphanumericComponents(id, strategy, sequence: 0)</c>).
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    [Obsolete("The sequence argument is ignored. Leave it out to call ExtractIdAlphanumericComponents(string, BitAllocationStrategy, long).")]
    public static (DateTime Timestamp, long WorkerId, long DatacenterId) ExtractIdAlphanumericComponents(
        string id,
        BitAllocationStrategy strategy,
        [Optional, DefaultParameterValue(TIMESTAMP_EPOCH)] long timestampEpoch,
        long sequence
    ) => ExtractIdAlphanumericComponents(id, strategy, timestampEpoch);
}
