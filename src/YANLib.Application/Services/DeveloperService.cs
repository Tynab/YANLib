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
using YANLib.EsIndexes;
using YANLib.EsServices;
using YANLib.Kafka.Etos;
using YANLib.Models;
using YANLib.RabbitMq.Etos;
using YANLib.Repositories;
using YANLib.Requests;
using YANLib.Responses;
using static System.DateTime;
using static YANLib.Kafka.KafkaTopic;
using static YANLib.YANLibConsts;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Services;

public class DeveloperService : YANLibAppService, IDeveloperService
{
    #region Fields
    private readonly ILogger<DeveloperService> _logger;
    private readonly IDeveloperRepository _repository;
    private readonly IDeveloperEsService _esService;
    private readonly ICertificateRepository _certificateRepository;
    private readonly IDistributedEventBus _distributedEventBus;
    private readonly ICapPublisher _capPublisher;
    private readonly IdGenerator _idGenerator;
    #endregion

    #region Constructors
    public DeveloperService(
        ILogger<DeveloperService> logger,
        IDeveloperRepository repository,
        IDeveloperEsService esService,
        ICertificateRepository certificateRepository,
        IDistributedEventBus distributedEventBus,
        ICapPublisher capPublisher
        )
    {
        _logger = logger;
        _repository = repository;
        _esService = esService;
        _certificateRepository = certificateRepository;
        _distributedEventBus = distributedEventBus;
        _capPublisher = capPublisher;
        _idGenerator = new IdGenerator(DevelopersWorkerId, YanlibDatacenterId);
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

    public async ValueTask<DeveloperResponse> Insert(DeveloperRequest request)
    {
        try
        {
            if (await _esService.Get(request.IdCard) is not null)
            {
                throw new BusinessException(EXIST_ID_CARD).WithData("IdCard", request.IdCard);
            }

            var id = _idGenerator.NextIdAlphabetic();
            var ent = ObjectMapper.Map<DeveloperRequest, Developer>(request);

            ent.Id = id;

            var rslt = ObjectMapper.Map<Developer, DeveloperResponse>(await _repository.Insert(ent));

            if (request.Certificates.IsNotEmptyAndNull())
            {
                var certEnts = ObjectMapper.Map<List<CertificateRipRequest>, List<Certificate>>(request.Certificates);

                certEnts.ForEach(x =>
                {
                    x.Id = _idGenerator.NextIdAlphabetic();
                    x.DeveloperId = id;
                    x.CreatedDate = Now;
                });

                rslt.Certificates = new List<CertificateResponse>(ObjectMapper.Map<List<Certificate>, List<CertificateResponse>>(certEnts));

                var etos = ObjectMapper.Map<List<Certificate>, List<CertificateCreateEto>>(certEnts);

                _logger.LogInformation("InsertDeveloperService-Publish: {ETOs}", etos.CamelSerialize());

                await _capPublisher.PublishAsync(CERT_CRT, etos);
            }

            return await _esService.Set(ObjectMapper.Map<DeveloperResponse, DeveloperIndex>(rslt)) ? rslt : throw new BusinessException(INTERNAL_SERVER_ERROR);
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
            var mdl = await _esService.Get(idCard) ?? throw new BusinessException(NOT_FOUND_DEV).WithData("IdCard", idCard);
            var ent = ObjectMapper.Map<DeveloperIndex, Developer>(mdl);
            var id = _idGenerator.NextIdAlphabetic();

            ent.Id = id;
            ent.Name = request.Name ?? ent.Name;
            ent.Phone = request.Phone ?? ent.Phone;
            ent.IdCard = idCard;
            ent.DeveloperTypeCode = request.DeveloperTypeCode ?? ent.DeveloperTypeCode;

            var rslt = ObjectMapper.Map<Developer, DeveloperResponse>(await _repository.Adjust(ent));

            if (request.Certificates.IsNotEmptyAndNull())
            {
                var certEnts = ObjectMapper.Map<List<CertificateRipRequest>, List<Certificate>>(request.Certificates);

                certEnts.ForEach(x =>
                {
                    x.Id = _idGenerator.NextIdAlphabetic();
                    x.DeveloperId = id;
                    x.CreatedDate = Now;
                });

                rslt.Certificates = new List<CertificateResponse>(ObjectMapper.Map<List<Certificate>, List<CertificateResponse>>(certEnts));

                var etos = ObjectMapper.Map<List<Certificate>, List<CertificateCreateEto>>(certEnts);

                _logger.LogInformation("AdjustDeveloperService-Publish: {ETOs}", etos.CamelSerialize());

                await _capPublisher.PublishAsync(CERT_CRT, etos);
            }
            else if (mdl.Certificates.IsNotEmptyAndNull())
            {
                mdl.Certificates.ForEach(x =>
                {
                    x.DeveloperId = id;
                    x.ModifiedDate = Now;
                });

                rslt.Certificates = new List<CertificateResponse>(mdl.Certificates);

                var etos = ObjectMapper.Map<List<CertificateResponse>, List<CertificateAdjustEto>>(mdl.Certificates);

                _logger.LogInformation("AdjustDeveloperService-Publish: {ETOs}", etos.CamelSerialize());

                await _distributedEventBus.PublishAsync(etos);
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
            var rslt = await _esService.DeleteAll();
            var mdls = await _repository.GetAll();
            var datas = new List<DeveloperIndex>();
            var semSlim = new SemaphoreSlim(1);

            await Task.WhenAll(mdls.Select(async x =>
            {
                var dto = ObjectMapper.Map<Developer, DeveloperIndex>(x);

                await semSlim.WaitAsync();

                try
                {
                    dto.Certificates = new List<CertificateResponse>(ObjectMapper.Map<IEnumerable<Certificate>, IEnumerable<CertificateResponse>>(await _certificateRepository.GetByDeveloperId(x.Id)));
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
