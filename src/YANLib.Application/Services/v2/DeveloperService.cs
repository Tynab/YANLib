using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using YANLib.Dtos;
using YANLib.ElasticsearchIndices;
using YANLib.Entities;
using YANLib.RedisDtos;
using YANLib.Repositories;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;
using static System.Threading.Tasks.Task;
using static YANLib.YANLibConsts;
using static YANLib.YANLibConsts.RedisConstant;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Services.v2;

public class DeveloperService(
    ILogger<DeveloperService> logger,
    IDeveloperRepository repository,
    IDeveloperElasticsearchService elasticsearchService,
    IRedisService<DeveloperTypeRedisDto> developerTypeRedisService,
    IRedisService<DeveloperProjectRedisDto> developerProjectRedisService,
    IProjectRepository projectRepository
) : YANLibAppService, IDeveloperService
{
    private readonly ILogger<DeveloperService> _logger = logger;
    private readonly IDeveloperRepository _repository = repository;
    private readonly IDeveloperElasticsearchService _elasticsearchService = elasticsearchService;
    private readonly IRedisService<DeveloperTypeRedisDto> _developerTypeRedisService = developerTypeRedisService;
    private readonly IRedisService<DeveloperProjectRedisDto> _developerProjectRedisService = developerProjectRedisService;
    private readonly IProjectRepository _projectRepository = projectRepository;

    public async Task<PagedResultDto<DeveloperResponse>> GetAllAsync(PagedAndSortedResultRequestDto input, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return ObjectMapper.Map<PagedResultDto<DeveloperElasticsearchIndex>, PagedResultDto<DeveloperResponse>>(await _elasticsearchService.GetAllAsync(input, cancellationToken));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAllAsync-DeveloperService-Exception: {Input}", input.Serialize());

            throw;
        }
    }

    public async Task<DeveloperResponse?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var dto = await _elasticsearchService.GetAsync(id, cancellationToken);

            return dto.IsNull() ? throw new EntityNotFoundException(typeof(DeveloperElasticsearchIndex), id) : ObjectMapper.Map<DeveloperElasticsearchIndex, DeveloperResponse>(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAsync-DeveloperService-Exception: {Id}", id);

            throw;
        }
    }

    public async Task<DeveloperResponse?> GetByIdCardAsync(string idCard, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var dto = (await _elasticsearchService.GetByIdCardAsync(idCard, cancellationToken)).FirstOrDefault();

            return dto.IsNull() ? throw new EntityNotFoundException(typeof(DeveloperElasticsearchIndex), idCard) : ObjectMapper.Map<DeveloperElasticsearchIndex, DeveloperResponse>(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByIdCardAsync-DeveloperService-Exception: {IdCard}", idCard);

            throw;
        }
    }

    public async Task<DeveloperResponse?> InsertAsync(DeveloperCreateRequest request, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            if ((await _elasticsearchService.GetByIdCardAsync(request.IdCard, cancellationToken)).IsNotNull())
            {
                throw new BusinessException(EXIST_ID_CARD).WithData(nameof(Developer.IdCard), request.IdCard);
            }

            var entityTask = _repository.InsertAsync(ObjectMapper.Map<DeveloperCreateRequest, Developer>(request), true, cancellationToken);
            var devTypeTask = _developerTypeRedisService.GetAsync(DeveloperTypeGroup, request.DeveloperTypeCode.ToString(), cancellationToken);

            _ = await WhenAny(entityTask, devTypeTask);

            var entity = await entityTask;

            if (entity.IsNull())
            {
                throw new BusinessException(SQL_SERVER_ERROR);
            }

            var result = ObjectMapper.Map<Developer, DeveloperResponse>(entity);

            result.DeveloperType = ObjectMapper.Map<(long Id, DeveloperTypeRedisDto? Dto), DeveloperTypeResponse?>((request.DeveloperTypeCode, await devTypeTask));

            return await _elasticsearchService.SetAsync(ObjectMapper.Map<DeveloperResponse, DeveloperElasticsearchIndex>(result), cancellationToken) ? result : throw new BusinessException(ELASTICSEARCH_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "InsertAsync-DeveloperService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async Task<DeveloperResponse?> AdjustAsync(Guid id, DeveloperUpdateRequest request, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var entity = await _repository.AdjustAsync(id, ObjectMapper.Map<DeveloperUpdateRequest, Developer>(request), cancellationToken);

            if (entity.IsNull())
            {
                throw new BusinessException(SQL_SERVER_ERROR);
            }

            var result = ObjectMapper.Map<Developer, DeveloperResponse>(entity);

            if (request.DeveloperTypeCode.HasValue)
            {
                result.DeveloperType = ObjectMapper.Map<(long? Id, DeveloperTypeRedisDto? Dto), DeveloperTypeResponse?>(
                    (request.DeveloperTypeCode, await _developerTypeRedisService.GetAsync(DeveloperTypeGroup, request.DeveloperTypeCode.Value.ToString(), cancellationToken))
                );
            }

            return await _elasticsearchService.SetAsync(ObjectMapper.Map<DeveloperResponse, DeveloperElasticsearchIndex>(result), cancellationToken) ? result : throw new BusinessException(ELASTICSEARCH_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "AdjustAsync-DeveloperService-Exception: {Id} - {Request}", id, request.Serialize());

            throw;
        }
    }

    public async Task<bool> DeleteAsync(Guid id, Guid updatedBy, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var dto = await _elasticsearchService.GetAsync(id, cancellationToken) ?? throw new EntityNotFoundException(typeof(DeveloperElasticsearchIndex));

            return (await _repository.ModifyAsync(new DeveloperDto
            {
                Id = dto.Id.Parse<Guid>(),
                UpdatedBy = updatedBy,
                IsDeleted = true,
            }, cancellationToken)).IsNull() ? throw new BusinessException(SQL_SERVER_ERROR) : await _elasticsearchService.DeleteAsync(id, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteAsync-DeveloperService-Exception: {Id} - {UpdatedBy}", id, updatedBy);

            throw;
        }
    }

    public async Task<bool> SyncDataToElasticsearchAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var cleanTask = _elasticsearchService.DeleteAllAsync(ElasticsearchIndex.Developer, cancellationToken);
            var entitiesTask = _repository.GetListAsync(x => !x.IsDeleted, cancellationToken: cancellationToken);

            _ = await WhenAny(cleanTask, entitiesTask);

            var result = await cleanTask;
            var entities = await entitiesTask;

            if (entities.IsNullEmpty())
            {
                return result;
            }

            var datas = new List<DeveloperElasticsearchIndex>();
            var slim = new SemaphoreSlim(1);

            await WhenAll(entities.Select(async x =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                var dto = ObjectMapper.Map<Developer, DeveloperElasticsearchIndex>(x);
                //var devProjDict = await _developerProjectRedisService.GetAllAsync($"{DeveloperProjectGroupPrefix}:{x.Id}", cancellationToken);

                //if (devProjDict.IsNotNull())
                //{
                //    var projIds = devProjDict.Select(y => ObjectMapper.Map<(Guid DeveloperId, KeyValuePair<string, DeveloperProjectRedisDto?> Pair), DeveloperProjectResponse>((x.Id, y))).Select(y => y.ProjectId);

                //    dto.Projects = [.. (await _projectRepository.GetListAsync(y => projIds.Contains(y.Id), cancellationToken: cancellationToken)).Select(y => ObjectMapper.Map<Project, ProjectResponse>(y))];
                //}

                await slim.WaitAsync(cancellationToken);

                try
                {
                    datas.Add(dto);
                }
                finally
                {
                    _ = slim.Release();
                }
            }));

            return result && await _elasticsearchService.SetBulkAsync(datas, ElasticsearchIndex.Developer, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDataToElasticsearchAsync-DeveloperService-Exception");

            throw;
        }
    }
}
