using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using YANLib.Requests.Insert;
using YANLib.Requests.Modify;
using YANLib.Responses;

namespace YANLib.Services.v2;

public interface IDeveloperTypeService : IApplicationService
{
    public ValueTask<PagedResultDto<DeveloperTypeResponse>?> GetAll(PagedAndSortedResultRequestDto dto);

    public ValueTask<DeveloperTypeResponse?> Get(long code);

    public ValueTask<DeveloperTypeResponse?> Insert(DeveloperTypeInsertRequest request);

    public ValueTask<DeveloperTypeResponse?> Modify(long code, DeveloperTypeModifyRequest request);

    public ValueTask<bool> Delete(long code, Guid updatedBy);

    public ValueTask<bool> SyncDbToRedis();
}
