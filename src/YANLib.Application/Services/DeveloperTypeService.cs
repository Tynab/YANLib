using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using YANLib.Core;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.Repositories;
using YANLib.Requests.DeveloperType;
using YANLib.Responses;
using static System.Threading.Tasks.Task;
using static YANLib.Constants.YANLibConsts.RedisConstant;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Services;

public class DeveloperTypeService(ILogger<DeveloperTypeService> logger, IDeveloperTypeRepository repository, IRedisService<RedisDtos.DeveloperTypeDto> redisService) : YANLibAppService, IDeveloperTypeService
{
    private readonly ILogger<DeveloperTypeService> _logger = logger;
    private readonly IDeveloperTypeRepository _repository = repository;
    private readonly IRedisService<RedisDtos.DeveloperTypeDto> _redisService = redisService;

    public async ValueTask<IEnumerable<DeveloperTypeResponse>> GetAll()
    {
        try
        {
            return (await _redisService.GetAll(DeveloperTypeGroup)).Select(ObjectMapper.Map<KeyValuePair<string, RedisDtos.DeveloperTypeDto>, DeveloperTypeResponse>);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAllDeveloperTypeService-Exception");

            throw;
        }
    }

    public async ValueTask<DeveloperTypeResponse> Get(long code)
    {
        try
        {
            var rslt = ObjectMapper.Map<RedisDtos.DeveloperTypeDto, DeveloperTypeResponse>(await _redisService.Get(DeveloperTypeGroup, code.ToString()));

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

    public async ValueTask<DeveloperTypeResponse> Create(DeveloperTypeCreateRequest request)
    {
        try
        {
            var dto = await _redisService.Get(DeveloperTypeGroup, request.Code.ToString());

            if (dto.IsNotNull())
            {
                throw new BusinessException(EXIST_ID).WithData("Code", request.Code);
            }

            var ent = ObjectMapper.Map<DeveloperTypeCreateRequest, DeveloperType>(request);
            var mdl = await _repository.InsertAsync(ent);

            if (mdl.IsNotNull())
            {
                _ = await _redisService.Set(DeveloperTypeGroup, mdl.Code.ToString(), ObjectMapper.Map<DeveloperType, RedisDtos.DeveloperTypeDto>(mdl));
            }

            return ObjectMapper.Map<DeveloperType, DeveloperTypeResponse>(mdl);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "CreateDeveloperTypeService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async ValueTask<DeveloperTypeResponse> Update(DeveloperTypeUpdateRequest request)
    {
        try
        {
            var mdl = await _repository.Modify(ObjectMapper.Map<(Guid Id, DeveloperTypeUpdateRequest Request), DeveloperTypeDto>(((
                await _redisService.Get(DeveloperTypeGroup, request.Code.ToString()) ?? throw new BusinessException(NOT_FOUND_DEV_TYPE).WithData("Code", request.Code)
            ).DeveloperTypeId, request)));

            if (mdl.IsNotNull())
            {
                _ = await _redisService.Set(DeveloperTypeGroup, mdl.Code.ToString(), ObjectMapper.Map<DeveloperType, RedisDtos.DeveloperTypeDto>(mdl));
            }

            return ObjectMapper.Map<DeveloperType, DeveloperTypeResponse>(mdl);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "UpdateDeveloperTypeService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async ValueTask<DeveloperTypeResponse> Delete(long code, Guid updatedBy)
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

            if (mdl.IsNotNull())
            {
                _ = await _redisService.Set(DeveloperTypeGroup, mdl.Code.ToString(), ObjectMapper.Map<DeveloperType, RedisDtos.DeveloperTypeDto>(mdl));
            }

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

            return mdls.IsNotEmptyAndNull() ? rslt && await _redisService.SetBulk(DeveloperTypeGroup, mdls.ToDictionary(x => x.Code.ToString(), ObjectMapper.Map<DeveloperType, RedisDtos.DeveloperTypeDto>)) : rslt;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDbToRedisDeveloperTypeService-Exception");

            throw;
        }
    }
}
