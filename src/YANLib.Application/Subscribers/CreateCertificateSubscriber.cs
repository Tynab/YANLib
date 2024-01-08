namespace YANLib.Subscribers;

public class CreateCertificateSubscriber(
    ILogger<CreateCertificateSubscriber> logger,
    ICertificateService certificateService
) : YANLibAppService, ICapSubscribe
{
    #region Fields
    private readonly ILogger<CreateCertificateSubscriber> _logger = logger;
    private readonly ICertificateService _certificateService = certificateService;
    #endregion

    #region Methods
    [CapSubscribe(CERT_CRT)]
    public async Task Subscibe(CertificateCreateEto eventData)
    {
        _logger.LogInformation("CreateCertificateSubscriber-Subscribe: {EventData}", eventData.Serialize());
        _logger.LogInformation("CreateCertificateSubscriber-CreateCertificateService: {Responses}", await _certificateService.Create(ObjectMapper.Map<CertificateCreateEto, CertificateRequest>(eventData)));
    }
    #endregion
}
