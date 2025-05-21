using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using YANLib.Domains;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.RedisDtos;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;
using YANLib.Snowflake;
using static System.Threading.Tasks.Task;
using static YANLib.YANLibConsts.RedisConstant;
using static YANLib.YANLibConsts.SnowflakeId.DatacenterId;
using static YANLib.YANLibConsts.SnowflakeId.WorkerId;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Services.v2;

public class DeveloperTypeService(ILogger<DeveloperTypeService> logger, IDeveloperTypeRepository repository, IRedisService<DeveloperTypeRedisDto> redisService) : YANLibAppService, IDeveloperTypeService
{
    private readonly ILogger<DeveloperTypeService> _logger = logger;
    private readonly IDeveloperTypeRepository _repository = repository;
    private readonly IRedisService<DeveloperTypeRedisDto> _redisService = redisService;
    private readonly IdGenerator _idGenerator = new(DeveloperId, YanlibId);

    public async Task<PagedResultDto<DeveloperTypeResponse>?> GetAllAsync(PagedAndSortedResultRequestDto input, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var dtos = await _redisService.GetAllAsync(DeveloperTypeGroup, cancellationToken);

            if (dtos.IsNullEmpty())
            {
                return new PagedResultDto<DeveloperTypeResponse>();
            }

            var queryableItems = dtos.Select(ObjectMapper.Map<KeyValuePair<string, DeveloperTypeRedisDto?>, DeveloperTypeResponse>).AsQueryable();

            if (input.Sorting.IsNotNullWhiteSpace())
            {
                queryableItems = queryableItems.OrderBy(input.Sorting);
            }

            return new PagedResultDto<DeveloperTypeResponse>(queryableItems.Count(), [.. queryableItems.Skip(input.SkipCount).Take(input.MaxResultCount)]);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAllAsync-DeveloperTypeService-Exception: {Input}", input.Serialize());

            throw;
        }
    }

    public async Task<DeveloperTypeResponse?> GetAsync(long id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var dto = await _redisService.GetAsync(DeveloperTypeGroup, id.ToString(), cancellationToken);

            return dto.IsNull() ? throw new EntityNotFoundException(typeof(DeveloperTypeResponse), id) : ObjectMapper.Map<(long Id, DeveloperTypeRedisDto Dto), DeveloperTypeResponse>((id, dto));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAsync-DeveloperTypeService-Exception: {Id}", id);

            throw;
        }
    }

    public async Task<DeveloperTypeResponse?> InsertAsync(DeveloperTypeCreateRequest request, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var entity = await _repository.InsertAsync(ObjectMapper.Map<(long Id, DeveloperTypeCreateRequest Request), DeveloperType>((_idGenerator.NextId(), request)), cancellationToken: cancellationToken);

            return entity.IsNull()
                ? throw new BusinessException(SQL_SERVER_ERROR)
                : await _redisService.SetAsync(DeveloperTypeGroup, entity.Id.ToString(), ObjectMapper.Map<DeveloperType, DeveloperTypeRedisDto>(entity), cancellationToken)
                ? ObjectMapper.Map<DeveloperType, DeveloperTypeResponse>(entity)
                : throw new BusinessException(REDIS_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "InsertAsync-DeveloperTypeService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async Task<DeveloperTypeResponse?> ModifyAsync(long id, DeveloperTypeUpdateRequest request, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var dto = await _redisService.GetAsync(DeveloperTypeGroup, id.ToString(), cancellationToken) ?? throw new EntityNotFoundException(typeof(DeveloperTypeResponse), id);
            var entity = await _repository.ModifyAsync(ObjectMapper.Map<(long Id, DeveloperTypeUpdateRequest Request), DeveloperTypeDto>((id, request)), cancellationToken);

            return entity.IsNull()
                ? throw new BusinessException(SQL_SERVER_ERROR)
                : await _redisService.SetAsync(DeveloperTypeGroup, id.ToString(), ObjectMapper.Map<DeveloperType, DeveloperTypeRedisDto>(entity), cancellationToken)
                ? ObjectMapper.Map<DeveloperType, DeveloperTypeResponse>(entity)
                : throw new BusinessException(REDIS_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ModifyAsync-DeveloperTypeService-Exception: {Id} - {Request}", id, request.Serialize());

            throw;
        }
    }

    public async Task<bool> DeleteAsync(long id, Guid updatedBy, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return (await _repository.ModifyAsync(new DeveloperTypeDto
            {
                Id = id,
                UpdatedBy = updatedBy,
                IsDeleted = true,
            }, cancellationToken)).IsNull() ? throw new BusinessException(SQL_SERVER_ERROR) : await _redisService.DeleteAsync(DeveloperTypeGroup, id.ToString(), cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteAsync-DeveloperTypeService-Exception: {Id} - {UpdatedBy}", id, updatedBy);

            throw;
        }
    }

    public async Task<bool> SyncDataToRedisAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var cleanTask = _redisService.DeleteAllAsync(DeveloperTypeGroup, cancellationToken);
            var entitiesTask = _repository.GetListAsync(static x => !x.IsDeleted, cancellationToken: cancellationToken);

            _ = await WhenAny(cleanTask, entitiesTask);

            var result = await cleanTask;
            var entities = await entitiesTask;

            return entities.IsNullEmpty()
                ? result
                : result && await _redisService.SetBulkAsync(DeveloperTypeGroup, entities.ToDictionary(static x => x.Id.ToString(), ObjectMapper.Map<DeveloperType, DeveloperTypeRedisDto>), cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDataToRedisAsync-DeveloperTypeService-Exception");

            throw;
        }
    }
}
