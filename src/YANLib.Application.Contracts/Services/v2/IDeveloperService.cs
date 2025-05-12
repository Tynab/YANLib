using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;

namespace YANLib.Services.v2;

public interface IDeveloperService : IApplicationService
{
    public Task<PagedResultDto<DeveloperResponse>> GetAll(PagedAndSortedResultRequestDto input);

    public Task<DeveloperResponse?> Get(Guid id);

    public Task<DeveloperResponse?> Insert(DeveloperCreateRequest request);

    public Task<DeveloperResponse?> Adjust(string idCard, DeveloperUpdateRequest request);

    public Task<bool> Delete(string idCard, Guid updatedBy);

    public Task<bool> SyncDbToEs();

    //public Task<DeveloperResponse?> GetByIdCard(string idCard);
}
