using System.Diagnostics;
using static System.DateTimeOffset;

namespace YANLib.Implementation.Snowflake;

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
            result = BASE_ALPHABETIC_CHARS[(int)(value % BASE_ALPHABETIC_CHARS_LENGTH)] + result;
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
            result = BASE_ALPHANUMERIC_CHARS[(int)(value % BASE_ALPHANUMERIC_CHARS_LENGTH)] + result;
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

    #endregion

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal long NextIdImplement(long timestampEpoch = TIMESTAMP_EPOCH)
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
                Sequence = (Sequence + 1) & MAX_SEQUENCE;

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

            return ((currentTimestamp - timestampEpoch) << TIMESTAMP_LEFT_SHIFT) | (DatacenterId << DATACENTER_ID_SHIFT) | (WorkerId << WORKER_ID_SHIFT) | (Sequence & MAX_SEQUENCE);
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal string NextIdAlphabeticImplement(long timestampEpoch = TIMESTAMP_EPOCH) => ToBaseAlphabetic(NextIdImplement(timestampEpoch));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal string NextIdAlphanumericImplement(long timestampEpoch = TIMESTAMP_EPOCH) => ToBaseAlphanumeric(NextIdImplement(timestampEpoch));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static (DateTime Timestamp, long WorkerId, long DatacenterId) ExtractIdComponentsImplement(long id, long timestampEpoch = TIMESTAMP_EPOCH, long sequence = default)
        => (FromUnixTimeMilliseconds((id >> TIMESTAMP_LEFT_SHIFT) + timestampEpoch - sequence).UtcDateTime, (id >> WORKER_ID_SHIFT) & ((1 << WORKER_ID_BITS) - 1), (id >> DATACENTER_ID_SHIFT) & ((1 << DATACENTER_ID_BITS) - 1));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static (DateTime Timestamp, long WorkerId, long DatacenterId) ExtractIdAlphabeticComponentsImplement(string id, long timestampEpoch = TIMESTAMP_EPOCH, long sequence = default)
        => ExtractIdComponentsImplement(FromBaseAlphabetic(id), timestampEpoch, sequence);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static (DateTime Timestamp, long WorkerId, long DatacenterId) ExtractIdAlphanumericComponentsImplement(string id, long timestampEpoch = TIMESTAMP_EPOCH, long sequence = default)
        => ExtractIdComponentsImplement(FromBaseAlphanumeric(id), timestampEpoch, sequence);
}
