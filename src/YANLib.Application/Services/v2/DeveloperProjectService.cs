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
using YANLib.Requests.v2.Create;
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

    public async Task<PagedResultDto<DeveloperProjectResponse>?> GetByDeveloper(PagedAndSortedResultRequestDto input, Guid developerId, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var dtos = await _redisService.GetAllAsync($"{DeveloperProjectGroupPrefix}:{developerId}", cancellationToken);

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

    public async Task<DeveloperProjectResponse?> GetByDeveloperAndProject(Guid developerId, string projectId, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var dto = await _redisService.GetAsync($"{DeveloperProjectGroupPrefix}:{developerId}", projectId, cancellationToken);

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

    public async Task<DeveloperProjectResponse?> Assign(DeveloperProjectCreateRequest request, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var devTask = _developerService.GetAsync(request.DeveloperId, cancellationToken);
            var projTask = _projectService.GetAsync(request.ProjectId, cancellationToken);

            _ = await WhenAny(devTask, projTask);

            var dev = await devTask;

            if (dev.IsNull())
            {
                throw new EntityNotFoundException(typeof(Developer), request.DeveloperId);
            }

            var proj = await projTask;

            if (proj.IsNull())
            {
                throw new EntityNotFoundException(typeof(Project), request.ProjectId);
            }

            var entity = await _repository.InsertAsync(new DeveloperProject
            {
                DeveloperId = request.DeveloperId,
                ProjectId = request.ProjectId,
                CreatedBy = request.CreatedBy,
                CreatedAt = UtcNow,
                IsActive = true,
                IsDeleted = false
            }, true, cancellationToken);

            return entity.IsNull()
                ? throw new BusinessException(SQL_SERVER_ERROR)
                : await _redisService.SetAsync($"{DeveloperProjectGroupPrefix}:{request.DeveloperId}", request.ProjectId, ObjectMapper.Map<DeveloperProject, DeveloperProjectRedisDto>(entity), cancellationToken)
                ? ObjectMapper.Map<DeveloperProject, DeveloperProjectResponse>(entity)
                : throw new BusinessException(REDIS_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Assign-DeveloperProjectService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async Task<bool> Unassign(Guid developerId, string projectId, Guid updatedBy, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var entity = await _repository.ModifyAsync(new DeveloperProjectDto
            {
                Id = (await _redisService.GetAsync($"{DeveloperProjectGroupPrefix}:{developerId}", projectId, cancellationToken) ?? throw new EntityNotFoundException(typeof(DeveloperProjectRedisDto))).Id,
                UpdatedBy = updatedBy,
                IsDeleted = true
            }, cancellationToken);

            return entity.IsNull() ? throw new BusinessException(SQL_SERVER_ERROR) : await _redisService.DeleteAsync($"{DeveloperProjectGroupPrefix}:{developerId}", projectId, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unassign-DeveloperProjectService-Exception: {DeveloperId} - {ProjectId} - {UpdatedBy}", developerId, projectId, updatedBy);

            throw;
        }
    }

    public async Task<bool> SyncDataToRedisAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var cleanTask = _redisService.DeleteGroupAsync($"{DeveloperProjectGroupPrefix}:", cancellationToken);
            var entitiesTask = _repository.GetListAsync(x => !x.IsDeleted, cancellationToken: cancellationToken);

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
                cancellationToken.ThrowIfCancellationRequested();

                await slim.WaitAsync(cancellationToken);

                try
                {
                    result &= await _redisService.SetBulkAsync($"{DeveloperProjectGroupPrefix}:{g.Key}", g.ToDictionary(y => y.ProjectId, y => ObjectMapper.Map<DeveloperProject, DeveloperProjectRedisDto>(y)), cancellationToken);
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
            _logger.LogError(ex, "SyncDataToRedisAsync-DeveloperProjectService-Exception");

            throw;
        }
    }

    public async Task<bool> SyncDataToRedisByDeveloperAsync(Guid developerId, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var cleanTask = _redisService.DeleteAllAsync($"{DeveloperProjectGroupPrefix}:{developerId}", cancellationToken);
            var entitiesTask = _repository.GetListAsync(x => x.DeveloperId == developerId && !x.IsDeleted, cancellationToken: cancellationToken);

            _ = await WhenAny(cleanTask, entitiesTask);

            var result = await cleanTask;
            var entities = await entitiesTask;

            return entities.IsNullEmpty()
                ? result
                : (result &= await _redisService.SetBulkAsync($"{DeveloperProjectGroupPrefix}:{developerId}", entities.ToDictionary(x => x.ProjectId, ObjectMapper.Map<DeveloperProject, DeveloperProjectRedisDto>), cancellationToken));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDataToRedisByDeveloperAsync-DeveloperProjectService-Exception: {DeveloperId}", developerId);

            throw;
        }
    }
}
