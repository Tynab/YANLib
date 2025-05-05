using StackExchange.Redis;

namespace YANLib.ConnectionFactories;

public interface IRedisConnectionFactory
{
    public ConnectionMultiplexer Connection();

    public string ConnectionString();
}
