using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using YANLib.Requests;

namespace YANLib.Services;

public interface IEcommerceService : IApplicationService
{
    public Task<object?> GetAccessToken(EcommerceLoginRequest request);

    public Task<object?> GetRefreshToken(string accessToken);
}
