using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;

namespace YANLib.Services.v2;

public interface IProjectService
{
    public Task<PagedResultDto<ProjectResponse>> GetAll(PagedAndSortedResultRequestDto input);

    public Task<ProjectResponse?> Get(string id);

    public Task<ProjectResponse?> Insert(ProjectCreateRequest request);

    public Task<ProjectResponse?> Modify(string id, ProjectUpdateRequest dto);

    public Task<bool> Delete(string id, Guid updatedBy);

    public Task<bool> SyncDbToEs();

    public Task<PagedResultDto<ProjectResponse>> SearchWithWildcard(PagedAndSortedResultRequestDto input, string searchText);

    public Task<PagedResultDto<ProjectResponse>> SearchWithPhrasePrefix(PagedAndSortedResultRequestDto input, string searchText);

    public Task<PagedResultDto<ProjectResponse>> SearchWithExactPhrase(PagedAndSortedResultRequestDto input, string searchText);

    public Task<PagedResultDto<ProjectResponse>> SearchWithKeywords(PagedAndSortedResultRequestDto input, string searchText);
}
