using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NUglify.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Http;
using Volo.Abp.Http.Client;
using YANLib.Core;
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

            if (headers.IsNotEmptyAndNull())
            {
                headers.ForEach(x => req.AddHeader(x.Key, x.Value));

                if (jsonInput.IsNotWhiteSpaceAndNull())
                {
                    _ = req.AddParameter(headers["Content-Type"], jsonInput, RequestBody);
                }
            }
            else
            {
                _ = req.AddHeader("Accept", "*/*");
                _ = req.AddHeader("Content-Type", "application/json");

                if (jsonInput.IsNotWhiteSpaceAndNull())
                {
                    _ = req.AddParameter("application/json", jsonInput, RequestBody);
                }
            }

            if (queryParams.IsNotEmptyAndNull())
            {
                queryParams.ForEach(x => req.AddParameter(x.Key, x.Value, QueryString));
            }

            var remSvcConfig = _remoteServiceOptions.RemoteServices.GetConfigurationOrDefaultOrNull(remoteRoot)?.BaseUrl;

            if (remSvcConfig.IsWhiteSpaceOrNull())
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

                if (res.Content.IsWhiteSpaceOrNull())
                {
                    throw new AbpRemoteCallException(new RemoteServiceErrorInfo
                    {
                        Code = NOT_FOUND,
                        Message = res.ErrorException?.Message
                    })
                    {
                        HttpStatusCode = res.StatusCode.ToInt()
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
                        HttpStatusCode = res.StatusCode.ToInt()
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
