using Microsoft.Extensions.Logging;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Security.Claims;
using YANLib;
using static YANLib.BaseConsts;
using static YANLib.BaseErrorCodes;
using static YANLib.Enums.SampleType;
using static System.Threading.Tasks.Task;
using YANLib.Entities;
using YANLib.Responses;
using YANLib.Requests.CreateOrUpdateRequest;
using YANLib.ListQueries;
using YANLib.EsIndices;

namespace YANLib.Services;

public class SampleEsService(
    ILogger<SampleEsService> logger,
    IBaseRepository<Sample> repository,
    IEsService<SampleEsIndex, Guid> esService,
    ICurrentPrincipalAccessor currentPrincipalAccessor
) : BaseAccessorService(currentPrincipalAccessor), ISampleEsService
{
    public async Task<PagedResultDto<SampleResponse>> GetList(SampleListQuery query, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return ObjectMapper.Map<PagedResultDto<SampleEsIndex>, PagedResultDto<SampleResponse>>(await esService.GetAllAsync(query.PagedAndSortedDto(), cancellationToken));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "GetList-SampleEsService-Exception: {Query}", query.Serialize());

            throw;
        }
    }

    public async Task<SampleResponse?> Get(Guid id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var dto = await esService.GetAsync(id, cancellationToken);

            return dto.IsNull() ? default : ObjectMapper.Map<SampleEsIndex, SampleResponse>(dto);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Get-SampleEsService-Exception: {Id}", id);

            throw;
        }
    }

    public async Task<SampleResponse?> Add(SampleCreateOrUpdateRequest request, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var entity = await repository.InsertAsync(ObjectMapper.Map<SampleCreateOrUpdateRequest, Sample>(request), cancellationToken: cancellationToken);

            return entity.IsNotNull() && await esService.SetAsync(ObjectMapper.Map<Sample, SampleEsIndex>(entity), cancellationToken)
                ? ObjectMapper.Map<Sample, SampleResponse>(entity)
                : throw new EntityNotFoundException(typeof(Sample));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Add-SampleEsService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async Task<SampleResponse?> Update(Guid id, SampleCreateOrUpdateRequest request, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var dto = await esService.GetAsync(id, cancellationToken) ?? throw new EntityNotFoundException(typeof(SampleEsIndex), id);
            var entity = await repository.UpdateAsync(ObjectMapper.Map<(Guid Id, SampleCreateOrUpdateRequest Request), Sample>((id, request)), cancellationToken: cancellationToken);

            return entity.IsNotNull() && await esService.SetAsync(ObjectMapper.Map<Sample, SampleEsIndex>(entity), cancellationToken)
                ? ObjectMapper.Map<Sample, SampleResponse>(entity)
                : throw new EntityNotFoundException(typeof(Sample), id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Update-SampleEsService-Exception: {Id} - {Request}", id, request.Serialize());

            throw;
        }
    }

    public async Task<bool> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return await repository.SoftDeleteAsync(id, UserId ?? throw new BusinessException(NOT_FOUND_ID), cancellationToken) && await esService.DeleteAsync(id, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Delete-SampleEsService-Exception: {Id}", id);

            throw;
        }
    }

    public async Task<bool> SyncDataToEs(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var cleanTask = esService.DeleteAllAsync(EsIndex.Sample, cancellationToken);
            var entitiesTask = repository.GetListAsync(x => !x.IsDeleted, cancellationToken: cancellationToken);

            _ = await WhenAny(cleanTask, entitiesTask);

            var result = await cleanTask;
            var entities = await entitiesTask;

            if (entities.IsNullEmpty())
            {
                return result;
            }

            var datas = new List<SampleEsIndex>();
            var slim = new SemaphoreSlim(1);

            await WhenAll(entities.Select(async x =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                var dto = ObjectMapper.Map<Sample, SampleEsIndex>(x);

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

            return result && await esService.SetBulkAsync(datas, EsIndex.Sample, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "SyncDataToEs-SampleEsService-Exception");

            throw;
        }
    }

    public async Task<PagedResultDto<SampleResponse>> SearchWithWildcard(SampleListQuery query, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return ObjectMapper.Map<PagedResultDto<SampleEsIndex>, PagedResultDto<SampleResponse>>(await esService.SearchWithWildcardAsync(
                query.PagedAndSortedDto(),
                query.Search,
                [nameof(SampleEsIndex.Name), nameof(SampleEsIndex.Description)],
                query.DateFrom,
                query.DateTo,
                x => x.UpdatedAt,
                query.IsActive ?? default,
                new Dictionary<string, object> { { nameof(SampleEsIndex.Type), Retail } },
                cancellationToken
            ));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "SearchWithWildcard-SampleEsService-Exception: {Query}", query.Serialize());

            throw;
        }
    }

    public async Task<PagedResultDto<SampleResponse>> SearchWithPhrasePrefix(SampleListQuery query, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return ObjectMapper.Map<PagedResultDto<SampleEsIndex>, PagedResultDto<SampleResponse>>(await esService.SearchWithPhrasePrefixAsync(
                query.PagedAndSortedDto(),
                query.Search,
                [nameof(SampleEsIndex.Name), nameof(SampleEsIndex.Description)],
                query.DateFrom,
                query.DateTo,
                x => x.UpdatedAt,
                query.IsActive ?? default,
                cancellationToken: cancellationToken
            ));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "SearchWithPhrasePrefix-SampleEsService-Exception: {Query}", query.Serialize());

            throw;
        }
    }

    public async Task<PagedResultDto<SampleResponse>> SearchWithExactPhrase(SampleListQuery query, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return ObjectMapper.Map<PagedResultDto<SampleEsIndex>, PagedResultDto<SampleResponse>>(await esService.SearchWithExactPhraseAsync(
                query.PagedAndSortedDto(),
                query.Search,
                [nameof(SampleEsIndex.Name), nameof(SampleEsIndex.Description)],
                query.DateFrom,
                query.DateTo,
                x => x.UpdatedAt,
                query.IsActive ?? default,
                cancellationToken: cancellationToken
            ));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "SearchWithExactPhrase-SampleEsService-Exception: {Query}", query.Serialize());

            throw;
        }
    }

    public async Task<PagedResultDto<SampleResponse>> SearchWithKeywords(SampleListQuery query, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return ObjectMapper.Map<PagedResultDto<SampleEsIndex>, PagedResultDto<SampleResponse>>(await esService.SearchWithKeywordsAsync(
                query.PagedAndSortedDto(),
                query.Search,
                [nameof(SampleEsIndex.Name), nameof(SampleEsIndex.Description)],
                query.DateFrom,
                query.DateTo,
                x => x.UpdatedAt,
                query.IsActive ?? default,
                cancellationToken: cancellationToken
            ));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "SearchWithKeywords-SampleEsService-Exception: {Query}", query.Serialize());

            throw;
        }
    }
}
