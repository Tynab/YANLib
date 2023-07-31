using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Volo.Abp.EventBus.Distributed;
using YANLib.Etos;
using YANLib.Requests;
using YANLib.Services;

namespace YANLib.Handlers;

public class CreateCertificateHandler : YANLibAppService, IDistributedEventHandler<CertificateCreateEto>
{
    #region Fields
    private readonly ILogger<CreateCertificateHandler> _logger;
    private readonly ICertificateService _certificateService;
    #endregion

    #region Constructors
    public CreateCertificateHandler(ILogger<CreateCertificateHandler> logger, ICertificateService certificateService)
    {
        _logger = logger;
        _certificateService = certificateService;
    }
    #endregion

    #region Implements
    public async Task HandleEventAsync(CertificateCreateEto eventData)
    {
        _logger.LogInformation("CreateCertificateHandler-Subcribe: {EventData}", eventData.CamelSerialize());
        _logger.LogInformation("CreateCertificateHandler-InsertCertificateService: {Response}", await _certificateService.Insert(ObjectMapper.Map<CertificateCreateEto, CertificateFullRequest>(eventData)));
    }
    #endregion
}
