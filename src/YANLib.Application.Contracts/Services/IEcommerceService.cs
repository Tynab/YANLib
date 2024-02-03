using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using YANLib.Requests;

namespace YANLib.Services;

public interface IEcommerceService : IApplicationService
{
    public ValueTask<string> GetAccessToken(EcommerceLoginRequest request);

    public ValueTask<string> GetRefreshToken(string accessToken);
}
