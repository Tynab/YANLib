using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using YANLib.Entities;
using YANLib.Requests.Developer;
using YANLib.Responses;

namespace YANLib.CrudService;

public class DeveloperService(IRepository<Developer, Guid> repository)
    : CrudAppService<Developer, DeveloperResponse, Guid, PagedAndSortedResultRequestDto, DeveloperCreateRequest, DeveloperUpdateRequest>(repository), IDeveloperService
{ }
//    ILogger<DeveloperService> logger,
//    IDeveloperRepository repository,
//    IDeveloperTypeService developerTypeService,
//    ICertificateRepository certificateRepository,
//    IDeveloperEsService esService,
//    IDistributedEventBus distributedEventBus,
//    ICapPublisher capPublisher
//) : YANLibAppService, IDeveloperService
//{
//    private readonly ILogger<DeveloperService> _logger = logger;
//    private readonly IDeveloperRepository _repository = repository;
//    private readonly IDeveloperTypeService _developerTypeService = developerTypeService;
//    private readonly ICertificateRepository _certificateRepository = certificateRepository;
//    private readonly IDeveloperEsService _esService = esService;
//    private readonly IDistributedEventBus _distributedEventBus = distributedEventBus;
//    private readonly ICapPublisher _capPublisher = capPublisher;
//    private readonly IdGenerator _idGenerator = new(DeveloperId, YanlibId);

//    public async ValueTask<DeveloperResponse> GetByIdCard(string idCard)
//    {
//        try
//        {
//            return ObjectMapper.Map<DeveloperIndex, DeveloperResponse>(await _esService.Get(idCard));
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, "GetByIdCardDeveloperService-Exception: {IdCard}", idCard);

//            throw;
//        }
//    }

//    public async ValueTask<DeveloperResponse> Create(DeveloperCreateRequest request)
//    {
//        try
//        {
//            if (await _esService.Get(request.IdCard) is not null)
//            {
//                throw new BusinessException(EXIST_ID_CARD).WithData("IdCard", request.IdCard);
//            }

//            var id = _idGenerator.NextIdAlphabetic();
//            var ent = ObjectMapper.Map<DeveloperCreateRequest, Developer>(request);

//            ent.Id = id;

//            var rslt = ObjectMapper.Map<Developer, DeveloperResponse>(await _repository.Create(ent));

//            if (rslt is not null)
//            {
//                rslt.DeveloperType = await _developerTypeService.Get(ent.DeveloperTypeId);
//            }

//            if (request.Certificates.IsNotEmptyAndNull())
//            {
//                var certs = new List<Certificate>();

//                request.Certificates.ForEach(async x =>
//                {
//                    var cert = ObjectMapper.Map<DeveloperCreateRequest.Certificate, Certificate>(x);

//                    cert.Id = _idGenerator.NextIdAlphabetic();
//                    cert.DeveloperId = id;
//                    cert.CreatedAt = Now;
//                    certs.Add(cert);

//                    var eto = ObjectMapper.Map<Certificate, CertificateCreateEto>(cert);

//                    await _capPublisher.PublishAsync(CERT_CRT, eto);
//                    _logger.LogInformation("InsertDeveloperService-Publish: {ETO}", eto.Serialize());
//                });

//                rslt.Certificates = new List<CertificateResponse>(ObjectMapper.Map<List<Certificate>, List<CertificateResponse>>(certs));
//            }

//            return await _esService.Set(ObjectMapper.Map<DeveloperResponse, DeveloperIndex>(rslt)) ? rslt : throw new BusinessException(INTERNAL_SERVER_ERROR);
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, "CreateDeveloperService-Exception: {Request}", request.Serialize());

//            throw;
//        }
//    }

//    public async ValueTask<DeveloperResponse> Adjust(string idCard, DeveloperUpdateRequest dto)
//    {
//        try
//        {
//            var mdl = await _esService.Get(idCard) ?? throw new BusinessException(NOT_FOUND_DEV).WithData("IdCard", idCard);
//            var ent = ObjectMapper.Map<DeveloperIndex, Developer>(mdl);
//            var id = _idGenerator.NextIdAlphabetic();

//            ent.Id = id;
//            ent.Name = dto.Name ?? ent.Name;
//            ent.Phone = dto.Phone ?? ent.Phone;
//            ent.IdCard = idCard;
//            ent.DeveloperTypeId = dto.DeveloperTypeCode ?? ent.DeveloperTypeId;

