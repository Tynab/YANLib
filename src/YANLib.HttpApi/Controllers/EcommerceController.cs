#if RELEASE
using Microsoft.AspNetCore.Authorization;
#endif
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using YANLib.Requests;
using YANLib.Services;

namespace YANLib.Controllers;

#if RELEASE
[Authorize(Roles = "GlobalRole, OtherRole")]
#endif
[ApiController]
[Route("api/remote/[controller]")]
public sealed class EcommerceController(ILogger<EcommerceController> logger, IEcommerceService service) : YANLibController
{
    private readonly ILogger<EcommerceController> _logger = logger;
    private readonly IEcommerceService _service = service;

    [HttpPost("access-token")]
    [SwaggerOperation(Summary = "Lấy access token của API login của trang Ecommerce")]
    public async Task<IActionResult> GetAccessToken([Required] EcommerceLoginRequest request)
    {
        _logger.LogInformation("GetAccessToken-EcommerceController: {Request}", request.Serialize());

        return Ok(await _service.GetAccessToken(request));
    }

    [HttpGet("refresh-token")]
    [SwaggerOperation(Summary = "Lấy refresh token của API refresh của trang Ecommerce")]
    public async Task<IActionResult> GetRefreshToken([Required] string accessToken)
    {
        _logger.LogInformation("GetRefreshToken-EcommerceController: {AccessToken}", accessToken);

        return Ok(await _service.GetRefreshToken(accessToken));
    }
}
