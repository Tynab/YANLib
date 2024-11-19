using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;

namespace YANLib.Services.v2;

public interface ICertificateService
{
    public ValueTask<PagedResultDto<CertificateResponse>> GetAll(PagedAndSortedResultRequestDto dto);

    public ValueTask<CertificateResponse?> GetByCode(string code);

    public ValueTask<IReadOnlyCollection<CertificateResponse>> GetByName(string name);

    public ValueTask<IReadOnlyCollection<CertificateResponse>> SearchByName(string searchText);

    public ValueTask<CertificateResponse?> Insert(CertificateCreateRequest request);

    public ValueTask<CertificateResponse?> Modify(string code, CertificateUpdateRequest dto);

    public ValueTask<bool> Delete(string code, Guid updatedBy);

    public ValueTask<bool> SyncDbToEs();
}
