using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using YANLib.Models;
using YANLib.Repositories;
using YANLib.Requests;
using YANLib.Responses;

namespace YANLib.Services;

public class CertificateService : YANLibAppService, ICertificateService
{
    #region Fields
    private readonly ILogger<CertificateService> _logger;
    private readonly ICertificateRepository _repository;
    #endregion

    #region Constructors
    public CertificateService(ILogger<CertificateService> logger, ICertificateRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }
    #endregion

    #region Implements
    public async ValueTask<CertificateResponse> Insert(CertificateFullRequest request)
    {
        try
        {
            return ObjectMapper.Map<Certificate, CertificateResponse>(await _repository.Insert(ObjectMapper.Map<CertificateFullRequest, Certificate>(request)));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "InsertCertificateService-Exception: {Request}", request.CamelSerialize());
            throw;
        }
    }
    #endregion
}
