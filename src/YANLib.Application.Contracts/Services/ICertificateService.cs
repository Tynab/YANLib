using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using YANLib.Requests;
using YANLib.Responses;

namespace YANLib.Services;

public interface ICertificateService : IApplicationService
{
    public ValueTask<List<CertificateResponse>> Inserts(List<CertificateFullRequest> requests);
    public ValueTask<List<CertificateResponse>> Updates(List<CertificateFullRequest> requests);
}
