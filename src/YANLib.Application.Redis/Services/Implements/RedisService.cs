using Elastic.Apm.StackExchange.Redis;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using YANLib.ConnectionFactories;
using static System.Text.Encoding;
using static System.Threading.Tasks.Task;
using static YANLib.YANLibConsts.RedisConstant;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Services.Implements;

public class RedisService<TRedisDto> : IRedisService<TRedisDto> where TRedisDto : YANLibApplicationRedisDto
{
    private readonly ILogger<RedisService<TRedisDto>> _logger;
    private readonly IRedisConnectionFactory _connectionFactory;
    private readonly ConnectionMultiplexer _connectionMultiplexer;
    private readonly IDatabase _database;

    public RedisService(ILogger<RedisService<TRedisDto>> logger, IRedisConnectionFactory connectionFactory)
    {
        _logger = logger;
        _connectionFactory = connectionFactory;
        _connectionMultiplexer = _connectionFactory.Connection();
        _connectionMultiplexer.UseElasticApm();
        _database = _connectionMultiplexer.GetDatabase();
    }

    public async Task<TRedisDto?> GetAsync(string group, string key, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            if (group.IsNullWhiteSpace() || key.IsNullWhiteSpace())
            {
                throw new BusinessException(BAD_REQUEST);
            }

            var redisValue = await _database.HashGetAsync((RedisKey)group.ToLowerInvariant(), (RedisValue)key.ToLowerInvariant()).WaitAsync(cancellationToken);

            return redisValue.HasValue ? UTF8.GetString(redisValue!).Deserialize<TRedisDto>() : default;
        }
        catch (OperationCanceledException ex)
        {
            _logger.LogWarning("Operation was canceled: {Method} - {Group} - {Key}", nameof(GetAsync), group, key);

            throw new OperationCanceledException($"Redis GetAsync operation canceled for {group}/{key}", ex, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAsync-RedisService-Exception: {Group} - {Key}", group, key);

            throw;
        }
    }

    public async Task<IDictionary<string, TRedisDto?>?> GetBulkAsync(string group, IEnumerable<string> keys, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            if (group.IsNullWhiteSpace() || keys.AllNullWhiteSpace())
            {
                throw new BusinessException(BAD_REQUEST);
            }

            var result = new Dictionary<string, TRedisDto?>();
            var slim = new SemaphoreSlim(1);

            await WhenAll(keys.Select(async k =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                var value = await _database.HashGetAsync((RedisKey)group.ToLowerInvariant(), (RedisValue)k.ToLowerInvariant()).WaitAsync(cancellationToken);

                if (value.HasValue)
                {
                    await slim.WaitAsync(cancellationToken);

                    try
                    {
                        if (!result.ContainsKey(k))
                        {
                            result.Add(k, UTF8.GetString(value!).Deserialize<TRedisDto>());
                        }
                    }
                    finally
                    {
                        _ = slim.Release();
                    }
                }
            }));

