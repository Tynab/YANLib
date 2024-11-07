using Microsoft.Extensions.Logging;
using NUglify.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using YANLib.Core;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.RedisDtos;
using YANLib.Repositories;
using YANLib.Requests.Insert;
using YANLib.Requests.Modify;
using YANLib.Responses;
using static System.Threading.Tasks.Task;
using static YANLib.YANLibConsts.RedisConstant;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Services.v2;

public class DeveloperCertificateService(
    ILogger<DeveloperCertificateService> logger,
    IDeveloperCertificateRepository repository,
    IRedisService<DeveloperCertificateRedisDto> redisService,
    IDeveloperService developerService,
    ICertificateService certificateService,
    IRepository<Developer, Guid> developerRepository,
    IRepository<Certificate, Guid> certificateCrudRepository
) : YANLibAppService, IDeveloperCertificateService
{
    private readonly ILogger<DeveloperCertificateService> _logger = logger;
    private readonly IDeveloperCertificateRepository _repository = repository;
    private readonly IRedisService<DeveloperCertificateRedisDto> _redisService = redisService;
    private readonly IDeveloperService _developerService = developerService;
    private readonly ICertificateService _certificateService = certificateService;
    private readonly IRepository<Developer, Guid> _developerRepository = developerRepository;
    private readonly IRepository<Certificate, Guid> _certificateCrudRepository = certificateCrudRepository;

    public async ValueTask<IEnumerable<DeveloperCertificateResponse>?> GetByDeveloper(string idCard)
    {
        try
        {
            var mdls = await _redisService.GetAll($"{DeveloperCertificateGroupPrefix}:{idCard}");

            return mdls.IsEmptyOrNull() ? default : mdls.Select(x => ObjectMapper.Map<(string IdCard, KeyValuePair<string, DeveloperCertificateRedisDto?> Pair), DeveloperCertificateResponse>((idCard, x)));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByDeveloper-DeveloperCertificateService-Exception: {IdCard}", idCard);

            throw;
        }
    }

    public async ValueTask<DeveloperCertificateResponse?> GetByDeveloperAndCertificate(string idCard, long code)
    {
        try
        {
            var mdl = await _redisService.Get($"{DeveloperCertificateGroupPrefix}:{idCard}", code.ToString());

            return mdl.IsNull() ? default : ObjectMapper.Map<(string IdCard, long Code, DeveloperCertificateRedisDto Dto), DeveloperCertificateResponse>((idCard, code, mdl));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByDeveloperAndCertificate-DeveloperCertificateService-Exception: {IdCard} - {Code}", idCard, code);

            throw;
        }
    }

    public async ValueTask<DeveloperCertificateResponse?> Insert(DeveloperCertificateInsertRequest request)
    {
        try
        {
            var devTask = _developerService.GetByIdCard(request.DeveloperIdCard).AsTask();
            var certTask = _certificateService.GetByCode(request.CertificateCode.ToString()).AsTask();

            await WhenAll(devTask, certTask);

            var dev = await devTask;
            var cert = await certTask;

            if (dev.IsNull())
            {
                throw new BusinessException(NOT_FOUND_DEV).WithData("IdCard", request.DeveloperIdCard);
            }

            if (cert.IsNull())
            {
                throw new BusinessException(NOT_FOUND_CERT).WithData("Code", request.CertificateCode);
            }

            var ent = await _repository.InsertAsync(ObjectMapper.Map<(Guid DeveloperId, Guid CertificateId, DeveloperCertificateInsertRequest Request), DeveloperCertificate>((dev.Id, cert.Id, request)));

            return ent.IsNotNull()
                && await _redisService.Set($"{DeveloperCertificateGroupPrefix}:{request.DeveloperIdCard}", request.CertificateCode.ToString(), ObjectMapper.Map<DeveloperCertificate, DeveloperCertificateRedisDto>(ent))
                ? ObjectMapper.Map<(string? IdCard, long Code, DeveloperCertificate Entity), DeveloperCertificateResponse>((dev.IdCard, cert.Code.ToLong(), ent))
                : default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Insert-DeveloperCertificateService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async ValueTask<DeveloperCertificateResponse?> Modify(DeveloperCertificateModifyRequest request)
    {
        try
        {
            var ent = await _repository.Modify(ObjectMapper.Map<(Guid Id, DeveloperCertificateModifyRequest Request), DeveloperCertificateDto>(((
                await _redisService.Get($"{DeveloperCertificateGroupPrefix}:{request.DeveloperIdCard}", request.CertificateCode.ToString())
                ?? throw new BusinessException(NOT_FOUND_DEV_CERT).WithData("Code", request.CertificateCode).WithData("IdCard", request.DeveloperIdCard)
            ).Id, request)));

            return ent.IsNotNull()
                && await _redisService.Set($"{DeveloperCertificateGroupPrefix}:{request.DeveloperIdCard}", request.CertificateCode.ToString(), ObjectMapper.Map<DeveloperCertificate, DeveloperCertificateRedisDto>(ent))
                ? ObjectMapper.Map<(string? IdCard, long Code, DeveloperCertificate Entity), DeveloperCertificateResponse>((request.DeveloperIdCard, request.CertificateCode, ent))
                : default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Modify-DeveloperCertificateService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async ValueTask<DeveloperCertificateResponse?> Delete(string idCard, long code, Guid updatedBy)
    {
        try
        {
            var ent = await _repository.Modify(new DeveloperCertificateDto
            {
                Id = (await _redisService.Get($"{DeveloperCertificateGroupPrefix}:{idCard}", code.ToString()) ?? throw new BusinessException(NOT_FOUND_DEV_CERT).WithData("Code", code).WithData("IdCard", idCard)).Id,
                UpdatedBy = updatedBy,
                IsDeleted = true,
            });

            return ent.IsNotNull() && await _redisService.Delete($"{DeveloperCertificateGroupPrefix}:{idCard}", code.ToString())
                ? ObjectMapper.Map<(string? IdCard, long Code, DeveloperCertificate Entity), DeveloperCertificateResponse>((idCard, code, ent))
                : default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Delete-DeveloperCertificateService-Exception: {IdCard} - {Code} - {UpdatedBy}", idCard, code, updatedBy);

            throw;
        }
    }

    public async ValueTask<bool> SyncDbToRedis()
    {
        try
        {
            var clnTask = _redisService.DeleteGroup($"{DeveloperCertificateGroupPrefix}:").AsTask();
            var mdlsTask = _repository.GetListAsync(x => x.IsDeleted == false);

            await WhenAll(clnTask, mdlsTask);

            var rslt = await clnTask;
            var mdls = await mdlsTask;

            if (mdls.IsNotEmptyAndNull())
            {
                mdls.Join(await _developerRepository.GetListAsync(x => mdls.Select(x => x.DeveloperId).Distinct().Contains(x.Id)), m => m.DeveloperId, d => d.Id, (m, d) => new
                {
                    DevId = d.Id,
                    DevIdCard = d.IdCard,
                    DevCert = m
                }).Join(await _certificateCrudRepository.GetListAsync(x => mdls.Select(x => x.CertificateId).Distinct().Contains(x.Id)), x => x.DevCert.CertificateId, c => c.Id, (x, c) => new
                {
                    Code = c.Code ?? string.Empty,
                    x.DevCert,
                    x.DevIdCard
                }).GroupBy(x => x.DevIdCard).ForEach(async g => rslt &= await _redisService.SetBulk(
                    $"{DeveloperCertificateGroupPrefix}:{g.Key}",
                    g.ToDictionary(x => x.Code.ToString(), x => ObjectMapper.Map<DeveloperCertificate, DeveloperCertificateRedisDto>(x.DevCert))
                ));
            }

            return rslt;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDbToRedis-DeveloperCertificateService-Exception");

            throw;
        }
    }

    public async ValueTask<bool> SyncDbToRedisByDeveloper(string idCard)
    {
        try
        {
            var devId = (await _developerService.GetByIdCard(idCard) ?? throw new BusinessException(NOT_FOUND_DEV).WithData("IdCard", idCard)).Id;
            var clnTask = _redisService.DeleteAll($"{DeveloperCertificateGroupPrefix}:{idCard}").AsTask();
            var mdlsTask = _repository.GetListAsync(x => x.DeveloperId == devId && x.IsDeleted == false);

            await WhenAll(clnTask, mdlsTask);

            var rslt = await clnTask;
            var mdls = await mdlsTask;

            return mdls.IsEmptyOrNull() ? rslt : rslt && await _redisService.SetBulk(
                $"{DeveloperCertificateGroupPrefix}:{idCard}",
                (await _certificateCrudRepository.GetListAsync(x => mdls.Select(x => x.CertificateId).Contains(x.Id))).Join(mdls, c => c.DeveloperId, m => m.DeveloperId, (c, m) => new
                {
                    Code = c.Code ?? string.Empty,
                    DevCert = m
                }).ToDictionary(x => x.Code.ToString(), x => ObjectMapper.Map<DeveloperCertificate, DeveloperCertificateRedisDto>(x.DevCert))
            );
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDbToRedisByDeveloper-DeveloperCertificateService-Exception: {IdCard}", idCard);

            throw;
        }
    }
}
