using StackExchange.Redis;
using YANLib.Application.Redis.ConnectionFactory;
using YANLib.Dtos;
using static System.Text.Encoding;

namespace YANLib.Application.Redis.Services.Implements;

public class RedisService : IRedisService<RedisDto>
{
    #region Fields
    private readonly IRedisConnectionFactory _redisConnectionFactory;
    private readonly IDatabase _database;
    #endregion

    #region Constructors
    public RedisService(IRedisConnectionFactory redisConnectionFactory)
    {
        _redisConnectionFactory = redisConnectionFactory;
        _database = _redisConnectionFactory.Connection().GetDatabase();
    }
    #endregion

    #region Implements
    public async ValueTask<IDictionary<string, RedisDto?>?> GetAll(string group)
    {
        if (group.IsWhiteSpaceOrNull())
        {
            return default;
        }
        var rslts = new Dictionary<string, RedisDto?>();
        foreach (var item in (await _database.HashGetAllAsync(group.ToLowerInvariant())).Where(e => e.Name.HasValue && e.Value.HasValue))
        {
            var val = item.Value;
            if (val.HasValue)
            {
                rslts.Add(item.Name.ToString(), UTF8.GetString(val!).Deserialize<RedisDto>());
            }
        }
        return rslts;
    }

    public async ValueTask<RedisDto?> Get(string group, string key)
    {
        if (group.IsWhiteSpaceOrNull() || key.IsWhiteSpaceOrNull())
        {
            return default;
        }
        var val = await _database.HashGetAsync((RedisKey)group.ToLowerInvariant(), (RedisValue)key.ToLowerInvariant());
        return val.HasValue ? UTF8.GetString(val!).Deserialize<RedisDto>() : default;
    }

    public async ValueTask<Dictionary<string, RedisDto?>?> GetBulk(string group, params string[] keys)
    {
        if (group.IsWhiteSpaceOrNull() || keys.AllWhiteSpaceOrNull())
        {
            return default;
        }
        var rslts = new Dictionary<string, RedisDto?>();
        foreach (var key in keys)
        {
            var val = await _database.HashGetAsync((RedisKey)group.ToLowerInvariant(), (RedisValue)key.ToLowerInvariant());
            if (val.HasValue)
            {
                rslts.Add(key, UTF8.GetString(val!).Deserialize<RedisDto>());
            }
        }
        return rslts;
    }

    public Task Set(string group, string key, RedisDto value) => _database.HashSetAsync((RedisKey)group.ToLowerInvariant(), (RedisValue)key.ToLowerInvariant(), value.CamelSerialize());

    public async Task SetBulk(string group, IDictionary<string, RedisDto> fields)
    {
        if (group.IsNotWhiteSpaceAndNull() && fields.IsNotEmptyAndNull())
        {
            await _database.HashSetAsync(group.ToLowerInvariant(), fields.Select(p => new HashEntry(p.Key.ToLowerInvariant(), p.Value.CamelSerialize())).ToArray());
        }
    }

    public async ValueTask<bool> DeleteAll(string group)
    {
        var dic = await GetAll(group);
        return dic!.IsNotEmptyAndNull() && await DeleteBulk(group, dic!.Select(p => p.Key).ToArray());
    }

    public async ValueTask<bool> Delete(string group, string key) => group.IsNotWhiteSpaceAndNull()
        && key.IsNotWhiteSpaceAndNull()
        && await _database.HashDeleteAsync((RedisKey)group.ToLowerInvariant(), (RedisValue)key.ToLowerInvariant());

    public async ValueTask<bool> DeleteBulk(string group, params string[] keys)
    {
        if (group.IsWhiteSpaceOrNull() || keys.AllWhiteSpaceOrNull())
        {
            return false;
        }
        var rslt = true;
        foreach (var key in keys.Where(k => k.IsNotWhiteSpaceAndNull()).Select(k => (RedisValue)k.ToLowerInvariant()))
        {
            rslt = rslt && await _database.HashDeleteAsync((RedisKey)group.ToLowerInvariant(), key);
        }
        return rslt;
    }
    #endregion
}
