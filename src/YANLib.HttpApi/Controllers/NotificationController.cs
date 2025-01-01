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
[Route("api/[controller]")]
public sealed class NotificationController(ILogger<NotificationController> logger, INotificationService service) : YANLibController
{
    private readonly ILogger<NotificationController> _logger = logger;
    private readonly INotificationService _service = service;

    [HttpPost("send")]
    [SwaggerOperation(summary: "Gởi thông báo")]
    public async Task<IActionResult> Send([Required] NotificationRequest request)
    {
        _logger.LogInformation("Send-NotificationController: {Request}", request.Serialize());
        await _service.Send(request);

        return Ok();
    }

    [HttpPost("schedule")]
    [SwaggerOperation(summary: "Lập lịch gởi thông báo")]
    public async Task<IActionResult> Schedule([Required] NotificationRequest request)
    {
        _logger.LogInformation("Schedule-NotificationController: {Request}", request.Serialize());
        await _service.Schedule(request);

        return Ok();
    }
}
