using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.EventBus.Distributed;
using YANLib.Etos;
using YANLib.Requests;
using YANLib.Services;

namespace YANLib.Handlers;

public class CreateCertificateHandler : YANLibAppService, IDistributedEventHandler<List<CertificateCreateEto>>
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
    public async Task HandleEventAsync(List<CertificateCreateEto> eventData)
    {
        _logger.LogInformation("CreateCertificateHandler-Subcribe: {EventData}", eventData.CamelSerialize());
        _logger.LogInformation("CreateCertificateHandler-InsertsCertificateService: {Responses}", await _certificateService.Inserts(ObjectMapper.Map<List<CertificateCreateEto>, List<CertificateFullRequest>>(eventData)));
    }
    #endregion
}
