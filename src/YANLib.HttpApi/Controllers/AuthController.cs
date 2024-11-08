using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using YANLib.Core;
using YANLib.Requests;
using YANLib.Services;

namespace YANLib.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AuthController(ILogger<AuthController> logger, IAuthService service) : ControllerBase
{
    private readonly ILogger<AuthController> _logger = logger;
    private readonly IAuthService _service = service;

    [IgnoreAntiforgeryToken]
    [HttpPost("generate-token")]
    [SwaggerOperation(Summary = "Tạo token")]
    public async ValueTask<IActionResult> GenerateToken([Required] UserLoginRequest request)
    {
        _logger.LogInformation("GenerateToken-AuthController: {Request}", request.Serialize());

        return Ok(new
        {
            Token = await _service.GenerateToken(request.UserName, request.Password)
        });
    }
}
