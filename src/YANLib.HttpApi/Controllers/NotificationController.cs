using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp;
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
    public async Task<IActionResult> SendNotification([Required] string message)
    {
        _logger.LogInformation("SendNotificationNotificationController: {Message}", message);
        await _service.SendNotification(message);

        return Ok();
    }
}
