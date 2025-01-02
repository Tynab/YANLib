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
    public ValueTask<PagedResultDto<DeveloperProjectResponse>?> GetByDeveloper(PagedAndSortedResultRequestDto input, Guid developerId);

    public ValueTask<DeveloperProjectResponse?> GetByDeveloperAndProject(Guid developerId, string projectId);

    public ValueTask<DeveloperProjectResponse?> Insert(DeveloperProjectCreateRequest request);

    public ValueTask<DeveloperProjectResponse?> Modify(DeveloperProjectUpdateRequest request);

    public ValueTask<bool?> Delete(Guid developerId, string projectId, Guid updatedBy);

    public ValueTask<bool> SyncDbToRedis();

    public ValueTask<bool> SyncDbToRedisByDeveloper(Guid developerId);
}
