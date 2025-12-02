using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NUglify.Helpers;
using RestSharp;
using Volo.Abp.Http;
using Volo.Abp.Http.Client;
using YANLib;
using static YANLib.BaseErrorCodes;
using static Newtonsoft.Json.Linq.JObject;
using static RestSharp.ParameterType;
using static System.Net.HttpStatusCode;

namespace YANLib.RemoteServices;

public class RemoteService(ILogger<RemoteService> logger, IOptionsSnapshot<AbpRemoteServiceOptions> remoteServiceOptions) : BaseAppService, IRemoteService
{
    private readonly AbpRemoteServiceOptions _remoteServiceOptions = remoteServiceOptions.Value;

    public async Task<T?> InvokeApi<T>(string remoteRoot, string path, Method method, Dictionary<string, string>? headers = null, string? jsonInput = null, Dictionary<string, object>? queryParams = null)
    {
        try
        {
            var request = new RestRequest(path, method);

            if (headers.IsNullEmpty())
            {
                _ = request.AddHeader("Accept", "*/*");
                _ = request.AddHeader("Content-Type", "application/json");

                if (jsonInput.IsNotNullWhiteSpace())
                {
                    _ = request.AddParameter("application/json", jsonInput, RequestBody);
                }
            }
            else
            {
                headers.ForEach(x => request.AddHeader(x.Key, x.Value));

                if (jsonInput.IsNotNullWhiteSpace())
                {
                    _ = request.AddParameter(headers["Content-Type"], jsonInput, RequestBody);
                }
            }

            if (queryParams.IsNotNullEmpty())
            {
                queryParams.ForEach(x => request.AddParameter(x.Key, x.Value, QueryString));
            }

            var config = _remoteServiceOptions.RemoteServices.GetConfigurationOrDefaultOrNull(remoteRoot)?.BaseUrl;

            if (config.IsNullWhiteSpace())
            {
                throw new AbpRemoteCallException(new RemoteServiceErrorInfo
                {
                    Code = NOT_FOUND,
                    Message = "RemoteServiceNotFound"
                });
            }

            var response = await new RestClient(config).ExecuteAsync(request);

            if (response.StatusCode is OK)
            {
                return response.Content.Deserialize<T>();
            }
            else
            {
                logger.LogError("Invoke API: {PathRoot} - {Code} - {Error} - {Content}", $"{remoteRoot}{path}", response.StatusCode, response.ErrorMessage, response.Content);

                if (response.Content.IsNullWhiteSpace())
                {
                    throw new AbpRemoteCallException(new RemoteServiceErrorInfo
                    {
                        Code = NOT_FOUND,
                        Message = response.ErrorException?.Message
                    })
                    {
                        HttpStatusCode = response.StatusCode.Parse<int>()
                    };
                }
                else
                {
                    var token = Parse(response.Content)["error"]?.ToString();

                    throw new AbpRemoteCallException(token?.Deserialize<RemoteServiceErrorInfo>() ?? new RemoteServiceErrorInfo
                    {
                        Message = token
                    })
                    {
                        HttpStatusCode = response.StatusCode.Parse<int>()
                    };
                }
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "InvokeApi-RemoteService-Exception: {PathRoot} - {Method} - {JsonInput} - {QueryParams}", $"{remoteRoot}{path}", method.ToString(), jsonInput, queryParams.Serialize());

            throw;
        }
    }
}
