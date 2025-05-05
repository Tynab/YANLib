using Id_Generator_Snowflake;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.RedisDtos;
using YANLib.Repositories;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;
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

    public async ValueTask<PagedResultDto<DeveloperTypeResponse>?> GetAll(PagedAndSortedResultRequestDto input)
    {
        try
        {
            var dtos = await _redisService.GetAll(DeveloperTypeGroup);

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
            _logger.LogError(ex, "GetAll-DeveloperTypeService-Exception: {Input}", input.Serialize());

            throw;
        }
    }

    public async ValueTask<DeveloperTypeResponse?> Get(long id)
    {
        try
        {
            var dto = await _redisService.Get(DeveloperTypeGroup, id.ToString());

            return dto.IsNull() ? throw new EntityNotFoundException(typeof(DeveloperTypeResponse), id) : ObjectMapper.Map<(long Id, DeveloperTypeRedisDto Dto), DeveloperTypeResponse>((id, dto));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Get-DeveloperTypeService-Exception: {Id}", id);

            throw;
        }
    }

    public async ValueTask<DeveloperTypeResponse?> Insert(DeveloperTypeCreateRequest request)
    {
        try
        {
            var entity = await _repository.InsertAsync(ObjectMapper.Map<(long Id, DeveloperTypeCreateRequest Request), DeveloperType>((_idGenerator.NextId(), request)));

            return entity.IsNull()
                ? throw new BusinessException(SQL_SERVER_ERROR)
                : await _redisService.Set(DeveloperTypeGroup, entity.Id.ToString(), ObjectMapper.Map<DeveloperType, DeveloperTypeRedisDto>(entity))
                ? ObjectMapper.Map<DeveloperType, DeveloperTypeResponse>(entity)
                : throw new BusinessException(REDIS_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Insert-DeveloperTypeService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async ValueTask<DeveloperTypeResponse?> Modify(long id, DeveloperTypeUpdateRequest request)
    {
        try
        {
            var dto = await _redisService.Get(DeveloperTypeGroup, id.ToString()) ?? throw new EntityNotFoundException(typeof(DeveloperTypeResponse), id);
            var entity = await _repository.Modify(ObjectMapper.Map<(long Id, DeveloperTypeUpdateRequest Request), DeveloperTypeDto>((id, request)));

            return entity.IsNull()
                ? throw new BusinessException(SQL_SERVER_ERROR)
                : await _redisService.Set(DeveloperTypeGroup, id.ToString(), ObjectMapper.Map<DeveloperType, DeveloperTypeRedisDto>(entity))
                ? ObjectMapper.Map<DeveloperType, DeveloperTypeResponse>(entity)
                : throw new BusinessException(REDIS_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Modify-DeveloperTypeService-Exception: {Id} - {Request}", id, request.Serialize());

            throw;
        }
    }

    public async ValueTask<bool> Delete(long id, Guid updatedBy)
    {
        try
        {
            return (await _repository.Modify(new DeveloperTypeDto
            {
                Id = id,
                UpdatedBy = updatedBy,
                IsDeleted = true,
            })).IsNull() ? throw new BusinessException(SQL_SERVER_ERROR) : await _redisService.Delete(DeveloperTypeGroup, id.ToString());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Delete-DeveloperTypeService-Exception: {Id} - {UpdatedBy}", id, updatedBy);

            throw;
        }
    }

    public async ValueTask<bool> SyncDbToRedis()
    {
        try
        {
            var cleanTask = _redisService.DeleteAll(DeveloperTypeGroup).AsTask();
            var entitiesTask = _repository.GetListAsync(static x => !x.IsDeleted);

            _ = await WhenAny(cleanTask, entitiesTask);

            var result = await cleanTask;
            var entities = await entitiesTask;

            return entities.IsNullEmpty() ? result : result && await _redisService.SetBulk(DeveloperTypeGroup, entities.ToDictionary(static x => x.Id.ToString(), ObjectMapper.Map<DeveloperType, DeveloperTypeRedisDto>));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDbToRedis-DeveloperTypeService-Exception");

            throw;
        }
    }
}
