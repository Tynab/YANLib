using Microsoft.Extensions.Options;
using StackExchange.Redis;
using Volo.Abp.DependencyInjection;
using static StackExchange.Redis.ConnectionMultiplexer;

namespace YANLib.Application.Redis.ConnectionFactory.Implements;

public class RedisConnectionFactory : IRedisConnectionFactory, ISingletonDependency
{
    private readonly RedisOptions _option;
    private readonly Lazy<ConnectionMultiplexer> _connection;

    public RedisConnectionFactory(IOptions<RedisOptions> options)
    {
        _option = options.Value;
        _connection = new Lazy<ConnectionMultiplexer>(() => Connect(_option.RedisConnectionString ?? string.Empty));
    }

    public ConnectionMultiplexer Connection() => _connection.Value;

    public string ConnectionString() => (_option.RedisConnectionString ?? ",").Split(',')[0];
}
