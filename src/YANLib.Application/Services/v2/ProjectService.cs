﻿using Microsoft.Extensions.Logging;
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
using YANLib.Snowflake;
using static System.Threading.Tasks.Task;
using static YANLib.YANLibConsts;
using static YANLib.YANLibConsts.SnowflakeId.DatacenterId;
using static YANLib.YANLibConsts.SnowflakeId.WorkerId;

namespace YANLib.Services.v2;

public class ProjectService(
    ILogger<ProjectService> logger,
    IProjectRepository repository,
    IElasticsearchService<ProjectEsIndex, string> esService,
    IDeveloperRepository developerRepository,
    IDeveloperProjectRepository developerProjectRepository
) : YANLibAppService, IProjectService
{
    private readonly ILogger<ProjectService> _logger = logger;
    private readonly IProjectRepository _repository = repository;
    private readonly IElasticsearchService<ProjectEsIndex, string> _esService = esService;
    private readonly IDeveloperRepository _developerRepository = developerRepository;
    private readonly IDeveloperProjectRepository _developerProjectRepository = developerProjectRepository;
    private readonly IdGenerator _idGenerator = new(DeveloperId, YanlibId);

    public async Task<PagedResultDto<ProjectResponse>> GetAllAsync(PagedAndSortedResultRequestDto input, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return ObjectMapper.Map<PagedResultDto<ProjectEsIndex>, PagedResultDto<ProjectResponse>>(await _esService.GetAllAsync(input, cancellationToken));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAllAsync-ProjectService-Exception: {Input}", input.Serialize());

            throw;
        }
    }

    public async Task<ProjectResponse?> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var dto = await _esService.GetAsync(id, cancellationToken);

            return dto.IsNull() ? default : ObjectMapper.Map<ProjectEsIndex, ProjectResponse>(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAsync-ProjectService-Exception: {Id}", id);

            throw;
        }
    }

    public async Task<ProjectResponse?> AddAsync(ProjectCreateRequest request, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var entity = await _repository.InsertAsync(ObjectMapper.Map<(string Id, ProjectCreateRequest Request), Project>((_idGenerator.NextIdAlphabetic(), request)), cancellationToken: cancellationToken);

            return entity.IsNotNull() && await _esService.SetAsync(ObjectMapper.Map<Project, ProjectEsIndex>(entity), cancellationToken)
                ? ObjectMapper.Map<Project, ProjectResponse>(entity)
                : throw new EntityNotFoundException(typeof(Project));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "InsertAsync-ProjectService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async Task<ProjectResponse?> ModifyAsync(string id, ProjectUpdateRequest request, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var dto = await _esService.GetAsync(id, cancellationToken) ?? throw new EntityNotFoundException(typeof(ProjectEsIndex), id);
            var entity = await _repository.ModifyAsync(ObjectMapper.Map<(string Id, ProjectUpdateRequest Request), ProjectDto>((id, request)), cancellationToken);

            return entity.IsNotNull() && await _esService.SetAsync(ObjectMapper.Map<Project, ProjectEsIndex>(entity), cancellationToken)
                ? ObjectMapper.Map<Project, ProjectResponse>(entity)
                : throw new EntityNotFoundException(typeof(Project), id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ModifyAsync-ProjectService-Exception: {Id} - {Request}", id, request.Serialize());

            throw;
        }
    }

    public async Task<bool> DeleteAsync(string id, Guid updatedBy, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return (await _repository.ModifyAsync(new ProjectDto
            {
                Id = (await _esService.GetAsync(id, cancellationToken) ?? throw new EntityNotFoundException(typeof(ProjectEsIndex), id)).Id.ToString(),
                UpdatedBy = updatedBy,
                IsDeleted = true,
            }, cancellationToken)).IsNotNull() && await _esService.DeleteAsync(id, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteAsync-ProjectService-Exception: {Id} - {UpdatedBy}", id, updatedBy);

            throw;
        }
    }

    public async Task<bool> SyncDataToElasticsearchAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var cleanTask = _esService.DeleteAllAsync(ElasticsearchIndex.Project, cancellationToken);
            var entitiesTask = _repository.GetListAsync(x => !x.IsDeleted, cancellationToken: cancellationToken);

            _ = await WhenAny(cleanTask, entitiesTask);

            var result = await cleanTask;
            var entities = await entitiesTask;

            if (entities.IsNullEmpty())
            {
                return result;
            }

            var datas = new List<ProjectEsIndex>();
            var slim = new SemaphoreSlim(1);

            await WhenAll(entities.Select(async x =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                var dto = ObjectMapper.Map<Project, ProjectEsIndex>(x);

                await slim.WaitAsync(cancellationToken);

                try
                {
                    var devIds = (await _developerProjectRepository.GetListAsync(y => y.ProjectId == x.Id && !y.IsDeleted, cancellationToken: cancellationToken)).Select(y => y.DeveloperId).ToArray();

                    dto.Developers = [.. (await _developerRepository.GetListAsync(y => devIds.Contains(y.Id) && !y.IsDeleted, cancellationToken: cancellationToken)).Select(y => ObjectMapper.Map<Developer, DeveloperEsIndex>(y))];
                    datas.Add(dto);
                }
                finally
                {
                    _ = slim.Release();
                }
            }));

            return result && await _esService.SetBulkAsync(datas, ElasticsearchIndex.Project, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDataToElasticsearchAsync-ProjectService-Exception");

            throw;
        }
    }

    public async Task<PagedResultDto<ProjectResponse>> SearchWithWildcardAsync(PagedAndSortedResultRequestDto input, string? searchText, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return ObjectMapper.Map<PagedResultDto<ProjectEsIndex>, PagedResultDto<ProjectResponse>>(await _esService.SearchWithWildcardAsync(
                input,
                searchText,
                [nameof(ProjectEsIndex.Name), nameof(ProjectEsIndex.Description)],
                cancellationToken
            ));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchWithWildcardAsync-ProjectService-Exception: {Input} - {SearchText}", input.Serialize(), searchText);

            throw;
        }
    }

    public async Task<PagedResultDto<ProjectResponse>> SearchWithPhrasePrefixAsync(PagedAndSortedResultRequestDto input, string? searchText, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return ObjectMapper.Map<PagedResultDto<ProjectEsIndex>, PagedResultDto<ProjectResponse>>(await _esService.SearchWithPhrasePrefixAsync(
                input,
                searchText,
                [nameof(ProjectEsIndex.Name), nameof(ProjectEsIndex.Description)],
                cancellationToken
            ));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchWithPhrasePrefixAsync-ProjectService-Exception: {Input} - {SearchText}", input.Serialize(), searchText);

            throw;
        }
    }

    public async Task<PagedResultDto<ProjectResponse>> SearchWithExactPhraseAsync(PagedAndSortedResultRequestDto input, string? searchText, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return ObjectMapper.Map<PagedResultDto<ProjectEsIndex>, PagedResultDto<ProjectResponse>>(await _esService.SearchWithExactPhraseAsync(
                input,
                searchText,
                [nameof(ProjectEsIndex.Name), nameof(ProjectEsIndex.Description)],
                cancellationToken
            ));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchWithExactPhraseAsync-ProjectService-Exception: {Input} - {SearchText}", input.Serialize(), searchText);

            throw;
        }
    }

    public async Task<PagedResultDto<ProjectResponse>> SearchWithKeywordsAsync(PagedAndSortedResultRequestDto input, string? searchText, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return ObjectMapper.Map<PagedResultDto<ProjectEsIndex>, PagedResultDto<ProjectResponse>>(await _esService.SearchWithKeywordsAsync(
                input,
                searchText,
                [nameof(ProjectEsIndex.Name), nameof(ProjectEsIndex.Description)],
                cancellationToken
            ));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchWithKeywordsAsync-ProjectService-Exception: {Input} - {SearchText}", input.Serialize(), searchText);

            throw;
        }
    }
}
