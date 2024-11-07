using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using YANLib.Requests;

namespace YANLib.Services.v1;

public interface IEcommerceService : IApplicationService
{
    public ValueTask<object?> GetAccessToken(EcommerceLoginRequest request);

    public ValueTask<object?> GetRefreshToken(string accessToken);
}
