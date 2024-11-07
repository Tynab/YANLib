using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using YANLib.Requests.Insert;
using YANLib.Requests.Modify;
using YANLib.Responses;

namespace YANLib.Services.v2;

public interface IDeveloperService : IApplicationService
{
    public ValueTask<DeveloperResponse?> GetByIdCard(string idCard);

    public ValueTask<DeveloperResponse?> Insert(DeveloperInsertRequest request);

    public ValueTask<DeveloperResponse?> Adjust(string idCard, DeveloperModifyRequest dto);

    public ValueTask<DeveloperResponse?> Delete(string idCard, Guid updatedBy);

    public ValueTask<List<DeveloperResponse>> GetByName(string name);

    public ValueTask<List<DeveloperResponse>> GetByPhone(string phone);

    public ValueTask<List<DeveloperResponse>> SearchByName(string searchText);

    public ValueTask<List<DeveloperResponse>> SearchByPhone(string searchText);

    public ValueTask<bool> SyncDbToEs();
}
