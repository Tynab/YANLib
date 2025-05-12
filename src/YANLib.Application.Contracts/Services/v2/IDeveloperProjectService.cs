using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;

namespace YANLib.Services.v2;

public interface IDeveloperProjectService : IApplicationService
{
    public Task<PagedResultDto<DeveloperProjectResponse>?> GetByDeveloper(PagedAndSortedResultRequestDto input, Guid developerId);

    public Task<DeveloperProjectResponse?> GetByDeveloperAndProject(Guid developerId, string projectId);

    public Task<DeveloperProjectResponse?> Insert(DeveloperProjectCreateRequest request);

    public Task<DeveloperProjectResponse?> Modify(DeveloperProjectUpdateRequest request);

    public Task<bool?> Delete(Guid developerId, string projectId, Guid updatedBy);

    public Task<bool> SyncDbToRedis();

    public Task<bool> SyncDbToRedisByDeveloper(Guid developerId);
}
