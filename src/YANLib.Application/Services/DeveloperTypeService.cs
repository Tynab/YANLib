using Id_Generator_Snowflake;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using YANLib.Core;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.RedisDtos;
using YANLib.Repositories;
using YANLib.Requests.Insert;
using YANLib.Requests.Modify;
using YANLib.Responses;
using static System.Threading.Tasks.Task;
using static YANLib.Constants.YANLibConsts.RedisConstant;
using static YANLib.Constants.YANLibConsts.SnowflakeId.DatacenterId;
using static YANLib.Constants.YANLibConsts.SnowflakeId.WorkerId;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Services;

public class DeveloperTypeService(ILogger<DeveloperTypeService> logger, IDeveloperTypeRepository repository, IRedisService<DeveloperRedisTypeDto> redisService) : YANLibAppService, IDeveloperTypeService
{
    private readonly ILogger<DeveloperTypeService> _logger = logger;
    private readonly IDeveloperTypeRepository _repository = repository;
    private readonly IRedisService<DeveloperRedisTypeDto> _redisService = redisService;
    private readonly IdGenerator _idGenerator = new(DeveloperId, YanlibId);

    public async ValueTask<IEnumerable<DeveloperTypeResponse>?> GetAll()
    {
        try
        {
            var dtos = await _redisService.GetAll(DeveloperTypeGroup);

            return dtos.IsEmptyOrNull() ? default : dtos.Select(ObjectMapper.Map<KeyValuePair<string, DeveloperRedisTypeDto?>, DeveloperTypeResponse>);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAllDeveloperTypeService-Exception");

            throw;
        }
    }

    public async ValueTask<DeveloperTypeResponse?> Get(long code)
    {
        try
        {
            var dto = await _redisService.Get(DeveloperTypeGroup, code.ToString());

            if (dto.IsNull())
            {
                return default;
            }

            var rslt = ObjectMapper.Map<DeveloperRedisTypeDto, DeveloperTypeResponse>(dto);

            if (rslt.IsNotNull())
            {
                rslt.Code = code;
            }

            return rslt;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetDeveloperTypeService-Exception: {Code}", code);

            throw;
        }
    }

    public async ValueTask<DeveloperTypeResponse?> Insert(DeveloperTypeInsertRequest request)
    {
        try
        {
            var ent = ObjectMapper.Map<DeveloperTypeInsertRequest, DeveloperType>(request);
            var code = _idGenerator.NextId();

            ent.Code = code;

            var mdl = await _repository.InsertAsync(ent);

            if (mdl.IsNull())
            {
                return default;
            }

            _ = await _redisService.Set(DeveloperTypeGroup, mdl.Code.ToString(), ObjectMapper.Map<DeveloperType, DeveloperRedisTypeDto>(mdl));

            return ObjectMapper.Map<DeveloperType, DeveloperTypeResponse>(mdl);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "InsertDeveloperTypeService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async ValueTask<DeveloperTypeResponse?> Modify(long code, DeveloperTypeModifyRequest request)
    {
        try
        {
            var mdl = await _repository.Modify(ObjectMapper.Map<(Guid Id, DeveloperTypeModifyRequest Request), DeveloperTypeDto>(((
                await _redisService.Get(DeveloperTypeGroup, code.ToString()) ?? throw new BusinessException(NOT_FOUND_DEV_TYPE).WithData("Code", code)
            ).DeveloperTypeId, request)));

            if (mdl.IsNull())
            {
                return default;
            }

            _ = await _redisService.Set(DeveloperTypeGroup, mdl.Code.ToString(), ObjectMapper.Map<DeveloperType, DeveloperRedisTypeDto>(mdl));

            return ObjectMapper.Map<DeveloperType, DeveloperTypeResponse>(mdl);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ModifyDeveloperTypeService-Exception: {Code} - {Request}", code, request.Serialize());

            throw;
        }
    }

    public async ValueTask<DeveloperTypeResponse?> Delete(long code, Guid updatedBy)
    {
        try
        {
            var dto = await _redisService.Get(DeveloperTypeGroup, code.ToString()) ?? throw new BusinessException(NOT_FOUND_DEV_TYPE).WithData("Code", code);

            var mdl = await _repository.Modify(new DeveloperTypeDto
            {
                Id = dto.DeveloperTypeId,
                UpdatedBy = updatedBy,
                IsDeleted = true,
            });

            if (mdl.IsNull())
            {
                return default;
            }

            _ = await _redisService.Delete(DeveloperTypeGroup, mdl.Code.ToString());

            return ObjectMapper.Map<DeveloperType, DeveloperTypeResponse>(mdl);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteDeveloperTypeService-Exception: {Code} - {UpdatedBy}", code, updatedBy);

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

            return mdls.IsNotEmptyAndNull() ? rslt && await _redisService.SetBulk(DeveloperTypeGroup, mdls.ToDictionary(x => x.Code.ToString(), ObjectMapper.Map<DeveloperType, DeveloperRedisTypeDto>)) : rslt;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDbToRedisDeveloperTypeService-Exception");

            throw;
        }
    }
}
