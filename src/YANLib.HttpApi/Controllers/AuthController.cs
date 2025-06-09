using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using YANLib.Requests;
using YANLib.Services;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace YANLib.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AuthController(ILogger<AuthController> logger, IAuthService service) : ControllerBase
{
    private readonly ILogger<AuthController> _logger = logger;
    private readonly IAuthService _service = service;

    [IgnoreAntiforgeryToken]
    [HttpPost("generate-token")]
    [SwaggerOperation(Summary = "Tạo token", Description = "Tạo JWT token cho người dùng sau khi xác thực thành công")]
    [ProducesResponseType(typeof(object), Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    [ProducesResponseType(Status401Unauthorized)]
    public async Task<IActionResult> GenerateToken([FromBody][Required] UserLoginRequest request)
    {
        _logger.LogInformation("GenerateToken-AuthController: {Request}", request.Serialize());

        return Ok(new
        {
            Token = await _service.GenerateToken(request.UserName, request.Password)
        });
    }
}