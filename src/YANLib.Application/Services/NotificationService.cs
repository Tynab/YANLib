using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Volo.Abp.EventBus.Distributed;
using YANLib.Core;
using YANLib.RabbitMq.Etos;
using YANLib.Requests;

namespace YANLib.Services;

public class NotificationService(ILogger<NotificationService> logger, IDistributedEventBus _distributedEventBus) : YANLibAppService, INotificationService
{
    private readonly ILogger<NotificationService> _logger = logger;
    private readonly IDistributedEventBus _distributedEventBus = _distributedEventBus;

    public async ValueTask Send(NotificationRequest request)
    {
        try
        {
            await _distributedEventBus.PublishAsync(ObjectMapper.Map<NotificationRequest, NotificationEto>(request));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Send-NotificationService-Exception: {Request}", request.Serialize());

            throw;
        }
    }
}
