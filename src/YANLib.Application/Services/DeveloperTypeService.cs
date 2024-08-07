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
using static YANLib.YANLibConsts.RedisConstant;
using static YANLib.YANLibConsts.SnowflakeId.DatacenterId;
using static YANLib.YANLibConsts.SnowflakeId.WorkerId;
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
            var mdls = await _redisService.GetAll(DeveloperTypeGroup);

            return mdls.IsEmptyOrNull() ? default : mdls.Select(ObjectMapper.Map<KeyValuePair<string, DeveloperRedisTypeDto?>, DeveloperTypeResponse>);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAll-DeveloperTypeService-Exception");

            throw;
        }
    }

    public async ValueTask<DeveloperTypeResponse?> Get(long code)
    {
        try
        {
            var mdl = await _redisService.Get(DeveloperTypeGroup, code.ToString());

            return mdl.IsNull() ? default : ObjectMapper.Map<(long Code, DeveloperRedisTypeDto Dto), DeveloperTypeResponse>((code, mdl));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Get-DeveloperTypeService-Exception: {Code}", code);

            throw;
        }
    }

    public async ValueTask<DeveloperTypeResponse?> Insert(DeveloperTypeInsertRequest request)
    {
        try
        {
            var ent = await _repository.InsertAsync(ObjectMapper.Map<(long Code, DeveloperTypeInsertRequest Request), DeveloperType>((_idGenerator.NextId(), request)));

            return ent.IsNotNull() && await _redisService.Set(DeveloperTypeGroup, ent.Code.ToString(), ObjectMapper.Map<DeveloperType, DeveloperRedisTypeDto>(ent))
                ? ObjectMapper.Map<DeveloperType, DeveloperTypeResponse>(ent)
                : default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Insert-DeveloperTypeService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async ValueTask<DeveloperTypeResponse?> Modify(long code, DeveloperTypeModifyRequest request)
    {
        try
        {
            var ent = await _repository.Modify(ObjectMapper.Map<(Guid Id, DeveloperTypeModifyRequest Request), DeveloperTypeDto>(((
                await _redisService.Get(DeveloperTypeGroup, code.ToString()) ?? throw new BusinessException(NOT_FOUND_DEV_TYPE).WithData("Code", code)
            ).DeveloperTypeId, request)));

            return ent.IsNotNull() && await _redisService.Set(DeveloperTypeGroup, ent.Code.ToString(), ObjectMapper.Map<DeveloperType, DeveloperRedisTypeDto>(ent))
                ? ObjectMapper.Map<DeveloperType, DeveloperTypeResponse>(ent)
                : default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Modify-DeveloperTypeService-Exception: {Code} - {Request}", code, request.Serialize());

            throw;
        }
    }

    public async ValueTask<DeveloperTypeResponse?> Delete(long code, Guid updatedBy)
    {
        try
        {
            var ent = await _repository.Modify(new DeveloperTypeDto
            {
                Id = (await _redisService.Get(DeveloperTypeGroup, code.ToString()) ?? throw new BusinessException(NOT_FOUND_DEV_TYPE).WithData("Code", code)).DeveloperTypeId,
                UpdatedBy = updatedBy,
                IsDeleted = true,
            });

            return ent.IsNotNull() && await _redisService.Delete(DeveloperTypeGroup, ent.Code.ToString()) ? ObjectMapper.Map<DeveloperType, DeveloperTypeResponse>(ent) : default;
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

            return mdls.IsNotEmptyAndNull() ? rslt && await _redisService.SetBulk(DeveloperTypeGroup, mdls.ToDictionary(x => x.Code.ToString(), ObjectMapper.Map<DeveloperType, DeveloperRedisTypeDto>)) : rslt;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDbToRedis-DeveloperTypeService-Exception");

            throw;
        }
    }
}
