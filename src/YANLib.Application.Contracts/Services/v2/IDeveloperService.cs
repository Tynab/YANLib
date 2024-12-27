using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;

namespace YANLib.Services.v2;

public interface IDeveloperService : IApplicationService
{
    public ValueTask<PagedResultDto<DeveloperResponse>> GetAll(PagedAndSortedResultRequestDto input);

    public ValueTask<DeveloperResponse?> Insert(DeveloperCreateRequest request);

    public ValueTask<DeveloperResponse?> Adjust(string idCard, DeveloperUpdateRequest dto);

    public ValueTask<DeveloperResponse?> Delete(string idCard, Guid updatedBy);

    public ValueTask<bool> SyncDbToEs();

    public ValueTask<DeveloperResponse?> GetByIdCard(string idCard);
}
