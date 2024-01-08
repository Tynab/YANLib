using YANLib.Application.Redis.ConnectionFactory;

namespace YANLib.Application.Redis.Services.Implements;

public class DeveloperTypeRedisService : IRedisService<DeveloperTypeRedisDto>
{
    #region Fields
    private readonly ILogger<DeveloperTypeRedisService> _logger;
    private readonly IRedisConnectionFactory _connectionFactory;
    private readonly ConnectionMultiplexer _connectionMultiplexer;
    private readonly IDatabase _database;
    #endregion

    #region Constructors
    public DeveloperTypeRedisService(ILogger<DeveloperTypeRedisService> logger, IRedisConnectionFactory connectionFactory)
    {
        _logger = logger;
        _connectionFactory = connectionFactory;
        _connectionMultiplexer = _connectionFactory.Connection();
        _database = _connectionMultiplexer.GetDatabase();
    }
    #endregion

    #region Implements
    public async ValueTask<DeveloperTypeRedisDto?> Get(string group, string key)
    {
        try
        {
            if (group.IsWhiteSpaceOrNull() || key.IsWhiteSpaceOrNull())
            {
                throw new BusinessException(BAD_REQUEST);
            }

            var val = await _database.HashGetAsync((RedisKey)group.ToLowerInvariant(), (RedisValue)key.ToLowerInvariant());

            return val.HasValue ? UTF8.GetString(val!).Deserialize<DeveloperTypeRedisDto>() : default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetDeveloperTypeRedisService-Exception: {Group} - {Key}", group, key);
            throw;
        }
    }

    public async ValueTask<IDictionary<string, DeveloperTypeRedisDto?>?> GetBulk(string group, params string[] keys)
    {
        try
        {
            if (group.IsWhiteSpaceOrNull() || keys.AllWhiteSpaceOrNull())
            {
                throw new BusinessException(BAD_REQUEST);
            }

            var rslts = new Dictionary<string, DeveloperTypeRedisDto?>();
            var semSlim = new SemaphoreSlim(1);

            await WhenAll(keys.Select(async k =>
            {
                await semSlim.WaitAsync();

                try
                {
                    var val = await _database.HashGetAsync((RedisKey)group.ToLowerInvariant(), (RedisValue)k.ToLowerInvariant());

                    if (val.HasValue)
                    {
                        rslts.Add(k, UTF8.GetString(val!).Deserialize<DeveloperTypeRedisDto>());
                    }
                }
                finally
                {
                    _ = semSlim.Release();
                }
            }));

            return rslts;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetBulkDeveloperTypeRedisService-Exception: {Group} - {Keys}", group, string.Join(", ", keys));
            throw;
        }
    }

    public async ValueTask<IDictionary<string, DeveloperTypeRedisDto?>?> GetAll(string group)
    {
        try
        {
            if (group.IsWhiteSpaceOrNull())
            {
                throw new BusinessException(BAD_REQUEST);
            }

            var rslts = new Dictionary<string, DeveloperTypeRedisDto?>();
            var semSlim = new SemaphoreSlim(1);

            await WhenAll((await _database.HashGetAllAsync(group.ToLowerInvariant())).Where(e => e.Name.HasValue && e.Value.HasValue).Select(async x =>
            {
                var val = x.Value;

                if (val.HasValue)
                {
                    await semSlim.WaitAsync();

                    try
                    {
                        rslts.Add(x.Name.ToString(), UTF8.GetString(val!).Deserialize<DeveloperTypeRedisDto>());
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
            _logger.LogError(ex, "GetAllDeveloperTypeRedisService-Exception: {Group}", group);
            throw;
        }
    }

    public async ValueTask<bool> Set(string group, string key, DeveloperTypeRedisDto value)
    {
        var jsonVal = value.Serialize();

        try
        {
            return group.IsWhiteSpaceOrNull() || key.IsWhiteSpaceOrNull() || value is null
                ? throw new BusinessException(BAD_REQUEST)
                : await _database.HashSetAsync((RedisKey)group.ToLowerInvariant(), (RedisValue)key.ToLowerInvariant(), jsonVal);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SetDeveloperTypeRedisService-Exception: {Group} - {Key} - {Value}", group, key, jsonVal);
            throw;
        }
    }

    public async ValueTask<bool> SetBulk(string group, IDictionary<string, DeveloperTypeRedisDto> fields)
    {
        try
        {
            if (group.IsWhiteSpaceOrNull() || fields.IsEmptyOrNull())
            {
                throw new BusinessException(BAD_REQUEST);
            }

            await _database.HashSetAsync(group.ToLowerInvariant(), fields.Select(p => new HashEntry(p.Key.ToLowerInvariant(), p.Value.Serialize())).ToArray());

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SetBulkDeveloperTypeRedisService-Exception: {Group} - {Fields}", group, fields.Serialize());
            throw;
        }
    }

    public async ValueTask<bool> Delete(string group, string key)
    {
        try
        {
            return group.IsWhiteSpaceOrNull() || key.IsWhiteSpaceOrNull() ? throw new BusinessException(BAD_REQUEST) : await _database.HashDeleteAsync((RedisKey)group.ToLowerInvariant(), (RedisValue)key.ToLowerInvariant());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteDeveloperTypeRedisService-Exception: {Group} - {Key}", group, key);
            throw;
        }
    }

    public async ValueTask<bool> DeleteBulk(string group, params string[] keys)
    {
        try
        {
            if (group.IsWhiteSpaceOrNull() || keys.AllWhiteSpaceOrNull())
            {
                throw new BusinessException(BAD_REQUEST);
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
            _logger.LogError(ex, "DeleteBulkDeveloperTypeRedisService-Exception: {Group} - {Keys}", group, string.Join(", ", keys));
            throw;
        }
    }

    public async ValueTask<bool> DeleteAll(string group)
    {
        try
        {
            if (group.IsWhiteSpaceOrNull())
            {
                throw new BusinessException(BAD_REQUEST);
            }

            var dic = await GetAll(group);

            return dic!.IsEmptyOrNull() || await DeleteBulk(group, dic!.Select(p => p.Key).ToArray());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteAllDeveloperTypeRedisService-Exception: {Group}", group);
            throw;
        }
    }

    public async ValueTask<IDictionary<string, IDictionary<string, DeveloperTypeRedisDto?>?>?> GetGroup(string groupPreffix)
    {
        try
        {
            var redisRslt = await GetGroupKeys(groupPreffix);

            if (redisRslt is not null)
            {
                var keys = (RedisKey[])redisRslt!;
                var rslts = new Dictionary<string, IDictionary<string, DeveloperTypeRedisDto?>?>();

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
            _logger.LogError(ex, "GetGroupDeveloperTypeRedisService-Exception: {GroupPreffix}", groupPreffix);
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

            return default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteGroupDeveloperTypeRedisService-Exception: {GroupPreffix}", groupPreffix);
            throw;
        }
    }
    #endregion

    #region Methods
    private async ValueTask<RedisResult> GetGroupKeys(string groupPreffix)
    {
        try
        {
            return groupPreffix.IsWhiteSpaceOrNull() ? throw new BusinessException(BAD_REQUEST) : await _database.ExecuteAsync(KeyCommand, $"{groupPreffix}*");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetGroupKeysDeveloperTypeRedisService-Exception: {GroupPreffix}", groupPreffix);
            throw;
        }
    }
    #endregion
}
