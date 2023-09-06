﻿using DotNetCore.CAP;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using YANLib.Kafka.Etos;
using YANLib.Requests;
using YANLib.Services;
using static YANLib.Kafka.KafkaTopic;

namespace YANLib.Subscribers;

public class CreateCertificateSubscriber : YANLibAppService, ICapSubscribe
{
    #region Fields
    private readonly ILogger<CreateCertificateSubscriber> _logger;
    private readonly ICertificateService _certificateService;
    #endregion

    #region Constructors
    public CreateCertificateSubscriber(
        ILogger<CreateCertificateSubscriber> logger,
        ICertificateService certificateService
    )
    {
        _logger = logger;
        _certificateService = certificateService;
    }
    #endregion

    #region Methods
    [CapSubscribe(CERT_CRT)]
    public async Task Subscibe(CertificateCreateEto eventData)
    {
        _logger.LogInformation("CreateCertificateSubscriber-Subscribe: {EventData}", eventData.CamelSerialize());
        _logger.LogInformation("CreateCertificateSubscriber-InsertCertificateService: {Responses}", await _certificateService.Insert(ObjectMapper.Map<CertificateCreateEto, CertificateRequest>(eventData)));
    }
    #endregion
}
