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
using YANLib.Entities;
using YANLib.EsIndices;
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
    IDeveloperEsService elasticsearchService,
    IRedisService<DeveloperTypeRedisDto> developerTypeRedisService,
    IRedisService<DeveloperProjectRedisDto> developerProjectRedisService,
    IProjectRepository projectRepository,
    IDeveloperProjectRepository developerProjectRepository
) : YANLibAppService, IDeveloperService
{
    private readonly ILogger<DeveloperService> _logger = logger;
    private readonly IDeveloperRepository _repository = repository;
    private readonly IDeveloperEsService _elasticsearchService = elasticsearchService;
    private readonly IRedisService<DeveloperTypeRedisDto> _developerTypeRedisService = developerTypeRedisService;
    private readonly IRedisService<DeveloperProjectRedisDto> _developerProjectRedisService = developerProjectRedisService;
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IDeveloperProjectRepository _developerProjectRepository = developerProjectRepository;

    public async Task<PagedResultDto<DeveloperResponse>> GetAllAsync(PagedAndSortedResultRequestDto input, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return ObjectMapper.Map<PagedResultDto<DeveloperEsIndex>, PagedResultDto<DeveloperResponse>>(await _elasticsearchService.GetAllAsync(input, cancellationToken));
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
            var dto = (await _elasticsearchService.GetById(id, cancellationToken)).FirstOrDefault();

            return dto.IsNull() ? throw new EntityNotFoundException(typeof(DeveloperEsIndex), id) : ObjectMapper.Map<DeveloperEsIndex, DeveloperResponse>(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAsync-DeveloperService-Exception: {Id}", id);

            throw;
        }
    }

    public async Task<DeveloperResponse?> GetByIdCard(string idCard, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var dto = await _elasticsearchService.GetAsync(idCard, cancellationToken);

            return dto.IsNull() ? throw new EntityNotFoundException(typeof(DeveloperEsIndex), idCard) : ObjectMapper.Map<DeveloperEsIndex, DeveloperResponse>(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByIdCard-DeveloperService-Exception: {IdCard}", idCard);

            throw;
        }
    }

    public async Task<DeveloperResponse?> AddAsync(DeveloperCreateRequest request, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            if ((await _elasticsearchService.GetAsync(request.IdCard, cancellationToken)).IsNotNull())
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
            var devType = await devTypeTask;

            result.DeveloperType = devType.IsNull() ? null : ObjectMapper.Map<(long Id, DeveloperTypeRedisDto Dto), DeveloperTypeResponse>((request.DeveloperTypeCode, devType));

            return await _elasticsearchService.SetAsync(ObjectMapper.Map<DeveloperResponse, DeveloperEsIndex>(result), cancellationToken) ? result : throw new BusinessException(ES_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "InsertAsync-DeveloperService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async Task<DeveloperResponse?> AdjustAsync(string idCard, DeveloperUpdateRequest request, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var tuple = await _repository.AdjustAsync(idCard, ObjectMapper.Map<DeveloperUpdateRequest, Developer>(request), cancellationToken);

            if (tuple.Developer.IsNull())
            {
                throw new BusinessException(SQL_SERVER_ERROR);
            }

            var result = ObjectMapper.Map<Developer, DeveloperResponse>(tuple.Developer);
            var devType = await _developerTypeRedisService.GetAsync(DeveloperTypeGroup, tuple.Developer.DeveloperTypeCode.ToString(), cancellationToken);

            result.DeveloperType = devType.IsNull() ? null : ObjectMapper.Map<(long Id, DeveloperTypeRedisDto Dto), DeveloperTypeResponse>((tuple.Developer.DeveloperTypeCode, devType));

            if (tuple.HasDeveloperProject)
            {
                var cleanTask = _developerProjectRedisService.DeleteAllAsync($"{DeveloperProjectGroupPrefix}:{tuple.OldId}", cancellationToken);
                var entitiesTask = _developerProjectRepository.GetListAsync(x => x.DeveloperId == tuple.Developer.Id && !x.IsDeleted, cancellationToken: cancellationToken);

                _ = await WhenAny(cleanTask, entitiesTask);

                var clean = await cleanTask;
                var entities = await entitiesTask;

                if (entities.IsNullEmpty() ? clean : (clean &= await _developerProjectRedisService.SetBulkAsync($"{DeveloperProjectGroupPrefix}:{tuple.Developer.Id}", entities.ToDictionary(
                    x => x.ProjectId, ObjectMapper.Map<DeveloperProject, DeveloperProjectRedisDto>
                ), cancellationToken)))
                {
                    var projIds = entities.Select(x => x.ProjectId).ToArray();

                    result.Projects = [.. (await _projectRepository.GetListAsync(x => projIds.Contains(x.Id), cancellationToken: cancellationToken)).Select(ObjectMapper.Map<Project, ProjectResponse>)];
                }
            }

            return await _elasticsearchService.SetAsync(ObjectMapper.Map<DeveloperResponse, DeveloperEsIndex>(result), cancellationToken) ? result : throw new BusinessException(ES_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "AdjustAsync-DeveloperService-Exception: {IdCard} - {Request}", idCard, request.Serialize());

            throw;
        }
    }

    public async Task<bool> DeleteAsync(string idCard, Guid updatedBy, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var dto = await _elasticsearchService.GetAsync(idCard, cancellationToken) ?? throw new EntityNotFoundException(typeof(DeveloperEsIndex));

            return (await _repository.ModifyAsync(new DeveloperDto
            {
                Id = dto.Id.Parse<Guid>(),
                UpdatedBy = updatedBy,
                IsDeleted = true,
            }, cancellationToken)).IsNull() ? throw new BusinessException(SQL_SERVER_ERROR) : await _elasticsearchService.DeleteAsync(idCard, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteAsync-DeveloperService-Exception: {IdCard} - {UpdatedBy}", idCard, updatedBy);

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

            var datas = new List<DeveloperEsIndex>();
            var slim = new SemaphoreSlim(1);

            await WhenAll(entities.Select(async x =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                var dto = ObjectMapper.Map<Developer, DeveloperEsIndex>(x);
                var devTypeDto = await _developerTypeRedisService.GetAsync(DeveloperTypeGroup, x.DeveloperTypeCode.ToString(), cancellationToken);

                if (devTypeDto.IsNotNull())
                {
                    dto.DeveloperType = ObjectMapper.Map<(long Id, DeveloperTypeRedisDto Dto), DeveloperTypeResponse>((x.DeveloperTypeCode, devTypeDto));
                }

                var devProjDict = await _developerProjectRedisService.GetAllAsync($"{DeveloperProjectGroupPrefix}:{x.Id}", cancellationToken);

                await slim.WaitAsync(cancellationToken);

                try
                {
                    if (devProjDict.IsNotNull())
                    {
                        var projIds = devProjDict.Select(y => ObjectMapper.Map<(Guid DeveloperId, KeyValuePair<string, DeveloperProjectRedisDto?> Pair), DeveloperProjectResponse>((x.Id, y))).Select(y => y.ProjectId).ToArray();

                        dto.Projects = [.. (await _projectRepository.GetListAsync(y => projIds.Contains(y.Id), cancellationToken: cancellationToken)).Select(ObjectMapper.Map<Project, ProjectResponse>)];
                    }

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
