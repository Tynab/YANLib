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
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.Object;
using YANLib.RedisDtos;
using YANLib.Repositories;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;
using YANLib.Text;
using static System.Threading.Tasks.Task;
using static YANLib.YANLibConsts.RedisConstant;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Services.v2;

public class DeveloperProjectService(
    ILogger<DeveloperProjectService> logger,
    IDeveloperProjectRepository repository,
    IRedisService<DeveloperProjectRedisDto> redisService,
    IDeveloperService developerService,
    IProjectService projectService
) : YANLibAppService, IDeveloperProjectService
{
    private readonly ILogger<DeveloperProjectService> _logger = logger;
    private readonly IDeveloperProjectRepository _repository = repository;
    private readonly IRedisService<DeveloperProjectRedisDto> _redisService = redisService;
    private readonly IDeveloperService _developerService = developerService;
    private readonly IProjectService _projectService = projectService;

    public async ValueTask<PagedResultDto<DeveloperProjectResponse>?> GetByDeveloper(PagedAndSortedResultRequestDto input, Guid developerId)
    {
        try
        {
            var dtos = await _redisService.GetAll($"{DeveloperProjectGroupPrefix}:{developerId}");

            if (dtos.IsNullEmpty())
            {
                return new PagedResultDto<DeveloperProjectResponse>();
            }

            var queryableItems = dtos.Select(x => ObjectMapper.Map<(Guid DeveloperId, KeyValuePair<string, DeveloperProjectRedisDto?> Pair), DeveloperProjectResponse>((developerId, x))).AsQueryable();

            if (input.Sorting.IsNotNullWhiteSpace())
            {
                queryableItems = queryableItems.OrderBy(input.Sorting);
            }

            return new PagedResultDto<DeveloperProjectResponse>(queryableItems.Count(), [.. queryableItems.Skip(input.SkipCount).Take(input.MaxResultCount)]);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByDeveloper-DeveloperProjectService-Exception: {DeveloperId}", developerId);

            throw;
        }
    }

    public async ValueTask<DeveloperProjectResponse?> GetByDeveloperAndProject(Guid developerId, string projectId)
    {
        try
        {
            var dto = await _redisService.Get($"{DeveloperProjectGroupPrefix}:{developerId}", projectId);

            return dto.IsNull()
                ? throw new EntityNotFoundException(typeof(DeveloperProjectRedisDto), projectId)
                : ObjectMapper.Map<(Guid DeveloperId, string ProjectId, DeveloperProjectRedisDto Dto), DeveloperProjectResponse>((developerId, projectId, dto));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByDeveloperAndProject-DeveloperProjectService-Exception: {DeveloperId} - {ProjectId}", developerId, projectId);

            throw;
        }
    }

    public async ValueTask<DeveloperProjectResponse?> Insert(DeveloperProjectCreateRequest request)
    {
        try
        {
            var devTask = _developerService.Get(request.DeveloperId).AsTask();
            var certTask = _projectService.Get(request.ProjectId).AsTask();

            _ = await WhenAny(devTask, certTask);

            var dev = await devTask;

            if (dev.IsNull())
            {
                throw new EntityNotFoundException(typeof(Developer), request.DeveloperId);
            }

            var cert = await certTask;

            if (cert.IsNull())
            {
                throw new EntityNotFoundException(typeof(Project), request.ProjectId);
            }

            var entity = await _repository.InsertAsync(ObjectMapper.Map<(Guid DeveloperId, string ProjectId, DeveloperProjectCreateRequest Request), DeveloperProject>((dev.Id, cert.Id, request)));

            return entity.IsNull()
                ? throw new BusinessException(SQL_SERVER_ERROR)
                : await _redisService.Set($"{DeveloperProjectGroupPrefix}:{request.DeveloperId}", request.ProjectId, ObjectMapper.Map<DeveloperProject, DeveloperProjectRedisDto>(entity))
                ? ObjectMapper.Map<(Guid DeveloperId, string ProjectId, DeveloperProject Entity), DeveloperProjectResponse>((dev.Id, cert.Id, entity))
                : throw new BusinessException(REDIS_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Insert-DeveloperProjectService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async ValueTask<DeveloperProjectResponse?> Modify(DeveloperProjectUpdateRequest request)
    {
        try
        {
            var entity = await _repository.Modify(ObjectMapper.Map<(Guid Id, DeveloperProjectUpdateRequest Request), DeveloperProjectDto>(((
                await _redisService.Get($"{DeveloperProjectGroupPrefix}:{request.DeveloperId}", request.ProjectId)
                ?? throw new EntityNotFoundException(typeof(DeveloperProjectRedisDto))
            ).Id, request)));

            return entity.IsNull()
                ? throw new BusinessException(SQL_SERVER_ERROR)
                : await _redisService.Set($"{DeveloperProjectGroupPrefix}:{request.DeveloperId}", request.ProjectId, ObjectMapper.Map<DeveloperProject, DeveloperProjectRedisDto>(entity))
                ? ObjectMapper.Map<(Guid DeveloperId, string ProjectId, DeveloperProject Entity), DeveloperProjectResponse>((request.DeveloperId, request.ProjectId, entity))
                : throw new BusinessException(REDIS_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Modify-DeveloperProjectService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async ValueTask<bool?> Delete(Guid developerId, string projectId, Guid updatedBy)
    {
        try
        {
            var entity = await _repository.Modify(new DeveloperProjectDto
            {
                Id = (await _redisService.Get($"{DeveloperProjectGroupPrefix}:{developerId}", projectId) ?? throw new EntityNotFoundException(typeof(DeveloperProjectRedisDto))).Id,
                UpdatedBy = updatedBy,
                IsDeleted = true,
            });

            return entity.IsNull() ? throw new BusinessException(SQL_SERVER_ERROR) : await _redisService.Delete($"{DeveloperProjectGroupPrefix}:{developerId}", projectId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Delete-DeveloperProjectService-Exception: {DeveloperId} - {ProjectId} - {UpdatedBy}", developerId, projectId, updatedBy);

            throw;
        }
    }

    public async ValueTask<bool> SyncDbToRedis()
    {
        try
        {
            var cleanTask = _redisService.DeleteGroup($"{DeveloperProjectGroupPrefix}:").AsTask();
            var entitiesTask = _repository.GetListAsync(x => !x.IsDeleted);

            _ = await WhenAny(cleanTask, entitiesTask);

            var result = await cleanTask;
            var entities = await entitiesTask;

            if (entities.IsNullEmpty())
            {
                return result;
            }

            var ss = new SemaphoreSlim(1);

            await WhenAll(entities.GroupBy(x => x.DeveloperId).Select(async g =>
            {
                await ss.WaitAsync();

                try
                {
                    result &= await _redisService.SetBulk($"{DeveloperProjectGroupPrefix}:{g.Key}", g.ToDictionary(y => y.ProjectId, y => ObjectMapper.Map<DeveloperProject, DeveloperProjectRedisDto>(y)));
                }
                finally
                {
                    _ = ss.Release();
                }
            }));

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDbToRedis-DeveloperProjectService-Exception");

            throw;
        }
    }

    public async ValueTask<bool> SyncDbToRedisByDeveloper(Guid developerId)
    {
        try
        {
            var cleanTask = _redisService.DeleteAll($"{DeveloperProjectGroupPrefix}:{developerId}").AsTask();
            var entitiesTask = _repository.GetListAsync(x => x.DeveloperId == developerId && !x.IsDeleted);

            _ = await WhenAny(cleanTask, entitiesTask);

            var result = await cleanTask;
            var entities = await entitiesTask;

            return entities.IsNullEmpty()
                ? result
                : (result &= await _redisService.SetBulk($"{DeveloperProjectGroupPrefix}:{developerId}", entities.ToDictionary(x => x.ProjectId, ObjectMapper.Map<DeveloperProject, DeveloperProjectRedisDto>)));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDbToRedisByDeveloper-DeveloperProjectService-Exception: {DeveloperId}", developerId);

            throw;
        }
    }
}
