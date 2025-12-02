using DotNetCore.CAP;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using YANLib;
using YANLib.Etos;
using YANLib.SignalRHubs;
using static YANLib.BaseConsts.RabbitMQTopic;

namespace YANLib.Handlers;

public class SampleHandler(ILogger<SampleHandler> logger, IHubContext<SampleHub> hubContext) : BaseAppService, ICapSubscribe
{
    [CapSubscribe(EOE_YANLIB_SAMPLE)]
    public async Task Subscribe(SampleEto eto)
    {
        logger.LogInformation("Subscribe-SampleHandler: {ETO}", eto.Serialize());

        await hubContext.Clients.All.SendAsync("ReceiveSampleMessage", eto.Message);
    }
}
