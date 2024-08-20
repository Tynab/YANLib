using System;
using System.Threading.Tasks;
using YANLib.Requests.Insert;
using YANLib.Requests.Modify;
using YANLib.Responses;

namespace YANLib.Services;

public interface ICertificateService
{
    public ValueTask<CertificateResponse?> GetByCode(string code);

    public ValueTask<CertificateResponse?> Insert(CertificateInsertRequest request);

    public ValueTask<CertificateResponse?> Modify(string code, CertificateModifyRequest dto);

    public ValueTask<bool> Delete(string code, Guid updatedBy);

    public ValueTask<bool> SyncDbToEs();
}
