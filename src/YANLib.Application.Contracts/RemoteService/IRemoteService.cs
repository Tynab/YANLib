using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace YANLib.RemoteService;

public interface IRemoteService : IApplicationService
{
    public ValueTask<T> InvokeApi<T>(string remoteRoot, string path, Method method, Dictionary<string, string> additionalHeaders = null, string jsonInput = null, Dictionary<string, object> queryParams = null);
}
