using System.Diagnostics;
using YANLib.Implementation;
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
        var currentTimestamp = GetCurrentTimestamp();

        while (currentTimestamp <= lastTimestamp)
        {
            currentTimestamp = GetCurrentTimestamp();
        }

        return currentTimestamp;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static string ToBaseAlphabetic(long value)
    {
        var result = string.Empty;

        do
        {
            result = BASE_ALPHABETIC_CHARS[(value % BASE_ALPHABETIC_CHARS_LENGTH).ParseImplement<int>()] + result;
            value /= BASE_ALPHABETIC_CHARS_LENGTH;
        } while (value > 0);

        return result;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static long FromBaseAlphabetic(string value)
    {
        var result = 0L;

        for (var i = 0; i < value.Length; i++)
        {
            result = result * BASE_ALPHABETIC_CHARS_LENGTH + BASE_ALPHABETIC_CHARS.IndexOf(value[i]);
        }

        return result;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static string ToBaseAlphanumeric(long value)
    {
        var result = string.Empty;

        do
        {
            result = BASE_ALPHANUMERIC_CHARS[(value % BASE_ALPHANUMERIC_CHARS_LENGTH).ParseImplement<int>()] + result;
            value /= BASE_ALPHANUMERIC_CHARS_LENGTH;
        } while (value > 0);

        return result;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static long FromBaseAlphanumeric(string value)
    {
        var result = 0L;

        for (var i = 0; i < value.Length; i++)
        {
            result = result * BASE_ALPHANUMERIC_CHARS_LENGTH + BASE_ALPHANUMERIC_CHARS.IndexOf(value[i]);
        }

        return result;
    }

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
    /// <param name="timestampEpoch">The epoch timestamp in milliseconds. Defaults to <see cref="TIMESTAMP_EPOCH"/>.</param>
    /// <returns>A unique 64-bit ID.</returns>
    /// <exception cref="Exception">Thrown when the system clock moves backwards.</exception>
    /// <remarks>
    /// The generated ID is composed of:
    /// - 41 bits for timestamp (milliseconds since epoch)
    /// - Configurable bits for datacenter ID
    /// - Configurable bits for worker ID
    /// - Configurable bits for sequence number
    /// 
    /// This method is thread-safe and can generate multiple unique IDs per millisecond based on the sequence bit allocation.
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
                throw new Exception("Clock moved backwards. Refusing to generate ID for timestamp earlier than last timestamp.");
            }
            else if (currentTimestamp == _lastTimestamp)
            {
                Sequence = (Sequence + 1) & _maxSequence;

                if (Sequence is 0)
                {
                    currentTimestamp = WaitForNextMillisecond(_lastTimestamp);
                }
            }
            else
            {
                Sequence = default;
            }

            _lastTimestamp = currentTimestamp;

            return ((currentTimestamp - timestampEpoch) << _timestampLeftShift) | (DatacenterId << _datacenterIdShift) | (WorkerId << _workerIdShift) | (Sequence & _maxSequence);
        }
    }

    /// <summary>
    /// Generates a new unique ID in base-26 alphabetic format (A-Z).
    /// </summary>
    /// <param name="timestampEpoch">The epoch timestamp in milliseconds. Defaults to <see cref="TIMESTAMP_EPOCH"/>.</param>
    /// <returns>A unique ID as a base-26 alphabetic string.</returns>
    /// <remarks>
    /// This method generates a Snowflake ID and then converts it to a base-26 alphabetic string.
    /// The resulting string is more compact than the decimal representation of the ID.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public string NextIdAlphabetic(long timestampEpoch = TIMESTAMP_EPOCH) => ToBaseAlphabetic(NextId(timestampEpoch));

    /// <summary>
    /// Generates a new unique ID in base-36 alphanumeric format (0-9, A-Z).
    /// </summary>
    /// <param name="timestampEpoch">The epoch timestamp in milliseconds. Defaults to <see cref="TIMESTAMP_EPOCH"/>.</param>
    /// <returns>A unique ID as a base-36 alphanumeric string.</returns>
    /// <remarks>
    /// This method generates a Snowflake ID and then converts it to a base-36 alphanumeric string.
    /// The resulting string is more compact than both the decimal and alphabetic representations of the ID.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public string NextIdAlphanumeric(long timestampEpoch = TIMESTAMP_EPOCH) => ToBaseAlphanumeric(NextId(timestampEpoch));

    /// <summary>
    /// Extracts the timestamp, worker ID, and datacenter ID components from a Snowflake ID.
    /// </summary>
    /// <param name="id">The Snowflake ID to extract components from.</param>
    /// <param name="timestampEpoch">The epoch timestamp in milliseconds. Defaults to <see cref="TIMESTAMP_EPOCH"/>.</param>
    /// <param name="sequence">The sequence value to adjust the timestamp. Defaults to 0.</param>
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
        var timestamp = FromUnixTimeMilliseconds((id >> timestampLeftShift) + timestampEpoch - sequence).UtcDateTime;
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
    /// <param name="sequence">The sequence value to adjust the timestamp. Defaults to 0.</param>
    /// <returns>A tuple containing the timestamp as a <see cref="DateTime"/>, worker ID, and datacenter ID.</returns>
    /// <remarks>
    /// This method simplifies component extraction by using predefined bit allocation strategies.
    /// The strategy must match the one used to generate the ID for correct extraction.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static (DateTime Timestamp, long WorkerId, long DatacenterId) ExtractIdComponents(long id, BitAllocationStrategy strategy, long timestampEpoch = TIMESTAMP_EPOCH, long sequence = default)
    {
        var (workerIdBits, datacenterIdBits, sequenceBits) = GetBitAllocationForStrategy(strategy);

        return ExtractIdComponents(id, timestampEpoch, sequence, workerIdBits, datacenterIdBits, sequenceBits);
    }

    /// <summary>
    /// Extracts the timestamp, worker ID, and datacenter ID components from a base-26 alphabetic Snowflake ID.
    /// </summary>
    /// <param name="id">The base-26 alphabetic Snowflake ID to extract components from.</param>
    /// <param name="timestampEpoch">The epoch timestamp in milliseconds. Defaults to <see cref="TIMESTAMP_EPOCH"/>.</param>
    /// <param name="sequence">The sequence value to adjust the timestamp. Defaults to 0.</param>
    /// <param name="workerIdBits">The number of bits allocated for the worker ID. Defaults to 5.</param>
    /// <param name="datacenterIdBits">The number of bits allocated for the datacenter ID. Defaults to 5.</param>
    /// <param name="sequenceBits">The number of bits allocated for the sequence. Defaults to 13.</param>
    /// <returns>A tuple containing the timestamp as a <see cref="DateTime"/>, worker ID, and datacenter ID.</returns>
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
    ) => ExtractIdComponents(FromBaseAlphabetic(id), timestampEpoch, sequence, workerIdBits, datacenterIdBits, sequenceBits);

    /// <summary>
    /// Extracts the timestamp, worker ID, and datacenter ID components from a base-26 alphabetic Snowflake ID using a predefined bit allocation strategy.
    /// </summary>
    /// <param name="id">The base-26 alphabetic Snowflake ID to extract components from.</param>
    /// <param name="strategy">The bit allocation strategy used when generating the ID.</param>
    /// <param name="timestampEpoch">The epoch timestamp in milliseconds. Defaults to <see cref="TIMESTAMP_EPOCH"/>.</param>
    /// <param name="sequence">The sequence value to adjust the timestamp. Defaults to 0.</param>
    /// <returns>A tuple containing the timestamp as a <see cref="DateTime"/>, worker ID, and datacenter ID.</returns>
    /// <remarks>
    /// This method simplifies component extraction by using predefined bit allocation strategies.
    /// The strategy must match the one used to generate the ID for correct extraction.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static (DateTime Timestamp, long WorkerId, long DatacenterId) ExtractIdAlphabeticComponents(string id, BitAllocationStrategy strategy, long timestampEpoch = TIMESTAMP_EPOCH, long sequence = default)
    {
        var (workerIdBits, datacenterIdBits, sequenceBits) = GetBitAllocationForStrategy(strategy);

        return ExtractIdAlphabeticComponents(id, timestampEpoch, sequence, workerIdBits, datacenterIdBits, sequenceBits);
    }

    /// <summary>
    /// Extracts the timestamp, worker ID, and datacenter ID components from a base-36 alphanumeric Snowflake ID.
    /// </summary>
    /// <param name="id">The base-36 alphanumeric Snowflake ID to extract components from.</param>
    /// <param name="timestampEpoch">The epoch timestamp in milliseconds. Defaults to <see cref="TIMESTAMP_EPOCH"/>.</param>
    /// <param name="sequence">The sequence value to adjust the timestamp. Defaults to 0.</param>
    /// <param name="workerIdBits">The number of bits allocated for the worker ID. Defaults to 5.</param>
    /// <param name="datacenterIdBits">The number of bits allocated for the datacenter ID. Defaults to 5.</param>
    /// <param name="sequenceBits">The number of bits allocated for the sequence. Defaults to 13.</param>
    /// <returns>A tuple containing the timestamp as a <see cref="DateTime"/>, worker ID, and datacenter ID.</returns>
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
    ) => ExtractIdComponents(FromBaseAlphanumeric(id), timestampEpoch, sequence, workerIdBits, datacenterIdBits, sequenceBits);

    /// <summary>
    /// Extracts the timestamp, worker ID, and datacenter ID components from a base-36 alphanumeric Snowflake ID using a predefined bit allocation strategy.
    /// </summary>
    /// <param name="id">The base-36 alphanumeric Snowflake ID to extract components from.</param>
    /// <param name="strategy">The bit allocation strategy used when generating the ID.</param>
    /// <param name="timestampEpoch">The epoch timestamp in milliseconds. Defaults to <see cref="TIMESTAMP_EPOCH"/>.</param>
    /// <param name="sequence">The sequence value to adjust the timestamp. Defaults to 0.</param>
    /// <returns>A tuple containing the timestamp as a <see cref="DateTime"/>, worker ID, and datacenter ID.</returns>
    /// <remarks>
    /// This method simplifies component extraction by using predefined bit allocation strategies.
    /// The strategy must match the one used to generate the ID for correct extraction.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static (DateTime Timestamp, long WorkerId, long DatacenterId) ExtractIdAlphanumericComponents(string id, BitAllocationStrategy strategy, long timestampEpoch = TIMESTAMP_EPOCH, long sequence = default)
    {
        var (workerIdBits, datacenterIdBits, sequenceBits) = GetBitAllocationForStrategy(strategy);

        return ExtractIdAlphanumericComponents(id, timestampEpoch, sequence, workerIdBits, datacenterIdBits, sequenceBits);
    }
}
