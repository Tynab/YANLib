using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YANLib.Core;
using YANLib.RemoteService;
using YANLib.Requests;
using static RestSharp.Method;
using static YANLib.Constants.YANLibConsts.RemoteService;
using static YANLib.Constants.YANLibConsts.RemoteService.Path;

namespace YANLib.Services;

public class EcommerceService(ILogger<EcommerceService> logger, IRemoteService remoteService) : YANLibAppService, IEcommerceService
{
    private readonly ILogger<EcommerceService> _logger = logger;
    private readonly IRemoteService _remoteService = remoteService;

    public async ValueTask<object?> GetAccessToken(EcommerceLoginRequest request)
    {
        var json = request.Serialize();

        try
        {
            return await _remoteService.InvokeApi<object>(EcommerceApi, Login, Post, headers: new Dictionary<string, string>
            {
                { "Accept", "*/*" },
                { "Content-Type", "application/x-www-form-urlencoded" }
            }, queryParams: request.Serialize().Deserialize<Dictionary<string, object>>());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAccessTokenEcommerceService-Exception: {Request}", json);

            throw;
        }
    }

    public async ValueTask<object?> GetRefreshToken(string accessToken)
    {
        try
        {
            return await _remoteService.InvokeApi<object>(EcommerceApi, TokenRefresh, Get, new Dictionary<string, string>
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
