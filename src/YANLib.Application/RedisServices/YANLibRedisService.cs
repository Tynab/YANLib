using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using YANLib.Services;
using static System.Threading.Tasks.Task;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.RedisServices;

public class YANLibRedisService<TCreateRequest, TUpdateRequest, TDto, TRedisDto, TResponse, TEntity, TKey>(
    ILogger<YANLibRedisService<TCreateRequest, TUpdateRequest, TDto, TRedisDto, TResponse, TEntity, TKey>> logger,
    IYANLibRepository<TDto, TEntity, TKey> repository,
    IRedisService<TRedisDto> redisService,
    string redisGroup
) : YANLibAppService, IYANLibRedisService<TCreateRequest, TUpdateRequest, TResponse, TKey>
    where TCreateRequest : YANLibApplicationCreateRequest
    where TUpdateRequest : YANLibApplicationUpdateRequest
    where TDto : YANLibDomainDto<TKey>
    where TRedisDto : YANLibApplicationRedisDto
    where TResponse : YANLibApplicationResponse<TKey>
    where TEntity : YANLibDomainEntity<TKey>
    where TKey : notnull, IEquatable<TKey>
{
    private readonly ILogger<YANLibRedisService<TCreateRequest, TUpdateRequest, TDto, TRedisDto, TResponse, TEntity, TKey>> _logger = logger;
    private readonly IYANLibRepository<TDto, TEntity, TKey> _repository = repository;
    private readonly IRedisService<TRedisDto> _redisService = redisService;
    private readonly string _redisGroup = redisGroup ?? throw new ArgumentNullException(nameof(redisGroup));

    public async Task<List<TResponse?>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var dtos = await _redisService.GetAllAsync(_redisGroup, cancellationToken);

            return dtos.IsNullEmpty() ? default : [.. dtos.Select(ObjectMapper.Map<KeyValuePair<string, TRedisDto?>, TResponse?>)];
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAllAsync-YANLibRedisService-Exception");

            throw;
        }
    }

    public async Task<TResponse?> GetOrAddAsync(TKey id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var key = id.Parse<string>() ?? throw new BusinessException(BUSINESS_ERROR).WithData("Id", id);
            var dto = await _redisService.GetAsync(_redisGroup, key, cancellationToken);

            if (dto.IsNull())
            {
                var entity = await _repository.SingleOrDefaultAsync(x => x.Id.Equals(id) && !x.IsDeleted, cancellationToken: cancellationToken) ?? throw new EntityNotFoundException(typeof(TResponse), id);

                new Thread(async () =>
                {
                    try
                    {
                        _ = await _redisService.SetAsync(_redisGroup, key, ObjectMapper.Map<TEntity, TRedisDto>(entity), cancellationToken);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "GetOrAddAsync-YANLibRedisService-Thread-Exception: {Id}", id);
                    }
                }).Start();

                return ObjectMapper.Map<TEntity, TResponse>(entity);
            }
            else
            {
                return ObjectMapper.Map<(TKey Id, TRedisDto Dto), TResponse>((id, dto));
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetOrAddAsync-YANLibRedisService-Exception: {Id}", id);

            throw;
        }
    }

    public async Task<TResponse?> AddAsync(TCreateRequest request, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var entity = await _repository.InsertAsync(ObjectMapper.Map<TCreateRequest, TEntity>(request), true, cancellationToken);
            var key = entity.Id.Parse<string>() ?? throw new BusinessException(BUSINESS_ERROR).WithData("Id", entity.Id);

            return entity.IsNull()
                ? throw new BusinessException(SQL_SERVER_ERROR)
                : await _redisService.SetAsync(_redisGroup, key, ObjectMapper.Map<TEntity, TRedisDto>(entity), cancellationToken)
                ? ObjectMapper.Map<TEntity, TResponse>(entity)
                : throw new BusinessException(REDIS_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "AddAsync-YANLibRedisService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async Task<TResponse?> ModifyAsync(TKey id, TUpdateRequest request, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var key = id.Parse<string>() ?? throw new BusinessException(BUSINESS_ERROR).WithData("Id", id);
            var dto = await _redisService.GetAsync(_redisGroup, key, cancellationToken) ?? throw new EntityNotFoundException(typeof(TResponse), id);
            var entity = await _repository.ModifyAsync(ObjectMapper.Map<(TKey Id, TUpdateRequest Request), TDto>((id, request)), cancellationToken);

            return entity.IsNull()
                ? throw new BusinessException(SQL_SERVER_ERROR)
                : await _redisService.SetAsync(_redisGroup, key, ObjectMapper.Map<TEntity, TRedisDto>(entity), cancellationToken)
                ? ObjectMapper.Map<TEntity, TResponse>(entity)
                : throw new BusinessException(REDIS_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ModifyAsync-YANLibRedisService-Exception: {Id} - {Request}", id, request.Serialize());

            throw;
        }
    }

    public async Task<bool> DeleteAsync(TKey id, Guid updatedBy, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var key = id.Parse<string>() ?? throw new BusinessException(BUSINESS_ERROR).WithData("Id", id);
            var dto = ObjectMapper.Map<(TKey Id, Guid UpdatedBy), TDto>((id, updatedBy));

            dto.IsDeleted = true;

            return (await _repository.ModifyAsync(dto, cancellationToken)).IsNull() ? throw new BusinessException(SQL_SERVER_ERROR) : await _redisService.DeleteAsync(_redisGroup, key, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteAsync-YANLibRedisService-Exception: {Id} - {UpdatedBy}", id, updatedBy);

            throw;
        }
    }

    public async Task<bool> SyncDataToRedisAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var cleanTask = _redisService.DeleteAllAsync(_redisGroup, cancellationToken);
            var entitiesTask = _repository.GetListAsync(static x => !x.IsDeleted, cancellationToken: cancellationToken);

            _ = await WhenAny(cleanTask, entitiesTask);

            var result = await cleanTask;
            var entities = await entitiesTask;

            return entities.IsNullEmpty()
                ? result
                : result && await _redisService.SetBulkAsync(_redisGroup, entities.ToDictionary(static x => x.Id.ToString() ?? string.Empty, ObjectMapper.Map<TEntity, TRedisDto>), cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDataToRedisAsync-YANLibRedisService-Exception");

            throw;
        }
    }
}
