using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using YANLib.Requests;

namespace YANLib.Services;

public interface ICertificateService : IApplicationService
{
    public ValueTask<bool> Create(CertificateRequest request);

    public ValueTask<bool> Update(CertificateRequest request);
}
