using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Volo.Abp.EventBus.Distributed;
using YANLib.Core;
using YANLib.RabbitMq.Etos;
using YANLib.SignalRHubs;

namespace YANLib.Handlers;

public class NotificationHandler(ILogger<NotificationHandler> logger, IHubContext<NotificationHub> hubContext) : YANLibAppService, IDistributedEventHandler<NotificationEto>
{
    private readonly ILogger<NotificationHandler> _logger = logger;
    private readonly IHubContext<NotificationHub> _hubContext = hubContext;

    public async Task HandleEventAsync(NotificationEto eventData)
    {
        _logger.LogInformation("NotificationHandler-Subscribe: {EventData}", eventData.Serialize());
        await _hubContext.Clients.All.SendAsync("ReceiveMessage", eventData.Message);
    }
}
