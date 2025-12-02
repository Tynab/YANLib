using Microsoft.Extensions.Logging;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Security.Claims;
using YANLib;
using static YANLib.BaseErrorCodes;
using static System.DateTime;
using static System.Threading.Tasks.Task;
using YANLib.Services;

namespace YANLib.RedisServices;

public class BaseRedisService<TCreateOrUpdateRequest, TRedisDto, TResponse, TEntity>(
    ILogger<BaseRedisService<TCreateOrUpdateRequest, TRedisDto, TResponse, TEntity>> logger,
    IBaseRepository<TEntity> repository,
    IRedisService<TRedisDto> redisService,
    string redisGroup,
    ICurrentPrincipalAccessor currentPrincipalAccessor
) : BaseAccessorService(currentPrincipalAccessor), IBaseRedisService<TCreateOrUpdateRequest, TResponse>
    where TCreateOrUpdateRequest : BaseCreateOrUpdateRequest
    where TRedisDto : BaseRedisDto
    where TResponse : BaseResponse
    where TEntity : BaseEntity
{
    public async Task<List<TResponse?>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var dtos = await redisService.GetAllAsync(redisGroup, cancellationToken);

            return dtos.IsNullEmpty() ? default : [.. dtos.Select(ObjectMapper.Map<KeyValuePair<string, TRedisDto?>, TResponse?>)];
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "GetAllAsync-ApplicationRedisService-Exception");

            throw;
        }
    }

    public async Task<TResponse?> GetOrAddAsync(Guid id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var key = id.Parse<string>() ?? throw new BusinessException(BUSINESS_ERROR).WithData("Id", id);
            var dto = await redisService.GetAsync(redisGroup, key, cancellationToken);

            if (dto.IsNull())
            {
                var entity = await repository.SingleOrDefaultAsync(x => x.Id.Equals(id) && !x.IsDeleted, cancellationToken: cancellationToken) ?? throw new EntityNotFoundException(typeof(TResponse), id);

                new Thread(async () =>
                {
                    try
                    {
                        _ = await redisService.SetAsync(redisGroup, key, ObjectMapper.Map<TEntity, TRedisDto>(entity), cancellationToken);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "GetOrAddAsync-ApplicationRedisService-Thread-Exception: {Id}", id);
                    }
                }).Start();

                return ObjectMapper.Map<TEntity, TResponse>(entity);
            }
            else
            {
                return ObjectMapper.Map<(Guid Id, TRedisDto Dto), TResponse>((id, dto));
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "GetOrAddAsync-ApplicationRedisService-Exception: {Id}", id);

            throw;
        }
    }

    public async Task<TResponse?> AddAsync(TCreateOrUpdateRequest request, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var model = ObjectMapper.Map<TCreateOrUpdateRequest, TEntity>(request);

            model.CreatedBy = UserId ?? throw new BusinessException(NOT_FOUND_ID);

            var entity = await repository.InsertAsync(model, true, cancellationToken);
            var key = entity.Id.Parse<string>() ?? throw new BusinessException(BUSINESS_ERROR).WithData("Id", entity.Id);

            return entity.IsNull()
                ? throw new BusinessException(SQL_SERVER_ERROR)
                : await redisService.SetAsync(redisGroup, key, ObjectMapper.Map<TEntity, TRedisDto>(entity), cancellationToken)
                ? ObjectMapper.Map<TEntity, TResponse>(entity)
                : throw new BusinessException(REDIS_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "AddAsync-ApplicationRedisService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async Task<TResponse?> UpdateAsync(Guid id, TCreateOrUpdateRequest request, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var key = id.Parse<string>() ?? throw new BusinessException(BUSINESS_ERROR).WithData("Id", id);
            var dto = await redisService.GetAsync(redisGroup, key, cancellationToken) ?? throw new EntityNotFoundException(typeof(TResponse), id);
            var model = ObjectMapper.Map<(Guid Id, TCreateOrUpdateRequest Request, TRedisDto Dto), TEntity>((id, request, dto));

            model.UpdatedBy = UserId ?? throw new BusinessException(NOT_FOUND_ID);
            model.UpdatedAt = UtcNow;

            var entity = await repository.UpdateAsync(model, true, cancellationToken);

            return entity.IsNull()
                ? throw new BusinessException(SQL_SERVER_ERROR)
                : await redisService.SetAsync(redisGroup, key, ObjectMapper.Map<TEntity, TRedisDto>(entity), cancellationToken)
                ? ObjectMapper.Map<TEntity, TResponse>(entity)
                : throw new BusinessException(REDIS_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "UpdateAsync-ApplicationRedisService-Exception: {Id} - {Request}", id, request.Serialize());

            throw;
        }
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var key = id.Parse<string>() ?? throw new BusinessException(BUSINESS_ERROR).WithData("Id", id);
            var dto = await redisService.GetAsync(redisGroup, key, cancellationToken) ?? throw new EntityNotFoundException(typeof(TResponse), id);

            return await repository.SoftDeleteAsync(id, UserId ?? throw new BusinessException(NOT_FOUND_ID), cancellationToken) ? await redisService.DeleteAsync(redisGroup, key, cancellationToken) : throw new BusinessException(SQL_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "DeleteAsync-ApplicationRedisService-Exception: {Id}", id);

            throw;
        }
    }

    public async Task<bool> SyncDataToRedisAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var cleanTask = redisService.DeleteAllAsync(redisGroup, cancellationToken);
            var entitiesTask = repository.GetListAsync(static x => !x.IsDeleted, cancellationToken: cancellationToken);

            _ = await WhenAny(cleanTask, entitiesTask);

            var result = await cleanTask;
            var entities = await entitiesTask;

            return entities.IsNullEmpty()
                ? result
                : result && await redisService.SetBulkAsync(redisGroup, entities.ToDictionary(static x => x.Id.ToString() ?? string.Empty, ObjectMapper.Map<TEntity, TRedisDto>), cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "SyncDataToRedisAsync-ApplicationRedisService-Exception");

            throw;
        }
    }
}
