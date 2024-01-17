using StackExchange.Redis;

namespace YANLib.Application.Redis.ConnectionFactory;

public interface IRedisConnectionFactory
{
    public ConnectionMultiplexer Connection();

    public string ConnectionString();
}
