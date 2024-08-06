using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using YANLib.SignalRHubs;

namespace YANLib.Services;

public class NotificationService(ILogger<NotificationService> logger, IHubContext<NotificationHub> hubContext) : YANLibAppService, INotificationService
{
    private readonly ILogger<NotificationService> _logger = logger;
    private readonly IHubContext<NotificationHub> _hubContext = hubContext;

    public async ValueTask SendNotification(string message)
    {
        try
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SendNotificationNotificationService-Exception: {Message}", message);

            throw;
        }
    }
}
