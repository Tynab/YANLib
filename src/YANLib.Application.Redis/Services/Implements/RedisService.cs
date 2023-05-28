using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using Volo.Abp;
using YANLib.Application.Redis.ConnectionFactory;
using YANLib.Dtos;
using YANLib.Exceptions;
using static System.Text.Encoding;
using static System.Threading.Tasks.Task;
using static YANLib.Exceptions.ExceptionMessage;

namespace YANLib.Application.Redis.Services.Implements;

public class RedisService : IRedisService<JsonDto>
{
    #region Fields
    private readonly ILogger<RedisService> _logger;
    private readonly IRedisConnectionFactory _connectionFactory;
    private readonly ConnectionMultiplexer _connectionMultiplexer;
    private readonly IDatabase _database;
    #endregion

    #region Constructors
    public RedisService(ILogger<RedisService> logger, IRedisConnectionFactory connectionFactory)
    {
        _logger = logger;
        _connectionFactory = connectionFactory;
        _connectionMultiplexer = _connectionFactory.Connection();
        _database = _connectionMultiplexer.GetDatabase();
    }
    #endregion

    #region Implements
    public async ValueTask<JsonDto?> Get(string group, string key)
    {
        try
        {
            if (group.IsWhiteSpaceOrNull() || key.IsWhiteSpaceOrNull())
            {
                throw new BusinessException(code: ExceptionCode.BAD_REQUEST, message: BAD_REQUEST);
            }
            var val = await _database.HashGetAsync((RedisKey)group.ToLowerInvariant(), (RedisValue)key.ToLowerInvariant());
            return val.HasValue ? UTF8.GetString(val!).Deserialize<JsonDto>() : default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetRedisService-Exception: {Group} ; {Key}", group, key);
            throw;
        }
    }

    public async ValueTask<IDictionary<string, JsonDto?>?> GetBulk(string group, params string[] keys)
    {
        try
        {
            if (group.IsWhiteSpaceOrNull() || keys.AllWhiteSpaceOrNull())
            {
                throw new BusinessException(code: ExceptionCode.BAD_REQUEST, message: BAD_REQUEST);
            }
            var rslts = new Dictionary<string, JsonDto?>();
            var semSlim = new SemaphoreSlim(1);
            await WhenAll(keys.Select(async k =>
            {
                var val = await _database.HashGetAsync((RedisKey)group.ToLowerInvariant(), (RedisValue)k.ToLowerInvariant());
                if (val.HasValue)
                {
                    await semSlim.WaitAsync();
                    try
                    {
                        rslts.Add(k, UTF8.GetString(val!).Deserialize<JsonDto>());
                    }
                    finally
                    {
                        _ = semSlim.Release();
                    }
                }
            }));
            return rslts;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetBulkRedisService-Exception: {Group} ; {Keys}", group, string.Join(", ", keys));
            throw;
        }
    }

    public async ValueTask<IDictionary<string, JsonDto?>?> GetAll(string group)
    {
        try
        {
            if (group.IsWhiteSpaceOrNull())
            {
                throw new BusinessException(code: ExceptionCode.BAD_REQUEST, message: BAD_REQUEST);
            }
            var rslts = new Dictionary<string, JsonDto?>();
            var semSlim = new SemaphoreSlim(1);
            await WhenAll((await _database.HashGetAllAsync(group.ToLowerInvariant())).Where(e => e.Name.HasValue && e.Value.HasValue).Select(async x =>
            {
                var val = x.Value;
                if (val.HasValue)
                {
                    await semSlim.WaitAsync();
                    try
                    {
                        rslts.Add(x.Name.ToString(), UTF8.GetString(val!).Deserialize<JsonDto>());
                    }
                    finally
                    {
                        _ = semSlim.Release();
                    }
                }
            }));
            return rslts;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAllRedisService-Exception: {Group}", group);
            throw;
        }
    }

    public async ValueTask<bool> Set(string group, string key, JsonDto value)
    {
        var jsonVal = value.CamelSerialize();
        try
        {
            return group.IsWhiteSpaceOrNull() || key.IsWhiteSpaceOrNull() || value is null
                ? throw new BusinessException(code: ExceptionCode.BAD_REQUEST, message: BAD_REQUEST)
                : await Delete(group, key) && await _database.HashSetAsync((RedisKey)group.ToLowerInvariant(), (RedisValue)key.ToLowerInvariant(), jsonVal);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SetRedisService-Exception: {Group} ; {Key} ; {Value}", group, key, jsonVal);
            throw;
        }
    }

