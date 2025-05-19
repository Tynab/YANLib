namespace YANLib.Snowflake;

/// <summary>
/// Provides a distributed unique ID generator implementation based on the Snowflake algorithm.
/// </summary>
/// <remarks>
/// This partial class contains the fields, constructors, and properties for the IdGenerator.
/// The Snowflake algorithm generates 64-bit IDs composed of a timestamp, datacenter ID, worker ID, and sequence number.
/// </remarks>
public partial class IdGenerator
{
    #region Fields

    private long _lastTimestamp = -1;
    private readonly object _lock = new();

    private readonly int _workerIdBits;
    private readonly int _datacenterIdBits;
    private readonly int _sequenceBits;

    private readonly long _maxWorkerId;
    private readonly long _maxDatacenterId;
    private readonly long _maxSequence;

    private readonly int _workerIdShift;
    private readonly int _datacenterIdShift;
    private readonly int _timestampLeftShift;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="IdGenerator"/> class with the specified worker ID and datacenter ID.
    /// </summary>
    /// <param name="workerId">The worker ID. Must be unique within the datacenter and within the valid range.</param>
    /// <param name="datacenterId">The datacenter ID. Must be unique across datacenters and within the valid range.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="workerId"/> or <paramref name="datacenterId"/> is outside the valid range.
    /// </exception>
    /// <remarks>
    /// This constructor uses the default bit allocation (5 bits for worker ID, 5 bits for datacenter ID, 13 bits for sequence).
    /// </remarks>
    public IdGenerator(long workerId, long datacenterId) : this(workerId, datacenterId, 0, DEFAULT_WORKER_ID_BITS, DEFAULT_DATACENTER_ID_BITS, DEFAULT_SEQUENCE_BITS) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="IdGenerator"/> class with the specified worker ID, datacenter ID, and sequence.
    /// </summary>
    /// <param name="workerId">The worker ID. Must be unique within the datacenter and within the valid range.</param>
    /// <param name="datacenterId">The datacenter ID. Must be unique across datacenters and within the valid range.</param>
    /// <param name="sequence">The initial sequence value.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="workerId"/> or <paramref name="datacenterId"/> is outside the valid range.
    /// </exception>
    /// <remarks>
    /// This constructor uses the default bit allocation (5 bits for worker ID, 5 bits for datacenter ID, 13 bits for sequence).
    /// </remarks>
    public IdGenerator(long workerId, long datacenterId, long sequence) : this(workerId, datacenterId, sequence, DEFAULT_WORKER_ID_BITS, DEFAULT_DATACENTER_ID_BITS, DEFAULT_SEQUENCE_BITS) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="IdGenerator"/> class with the specified worker ID, datacenter ID, sequence,
    /// and custom bit allocation.
    /// </summary>
    /// <param name="workerId">The worker ID. Must be unique within the datacenter and within the valid range.</param>
    /// <param name="datacenterId">The datacenter ID. Must be unique across datacenters and within the valid range.</param>
    /// <param name="sequence">The initial sequence value.</param>
    /// <param name="workerIdBits">The number of bits to allocate for the worker ID.</param>
    /// <param name="datacenterIdBits">The number of bits to allocate for the datacenter ID.</param>
    /// <param name="sequenceBits">The number of bits to allocate for the sequence.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="workerId"/> or <paramref name="datacenterId"/> is outside the valid range,
    /// or when the total bits allocated exceeds 23.
    /// </exception>
    /// <remarks>
    /// The worker ID and datacenter ID must be within their respective valid ranges to ensure uniqueness of generated IDs.
    /// The total number of bits allocated for worker ID, datacenter ID, and sequence must equal 23.
    /// </remarks>
    public IdGenerator(long workerId, long datacenterId, long sequence, int workerIdBits, int datacenterIdBits, int sequenceBits)
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

        // Set bit allocations
        _workerIdBits = workerIdBits;
        _datacenterIdBits = datacenterIdBits;
        _sequenceBits = sequenceBits;

        // Calculate maximum values
        _maxWorkerId = -1L ^ (-1L << _workerIdBits);
        _maxDatacenterId = -1L ^ (-1L << _datacenterIdBits);
        _maxSequence = -1L ^ (-1L << _sequenceBits);

        // Calculate shifts
        _workerIdShift = _sequenceBits;
        _datacenterIdShift = _sequenceBits + _workerIdBits;
        _timestampLeftShift = _sequenceBits + _workerIdBits + _datacenterIdBits;

        // Validate IDs
        if (workerId < 0 || workerId > _maxWorkerId)
        {
            throw new ArgumentException($"Worker ID must be between 0 and {_maxWorkerId}, but got {workerId}.", nameof(workerId));
        }

        if (datacenterId < 0 || datacenterId > _maxDatacenterId)
        {
            throw new ArgumentException($"Datacenter ID must be between 0 and {_maxDatacenterId}, but got {datacenterId}.", nameof(datacenterId));
        }

