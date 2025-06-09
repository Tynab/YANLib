using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;

namespace YANLib.Services.v2;

public interface IDeveloperService : IApplicationService
{
    public Task<PagedResultDto<DeveloperResponse>> GetAllAsync(PagedAndSortedResultRequestDto input, CancellationToken cancellationToken = default);

    public Task<DeveloperResponse?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<DeveloperResponse?> GetByIdCard(string idCard, CancellationToken cancellationToken = default);

    public Task<DeveloperResponse?> AddAsync(DeveloperCreateRequest request, CancellationToken cancellationToken = default);

    public Task<DeveloperResponse?> AdjustAsync(string id, DeveloperUpdateRequest request, CancellationToken cancellationToken = default);

    public Task<bool> DeleteAsync(string id, Guid updatedBy, CancellationToken cancellationToken = default);

    public Task<bool> SyncDataToElasticsearchAsync(CancellationToken cancellationToken = default);
}
