using DotNetCore.CAP;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using YANLib.Core;
using YANLib.Kafka.Etos;
using YANLib.Requests;
using YANLib.Services;
using static YANLib.Kafka.KafkaTopic;

namespace YANLib.Subscribers;

public class CreateCertificateSubscriber : YANLibAppService, ICapSubscribe
{
    private readonly ILogger<CreateCertificateSubscriber> _logger;
    private readonly ICertificateService _certificateService;

    public CreateCertificateSubscriber(ILogger<CreateCertificateSubscriber> logger, ICertificateService certificateService)
    {
        _logger = logger;
        _certificateService = certificateService;
    }

    [CapSubscribe(CERT_CRT)]
    public async Task Subscibe(CertificateCreateEto eventData)
    {
        _logger.LogInformation("CreateCertificateSubscriber-Subscribe: {EventData}", eventData.Serialize());
        _logger.LogInformation("CreateCertificateSubscriber-CreateCertificateService: {Responses}", await _certificateService.Create(ObjectMapper.Map<CertificateCreateEto, CertificateRequest>(eventData)));
    }
}
