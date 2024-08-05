//using Microsoft.Extensions.Logging;
//using System.Threading.Tasks;
//using Volo.Abp.EventBus.Distributed;
//using YANLib.Core;
//using YANLib.CrudService;
//using YANLib.RabbitMq.Etos;
//using YANLib.Requests.Insert;

//namespace YANLib.Handlers;

//public class AdjustCertificateHandler(
//    ILogger<AdjustCertificateHandler> logger,
//    ICertificateCrudService certificateService
//) : YANLibAppService, IDistributedEventHandler<CertificateAdjustEto>
//{
//    private readonly ILogger<AdjustCertificateHandler> _logger = logger;
//    private readonly ICertificateCrudService _certificateService = certificateService;

//    public async Task HandleEventAsync(CertificateAdjustEto eventData)
//    {
//        _logger.LogInformation("AdjustCertificateHandler-Subscribe: {EventData}", eventData.Serialize());
//        _logger.LogInformation("AdjustCertificateHandler-UpdateCertificateService: {Responses}", await _certificateService.Update(ObjectMapper.Map<CertificateAdjustEto, CertificateInsertRequest>(eventData)));
//    }
//}
