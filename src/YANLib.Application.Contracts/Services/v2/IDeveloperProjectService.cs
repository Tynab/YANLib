using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using YANLib.Requests.v2.Create;
using YANLib.Responses;

namespace YANLib.Services.v2;

public interface IDeveloperProjectService : IApplicationService
{
    public Task<PagedResultDto<DeveloperProjectResponse>?> GetByDeveloperAsync(PagedAndSortedResultRequestDto input, Guid developerId, CancellationToken cancellationToken = default);

    public Task<DeveloperProjectResponse?> GetByDeveloperAndProjectAsync(Guid developerId, string projectId, CancellationToken cancellationToken = default);

    public Task<DeveloperProjectResponse?> AssignAsync(DeveloperProjectCreateRequest request, CancellationToken cancellationToken = default);

    public Task<bool> UnassignAsync(Guid developerId, string projectId, Guid updatedBy, CancellationToken cancellationToken = default);

    public Task<bool> SyncDataToRedisAsync(CancellationToken cancellationToken = default);

    public Task<bool> SyncDataToRedisByDeveloperAsync(Guid developerId, CancellationToken cancellationToken = default);
}
