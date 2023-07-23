using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public async ValueTask<CertificateResponse> Get(Guid id)
    {
        try
        {
            return ObjectMapper.Map<Certificate, CertificateResponse>(await _repository.Get(id));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetCertificateService-Exception: {Id}", id);
            throw;
        }
    }

    public async ValueTask<CertificateResponse> Insert(CertificateRequest request)
    {
        try
        {
            return ObjectMapper.Map<Certificate, CertificateResponse>(await _repository.Insert(ObjectMapper.Map<CertificateRequest, Certificate>(request)));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "InsertCertificateService-Exception: {Request}", request.CamelSerialize());
            throw;
        }
    }

    public async ValueTask<CertificateResponse> Update(CertificateFullRequest request)
    {
        try
        {
            return ObjectMapper.Map<Certificate, CertificateResponse>(await _repository.Update(ObjectMapper.Map<CertificateFullRequest, Certificate>(request)));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "UpdateCertificateService-Exception: {Request}", request.CamelSerialize());
            throw;
        }
    }

    public async ValueTask<List<CertificateResponse>> GetByDeveloperId(Guid developerId)
    {
        try
        {
            return ObjectMapper.Map<IEnumerable<Certificate>, IEnumerable<CertificateResponse>>(await _repository.GetByDeveloperId(developerId)).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByDeveloperIdCertificateService-Exception: {DeveloperId}", developerId);
            throw;
        }
    }
    #endregion
}
