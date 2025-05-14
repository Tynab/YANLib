using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;

namespace YANLib.Services.v2;

public interface IDeveloperTypeService : IApplicationService
{
    public Task<PagedResultDto<DeveloperTypeResponse>?> GetAllAsync(PagedAndSortedResultRequestDto input, CancellationToken cancellationToken = default);

    public Task<DeveloperTypeResponse?> GetAsync(long code, CancellationToken cancellationToken = default);

    public Task<DeveloperTypeResponse?> InsertAsync(DeveloperTypeCreateRequest request, CancellationToken cancellationToken = default);

    public Task<DeveloperTypeResponse?> ModifyAsync(long code, DeveloperTypeUpdateRequest request, CancellationToken cancellationToken = default);

    public Task<bool> DeleteAsync(long code, Guid updatedBy, CancellationToken cancellationToken = default);

    public Task<bool> SyncDataToRedisAsync(CancellationToken cancellationToken = default);
}
