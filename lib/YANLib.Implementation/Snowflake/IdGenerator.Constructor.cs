namespace YANLib.Implementation.Snowflake;

public partial class IdGenerator
{
    #region Fields

    private long _lastTimestamp = -1;
    private readonly object _lock = new();

    #endregion

    #region Constructors

    protected internal IdGenerator(long workerId, long datacenterId, long sequence = default)
    {
        if (workerId is < 0 or > MAX_WORKER_ID)
        {
            throw new ArgumentException($"Worker ID must be between 0 and {MAX_WORKER_ID}, but got {workerId}.", nameof(workerId));
        }

        if (datacenterId is < 0 or > MAX_DATACENTER_ID)
        {
            throw new ArgumentException($"Datacenter ID must be between 0 and {MAX_DATACENTER_ID}, but got {datacenterId}.", nameof(datacenterId));
        }

        WorkerId = workerId;
        DatacenterId = datacenterId;
        Sequence = sequence;
    }

    #endregion

    #region Properties

    public long WorkerId { get; protected set; }

    public long DatacenterId { get; protected set; }

    public long Sequence { get; internal set; }

    #endregion
}
