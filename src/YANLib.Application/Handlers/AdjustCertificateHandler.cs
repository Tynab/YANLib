namespace YANLib.Handlers;

public class AdjustCertificateHandler(
    ILogger<AdjustCertificateHandler> logger,
    ICertificateService certificateService
) : YANLibAppService, IDistributedEventHandler<CertificateAdjustEto>
{
    #region Fields
    private readonly ILogger<AdjustCertificateHandler> _logger = logger;
    private readonly ICertificateService _certificateService = certificateService;
    #endregion

    #region Implements
    public async Task HandleEventAsync(CertificateAdjustEto eventData)
    {
        _logger.LogInformation("AdjustCertificateHandler-Subscribe: {EventData}", eventData.Serialize());
        _logger.LogInformation("AdjustCertificateHandler-UpdateCertificateService: {Responses}", await _certificateService.Update(ObjectMapper.Map<CertificateAdjustEto, CertificateRequest>(eventData)));
    }
    #endregion
}
