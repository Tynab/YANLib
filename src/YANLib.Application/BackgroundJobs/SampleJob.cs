using DotNetCore.CAP;
using EOE.CCSBE.Etos;
using Microsoft.Extensions.Logging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Threading;
using YANLib;
using YANLib.BackgroundArgs;
using static YANLib.BaseConsts.RabbitMQTopic;

namespace YANLib.BackgroundJobs;

public class SampleJob(ILogger<SampleJob> logger, ICapPublisher capPublisher, ICancellationTokenProvider cancellationTokenProvider) : AsyncBackgroundJob<SampleArgs>, ITransientDependency
{
    public override async Task ExecuteAsync(SampleArgs args)
    {
        try
        {
            cancellationTokenProvider.Token.ThrowIfCancellationRequested();

            var eto = new SampleEto(args.Message);

            logger.LogInformation("ExecuteAsync-SampleJob: {ETO}", eto.Serialize());

            await capPublisher.PublishAsync(EOE_YANLIB_SAMPLE, eto, cancellationToken: cancellationTokenProvider.Token);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "ExecuteAsync-SampleJob-Exception: {Args}", args.Serialize());

            throw;
        }
    }
}
