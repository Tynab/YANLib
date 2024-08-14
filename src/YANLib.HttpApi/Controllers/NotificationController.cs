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
[ApiExplorerSettings(GroupName = "sample")]
[Route("api/[controller]")]
public sealed class NotificationController(ILogger<NotificationController> logger, INotificationService service) : YANLibController
{
    private readonly ILogger<NotificationController> _logger = logger;
    private readonly INotificationService _service = service;

    [HttpPost]
    [SwaggerOperation(summary: "Gởi thông báo")]
    public async Task<IActionResult> Send([Required] NotificationRequest request)
    {
        _logger.LogInformation("Send-NotificationController: {Request}", request.Serialize());
        //await _service.Send(request);
        await _service.Schedule(request);

        return Ok();
    }
}
