using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.EventBus.Distributed;
using YANLib.Args;
using YANLib.Core;
using YANLib.RabbitMq.Etos;
using YANLib.Requests;
using static System.Guid;
using static YANLib.Core.YANNum;
using static YANLib.Core.YANText;

namespace YANLib.Services;

public class NotificationService(ILogger<NotificationService> logger, IDistributedEventBus distributedEventBus, IBackgroundJobManager backgroundJobManager) : YANLibAppService, INotificationService
{
    private readonly ILogger<NotificationService> _logger = logger;
    private readonly IDistributedEventBus _distributedEventBus = distributedEventBus;
    private readonly IBackgroundJobManager _backgroundJobManager = backgroundJobManager;

    public async ValueTask Send(NotificationRequest request)
    {
        try
        {
            var eto = ObjectMapper.Map<NotificationRequest, NotificationEto>(request);

            _logger.LogInformation("Send-NotificationService: {ETO}", eto.Serialize());
            await _distributedEventBus.PublishAsync(eto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Send-NotificationService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async ValueTask Schedule(NotificationRequest request)
    {
        try
        {
            var args = new NotificationArgs(request.Message, request.SentBy);

            _logger.LogInformation("Schedule-NotificationService: {Args}", args.Serialize());
            _ = await _backgroundJobManager.EnqueueAsync(args, delay: TimeSpan.FromSeconds(60));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Schedule-NotificationService-Exception: {Request}", request.Serialize());

            throw;
        }
    }
}
