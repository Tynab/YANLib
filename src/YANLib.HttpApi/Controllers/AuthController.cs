using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using YANLib.Requests;
using YANLib.Services;

namespace YANLib.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = "sample")]
[Route("api/[controller]")]
public sealed class AuthController(IAuthService service) : ControllerBase
{
    private readonly IAuthService _service = service;

    [HttpPost("generate-token")]
    [IgnoreAntiforgeryToken]
    public async ValueTask<IActionResult> GenerateToken([Required] UserLoginRequest userLoginDto) => Ok(new
    {
        Token = await _service.GenerateToken(userLoginDto.UserName, userLoginDto.Password)
    });
}
