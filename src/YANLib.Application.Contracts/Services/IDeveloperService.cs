using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using YANLib.Requests.Developer;
using YANLib.Responses;

namespace YANLib.Services;

public interface IDeveloperService : IApplicationService
{
    public ValueTask<DeveloperResponse> GetByIdCard(string idCard);

    public ValueTask<DeveloperResponse> Create(DeveloperCreateRequest request);

    public ValueTask<DeveloperResponse> Adjust(string idCard, DeveloperUpdateRequest dto);

    public ValueTask<List<DeveloperResponse>> GetByPhone(string phone);

    public ValueTask<List<DeveloperResponse>> SearchByPhone(string searchText);

    public ValueTask<bool> SyncDbToEs();
}
