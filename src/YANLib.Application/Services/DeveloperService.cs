using DotNetCore.CAP;
using Id_Generator_Snowflake;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.EventBus.Distributed;
using YANLib.Entities;
using YANLib.EsIndexes;
using YANLib.EsServices;
using YANLib.Kafka.Etos;
using YANLib.RabbitMq.Etos;
using YANLib.Repositories;
using YANLib.Requests;
using YANLib.Responses;
using static System.DateTime;
using static System.Threading.Tasks.Task;
using static YANLib.Kafka.KafkaTopic;
using static YANLib.YANLibConsts.SnowflakeId.DatacenterId;
using static YANLib.YANLibConsts.SnowflakeId.WorkerId;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Services;

public class DeveloperService : YANLibAppService, IDeveloperService
{
    #region Fields
    private readonly ILogger<DeveloperService> _logger;
    private readonly IDeveloperRepository _repository;
    private readonly ICertificateRepository _certificateRepository;
    private readonly IDeveloperEsService _esService;
    private readonly IDistributedEventBus _distributedEventBus;
    private readonly ICapPublisher _capPublisher;
    private readonly IDeveloperTypeService _developerTypeService;
    private readonly IdGenerator _idGenerator;
    #endregion

    #region Constructors
    public DeveloperService(
        ILogger<DeveloperService> logger,
        IDeveloperRepository repository,
        ICertificateRepository certificateRepository,
        IDeveloperEsService esService,
        IDistributedEventBus distributedEventBus,
        ICapPublisher capPublisher,
        IDeveloperTypeService developerTypeService
        )
    {
        _logger = logger;
        _repository = repository;
        _esService = esService;
        _certificateRepository = certificateRepository;
        _distributedEventBus = distributedEventBus;
        _capPublisher = capPublisher;
        _developerTypeService = developerTypeService;
        _idGenerator = new IdGenerator(DeveloperId, YanlibId);
    }
    #endregion

    #region Implements
    public async ValueTask<DeveloperResponse> Get(string id)
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

    public async ValueTask<List<DeveloperResponse>> SearchByPhone(string searchText)
    {
        try
        {
            return ObjectMapper.Map<IEnumerable<DeveloperIndex>, IEnumerable<DeveloperResponse>>(await _esService.SearchByPhone(searchText)).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchByPhoneDeveloperService-Exception: {SearchText}", searchText);
            throw;
        }
    }

    public async ValueTask<DeveloperResponse> Insert(DeveloperRequest request)
    {
        try
        {
            if (await _esService.Get(request.IdCard) is not null)
            {
                throw new BusinessException(EXIST_ID_CARD).WithData("IdCard", request.IdCard);
            }

            var id = _idGenerator.NextIdAlphabetic();
            var ent = new Developer(id);

            _ = ObjectMapper.Map(request, ent);
            ent.CreatedDate = Now;

            var rslt = ObjectMapper.Map<Developer, DeveloperResponse>(await _repository.InsertAsync(ent));

            rslt.DeveloperType = await _developerTypeService.Get(ent.DeveloperTypeCode);

            if (request.Certificates.IsNotEmptyAndNull())
            {
                var certs = new List<Certificate>();

                foreach (var item in request.Certificates)
                {
                    var cert = ObjectMapper.Map<DeveloperRequest.Certificate, Certificate>(item);

                    cert.Id = _idGenerator.NextIdAlphabetic();
                    cert.DeveloperId = id;
                    cert.CreatedDate = Now;
                    certs.Add(cert);

                    var eto = ObjectMapper.Map<Certificate, CertificateCreateEto>(cert);

                    await _capPublisher.PublishAsync(CERT_CRT, eto);
                    _logger.LogInformation("InsertDeveloperService-Publish: {ETO}", eto.CamelSerialize());
                }

                rslt.Certificates = new List<CertificateResponse>(ObjectMapper.Map<List<Certificate>, List<CertificateResponse>>(certs));
            }

            return await _esService.Set(ObjectMapper.Map<DeveloperResponse, DeveloperIndex>(rslt)) ? rslt : throw new BusinessException(INTERNAL_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "InsertDeveloperService-Exception: {Request}", request.CamelSerialize());
            throw;
        }
    }

