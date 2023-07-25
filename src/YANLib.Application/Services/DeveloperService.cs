using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using YANLib.EsIndexs;
using YANLib.EsServices;
using YANLib.Models;
using YANLib.Repositories;
using YANLib.Requests;
using YANLib.Responses;
using static System.Guid;

namespace YANLib.Services;

public class DeveloperService : YANLibAppService, IDeveloperService
{
    #region Fields
    private readonly ILogger<DeveloperService> _logger;
    private readonly IDeveloperRepository _repository;
    private readonly IDeveloperEsService _esService;
    private readonly ICertificateRepository _certificateRepository;
    #endregion

    #region Constructors
    public DeveloperService(ILogger<DeveloperService> logger, IDeveloperRepository repository, IDeveloperEsService esService, ICertificateRepository certificateRepository)
    {
        _logger = logger;
        _repository = repository;
        _esService = esService;
        _certificateRepository = certificateRepository;
    }
    #endregion

    #region Implements
    public async ValueTask<DeveloperResponse> Get(Guid id)
    {
        try
        {
            return ObjectMapper.Map<DeveloperIndex, DeveloperResponse>((await _esService.GetByDeveloperId(id)).OrderByDescending(x => x.Version).FirstOrDefault());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetDeveloperService-Exception: {Id}", id);
            throw;
        }
    }

    public async ValueTask<DeveloperResponse> GetByIdCard(string idCard)
    {
        try
        {
            return ObjectMapper.Map<DeveloperIndex, DeveloperResponse>(await _esService.Get(idCard));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByIdCardDeveloperService-Exception: {IdCard}", idCard);
            throw;
        }
    }

    public async ValueTask<List<DeveloperResponse>> GetByPhone(string phone)
    {
        try
        {
            return ObjectMapper.Map<IEnumerable<DeveloperIndex>, IEnumerable<DeveloperResponse>>(await _esService.GetByPhone(phone)).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByPhoneDeveloperService-Exception: {Phone}", phone);
            throw;
        }
    }

    public async ValueTask<DeveloperResponse> Insert(DeveloperRequest request)
    {
        try
        {
            var id = NewGuid();
            var ent = ObjectMapper.Map<DeveloperRequest, Developer>(request);
            var certEnts = ObjectMapper.Map<List<CertificateRipRequest>, List<Certificate>>(request.Certificates);

            ent.Id = id;
            certEnts?.ForEach(x => x.DeveloperId = id);

            var rslt = ObjectMapper.Map<Developer, DeveloperResponse>(await _repository.Insert(ent));

            rslt.Certificates = new List<CertificateResponse>(ObjectMapper.Map<IEnumerable<Certificate>, IEnumerable<CertificateResponse>>(await _certificateRepository.Inserts(certEnts)));

            return await _esService.Set(ObjectMapper.Map<DeveloperResponse, DeveloperIndex>(rslt)) ? rslt : throw new BusinessException();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "InsertDeveloperService-Exception: {Request}", request.CamelSerialize());
            throw;
        }
    }

    public ValueTask<DeveloperResponse> Adjust(string idCard, DeveloperFreeRequest request)
    {
        throw new NotImplementedException();
    }
    #endregion
}
