using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;

namespace YANLib.Services.v2;

public interface IProjectService
{
    public Task<PagedResultDto<ProjectResponse>> GetAllAsync(PagedAndSortedResultRequestDto input, CancellationToken cancellationToken = default);

    public Task<ProjectResponse?> GetAsync(string id, CancellationToken cancellationToken = default);

    public Task<ProjectResponse?> InsertAsync(ProjectCreateRequest request, CancellationToken cancellationToken = default);

    public Task<ProjectResponse?> ModifyAsync(string id, ProjectUpdateRequest dto, CancellationToken cancellationToken = default);

    public Task<bool> DeleteAsync(string id, Guid updatedBy, CancellationToken cancellationToken = default);

    public Task<bool> SyncDataToElasticsearchAsync(CancellationToken cancellationToken = default);

    public Task<PagedResultDto<ProjectResponse>> SearchWithWildcardAsync(PagedAndSortedResultRequestDto input, string searchText, CancellationToken cancellationToken = default);

    public Task<PagedResultDto<ProjectResponse>> SearchWithPhrasePrefixAsync(PagedAndSortedResultRequestDto input, string searchText, CancellationToken cancellationToken = default);

    public Task<PagedResultDto<ProjectResponse>> SearchWithExactPhraseAsync(PagedAndSortedResultRequestDto input, string searchText, CancellationToken cancellationToken = default);

    public Task<PagedResultDto<ProjectResponse>> SearchWithKeywordsAsync(PagedAndSortedResultRequestDto input, string searchText, CancellationToken cancellationToken = default);
}
