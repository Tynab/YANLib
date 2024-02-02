using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YANLib.Core;
using YANLib.RemoteService;
using YANLib.Requests;
using static RestSharp.Method;
using static YANLib.YANLibConsts.RemoteService;
using static YANLib.YANLibConsts.RemoteService.Path;

namespace YANLib.Services;

public class EcommerceService(
    ILogger<EcommerceService> logger,
    IRemoteService remoteService
) : YANLibAppService, IEcommerceService
{
    private readonly ILogger<EcommerceService> _logger = logger;
    private readonly IRemoteService _remoteService = remoteService;

    public async ValueTask<string> GetAccessToken(EcommerceLoginRequest request)
    {
        var json = request.Serialize();

        try
        {
            return await _remoteService.InvokeApi<string>(Ecommerce, ApiLogin, Post, jsonInput: json);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAccessTokenEcommerceService-Exception: {Request}", json);

            throw;
        }
    }

    public async ValueTask<string> GetRefreshToken(string accessToken)
    {
        try
        {
            return await _remoteService.InvokeApi<string>(Ecommerce, ApiRefresh, Get, new Dictionary<string, string>
            {
                { "Authorization", $"Bearer {accessToken}" }
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetRefreshTokenEcommerceService-Exception: {AccessToken}", accessToken);

            throw;
        }
    }
}
