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
    public async ValueTask<List<CertificateResponse>> Inserts(List<CertificateFullRequest> requests)
    {
        try
        {
            return ObjectMapper.Map<IEnumerable<Certificate>, IEnumerable<CertificateResponse>>(await _repository.Inserts(ObjectMapper.Map<List<CertificateFullRequest>, List<Certificate>>(requests))).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "InsertsCertificateService-Exception: {Requests}", requests.CamelSerialize());
            throw;
        }
    }
    #endregion
}
