using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using YANLib.Application.Redis.Services;
using YANLib.Entities;
using YANLib.RedisDtos;
using YANLib.Requests.DeveloperType;
using YANLib.Responses;
using static System.DateTime;
using static System.Threading.Tasks.Task;
using static YANLib.YANLibConsts.RedisConstant;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Services;

public class DeveloperTypeService(
    ILogger<DeveloperTypeService> logger,
    IRepository<DeveloperType, int> repository,
    IRedisService<DeveloperTypeRedisDto> redisService
) : YANLibAppService, IDeveloperTypeService
{
    #region Fields
    private readonly ILogger<DeveloperTypeService> _logger = logger;
    private readonly IRepository<DeveloperType, int> _repository = repository;
    private readonly IRedisService<DeveloperTypeRedisDto> _redisService = redisService;
    #endregion

    #region Implements
    public async ValueTask<List<DeveloperTypeResponse>> GetAll()
    {
        try
        {
            return (await _redisService.GetAll(DeveloperTypeGroup)).Select(ObjectMapper.Map<KeyValuePair<string, DeveloperTypeRedisDto>, DeveloperTypeResponse>).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAllDeveloperTypeService-Exception");
            throw;
        }
    }

    public async ValueTask<DeveloperTypeResponse> Get(int code)
    {
        try
        {
            var rslt = ObjectMapper.Map<DeveloperTypeRedisDto, DeveloperTypeResponse>(await _redisService.Get(DeveloperTypeGroup, code.ToString()));

            if (rslt is not null)
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

            if (dto is not null)
            {
                throw new BusinessException(EXIST_ID).WithData("Code", request.Code);
            }

            var ent = ObjectMapper.Map<DeveloperTypeCreateRequest, DeveloperType>(request);

            ent.CreatedAt = Now;

            var mdl = await _repository.InsertAsync(ent);

            if (mdl is not null)
            {
                _ = await _redisService.Set(DeveloperTypeGroup, mdl.Id.ToString(), ObjectMapper.Map<DeveloperType, DeveloperTypeRedisDto>(mdl));
            }

            return ObjectMapper.Map<DeveloperType, DeveloperTypeResponse>(mdl);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "CreateDeveloperTypeService-Exception: {Request}", request.Serialize());
            throw;
        }
    }

    public async ValueTask<DeveloperTypeResponse> Update(int code, DeveloperTypeUpdateRequest request)
    {
        try
        {
            var dto = await _redisService.Get(DeveloperTypeGroup, code.ToString()) ?? throw new BusinessException(NOT_FOUND_DEV_TYPE).WithData("Code", code);

            request.Name = request.Name.IsWhiteSpaceOrNull() ? dto.Name : request.Name;
            request.IsActive ??= dto.IsActive;

            var ent = ObjectMapper.Map<(int, DeveloperTypeUpdateRequest), DeveloperType>((code, request));

            ent.CreatedAt = dto.CreatedAt;
            ent.UpdatedAt = Now;

            var mdl = await _repository.UpdateAsync(ent);

            if (mdl is not null)
            {
                _ = await _redisService.Set(DeveloperTypeGroup, mdl.Id.ToString(), ObjectMapper.Map<DeveloperType, DeveloperTypeRedisDto>(mdl));
            }

            return ObjectMapper.Map<DeveloperType, DeveloperTypeResponse>(mdl);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "UpdateDeveloperTypeService-Exception: {Request}", request.Serialize());
            throw;
        }
    }

    public async ValueTask<bool> SyncDbToRedis()
    {
        try
        {
            var clnTask = _redisService.DeleteAll(DeveloperTypeGroup).AsTask();
            var mdlsTask = _repository.GetListAsync();

            await WhenAll(clnTask, mdlsTask);

            var rslt = await clnTask;
            var mdls = await mdlsTask;

            return mdls.IsNotEmptyAndNull() ? rslt && await _redisService.SetBulk(DeveloperTypeGroup, mdls.ToDictionary(x => x.Id.ToString(), ObjectMapper.Map<DeveloperType, DeveloperTypeRedisDto>)) : rslt;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDbToRedisDeveloperTypeService-Exception");
            throw;
        }
    }
    #endregion
}