    public async ValueTask<bool> SetBulk(string group, IDictionary<string, JsonDto> fields)
    {
        try
        {
            if (group.IsWhiteSpaceOrNull() || fields.IsEmptyOrNull())
            {
                throw new BusinessException(code: ExceptionCode.BAD_REQUEST, message: BAD_REQUEST);
            }
            await _database.HashSetAsync(group.ToLowerInvariant(), fields.Select(p => new HashEntry(p.Key.ToLowerInvariant(), p.Value.CamelSerialize())).ToArray());
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SetBulkRedisService-Exception: {Group} ; {Fields}", group, fields.CamelSerialize());
            throw;
        }
    }

    public async ValueTask<bool> Delete(string group, string key)
    {
        try
        {
            return group.IsWhiteSpaceOrNull() || key.IsWhiteSpaceOrNull()
                ? throw new BusinessException(code: ExceptionCode.BAD_REQUEST, message: BAD_REQUEST)
                : await _database.HashDeleteAsync((RedisKey)group.ToLowerInvariant(), (RedisValue)key.ToLowerInvariant());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteRedisService-Exception: {Group} ; {Key}", group, key);
            throw;
        }
    }

    public async ValueTask<bool> DeleteBulk(string group, params string[] keys)
    {
        try
        {
            if (group.IsWhiteSpaceOrNull() || keys.AllWhiteSpaceOrNull())
            {
                throw new BusinessException(code: ExceptionCode.BAD_REQUEST, message: BAD_REQUEST);
            }
            var rslt = true;
            var semSlim = new SemaphoreSlim(1);
            await WhenAll(keys.Where(k => k.IsNotWhiteSpaceAndNull()).Select(async k =>
            {
                await semSlim.WaitAsync();
                try
                {
                    rslt = rslt && await _database.HashDeleteAsync((RedisKey)group.ToLowerInvariant(), (RedisValue)k.ToLowerInvariant());
                }
                finally
                {
                    _ = semSlim.Release();
                }
            }));
            return rslt;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteBulkRedisService-Exception: {Group} ; {Keys}", group, string.Join(", ", keys));
            throw;
        }
    }

    public async ValueTask<bool> DeleteAll(string group)
    {
        try
        {
            if (group.IsWhiteSpaceOrNull())
            {
                throw new BusinessException(code: ExceptionCode.BAD_REQUEST, message: BAD_REQUEST);
            }
            var dic = await GetAll(group);
            return dic!.IsEmptyOrNull() || await DeleteBulk(group, dic!.Select(p => p.Key).ToArray());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteAllRedisService-Exception: {Group}", group);
            throw;
        }
    }

    public async ValueTask<IDictionary<string, IDictionary<string, JsonDto?>?>?> GetGroup(string groupPreffix)
    {
        try
        {
            var redisRslt = await GetGroupKeys(groupPreffix);
            if (redisRslt is not null)
            {
                var keys = (RedisKey[])redisRslt!;
                var rslts = new Dictionary<string, IDictionary<string, JsonDto?>?>();
                if (keys.IsNotEmptyAndNull())
                {
                    var semSlim = new SemaphoreSlim(1);
                    await WhenAll(keys.Select(async k =>
                    {
                        var dic = await GetAll(k!);
                        if (dic!.IsNotEmptyAndNull())
                        {
                            await semSlim.WaitAsync();
                            try
                            {
                                rslts.Add(k.ToString().Split(":").Reverse().FirstOrDefault() ?? string.Empty, dic!);
                            }
                            finally
                            {
                                _ = semSlim.Release();
                            }
                        }
                    }));
                }
                return rslts;
            }
            return default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetGroupRedisService-Exception: {GroupPreffix}", groupPreffix);
            throw;
        }
    }

    public async ValueTask<bool> DeleteGroup(string groupPreffix)
    {
        try
        {
            var redisRslt = await GetGroupKeys(groupPreffix);
            if (redisRslt is not null)
            {
                var keys = (RedisKey[])redisRslt!;
                return keys.IsEmptyOrNull() || await _database.KeyDeleteAsync(keys) > 0;
            }
            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteGroupRedisService-Exception: {GroupPreffix}", groupPreffix);
            throw;
        }
    }
    #endregion

    #region Methods
    private async ValueTask<RedisResult> GetGroupKeys(string groupPreffix)
    {
        try
        {
            return groupPreffix.IsWhiteSpaceOrNull()
                ? throw new BusinessException(code: ExceptionCode.BAD_REQUEST, message: BAD_REQUEST)
                : await _database.ExecuteAsync("KEYS", $"{groupPreffix}*");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetGroupKeysRedisService-Exception: {GroupPreffix}", groupPreffix);
            throw;
        }
    }
    #endregion
}
