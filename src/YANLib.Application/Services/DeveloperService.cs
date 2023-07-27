using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using YANLib.EsIndexs;
using YANLib.EsServices;
using YANLib.Localization;
using YANLib.Models;
using YANLib.Repositories;
using YANLib.Requests;
using YANLib.Responses;
using static System.Guid;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Services;

public class DeveloperService : YANLibAppService, IDeveloperService
{
    #region Fields
    private readonly ILogger<DeveloperService> _logger;
    private readonly IStringLocalizer<YANLibResource> _localizer;
    private readonly IDeveloperRepository _repository;
    private readonly IDeveloperEsService _esService;
    private readonly ICertificateRepository _certificateRepository;
    #endregion

    #region Constructors
    public DeveloperService(ILogger<DeveloperService> logger, IStringLocalizer<YANLibResource> localizer, IDeveloperRepository repository, IDeveloperEsService esService, ICertificateRepository certificateRepository)
    {
        _logger = logger;
        _localizer = localizer;
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
            if (await _esService.Get(request.IdCard) is not null)
            {
                throw new BusinessException(EXIST_ID_CARD);
            }

            var id = NewGuid();
            var ent = ObjectMapper.Map<DeveloperRequest, Developer>(request);
            var certEnts = ObjectMapper.Map<List<CertificateRipRequest>, List<Certificate>>(request.Certificates);

            ent.Id = id;
            certEnts?.ForEach(x => x.DeveloperId = id);

            var rslt = ObjectMapper.Map<Developer, DeveloperResponse>(await _repository.Insert(ent));

            if (request.Certificates.IsNotEmptyAndNull())
            {
                rslt.Certificates = new List<CertificateResponse>(ObjectMapper.Map<IEnumerable<Certificate>, IEnumerable<CertificateResponse>>(await _certificateRepository.Inserts(certEnts)));
            }

            return await _esService.Set(ObjectMapper.Map<DeveloperResponse, DeveloperIndex>(rslt)) ? rslt : throw new BusinessException();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "InsertDeveloperService-Exception: {Request}", request.CamelSerialize());
            throw;
        }
    }

    public async ValueTask<DeveloperResponse> Adjust(string idCard, DeveloperFreeRequest request)
    {
        try
        {
            var mdl = await _esService.Get(idCard) ?? throw new BusinessException();
            var ent = ObjectMapper.Map<DeveloperIndex, Developer>(mdl);
            var id = NewGuid();
            var certEnts = ObjectMapper.Map<List<CertificateRipRequest>, List<Certificate>>(request.Certificates);

            ent.Id = id;
            ent.Name = request.Name ?? ent.Name;
            ent.Phone = request.Phone ?? ent.Phone;
            ent.IdCard = idCard;
            ent.DeveloperTypeCode = request.DeveloperTypeCode ?? ent.DeveloperTypeCode;
            certEnts?.ForEach(x => x.DeveloperId = id);

            var rslt = ObjectMapper.Map<Developer, DeveloperResponse>(await _repository.Adjust(ent));

            if (request.Certificates.IsNotEmptyAndNull())
            {
                if (mdl.Certificates.IsNotEmptyAndNull())
                {
                    await _certificateRepository.Updates(ObjectMapper.Map<IEnumerable<CertificateResponse>, IEnumerable<Certificate>>(mdl.Certificates.Select(x =>
                    {
                        x.DeveloperId = null;
                        return x;
                    })));
                }

                rslt.Certificates = new List<CertificateResponse>(ObjectMapper.Map<IEnumerable<Certificate>, IEnumerable<CertificateResponse>>(await _certificateRepository.Inserts(certEnts)));
            }

            return await _esService.Set(ObjectMapper.Map<DeveloperResponse, DeveloperIndex>(rslt)) ? rslt : throw new BusinessException();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "AdjustDeveloperService-Exception: {Request}", request.CamelSerialize());
            throw;
        }
    }

    public async ValueTask<bool> SyncDbToEs()
    {
        try
        {
            var rslt = await _esService.DeleteAll();
            var mdls = await _repository.GetAll();

            return mdls.IsNotEmptyAndNull() ? rslt && await _esService.SetBulk(ObjectMapper.Map<List<Developer>, List<DeveloperIndex>>(mdls.ToList())) : rslt;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDbToEsDeveloperService-Exception");
            throw;
        }
    }
    #endregion
}
