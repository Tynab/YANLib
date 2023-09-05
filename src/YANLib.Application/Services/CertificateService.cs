using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using YANLib.Entities;
using YANLib.Repositories;
using YANLib.Requests;

namespace YANLib.Services;

public class CertificateService : YANLibAppService, ICertificateService
{
    #region Fields
    private readonly ILogger<CertificateService> _logger;
    private readonly ICertificateRepository _repository;
    #endregion

    #region Constructors
    public CertificateService(
        ILogger<CertificateService> logger,
        ICertificateRepository repository
    )
    {
        _logger = logger;
        _repository = repository;
    }
    #endregion

    #region Implements
    public async ValueTask<bool> Insert(CertificateRequest request)
    {
        try
        {
            return await _repository.Insert(ObjectMapper.Map<CertificateRequest, Certificate>(request)) is not null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "InsertCertificateService-Exception: {Request}", request.CamelSerialize());
            throw;
        }
    }

    public async ValueTask<bool> Update(CertificateRequest request)
    {
        try
        {
            return await _repository.Update(ObjectMapper.Map<CertificateRequest, Certificate>(request)) is not null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "UpdateCertificateService-Exception: {Request}", request.CamelSerialize());
            throw;
        }
    }
    #endregion
}