        WorkerId = workerId;
        DatacenterId = datacenterId;
        Sequence = sequence;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IdGenerator"/> class with the specified worker ID, datacenter ID,
    /// and a predefined bit allocation strategy.
    /// </summary>
    /// <param name="workerId">The worker ID. Must be unique within the datacenter and within the valid range for the selected strategy.</param>
    /// <param name="datacenterId">The datacenter ID. Must be unique across datacenters and within the valid range for the selected strategy.</param>
    /// <param name="strategy">The bit allocation strategy to use.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="workerId"/> or <paramref name="datacenterId"/> is outside the valid range for the selected strategy.
    /// </exception>
    /// <remarks>
    /// This constructor simplifies the creation of an IdGenerator by using predefined bit allocation strategies.
    /// Each strategy optimizes for different scenarios:
    /// - Default: Balanced approach suitable for most applications
    /// - MoreDistributed: Optimized for systems with many workers and datacenters
    /// - HighVolume: Optimized for generating many IDs per millisecond on few nodes
    /// - Balanced: Middle ground between distribution and sequence capacity
    /// </remarks>
    public IdGenerator(long workerId, long datacenterId, BitAllocationStrategy strategy) : this(workerId, datacenterId, 0, strategy) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="IdGenerator"/> class with the specified worker ID, datacenter ID, sequence,
    /// and a predefined bit allocation strategy.
    /// </summary>
    /// <param name="workerId">The worker ID. Must be unique within the datacenter and within the valid range for the selected strategy.</param>
    /// <param name="datacenterId">The datacenter ID. Must be unique across datacenters and within the valid range for the selected strategy.</param>
    /// <param name="sequence">The initial sequence value.</param>
    /// <param name="strategy">The bit allocation strategy to use.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="workerId"/> or <paramref name="datacenterId"/> is outside the valid range for the selected strategy.
    /// </exception>
    /// <remarks>
    /// This constructor simplifies the creation of an IdGenerator by using predefined bit allocation strategies.
    /// Each strategy optimizes for different scenarios:
    /// - Default: Balanced approach suitable for most applications
    /// - MoreDistributed: Optimized for systems with many workers and datacenters
    /// - HighVolume: Optimized for generating many IDs per millisecond on few nodes
    /// - Balanced: Middle ground between distribution and sequence capacity
    /// </remarks>
    public IdGenerator(long workerId, long datacenterId, long sequence, BitAllocationStrategy strategy)
    {
        switch (strategy)
        {
            case BitAllocationStrategy.MoreDistributed:
            {
                _workerIdBits = MORE_DISTRIBUTED_WORKER_ID_BITS;
                _datacenterIdBits = MORE_DISTRIBUTED_DATACENTER_ID_BITS;
                _sequenceBits = MORE_DISTRIBUTED_SEQUENCE_BITS;
                break;
            }
            case BitAllocationStrategy.HighVolume:
            {
                _workerIdBits = HIGH_VOLUME_WORKER_ID_BITS;
                _datacenterIdBits = HIGH_VOLUME_DATACENTER_ID_BITS;
                _sequenceBits = HIGH_VOLUME_SEQUENCE_BITS;
                break;
            }
            case BitAllocationStrategy.Balanced:
            {
                _workerIdBits = BALANCED_WORKER_ID_BITS;
                _datacenterIdBits = BALANCED_DATACENTER_ID_BITS;
                _sequenceBits = BALANCED_SEQUENCE_BITS;
                break;
            }
            case BitAllocationStrategy.Default:
            default:
            {
                _workerIdBits = DEFAULT_WORKER_ID_BITS;
                _datacenterIdBits = DEFAULT_DATACENTER_ID_BITS;
                _sequenceBits = DEFAULT_SEQUENCE_BITS;
                break;
            }
        }

        // Calculate maximum values
        _maxWorkerId = -1L ^ (-1L << _workerIdBits);
        _maxDatacenterId = -1L ^ (-1L << _datacenterIdBits);
        _maxSequence = -1L ^ (-1L << _sequenceBits);

        // Calculate shifts
        _workerIdShift = _sequenceBits;
        _datacenterIdShift = _sequenceBits + _workerIdBits;
        _timestampLeftShift = _sequenceBits + _workerIdBits + _datacenterIdBits;

        // Validate IDs
        if (workerId < 0 || workerId > _maxWorkerId)
        {
            throw new ArgumentException($"Worker ID must be between 0 and {_maxWorkerId}, but got {workerId}.", nameof(workerId));
        }

        if (datacenterId < 0 || datacenterId > _maxDatacenterId)
        {
            throw new ArgumentException($"Datacenter ID must be between 0 and {_maxDatacenterId}, but got {datacenterId}.", nameof(datacenterId));
        }

        WorkerId = workerId;
        DatacenterId = datacenterId;
        Sequence = sequence;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the worker ID component of this ID generator.
    /// </summary>
    /// <remarks>
    /// The worker ID identifies the worker or process within a datacenter.
    /// </remarks>
    public long WorkerId { get; protected set; }

    /// <summary>
    /// Gets the datacenter ID component of this ID generator.
    /// </summary>
    /// <remarks>
    /// The datacenter ID identifies the datacenter where this ID generator is running.
    /// </remarks>
    public long DatacenterId { get; protected set; }

    /// <summary>
    /// Gets or sets the sequence component of this ID generator.
    /// </summary>
    /// <remarks>
    /// The sequence is incremented for every ID generated within the same millisecond and is reset when the clock moves forward.
    /// </remarks>
    public long Sequence { get; internal set; }

    /// <summary>
    /// Gets the number of bits allocated for the worker ID component.
    /// </summary>
    public int WorkerIdBits => _workerIdBits;

    /// <summary>
    /// Gets the number of bits allocated for the datacenter ID component.
    /// </summary>
    public int DatacenterIdBits => _datacenterIdBits;

    /// <summary>
    /// Gets the number of bits allocated for the sequence component.
    /// </summary>
    public int SequenceBits => _sequenceBits;

    /// <summary>
    /// Gets the maximum value for the worker ID component.
    /// </summary>
    public long MaxWorkerId => _maxWorkerId;

    /// <summary>
    /// Gets the maximum value for the datacenter ID component.
    /// </summary>
    public long MaxDatacenterId => _maxDatacenterId;

    /// <summary>
    /// Gets the maximum value for the sequence component.
    /// </summary>
    public long MaxSequence => _maxSequence;

    #endregion
}
