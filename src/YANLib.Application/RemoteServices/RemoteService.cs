using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NUglify.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Http;
using Volo.Abp.Http.Client;
using YANLib.Object;
using YANLib.Unmanaged;
using static Newtonsoft.Json.Linq.JObject;
using static RestSharp.ParameterType;
using static System.Net.HttpStatusCode;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.RemoteServices;

public class RemoteService(ILogger<RemoteService> logger, IOptionsSnapshot<AbpRemoteServiceOptions> remoteServiceOptions) : YANLibAppService, IRemoteService
{
    private readonly ILogger<RemoteService> _logger = logger;
    private readonly AbpRemoteServiceOptions _remoteServiceOptions = remoteServiceOptions.Value;

    public async ValueTask<T?> InvokeApi<T>(string remoteRoot, string path, Method method, Dictionary<string, string>? headers = null, string? jsonInput = null, Dictionary<string, object>? queryParams = null)
    {
        try
        {
            var req = new RestRequest(path, method);

            if (headers.IsNullOEmpty())
            {
                _ = req.AddHeader("Accept", "*/*");
                _ = req.AddHeader("Content-Type", "application/json");

                if (jsonInput.IsNotNullNWhiteSpace())
                {
                    _ = req.AddParameter("application/json", jsonInput, RequestBody);
                }
            }
            else
            {
                headers.ForEach(x => req.AddHeader(x.Key, x.Value));

                if (jsonInput.IsNotNullNWhiteSpace())
                {
                    _ = req.AddParameter(headers["Content-Type"], jsonInput, RequestBody);
                }
            }

            if (queryParams.IsNotNullNEmpty())
            {
                queryParams.ForEach(x => req.AddParameter(x.Key, x.Value, QueryString));
            }

            var remSvcConfig = _remoteServiceOptions.RemoteServices.GetConfigurationOrDefaultOrNull(remoteRoot)?.BaseUrl;

            if (remSvcConfig.IsNullOWhiteSpace())
            {
                throw new AbpRemoteCallException(new RemoteServiceErrorInfo
                {
                    Code = NOT_FOUND,
                    Message = "RemoteServiceNotFound"
                });
            }

            var res = await new RestClient(remSvcConfig).ExecuteAsync(req);

            if (res.StatusCode is OK)
            {
                return res.Content.Deserialize<T>();
            }
            else
            {
                _logger.LogError("Invoke API: {PathRoot} - {Code} - {Error} - {Content}", $"{remoteRoot}{path}", res.StatusCode, res.ErrorMessage, res.Content);

                if (res.Content.IsNullOWhiteSpace())
                {
                    throw new AbpRemoteCallException(new RemoteServiceErrorInfo
                    {
                        Code = NOT_FOUND,
                        Message = res.ErrorException?.Message
                    })
                    {
                        HttpStatusCode = res.StatusCode.To<int>()
                    };
                }
                else
                {
                    var jtoken = Parse(res.Content)["error"]?.ToString();

                    throw new AbpRemoteCallException(jtoken?.Deserialize<RemoteServiceErrorInfo>() ?? new RemoteServiceErrorInfo
                    {
                        Message = jtoken
                    })
                    {
                        HttpStatusCode = res.StatusCode.To<int>()
                    };
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "InvokeApi-RemoteService-Exception: {PathRoot} - {Method} - {JsonInput} - {QueryParams}", $"{remoteRoot}{path}", method.ToString(), jsonInput, queryParams.Serialize());

            throw;
        }
    }
}
