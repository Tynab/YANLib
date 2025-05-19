using System.Diagnostics;

namespace YANLib.Snowflake;

public partial class IdGenerator(long workerId, long datacenterId, long sequence = 0) : Implementation.Snowflake.IdGenerator(workerId, datacenterId, sequence)
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal long NextId(long timestampEpoch = TIMESTAMP_EPOCH) => NextIdImplement(timestampEpoch);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal string NextIdAlphabetic(long timestampEpoch = TIMESTAMP_EPOCH) => NextIdAlphabeticImplement(timestampEpoch);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal string NextIdAlphanumeric(long timestampEpoch = TIMESTAMP_EPOCH) => NextIdAlphanumericImplement(timestampEpoch);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static (DateTime Timestamp, long WorkerId, long DatacenterId) ExtractIdComponents(long id, long timestampEpoch = TIMESTAMP_EPOCH, long sequence = default)
        => ExtractIdComponentsImplement(id, timestampEpoch, sequence);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static (DateTime Timestamp, long WorkerId, long DatacenterId) ExtractIdAlphabeticComponents(string id, long timestampEpoch = TIMESTAMP_EPOCH, long sequence = default)
        => ExtractIdAlphabeticComponentsImplement(id, timestampEpoch, sequence);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static (DateTime Timestamp, long WorkerId, long DatacenterId) ExtractIdAlphanumericComponents(string id, long timestampEpoch = TIMESTAMP_EPOCH, long sequence = default)
        => ExtractIdAlphanumericComponentsImplement(id, timestampEpoch, sequence);
}
