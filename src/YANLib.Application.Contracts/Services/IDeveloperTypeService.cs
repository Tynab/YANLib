using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using YANLib.Requests.DeveloperType;
using YANLib.Responses;

namespace YANLib.Services;

public interface IDeveloperTypeService : IApplicationService
{
    public ValueTask<IEnumerable<DeveloperTypeResponse>> GetAll();

    public ValueTask<DeveloperTypeResponse> Get(long code);

    public ValueTask<DeveloperTypeResponse> Create(DeveloperTypeCreateRequest request);

    public ValueTask<DeveloperTypeResponse> Update(DeveloperTypeUpdateRequest request);

    public ValueTask<DeveloperTypeResponse> Delete(long code, Guid updatedBy);

    public ValueTask<bool> SyncDbToRedis();
}
