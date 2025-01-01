using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.Object;
using YANLib.RedisDtos;
using YANLib.Repositories;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
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
    ICertificateService certificateService
) : YANLibAppService, IDeveloperCertificateService
{
    private readonly ILogger<DeveloperCertificateService> _logger = logger;
    private readonly IDeveloperCertificateRepository _repository = repository;
    private readonly IRedisService<DeveloperCertificateRedisDto> _redisService = redisService;
    private readonly IDeveloperService _developerService = developerService;
    private readonly ICertificateService _certificateService = certificateService;

    public async ValueTask<PagedResultDto<DeveloperCertificateResponse>?> GetByDeveloper(PagedAndSortedResultRequestDto input, Guid developerId)
    {
        try
        {
            var dtos = await _redisService.GetAll($"{DeveloperCertificateGroupPrefix}:{developerId}");

            if (dtos.IsNullOEmpty())
            {
                return new PagedResultDto<DeveloperCertificateResponse>();
            }

            var queryableItems = dtos.Select(x => ObjectMapper.Map<(Guid DeveloperId, KeyValuePair<string, DeveloperCertificateRedisDto?> Pair), DeveloperCertificateResponse>((developerId, x))).AsQueryable();

            if (input.Sorting.IsNotNullNWhiteSpace())
            {
                queryableItems = queryableItems.OrderBy(input.Sorting);
            }

            return new PagedResultDto<DeveloperCertificateResponse>(queryableItems.Count(), [.. queryableItems.Skip(input.SkipCount).Take(input.MaxResultCount)]);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByDeveloper-DeveloperCertificateService-Exception: {DeveloperId}", developerId);

            throw;
        }
    }

    public async ValueTask<DeveloperCertificateResponse?> GetByDeveloperAndCertificate(Guid developerId, string certificateCode)
    {
        try
        {
            var dto = await _redisService.Get($"{DeveloperCertificateGroupPrefix}:{developerId}", certificateCode);

            return dto.IsNull()
                ? throw new EntityNotFoundException(typeof(DeveloperCertificateRedisDto), certificateCode)
                : ObjectMapper.Map<(Guid DeveloperId, string CertificateCode, DeveloperCertificateRedisDto Dto), DeveloperCertificateResponse>((developerId, certificateCode, dto));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByDeveloperAndCertificate-DeveloperCertificateService-Exception: {DeveloperId} - {CertificateCode}", developerId, certificateCode);

            throw;
        }
    }

    public async ValueTask<DeveloperCertificateResponse?> Insert(DeveloperCertificateCreateRequest request)
    {
        try
        {
            var devTask = _developerService.Get(request.DeveloperId).AsTask();
            var certTask = _certificateService.Get(request.CertificateCode).AsTask();

            _ = await WhenAny(devTask, certTask);

            var dev = await devTask;

            if (dev.IsNull())
            {
                throw new EntityNotFoundException(typeof(Developer), request.DeveloperId);
            }

            var cert = await certTask;

            if (cert.IsNull())
            {
                throw new EntityNotFoundException(typeof(Certificate), request.CertificateCode);
            }

            var entity = await _repository.InsertAsync(ObjectMapper.Map<(Guid DeveloperId, string CertificateCode, DeveloperCertificateCreateRequest Request), DeveloperCertificate>((dev.Id, cert.Id, request)));

            return entity.IsNull()
                ? throw new BusinessException(SQL_SERVER_ERROR)
                : await _redisService.Set($"{DeveloperCertificateGroupPrefix}:{request.DeveloperId}", request.CertificateCode, ObjectMapper.Map<DeveloperCertificate, DeveloperCertificateRedisDto>(entity))
                ? ObjectMapper.Map<(Guid DeveloperId, string CertificateCode, DeveloperCertificate Entity), DeveloperCertificateResponse>((dev.Id, cert.Id, entity))
                : throw new BusinessException(REDIS_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Insert-DeveloperCertificateService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async ValueTask<DeveloperCertificateResponse?> Modify(DeveloperCertificateUpdateRequest request)
    {
        try
        {
            var entity = await _repository.Modify(ObjectMapper.Map<(Guid Id, DeveloperCertificateUpdateRequest Request), DeveloperCertificateDto>(((
                await _redisService.Get($"{DeveloperCertificateGroupPrefix}:{request.DeveloperId}", request.CertificateCode)
                ?? throw new EntityNotFoundException(typeof(DeveloperCertificateRedisDto))
            ).Id, request)));

            return entity.IsNull()
                ? throw new BusinessException(SQL_SERVER_ERROR)
                : await _redisService.Set($"{DeveloperCertificateGroupPrefix}:{request.DeveloperId}", request.CertificateCode, ObjectMapper.Map<DeveloperCertificate, DeveloperCertificateRedisDto>(entity))
                ? ObjectMapper.Map<(Guid DeveloperId, string CertificateCode, DeveloperCertificate Entity), DeveloperCertificateResponse>((request.DeveloperId, request.CertificateCode, entity))
                : throw new BusinessException(REDIS_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Modify-DeveloperCertificateService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async ValueTask<bool?> Delete(Guid developerId, string certificateCode, Guid updatedBy)
    {
        try
        {
            var entity = await _repository.Modify(new DeveloperCertificateDto
            {
                Id = (await _redisService.Get($"{DeveloperCertificateGroupPrefix}:{developerId}", certificateCode) ?? throw new EntityNotFoundException(typeof(DeveloperCertificateRedisDto))).Id,
                UpdatedBy = updatedBy,
                IsDeleted = true,
            });

            return entity.IsNull() ? throw new BusinessException(SQL_SERVER_ERROR) : await _redisService.Delete($"{DeveloperCertificateGroupPrefix}:{developerId}", certificateCode);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Delete-DeveloperCertificateService-Exception: {DeveloperId} - {CertificateCode} - {UpdatedBy}", developerId, certificateCode, updatedBy);

            throw;
        }
    }

    public async ValueTask<bool> SyncDbToRedis()
    {
        try
        {
            var cleanTask = _redisService.DeleteGroup($"{DeveloperCertificateGroupPrefix}:").AsTask();
            var entitiesTask = _repository.GetListAsync(x => !x.IsDeleted);

            _ = await WhenAny(cleanTask, entitiesTask);

            var result = await cleanTask;
            var entities = await entitiesTask;

            if (entities.IsNullOEmpty())
            {
                return result;
            }

            var ss = new SemaphoreSlim(1);

            await WhenAll(entities.GroupBy(x => x.DeveloperId).Select(async g =>
            {
                await ss.WaitAsync();

                try
                {
                    result &= await _redisService.SetBulk($"{DeveloperCertificateGroupPrefix}:{g.Key}", g.ToDictionary(y => y.CertificateCode, y => ObjectMapper.Map<DeveloperCertificate, DeveloperCertificateRedisDto>(y)));
                }
                finally
                {
                    _ = ss.Release();
                }
            }));

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDbToRedis-DeveloperCertificateService-Exception");

            throw;
        }
    }

    public async ValueTask<bool> SyncDbToRedisByDeveloper(Guid developerId)
    {
        try
        {
            var cleanTask = _redisService.DeleteAll($"{DeveloperCertificateGroupPrefix}:{developerId}").AsTask();
            var entitiesTask = _repository.GetListAsync(x => x.DeveloperId == developerId && !x.IsDeleted);

            _ = await WhenAny(cleanTask, entitiesTask);

            var result = await cleanTask;
            var entities = await entitiesTask;

            return entities.IsNullOEmpty()
                ? result
                : (result &= await _redisService.SetBulk($"{DeveloperCertificateGroupPrefix}:{developerId}", entities.ToDictionary(x => x.CertificateCode, ObjectMapper.Map<DeveloperCertificate, DeveloperCertificateRedisDto>)));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDbToRedisByDeveloper-DeveloperCertificateService-Exception: {DeveloperId}", developerId);

            throw;
        }
    }
}
