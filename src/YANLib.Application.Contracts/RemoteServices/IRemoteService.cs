using RestSharp;
using Volo.Abp.Application.Services;

namespace YANLib.RemoteServices;

public interface IRemoteService : IApplicationService
{
    public Task<T?> InvokeApi<T>(string remoteRoot, string path, Method method, Dictionary<string, string>? headers = null, string? jsonInput = null, Dictionary<string, object>? queryParams = null);
}
