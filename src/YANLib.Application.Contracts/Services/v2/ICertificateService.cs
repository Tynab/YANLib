using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.Requests.Insert;
using YANLib.Requests.Modify;
using YANLib.Responses;

namespace YANLib.Services.v2;

public interface ICertificateService
{
    public ValueTask<PagedResultDto<CertificateResponse>> GetAll(PagedAndSortedResultRequestDto dto);

    public ValueTask<CertificateResponse?> GetByCode(string code);

    public ValueTask<IReadOnlyCollection<CertificateResponse>> GetByName(string name);

    public ValueTask<IReadOnlyCollection<CertificateResponse>> SearchByName(string searchText);

    public ValueTask<CertificateResponse?> Insert(CertificateInsertRequest request);

    public ValueTask<CertificateResponse?> Modify(string code, CertificateModifyRequest dto);

    public ValueTask<bool> Delete(string code, Guid updatedBy);

    public ValueTask<bool> SyncDbToEs();
}
