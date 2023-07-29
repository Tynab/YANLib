using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YANLib.Application.Redis.Services;
using YANLib.Dtos;
using YANLib.Models;
using YANLib.Repositories;
using YANLib.Requests;
using YANLib.Responses;
using static YANLib.Common.RedisConstant;

namespace YANLib.Services;

public class DeveloperTypeService : YANLibAppService, IDeveloperTypeService
{
    #region Fields
    private readonly ILogger<DeveloperTypeService> _logger;
    private readonly IDeveloperTypeRepository _repository;
    private readonly IRedisService<DeveloperTypeRedisDto> _redisService;
    #endregion

    #region Constructors
    public DeveloperTypeService(ILogger<DeveloperTypeService> logger, IDeveloperTypeRepository repository, IRedisService<DeveloperTypeRedisDto> redisService)
    {
        _logger = logger;
        _repository = repository;
        _redisService = redisService;
    }
    #endregion

    #region Implements
    public async ValueTask<List<DeveloperTypeResponse>> GetAll()
    {
        try
        {
            return (await _redisService.GetAll(DEV_TYPE_GRP)).Select(ObjectMapper.Map<KeyValuePair<string, DeveloperTypeRedisDto>, DeveloperTypeResponse>).ToList();
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
            var rslt = ObjectMapper.Map<DeveloperTypeRedisDto, DeveloperTypeResponse>(await _redisService.Get(DEV_TYPE_GRP, code.ToString()));

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

    public async ValueTask<DeveloperTypeResponse> Insert(DeveloperTypeRequest request)
    {
        try
        {
            var mdl = await _repository.Insert(ObjectMapper.Map<DeveloperTypeRequest, DeveloperType>(request));

            if (mdl is not null)
            {
                await _redisService.Set(DEV_TYPE_GRP, mdl.Code.ToString(), ObjectMapper.Map<DeveloperType, DeveloperTypeRedisDto>(mdl));
            }

            return ObjectMapper.Map<DeveloperType, DeveloperTypeResponse>(mdl);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "InsertDeveloperTypeService-Exception: {Request}", request.CamelSerialize());
            throw;
        }
    }

    public async ValueTask<DeveloperTypeResponse> Update(DeveloperTypeRequest request)
    {
        try
        {
            var mdl = await _repository.Update(ObjectMapper.Map<DeveloperTypeRequest, DeveloperType>(request));

            if (mdl is not null)
            {
                await _redisService.Set(DEV_TYPE_GRP, mdl.Code.ToString(), ObjectMapper.Map<DeveloperType, DeveloperTypeRedisDto>(mdl));
            }

            return ObjectMapper.Map<DeveloperType, DeveloperTypeResponse>(mdl);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "UpdateDeveloperTypeService-Exception: {Request}", request.CamelSerialize());
            throw;
        }
    }

    public async ValueTask<bool> SyncDbToRedis()
    {
        try
        {
            var task = _redisService.DeleteAll(DEV_TYPE_GRP);
            var mdls = await _repository.GetAll();
            var rslt = await task;

            return mdls.IsNotEmptyAndNull() ? rslt && await _redisService.SetBulk(DEV_TYPE_GRP, mdls.ToDictionary(x => x.Code.ToString(), ObjectMapper.Map<DeveloperType, DeveloperTypeRedisDto>)) : rslt;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDbToRedisDeveloperTypeService-Exception");
            throw;
        }
    }
    #endregion
}
