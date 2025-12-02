using Volo.Abp.Application.Dtos;
using YANLib.ListQueries;
using YANLib.Requests.CreateOrUpdateRequest;
using YANLib.Responses;

namespace YANLib.Services;

public interface ISampleEsService
{
    public Task<PagedResultDto<SampleResponse>> GetList(SampleListQuery query, CancellationToken cancellationToken = default);

    public Task<SampleResponse?> Get(Guid id, CancellationToken cancellationToken = default);

    public Task<SampleResponse?> Add(SampleCreateOrUpdateRequest request, CancellationToken cancellationToken = default);

    public Task<SampleResponse?> Update(Guid id, SampleCreateOrUpdateRequest request, CancellationToken cancellationToken = default);

    public Task<bool> Delete(Guid id, CancellationToken cancellationToken = default);

    public Task<bool> SyncDataToEs(CancellationToken cancellationToken = default);

    public Task<PagedResultDto<SampleResponse>> SearchWithWildcard(SampleListQuery query, CancellationToken cancellationToken = default);

    public Task<PagedResultDto<SampleResponse>> SearchWithPhrasePrefix(SampleListQuery query, CancellationToken cancellationToken = default);

    public Task<PagedResultDto<SampleResponse>> SearchWithExactPhrase(SampleListQuery query, CancellationToken cancellationToken = default);

    public Task<PagedResultDto<SampleResponse>> SearchWithKeywords(SampleListQuery query, CancellationToken cancellationToken = default);
}
