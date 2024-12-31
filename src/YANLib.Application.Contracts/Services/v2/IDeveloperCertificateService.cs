using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;

namespace YANLib.Services.v2;

public interface IDeveloperCertificateService : IApplicationService
{
    public ValueTask<PagedResultDto<DeveloperCertificateResponse>?> GetByDeveloper(PagedAndSortedResultRequestDto input, Guid developerId);

    public ValueTask<DeveloperCertificateResponse?> GetByDeveloperAndCertificate(Guid developerId, string certificateCode);

    public ValueTask<DeveloperCertificateResponse?> Insert(DeveloperCertificateCreateRequest request);

    public ValueTask<DeveloperCertificateResponse?> Modify(DeveloperCertificateUpdateRequest request);

    public ValueTask<bool?> Delete(Guid developerId, string certificateCode, Guid updatedBy);

    public ValueTask<bool> SyncDbToRedis();

    public ValueTask<bool> SyncDbToRedisByDeveloper(Guid developerId);
}
