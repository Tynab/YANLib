using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using YANLib.Requests;
using YANLib.Responses;

namespace YANLib.Services;

public interface ICertificateService : IApplicationService
{
    public ValueTask<CertificateResponse> Insert(CertificateFullRequest request);
}
