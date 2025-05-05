using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;

namespace YANLib.Services.v2;

public interface IProjectService
{
    public ValueTask<PagedResultDto<ProjectResponse>> GetAll(PagedAndSortedResultRequestDto input);

    public ValueTask<ProjectResponse?> Get(string id);

    public ValueTask<ProjectResponse?> Insert(ProjectCreateRequest request);

    public ValueTask<ProjectResponse?> Modify(string id, ProjectUpdateRequest dto);

    public ValueTask<bool> Delete(string id, Guid updatedBy);

    public ValueTask<bool> SyncDbToEs();

    public ValueTask<PagedResultDto<ProjectResponse>> SearchWithWildcard(PagedAndSortedResultRequestDto input, string searchText);

    public ValueTask<PagedResultDto<ProjectResponse>> SearchWithPhrasePrefix(PagedAndSortedResultRequestDto input, string searchText);

    public ValueTask<PagedResultDto<ProjectResponse>> SearchWithExactPhrase(PagedAndSortedResultRequestDto input, string searchText);

    public ValueTask<PagedResultDto<ProjectResponse>> SearchWithKeywords(PagedAndSortedResultRequestDto input, string searchText);
}
