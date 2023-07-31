using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.EventBus.Distributed;
using YANLib.Etos;
using YANLib.Requests;
using YANLib.Services;

namespace YANLib.Handlers;

public class AdjustCertificateHandler : YANLibAppService, IDistributedEventHandler<List<CertificateAdjustEto>>
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
    public async Task HandleEventAsync(List<CertificateAdjustEto> eventData)
    {
        _logger.LogInformation("AdjustCertificateHandler-Subcribe: {EventData}", eventData.CamelSerialize());
        _logger.LogInformation("AdjustCertificateHandler-UpdatesCertificateService: {Responses}", await _certificateService.Updates(ObjectMapper.Map<List<CertificateAdjustEto>, List<CertificateFullRequest>>(eventData)));
    }
    #endregion
}
