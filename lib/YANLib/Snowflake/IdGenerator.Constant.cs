namespace YANLib.Snowflake;

/// <summary>
/// Provides a distributed unique ID generator implementation based on the Snowflake algorithm.
/// </summary>
/// <remarks>
/// This partial class contains the constant values used in the Snowflake ID generation algorithm,
/// including bit allocations, maximum values, and shift operations for the different components of the ID.
/// </remarks>
public partial class IdGenerator
{
    /// <summary>
    /// The epoch timestamp in milliseconds (January 1, 2023 00:00:00 UTC).
    /// </summary>
    /// <remarks>
    /// This constant represents the starting point for timestamp calculations in the Snowflake algorithm.
    /// </remarks>
    public const long TIMESTAMP_EPOCH = 1_672_531_200_000;

    private const int TOTAL_BITS = 23;

    // Default bit allocation (5-5-13)
    private const int DEFAULT_WORKER_ID_BITS = 5;
    private const int DEFAULT_DATACENTER_ID_BITS = 5;
    private const int DEFAULT_SEQUENCE_BITS = 13;

    // More Distributed bit allocation (10-10-3)
    private const int MORE_DISTRIBUTED_WORKER_ID_BITS = 10;
    private const int MORE_DISTRIBUTED_DATACENTER_ID_BITS = 10;
    private const int MORE_DISTRIBUTED_SEQUENCE_BITS = 3;

    // High Volume bit allocation (2-2-19)
    private const int HIGH_VOLUME_WORKER_ID_BITS = 2;
    private const int HIGH_VOLUME_DATACENTER_ID_BITS = 2;
    private const int HIGH_VOLUME_SEQUENCE_BITS = 19;

    // Balanced bit allocation (8-8-7)
    private const int BALANCED_WORKER_ID_BITS = 8;
    private const int BALANCED_DATACENTER_ID_BITS = 8;
    private const int BALANCED_SEQUENCE_BITS = 7;

    private const string BASE_ALPHABETIC_CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private static readonly int BASE_ALPHABETIC_CHARS_LENGTH = BASE_ALPHABETIC_CHARS.Length;

    private const string BASE_ALPHANUMERIC_CHARS = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private static readonly int BASE_ALPHANUMERIC_CHARS_LENGTH = BASE_ALPHANUMERIC_CHARS.Length;
}
