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
    public ValueTask<PagedResultDto<DeveloperTypeResponse>?> GetAll(PagedAndSortedResultRequestDto input);

    public ValueTask<DeveloperTypeResponse?> Get(long code);

    public ValueTask<DeveloperTypeResponse?> Insert(DeveloperTypeCreateRequest request);

    public ValueTask<DeveloperTypeResponse?> Modify(long code, DeveloperTypeUpdateRequest request);

    public ValueTask<bool> Delete(long code, Guid updatedBy);

    public ValueTask<bool> SyncDbToRedis();
}
