using Id_Generator_Snowflake;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.EsIndices;
using YANLib.Repositories;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;
using static System.Threading.Tasks.Task;
using static YANLib.YANLibConsts;
using static YANLib.YANLibConsts.SnowflakeId.DatacenterId;
using static YANLib.YANLibConsts.SnowflakeId.WorkerId;

namespace YANLib.Services.v2;

public class ProjectService(ILogger<ProjectService> logger, IProjectRepository repository, IEsService<ProjectEsIndex> esService) : YANLibAppService, IProjectService
{
    private readonly ILogger<ProjectService> _logger = logger;
    private readonly IProjectRepository _repository = repository;
    private readonly IEsService<ProjectEsIndex> _esService = esService;
    private readonly IdGenerator _idGenerator = new(DeveloperId, YanlibId);

    public async ValueTask<PagedResultDto<ProjectResponse>> GetAll(PagedAndSortedResultRequestDto input)
    {
        try
        {
            return ObjectMapper.Map<PagedResultDto<ProjectEsIndex>, PagedResultDto<ProjectResponse>>(await _esService.GetAll(input));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAll-ProjectService-Exception: {Input}", input.Serialize());

            throw;
        }
    }

    public async ValueTask<ProjectResponse?> Get(string id)
    {
        try
        {
            var dto = await _esService.Get(id);

            return dto.IsNull() ? default : ObjectMapper.Map<ProjectEsIndex, ProjectResponse>(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Get-ProjectService-Exception: {Id}", id);

            throw;
        }
    }

    public async ValueTask<ProjectResponse?> Insert(ProjectCreateRequest request)
    {
        try
        {
            var entity = await _repository.InsertAsync(ObjectMapper.Map<(string Id, ProjectCreateRequest Request), Project>((_idGenerator.NextIdAlphabetic(), request)));

            return entity.IsNotNull() && await _esService.Set(ObjectMapper.Map<Project, ProjectEsIndex>(entity))
                ? ObjectMapper.Map<Project, ProjectResponse>(entity)
                : throw new EntityNotFoundException(typeof(Project));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Insert-ProjectService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async ValueTask<ProjectResponse?> Modify(string id, ProjectUpdateRequest request)
    {
        try
        {
            var dto = await _esService.Get(id) ?? throw new EntityNotFoundException(typeof(ProjectEsIndex), id);
            var entity = await _repository.Modify(ObjectMapper.Map<(string Id, ProjectUpdateRequest Request), ProjectDto>((id, request)));

            return entity.IsNotNull() && await _esService.Set(ObjectMapper.Map<Project, ProjectEsIndex>(entity))
                ? ObjectMapper.Map<Project, ProjectResponse>(entity)
                : throw new EntityNotFoundException(typeof(Project), id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Modify-ProjectService-Exception: {Id} - {Dto}", id, request.Serialize());

            throw;
        }
    }

    public async ValueTask<bool> Delete(string id, Guid updatedBy)
    {
        try
        {
            return (await _repository.Modify(new ProjectDto
            {
                Id = (await _esService.Get(id) ?? throw new EntityNotFoundException(typeof(ProjectEsIndex), id)).Id.ToString(),
                UpdatedBy = updatedBy,
                IsDeleted = true,
            })).IsNotNull() && await _esService.Delete(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Delete-ProjectService-Exception: {Id} - {UpdatedBy}", id, updatedBy);

            throw;
        }
    }

    public async ValueTask<bool> SyncDbToEs()
    {
        try
        {
            var cleanTask = _esService.DeleteAll(ElasticsearchIndex.Project).AsTask();
            var entitiesTask = _repository.GetListAsync(x => !x.IsDeleted);

            _ = await WhenAny(cleanTask, entitiesTask);

            var result = await cleanTask;
            var entities = await entitiesTask;

            if (entities.IsNullEmpty())
            {
                return result;
            }

            var datas = new List<ProjectEsIndex>();
            var ss = new SemaphoreSlim(1);

            await WhenAll(entities.Select(async x =>
            {
                var dto = ObjectMapper.Map<Project, ProjectEsIndex>(x);

                await ss.WaitAsync();

                try
                {
                    datas.Add(dto);
                }
                finally
                {
                    _ = ss.Release();
                }
            }));

            return result && await _esService.SetBulk(datas, ElasticsearchIndex.Project);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDbToEs-ProjectService-Exception");

            throw;
        }
    }

    public async ValueTask<PagedResultDto<ProjectResponse>> SearchWithWildcard(PagedAndSortedResultRequestDto input, string searchText)
    {
        try
        {
            return ObjectMapper.Map<PagedResultDto<ProjectEsIndex>, PagedResultDto<ProjectResponse>>(await _esService.SearchWithWildcard(input, searchText, nameof(ProjectEsIndex.Name), nameof(ProjectEsIndex.Description)));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchWithWildcard-ProjectService-Exception: {Input} - {SearchText}", input.Serialize(), searchText);

            throw;
        }
    }

    public async ValueTask<PagedResultDto<ProjectResponse>> SearchWithPhrasePrefix(PagedAndSortedResultRequestDto input, string searchText)
    {
        try
        {
            return ObjectMapper.Map<PagedResultDto<ProjectEsIndex>, PagedResultDto<ProjectResponse>>(await _esService.SearchWithPhrasePrefix(input, searchText, nameof(ProjectEsIndex.Name), nameof(ProjectEsIndex.Description)));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchWithPhrasePrefix-ProjectService-Exception: {Input} - {SearchText}", input.Serialize(), searchText);

            throw;
        }
    }

    public async ValueTask<PagedResultDto<ProjectResponse>> SearchWithExactPhrase(PagedAndSortedResultRequestDto input, string searchText)
    {
        try
        {
            return ObjectMapper.Map<PagedResultDto<ProjectEsIndex>, PagedResultDto<ProjectResponse>>(await _esService.SearchWithExactPhrase(input, searchText, nameof(ProjectEsIndex.Name), nameof(ProjectEsIndex.Description)));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchWithExactPhrase-ProjectService-Exception: {Input} - {SearchText}", input.Serialize(), searchText);

            throw;
        }
    }

    public async ValueTask<PagedResultDto<ProjectResponse>> SearchWithKeywords(PagedAndSortedResultRequestDto input, string searchText)
    {
        try
        {
            return ObjectMapper.Map<PagedResultDto<ProjectEsIndex>, PagedResultDto<ProjectResponse>>(await _esService.SearchWithKeywords(input, searchText, nameof(ProjectEsIndex.Name), nameof(ProjectEsIndex.Description)));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchWithKeywords-ProjectService-Exception: {Input} - {SearchText}", input.Serialize(), searchText);

            throw;
        }
    }
}
