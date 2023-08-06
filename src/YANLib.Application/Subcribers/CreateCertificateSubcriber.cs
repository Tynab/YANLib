using DotNetCore.CAP;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using YANLib.Kafka.Etos;
using YANLib.Requests;
using YANLib.Services;
using static YANLib.Kafka.KafkaTopic;

namespace YANLib.Subcribers;

public class CreateCertificateSubcriber : YANLibAppService, ICapSubscribe
{
    #region Fields
    private readonly ILogger<CreateCertificateSubcriber> _logger;
    private readonly ICertificateService _certificateService;
    #endregion

    #region Constructors
    public CreateCertificateSubcriber(ILogger<CreateCertificateSubcriber> logger, ICertificateService certificateService)
    {
        _logger = logger;
        _certificateService = certificateService;
    }
    #endregion

    #region Methods
    [CapSubscribe(CERT_CRT)]
    public async Task Subcibe(List<CertificateCreateEto> eventData)
    {
        _logger.LogInformation("CreateCertificateSubcriber-Subcribe: {EventData}", eventData.CamelSerialize());
        _logger.LogInformation("CreateCertificateSubcriber-InsertsCertificateService: {Responses}", await _certificateService.Inserts(ObjectMapper.Map<List<CertificateCreateEto>, List<CertificateFullRequest>>(eventData)));
    }
    #endregion
}