//            var rslt = ObjectMapper.Map<Developer, DeveloperResponse>(await _repository.Adjust(ent));

//            if (rslt is not null)
//            {
//                rslt.DeveloperType = await _developerTypeService.Get(ent.DeveloperTypeId);
//            }

//            if (dto.Certificates.IsNotEmptyAndNull())
//            {
//                var certs = new List<Certificate>();

//                dto.Certificates.ForEach(async x =>
//                {
//                    var cert = ObjectMapper.Map<DeveloperUpdateRequest.Certificate, Certificate>(x);

//                    cert.Id = _idGenerator.NextIdAlphabetic();
//                    cert.DeveloperId = id;
//                    cert.CreatedAt = Now;
//                    certs.Add(cert);

//                    var eto = ObjectMapper.Map<Certificate, CertificateCreateEto>(cert);

//                    await _capPublisher.PublishAsync(CERT_CRT, eto);
//                    _logger.LogInformation("AdjustDeveloperService-Publish: {ETO}", eto.Serialize());
//                });

//                rslt.Certificates = new List<CertificateResponse>(ObjectMapper.Map<List<Certificate>, List<CertificateResponse>>(certs));
//            }
//            else if (mdl.Certificates.IsNotEmptyAndNull())
//            {
//                mdl.Certificates.ForEach(async x =>
//                {
//                    x.DeveloperId = id;
//                    x.UpdatedAt = Now;

//                    var eto = ObjectMapper.Map<CertificateResponse, CertificateAdjustEto>(x);

//                    await _distributedEventBus.PublishAsync(eto);
//                    _logger.LogInformation("AdjustDeveloperService-Publish: {ETO}", eto.Serialize());
//                });

//                rslt.Certificates = new List<CertificateResponse>(mdl.Certificates);
//            }

//            return await _esService.Set(ObjectMapper.Map<DeveloperResponse, DeveloperIndex>(rslt)) ? rslt : throw new BusinessException(INTERNAL_SERVER_ERROR);
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, "AdjustDeveloperService-Exception: {IdCard} - {DTO}", idCard, dto.Serialize());

//            throw;
//        }
//    }

//    public async ValueTask<List<DeveloperResponse>> GetByPhone(string phone)
//    {
//        try
//        {
//            return ObjectMapper.Map<IEnumerable<DeveloperIndex>, IEnumerable<DeveloperResponse>>(await _esService.GetByPhone(phone)).ToList();
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, "GetByPhoneDeveloperService-Exception: {Phone}", phone);

//            throw;
//        }
//    }

//    public async ValueTask<List<DeveloperResponse>> SearchByPhone(string searchText)
//    {
//        try
//        {
//            return ObjectMapper.Map<IEnumerable<DeveloperIndex>, IEnumerable<DeveloperResponse>>(await _esService.SearchByPhone(searchText)).ToList();
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, "SearchByPhoneDeveloperService-Exception: {SearchText}", searchText);

//            throw;
//        }
//    }

//    public async ValueTask<bool> SyncDbToEs()
//    {
//        try
//        {
//            var clnTask = _esService.DeleteAll().AsTask();
//            var mdlsTask = _repository.GetAll().AsTask();

//            await WhenAll(clnTask, mdlsTask);

//            var rslt = await clnTask;
//            var mdls = await mdlsTask;
//            var datas = new List<DeveloperIndex>();
//            var semSlim = new SemaphoreSlim(1);

//            await WhenAll(mdls.Select(async x =>
//            {
//                var dto = ObjectMapper.Map<Developer, DeveloperIndex>(x);

//                await semSlim.WaitAsync();

//                try
//                {
//                    dto.Certificates = new List<CertificateResponse>(ObjectMapper.Map<IEnumerable<Certificate>, IEnumerable<CertificateResponse>>(await _certificateRepository.GetByDeveloperId(x.Id)).ToList());
//                    datas.Add(dto);
//                }
//                finally
//                {
//                    _ = semSlim.Release();
//                }
//            }));

//            return mdls.IsNotEmptyAndNull() ? rslt && await _esService.SetBulk(datas) : rslt;
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, "SyncDbToEsDeveloperService-Exception");

//            throw;
//        }
//    }
//}
