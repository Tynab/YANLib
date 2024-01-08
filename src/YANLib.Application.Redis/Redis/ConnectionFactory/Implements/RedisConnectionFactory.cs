namespace YANLib.Application.Redis.ConnectionFactory.Implements;

public class RedisConnectionFactory : IRedisConnectionFactory, ISingletonDependency
{
    #region Fields
    private readonly RedisOptions _option;
    private readonly Lazy<ConnectionMultiplexer> _connection;
    #endregion

    #region Constructors
    public RedisConnectionFactory(IOptions<RedisOptions> options)
    {
        _option = options.Value;
        _connection = new Lazy<ConnectionMultiplexer>(() => Connect(_option.RedisConnectionString ?? string.Empty));
    }
    #endregion

    #region Implements
    public ConnectionMultiplexer Connection() => _connection.Value;

    public string ConnectionString() => (_option.RedisConnectionString ?? ",").Split(',')[0];
    #endregion
}
