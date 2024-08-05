using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.SignalR;
using Volo.Abp.DependencyInjection;

namespace YANLib.SignalRHub;

//[HubRoute("/notification-hub")]
public class NotificationHub(ILogger<NotificationHub> logger, IHubContext<NotificationHub> hubContext) : AbpHub, INotificationHub
{
    private readonly ILogger<NotificationHub> _logger = logger;
    private readonly IHubContext<NotificationHub> _hubContext = hubContext;

    public async ValueTask SendNotification(string message)
    {
        try
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SendNotificationNotificationHub-Exception: {Message}", message);

            throw;
        }
    }
}
