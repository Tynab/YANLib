using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Volo.Abp.EventBus.Distributed;
using YANLib.Etos;
using YANLib.Requests;
using YANLib.Services;

namespace YANLib.Handlers;

public class AdjustCertificateHandler : YANLibAppService, IDistributedEventHandler<CertificateAdjustEto>
{
    #region Fields
    private readonly ILogger<AdjustCertificateHandler> _logger;
    private readonly ICertificateService _certificateService;
    #endregion

    #region Constructors
    public AdjustCertificateHandler(ILogger<AdjustCertificateHandler> logger, ICertificateService certificateService)
    {
        _logger = logger;
        _certificateService = certificateService;
    }
    #endregion

    #region Implements
    public async Task HandleEventAsync(CertificateAdjustEto eventData)
    {
        _logger.LogInformation("AdjustCertificateHandler-Subcribe: {ETO}", eventData.CamelSerialize());
        _logger.LogInformation("AdjustCertificateHandler-InsertCertificateService: {Response}", await _certificateService.Insert(ObjectMapper.Map<CertificateAdjustEto, CertificateFullRequest>(eventData)));
    }
    #endregion
}