            return result;
        }
        catch (OperationCanceledException ex)
        {
            _logger.LogWarning("Operation was canceled: {Method} - {Group} - {Keys}", nameof(GetBulkAsync), group, keys.Serialize());

            throw new OperationCanceledException($"Redis GetBulkAsync operation canceled for {group}", ex, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetBulkAsync-RedisService-Exception: {Group} - {Keys}", group, keys.Serialize());

            throw;
        }
    }

    public async Task<IDictionary<string, TRedisDto?>?> GetAllAsync(string? group, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            if (group.IsNullWhiteSpace())
            {
                throw new BusinessException(BAD_REQUEST);
            }

            var result = new Dictionary<string, TRedisDto?>();
            var slim = new SemaphoreSlim(1);

            await WhenAll((await _database.HashGetAllAsync(group.ToLowerInvariant()).WaitAsync(cancellationToken)).Where(e => e.Name.HasValue && e.Value.HasValue).Select(async x =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (x.Value.HasValue)
                {
                    await slim.WaitAsync(cancellationToken);

                    try
                    {
                        var key = x.Name.ToString();

                        if (!result.ContainsKey(key))
                        {
                            result.Add(key, UTF8.GetString(x.Value!).Deserialize<TRedisDto>());
                        }
                    }
                    finally
                    {
                        _ = slim.Release();
                    }
                }
            }));

            return result;
        }
        catch (OperationCanceledException ex)
        {
            _logger.LogWarning("Operation was canceled: {Method} - {Group}", nameof(GetAllAsync), group);

            throw new OperationCanceledException($"Redis GetAllAsync operation canceled for {group}", ex, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAllAsync-RedisService-Exception: {Group}", group);

            throw;
        }
    }

    public async Task<bool> SetAsync(string group, string key, TRedisDto value, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var json = value.Serialize();

        try
        {
            _ = group.IsNullWhiteSpace() || key.IsNullWhiteSpace() || value.IsNull()
                ? throw new BusinessException(BAD_REQUEST)
                : await _database.HashSetAsync((RedisKey)group.ToLowerInvariant(), (RedisValue)key.ToLowerInvariant(), json).WaitAsync(cancellationToken);

            return true;
        }
        catch (OperationCanceledException ex)
        {
            _logger.LogWarning("Operation was canceled: {Method} - {Group} - {Key}", nameof(SetAsync), group, key);

            throw new OperationCanceledException($"Redis SetAsync operation canceled for {group}/{key}", ex, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SetAsync-RedisService-Exception: {Group} - {Key} - {Value}", group, key, json);

            throw;
        }
    }

    public async Task<bool> SetBulkAsync(string group, IDictionary<string, TRedisDto> fields, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            if (group.IsNullWhiteSpace() || fields.IsNullEmpty())
            {
                throw new BusinessException(BAD_REQUEST);
            }

            await _database.HashSetAsync(group.ToLowerInvariant(), [.. fields.Select(static p => new HashEntry(p.Key.ToLowerInvariant(), p.Value.Serialize()))]).WaitAsync(cancellationToken);

            return true;
        }
        catch (OperationCanceledException ex)
        {
            _logger.LogWarning("Operation was canceled: {Method} - {Group}", nameof(SetBulkAsync), group);

            throw new OperationCanceledException($"Redis SetBulkAsync operation canceled for {group}", ex, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SetBulkAsync-RedisService-Exception: {Group} - {Fields}", group, fields.Serialize());

            throw;
        }
    }

    public async Task<bool> DeleteAsync(string group, string key, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return group.IsNullWhiteSpace() || key.IsNullWhiteSpace()
                ? throw new BusinessException(BAD_REQUEST)
                : await _database.HashDeleteAsync((RedisKey)group.ToLowerInvariant(), (RedisValue)key.ToLowerInvariant()).WaitAsync(cancellationToken);
        }
        catch (OperationCanceledException ex)
        {
            _logger.LogWarning("Operation was canceled: {Method} - {Group} - {Key}", nameof(DeleteAsync), group, key);

            throw new OperationCanceledException($"Redis DeleteAsync operation canceled for {group}/{key}", ex, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteAsync-RedisService-Exception: {Group} - {Key}", group, key);

            throw;
        }
    }

    public async Task<bool> DeleteBulkAsync(string group, IEnumerable<string> keys, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            if (group.IsNullWhiteSpace() || keys.AllNullWhiteSpace())
            {
                throw new BusinessException(BAD_REQUEST);
            }

            var result = true;
            var slim = new SemaphoreSlim(1);

            await WhenAll(keys.Where(k => k.IsNotNullWhiteSpace()).Select(async k =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                await slim.WaitAsync(cancellationToken);

                try
                {
                    result = result && await _database.HashDeleteAsync((RedisKey)group.ToLowerInvariant(), (RedisValue)k.ToLowerInvariant()).WaitAsync(cancellationToken);
                }
                finally
                {
                    _ = slim.Release();
                }
            }));

            return result;
        }
        catch (OperationCanceledException ex)
        {
            _logger.LogWarning("Operation was canceled: {Method} - {Group} - {Keys}", nameof(DeleteBulkAsync), group, keys.Serialize());

            throw new OperationCanceledException($"Redis DeleteBulkAsync operation canceled for {group}", ex, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteBulkAsync-RedisService-Exception: {Group} - {Keys}", group, keys.Serialize());

            throw;
        }
    }

    public async Task<bool> DeleteAllAsync(string group, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            if (group.IsNullWhiteSpace())
            {
                throw new BusinessException(BAD_REQUEST);
            }

            var dict = await GetAllAsync(group, cancellationToken);

            return dict.IsNullEmpty() || await DeleteBulkAsync(group, [.. dict.Select(static p => p.Key)], cancellationToken);
        }
        catch (OperationCanceledException ex)
        {
            _logger.LogWarning("Operation was canceled: {Method} - {Group}", nameof(DeleteAllAsync), group);

            throw new OperationCanceledException($"Redis DeleteAllAsync operation canceled for {group}", ex, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteAllAsync-RedisService-Exception: {Group}", group);

            throw;
        }
    }

    public async Task<IDictionary<string, IDictionary<string, TRedisDto?>?>?> GetGroupAsync(string groupPreffix, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var redisResult = await GetGroupKeysAsync(groupPreffix, cancellationToken);

            if (redisResult.IsNull)
            {
                return default;
            }

            var keys = (RedisKey[]?)redisResult;
            var result = new Dictionary<string, IDictionary<string, TRedisDto?>?>();

            if (keys.IsNotNullEmpty())
            {
                var slim = new SemaphoreSlim(1);

                await WhenAll(keys.Select(async k =>
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var dict = await GetAllAsync(k, cancellationToken);

                    if (dict.IsNotNullEmpty())
                    {
                        await slim.WaitAsync(cancellationToken);

                        try
                        {
                            _ = result.TryAdd(k.ToString().Split(":").AsEnumerable().Reverse().FirstOrDefault() ?? string.Empty, dict);
                        }
                        finally
                        {
                            _ = slim.Release();
                        }
                    }
                }));
            }

            return result;
        }
        catch (OperationCanceledException ex)
        {
            _logger.LogWarning("Operation was canceled: {Method} - {GroupPreffix}", nameof(GetGroupAsync), groupPreffix);

            throw new OperationCanceledException($"Redis GetGroupAsync operation canceled for {groupPreffix}", ex, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetGroupAsync-RedisService-Exception: {GroupPreffix}", groupPreffix);

            throw;
        }
    }

    public async Task<bool> DeleteGroupAsync(string groupPreffix, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var redisResult = await GetGroupKeysAsync(groupPreffix, cancellationToken);

            if (redisResult.IsNull)
            {
                return default;
            }

            var keys = (RedisKey[]?)redisResult;

            return keys.IsNullEmpty() || await _database.KeyDeleteAsync(keys).WaitAsync(cancellationToken) > 0;
        }
        catch (OperationCanceledException ex)
        {
            _logger.LogWarning("Operation was canceled: {Method} - {GroupPreffix}", nameof(DeleteGroupAsync), groupPreffix);

            throw new OperationCanceledException($"Redis DeleteGroupAsync operation canceled for {groupPreffix}", ex, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteGroupAsync-RedisService-Exception: {GroupPreffix}", groupPreffix);

            throw;
        }
    }

    private async Task<RedisResult> GetGroupKeysAsync(string groupPreffix, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return groupPreffix.IsNullWhiteSpace() ? throw new BusinessException(BAD_REQUEST) : await _database.ExecuteAsync(KeyCommand, $"{groupPreffix}*").WaitAsync(cancellationToken);
        }
        catch (OperationCanceledException ex)
        {
            _logger.LogWarning("Operation was canceled: {Method} - {GroupPreffix}", nameof(GetGroupKeysAsync), groupPreffix);

            throw new OperationCanceledException($"Redis GetGroupKeysAsync operation canceled for {groupPreffix}", ex, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetGroupKeysAsync-RedisService-Exception: {GroupPreffix}", groupPreffix);

            throw;
        }
    }
}
