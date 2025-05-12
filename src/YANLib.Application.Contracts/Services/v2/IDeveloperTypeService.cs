using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;

namespace YANLib.Services.v2;

public interface IDeveloperTypeService : IApplicationService
{
    public Task<PagedResultDto<DeveloperTypeResponse>?> GetAll(PagedAndSortedResultRequestDto input);

    public Task<DeveloperTypeResponse?> Get(long code);

    public Task<DeveloperTypeResponse?> Insert(DeveloperTypeCreateRequest request);

    public Task<DeveloperTypeResponse?> Modify(long code, DeveloperTypeUpdateRequest request);

    public Task<bool> Delete(long code, Guid updatedBy);

    public Task<bool> SyncDbToRedis();
}