    public async ValueTask<DeveloperResponse> Adjust(string idCard, DeveloperAdjustRequest request)
    {
        try
        {
            var mdl = await _esService.Get(idCard) ?? throw new BusinessException(NOT_FOUND_DEV).WithData("IdCard", idCard);
            var id = _idGenerator.NextIdAlphabetic();
            var ent = new Developer(id);

            _ = ObjectMapper.Map(mdl, ent);

            ent.Name = request.Name ?? ent.Name;
            ent.Phone = request.Phone ?? ent.Phone;
            ent.IdCard = idCard;
            ent.DeveloperTypeCode = request.DeveloperTypeCode ?? ent.DeveloperTypeCode;

            var rslt = ObjectMapper.Map<Developer, DeveloperResponse>(await _repository.Adjust(ent));

            rslt.DeveloperType = await _developerTypeService.Get(ent.DeveloperTypeCode);

            if (request.Certificates.IsNotEmptyAndNull())
            {
                var certs = new List<Certificate>();

                foreach (var item in request.Certificates)
                {
                    var cert = ObjectMapper.Map<DeveloperAdjustRequest.Certificate, Certificate>(item);

                    cert.Id = _idGenerator.NextIdAlphabetic();
                    cert.DeveloperId = id;
                    cert.CreatedDate = Now;
                    certs.Add(cert);

                    var eto = ObjectMapper.Map<Certificate, CertificateCreateEto>(cert);

                    await _capPublisher.PublishAsync(CERT_CRT, eto);
                    _logger.LogInformation("AdjustDeveloperService-Publish: {ETO}", eto.CamelSerialize());
                }

                rslt.Certificates = new List<CertificateResponse>(ObjectMapper.Map<List<Certificate>, List<CertificateResponse>>(certs));
            }
            else if (mdl.Certificates.IsNotEmptyAndNull())
            {
                foreach (var cert in mdl.Certificates)
                {
                    cert.DeveloperId = id;
                    cert.ModifiedDate = Now;

                    var eto = ObjectMapper.Map<CertificateResponse, CertificateAdjustEto>(cert);

                    _logger.LogInformation("AdjustDeveloperService-Publish: {ETO}", eto.CamelSerialize());
                    await _distributedEventBus.PublishAsync(eto);
                }

                rslt.Certificates = new List<CertificateResponse>(mdl.Certificates);
            }

            return await _esService.Set(ObjectMapper.Map<DeveloperResponse, DeveloperIndex>(rslt)) ? rslt : throw new BusinessException(INTERNAL_SERVER_ERROR);
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
            var task = _esService.DeleteAll();
            var mdls = await _repository.GetListAsync();
            var datas = new List<DeveloperIndex>();
            var semSlim = new SemaphoreSlim(1);
            var rslt = await task;

            await WhenAll(mdls.Select(async x =>
            {
                var certsTask = _certificateRepository.GetByDeveloperId(x.Id);
                var dto = ObjectMapper.Map<Developer, DeveloperIndex>(x);

                dto.DeveloperType = await _developerTypeService.Get(x.DeveloperTypeCode);
                dto.Certificates = new List<CertificateResponse>(ObjectMapper.Map<IEnumerable<Certificate>, IEnumerable<CertificateResponse>>(await certsTask).ToList());
                await semSlim.WaitAsync();

                try
                {
                    datas.Add(dto);
                }
                finally
                {
                    _ = semSlim.Release();
                }
            }));

            return mdls.IsNotEmptyAndNull() ? rslt && await _esService.SetBulk(datas) : rslt;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDbToEsDeveloperService-Exception");
            throw;
        }
    }
    #endregion
}
