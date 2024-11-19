using Id_Generator_Snowflake;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using YANLib.Core;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.RedisDtos;
using YANLib.Repositories;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;
using static System.Threading.Tasks.Task;
using static YANLib.YANLibConsts.RedisConstant;
using static YANLib.YANLibConsts.SnowflakeId.DatacenterId;
using static YANLib.YANLibConsts.SnowflakeId.WorkerId;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Services.v2;

public class DeveloperTypeService(ILogger<DeveloperTypeService> logger, IDeveloperTypeRepository repository, IRedisService<DeveloperRedisTypeDto> redisService) : YANLibAppService, IDeveloperTypeService
{
    private readonly ILogger<DeveloperTypeService> _logger = logger;
    private readonly IDeveloperTypeRepository _repository = repository;
    private readonly IRedisService<DeveloperRedisTypeDto> _redisService = redisService;
    private readonly IdGenerator _idGenerator = new(DeveloperId, YanlibId);

    public async ValueTask<PagedResultDto<DeveloperTypeResponse>?> GetAll(PagedAndSortedResultRequestDto dto)
    {
        try
        {
            var mdls = await _redisService.GetAll(DeveloperTypeGroup);

            if (mdls.IsEmptyOrNull())
            {
                return new PagedResultDto<DeveloperTypeResponse>();
            }

            var queryableItems = mdls.Select(ObjectMapper.Map<KeyValuePair<string, DeveloperRedisTypeDto?>, DeveloperTypeResponse>).AsQueryable();

            if (dto.Sorting.IsNotWhiteSpaceAndNull())
            {
                queryableItems = queryableItems.OrderBy(dto.Sorting);
            }

            return new PagedResultDto<DeveloperTypeResponse>(queryableItems.Count(), [.. queryableItems.Skip(dto.SkipCount).Take(dto.MaxResultCount)]);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAll-DeveloperTypeService-Exception: {DTO}", dto.Serialize());

            throw;
        }
    }

    public async ValueTask<DeveloperTypeResponse?> Get(long code)
    {
        try
        {
            var mdl = await _redisService.Get(DeveloperTypeGroup, code.ToString());

            return mdl.IsNull() ? throw new EntityNotFoundException(typeof(DeveloperTypeResponse), code) : ObjectMapper.Map<(long Code, DeveloperRedisTypeDto Dto), DeveloperTypeResponse>((code, mdl));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Get-DeveloperTypeService-Exception: {Code}", code);

            throw;
        }
    }

    public async ValueTask<DeveloperTypeResponse?> Insert(DeveloperTypeCreateRequest request)
    {
        try
        {
            var ent = await _repository.InsertAsync(ObjectMapper.Map<(long Code, DeveloperTypeCreateRequest Request), DeveloperType>((_idGenerator.NextId(), request)));

            return ent.IsNotNull() && await _redisService.Set(DeveloperTypeGroup, ent.Code.ToString(), ObjectMapper.Map<DeveloperType, DeveloperRedisTypeDto>(ent))
                ? ObjectMapper.Map<DeveloperType, DeveloperTypeResponse>(ent)
                : throw new EntityNotFoundException(typeof(DeveloperTypeResponse));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Insert-DeveloperTypeService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async ValueTask<DeveloperTypeResponse?> Modify(long code, DeveloperTypeUpdateRequest request)
    {
        try
        {
            var dto = await _redisService.Get(DeveloperTypeGroup, code.ToString()) ?? throw new BusinessException(NOT_FOUND_DEV_TYPE).WithData("Code", code);
            var ent = await _repository.Modify(ObjectMapper.Map<(Guid Id, DeveloperTypeUpdateRequest Request), DeveloperTypeDto>((dto.DeveloperTypeId, request)));

            return ent.IsNotNull() && await _redisService.Set(DeveloperTypeGroup, ent.Code.ToString(), ObjectMapper.Map<DeveloperType, DeveloperRedisTypeDto>(ent))
                ? ObjectMapper.Map<DeveloperType, DeveloperTypeResponse>(ent)
                : throw new EntityNotFoundException(typeof(DeveloperTypeResponse), dto.DeveloperTypeId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Modify-DeveloperTypeService-Exception: {Code} - {Request}", code, request.Serialize());

            throw;
        }
    }

    public async ValueTask<bool> Delete(long code, Guid updatedBy)
    {
        try
        {
            return (await _repository.Modify(new DeveloperTypeDto
            {
                Id = (await _redisService.Get(DeveloperTypeGroup, code.ToString()) ?? throw new BusinessException(NOT_FOUND_DEV_TYPE).WithData("Code", code)).DeveloperTypeId,
                UpdatedBy = updatedBy,
                IsDeleted = true,
            })).IsNotNull() && await _redisService.Delete(DeveloperTypeGroup, code.ToString());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Delete-DeveloperTypeService-Exception: {Code} - {UpdatedBy}", code, updatedBy);

            throw;
        }
    }

    public async ValueTask<bool> SyncDbToRedis()
    {
        try
        {
            var clnTask = _redisService.DeleteAll(DeveloperTypeGroup).AsTask();
            var mdlsTask = _repository.GetListAsync(x => x.IsDeleted == false);

            await WhenAll(clnTask, mdlsTask);

            var rslt = await clnTask;
            var mdls = await mdlsTask;

            return mdls.IsEmptyOrNull() ? rslt : rslt && await _redisService.SetBulk(DeveloperTypeGroup, mdls.ToDictionary(x => x.Code.ToString(), ObjectMapper.Map<DeveloperType, DeveloperRedisTypeDto>));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDbToRedis-DeveloperTypeService-Exception");

            throw;
        }
    }
}
