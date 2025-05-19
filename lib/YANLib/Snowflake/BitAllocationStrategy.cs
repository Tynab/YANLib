namespace YANLib.Snowflake;

/// <summary>
/// Defines the bit allocation strategies for the Snowflake ID generator.
/// </summary>
/// <remarks>
/// Each strategy allocates the 23 available bits differently between worker ID, datacenter ID, and sequence components,
/// optimizing for different use cases.
/// </remarks>
public enum BitAllocationStrategy
{
    /// <summary>
    /// Default allocation: 5 bits for worker ID, 5 bits for datacenter ID, 13 bits for sequence.
    /// Supports up to 32 workers per datacenter, 32 datacenters, and 8,192 IDs per millisecond per worker.
    /// </summary>
    Default,

    /// <summary>
    /// More distributed allocation: 10 bits for worker ID, 10 bits for datacenter ID, 3 bits for sequence.
    /// Supports up to 1,024 workers per datacenter, 1,024 datacenters, and 8 IDs per millisecond per worker.
    /// Optimized for highly distributed systems with many nodes.
    /// </summary>
    MoreDistributed,

    /// <summary>
    /// High volume allocation: 2 bits for worker ID, 2 bits for datacenter ID, 19 bits for sequence.
    /// Supports up to 4 workers per datacenter, 4 datacenters, and 524,288 IDs per millisecond per worker.
    /// Optimized for high-throughput scenarios with few nodes.
    /// </summary>
    HighVolume,

    /// <summary>
    /// Balanced allocation: 8 bits for worker ID, 8 bits for datacenter ID, 7 bits for sequence.
    /// Supports up to 256 workers per datacenter, 256 datacenters, and 128 IDs per millisecond per worker.
    /// Provides a balance between distribution and sequence capacity.
    /// </summary>
    Balanced
}
