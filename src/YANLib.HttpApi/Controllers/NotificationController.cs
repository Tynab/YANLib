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
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace YANLib.Controllers;

#if RELEASE
[Authorize(Roles = "GlobalRole, OtherRole")]
#endif
[ApiController]
[Route("api/[controller]")]
public sealed class NotificationController(ILogger<NotificationController> logger, INotificationService service) : YANLibController
{
    private readonly ILogger<NotificationController> _logger = logger;
    private readonly INotificationService _service = service;

    [HttpPost("send")]
    [SwaggerOperation(
        Summary = "Gởi thông báo",
        Description = "Gửi thông báo ngay lập tức đến người dùng hoặc nhóm người dùng được chỉ định"
    )]
    [ProducesResponseType(Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<IActionResult> Send([FromBody][Required] NotificationRequest request)
    {
        _logger.LogInformation("Send-NotificationController: {Request}", request.Serialize());

        await _service.Send(request);

        return Ok();
    }

    [HttpPost("schedule")]
    [SwaggerOperation(
        Summary = "Lập lịch gởi thông báo",
        Description = "Lập lịch gửi thông báo vào thời điểm được chỉ định trong tương lai"
    )]
    [ProducesResponseType(Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<IActionResult> Schedule([FromBody][Required] NotificationRequest request)
    {
        _logger.LogInformation("Schedule-NotificationController: {Request}", request.Serialize());

        await _service.Schedule(request);

        return Ok();
    }
}
