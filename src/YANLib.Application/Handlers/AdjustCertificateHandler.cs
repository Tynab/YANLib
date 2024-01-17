using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Volo.Abp.EventBus.Distributed;
using YANLib.Core;
using YANLib.RabbitMq.Etos;
using YANLib.Requests;
using YANLib.Services;

namespace YANLib.Handlers;

public class AdjustCertificateHandler(
    ILogger<AdjustCertificateHandler> logger,
    ICertificateService certificateService
) : YANLibAppService, IDistributedEventHandler<CertificateAdjustEto>
{
    private readonly ILogger<AdjustCertificateHandler> _logger = logger;
    private readonly ICertificateService _certificateService = certificateService;

    public async Task HandleEventAsync(CertificateAdjustEto eventData)
    {
        _logger.LogInformation("AdjustCertificateHandler-Subscribe: {EventData}", eventData.Serialize());
        _logger.LogInformation("AdjustCertificateHandler-UpdateCertificateService: {Responses}", await _certificateService.Update(ObjectMapper.Map<CertificateAdjustEto, CertificateRequest>(eventData)));
    }
}
