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
using YANLib.RedisDtos;
using YANLib.Repositories;
using YANLib.Responses;
using static System.DateTime;
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

    public async Task<PagedResultDto<DeveloperProjectResponse>?> GetByDeveloper(PagedAndSortedResultRequestDto input, Guid developerId)
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

    public async Task<DeveloperProjectResponse?> GetByDeveloperAndProject(Guid developerId, string projectId)
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

    public async Task<bool> Assign(Guid developerId, string projectId, Guid updatedBy, CancellationToken cancellationToken)
    {
        try
        {
            var devTask = _developerService.Get(developerId);
            var projTask = _projectService.Get(projectId);

            _ = await WhenAny(devTask, projTask);

            var dev = await devTask;

            if (dev.IsNull())
            {
                throw new EntityNotFoundException(typeof(Developer), developerId);
            }

            var proj = await projTask;

            if (proj.IsNull())
            {
                throw new EntityNotFoundException(typeof(Project), projectId);
            }

            var entity = await _repository.InsertAsync(new DeveloperProject
            {
                DeveloperId = developerId,
                ProjectId = projectId,
                CreatedBy = updatedBy,
                CreatedAt = UtcNow,
                IsActive = true,
                IsDeleted = false
            }, cancellationToken: cancellationToken);

            return entity.IsNull()
                ? throw new BusinessException(SQL_SERVER_ERROR)
                : await _redisService.Set($"{DeveloperProjectGroupPrefix}:{developerId}", projectId, ObjectMapper.Map<DeveloperProject, DeveloperProjectRedisDto>(entity));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Assign-DeveloperProjectService-Exception: {DeveloperId} - {ProjectId} - {UpdatedBy}", developerId, projectId, updatedBy);

            throw;
        }
    }

    public async Task<bool> Unassign(Guid developerId, string projectId, Guid updatedBy)
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
            _logger.LogError(ex, "Unassign-DeveloperProjectService-Exception: {DeveloperId} - {ProjectId} - {UpdatedBy}", developerId, projectId, updatedBy);

            throw;
        }
    }

    public async Task<bool> SyncDbToRedis()
    {
        try
        {
            var cleanTask = _redisService.DeleteGroup($"{DeveloperProjectGroupPrefix}:");
            var entitiesTask = _repository.GetListAsync(x => !x.IsDeleted);

            _ = await WhenAny(cleanTask, entitiesTask);

            var result = await cleanTask;
            var entities = await entitiesTask;

            if (entities.IsNullEmpty())
            {
                return result;
            }

            var slim = new SemaphoreSlim(1);

            await WhenAll(entities.GroupBy(x => x.DeveloperId).Select(async g =>
            {
                await slim.WaitAsync();

                try
                {
                    result &= await _redisService.SetBulk($"{DeveloperProjectGroupPrefix}:{g.Key}", g.ToDictionary(y => y.ProjectId, y => ObjectMapper.Map<DeveloperProject, DeveloperProjectRedisDto>(y)));
                }
                finally
                {
                    _ = slim.Release();
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

    public async Task<bool> SyncDbToRedisByDeveloper(Guid developerId)
    {
        try
        {
            var cleanTask = _redisService.DeleteAll($"{DeveloperProjectGroupPrefix}:{developerId}");
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
