using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Threading;
using YANLib.BackgroundArgs;
using YANLib.RabbitMq.Etos;

namespace YANLib.BackgroundJobs;

public class NotificationJob(ILogger<NotificationJob> logger, IDistributedEventBus distributedEventBus, ICancellationTokenProvider cancellationTokenProvider) : AsyncBackgroundJob<NotificationArgs>, ITransientDependency
{
    private readonly ILogger<NotificationJob> _logger = logger;
    private readonly IDistributedEventBus _distributedEventBus = distributedEventBus;
    private readonly ICancellationTokenProvider _cancellationTokenProvider = cancellationTokenProvider;

    public override async Task ExecuteAsync(NotificationArgs args)
    {
        try
        {
            _cancellationTokenProvider.Token.ThrowIfCancellationRequested();

            var eto = new NotificationEto(args.Message, args.SentBy);

            _logger.LogInformation("ExecuteAsync-NotificationJob: {ETO}", eto.Serialize());
            await _distributedEventBus.PublishAsync(eto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ExecuteAsync-NotificationJob-Exception: {Args}", args.Serialize());

            throw;
        }
    }
}
