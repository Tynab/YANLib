//using DotNetCore.CAP;
//using Microsoft.Extensions.Logging;
//using System.Threading.Tasks;
//using YANLib.Core;
//using YANLib.CrudService;
//using YANLib.Kafka.Etos;
//using YANLib.Requests.Insert;
//using static YANLib.Kafka.KafkaTopic;

//namespace YANLib.Subscribers;

//public class CreateCertificateSubscriber(
//    ILogger<CreateCertificateSubscriber> logger,
//    ICertificateCrudService certificateService
//) : YANLibAppService, ICapSubscribe
//{
//    private readonly ILogger<CreateCertificateSubscriber> _logger = logger;
//    private readonly ICertificateCrudService _certificateService = certificateService;

//    [CapSubscribe(CERT_CRT)]
//    public async Task Subscibe(CertificateCreateEto eventData)
//    {
//        _logger.LogInformation("CreateCertificateSubscriber-Subscribe: {EventData}", eventData.Serialize());
//        _logger.LogInformation("CreateCertificateSubscriber-CreateCertificateService: {Responses}", await _certificateService.Create(ObjectMapper.Map<CertificateCreateEto, CertificateInsertRequest>(eventData)));
//    }
//}
