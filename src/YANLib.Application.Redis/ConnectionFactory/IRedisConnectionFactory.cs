using StackExchange.Redis;

namespace YANLib.ConnectionFactory;

public interface IRedisConnectionFactory
{
    public ConnectionMultiplexer Connection();

    public string ConnectionString();
}
