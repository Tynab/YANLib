using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using YANLib.Requests.Insert;
using YANLib.Requests.Modify;
using YANLib.Responses;

namespace YANLib.Services;

public interface IDeveloperTypeService : IApplicationService
{
    public ValueTask<IEnumerable<DeveloperTypeResponse>?> GetAll();

    public ValueTask<DeveloperTypeResponse?> Get(long code);

    public ValueTask<DeveloperTypeResponse?> Insert(DeveloperTypeInsertRequest request);

    public ValueTask<DeveloperTypeResponse?> Modify(long code, DeveloperTypeModifyRequest request);

    public ValueTask<DeveloperTypeResponse?> Delete(long code, Guid updatedBy);

    public ValueTask<bool> SyncDbToRedis();
}
