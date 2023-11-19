using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using YANLib.Requests;
using YANLib.Responses;

namespace YANLib.Services;

public interface IDeveloperTypeService : IApplicationService
{
    public ValueTask<List<DeveloperTypeResponse>> GetAll();

    public ValueTask<DeveloperTypeResponse> Get(int code);

    public ValueTask<DeveloperTypeResponse> Create(DeveloperTypeRequest request);

    public ValueTask<DeveloperTypeResponse> Update(DeveloperTypeRequest request);

    public ValueTask<bool> SyncDbToRedis();
}
