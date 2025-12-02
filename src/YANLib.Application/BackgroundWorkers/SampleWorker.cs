using DotNetCore.CAP;
using EOE.CCSBE.Etos;
using Microsoft.Extensions.Logging;
using Volo.Abp.BackgroundWorkers.Hangfire;
using Volo.Abp.Threading;
using YANLib;
using static YANLib.BaseConsts.RabbitMQTopic;
using static Hangfire.Cron;

namespace YANLib.BackgroundWorkers;

public class SampleWorker : HangfireBackgroundWorkerBase
{
    private readonly ILogger<SampleWorker> _logger;
    private readonly ICapPublisher _capPublisher;
    private readonly ICancellationTokenProvider _cancellationTokenProvider;

    public SampleWorker(ILogger<SampleWorker> logger, ICapPublisher capPublisher, ICancellationTokenProvider cancellationTokenProvider)
    {
        _logger = logger;
        _cancellationTokenProvider = cancellationTokenProvider;
        _capPublisher = capPublisher;

        RecurringJobId = nameof(SampleWorker);
        CronExpression = Yearly();
    }

    public override async Task DoWorkAsync(CancellationToken cancellationToken = default)
    {
        _cancellationTokenProvider.Token.ThrowIfCancellationRequested();

        try
        {
            var eto = new SampleEto("Happy New Year to CCS!");

            _logger.LogInformation("DoWorkAsync-SampleWorker: {Eto}", eto.Serialize());

            await _capPublisher.PublishAsync(EOE_YANLIB_SAMPLE, eto, cancellationToken: cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DoWorkAsync-SampleWorker-Exception");

            throw;
        }
    }
}
