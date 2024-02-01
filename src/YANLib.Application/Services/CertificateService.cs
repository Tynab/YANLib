using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using YANLib.Core;
using YANLib.Entities;
using YANLib.Repositories;
using YANLib.Requests;

namespace YANLib.Services;

public class CertificateService : YANLibAppService, ICertificateService
{
    private readonly ILogger<CertificateService> _logger;
    private readonly ICertificateRepository _repository;

    public CertificateService(ILogger<CertificateService> logger, ICertificateRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public async ValueTask<bool> Create(CertificateRequest request)
    {
        try
        {
            return await _repository.Create(ObjectMapper.Map<CertificateRequest, Certificate>(request)) is not null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "CreateCertificateService-Exception: {Request}", request.Serialize());
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
            _logger.LogError(ex, "UpdateCertificateService-Exception: {Request}", request.Serialize());
            throw;
        }
    }
}
