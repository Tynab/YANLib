using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using YANLib.SignalRHub;

namespace YANLib.Services;

public class NotificationService(ILogger<NotificationService> logger, INotificationHub notificationHub) : YANLibAppService, INotificationService
{
    private readonly ILogger<NotificationService> _logger = logger;
    private readonly INotificationHub _notificationHub = notificationHub;

    public async ValueTask SendNotification(string message)
    {
        try
        {
            await _notificationHub.SendNotification(message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SendNotificationNotificationService-Exception: {Message}", message);

            throw;
        }
    }
}
