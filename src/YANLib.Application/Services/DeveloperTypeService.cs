using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YANLib.Application.Redis.Services;
using YANLib.Entities;
using YANLib.RedisDtos;
using YANLib.Repositories;
using YANLib.Requests;
using YANLib.Responses;
using static YANLib.YANLibConsts.RedisConstant;

namespace YANLib.Services;

public class DeveloperTypeService : YANLibAppService, IDeveloperTypeService
{
    #region Fields
    private readonly ILogger<DeveloperTypeService> _logger;
    private readonly IDeveloperTypeRepository _repository;
    private readonly IRedisService<DeveloperTypeDto> _redisService;
    #endregion

    #region Constructors
    public DeveloperTypeService(
        ILogger<DeveloperTypeService> logger,
        IDeveloperTypeRepository repository,
        IRedisService<DeveloperTypeDto> redisService
        )
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
            return (await _redisService.GetAll(DeveloperTypeGroup)).Select(ObjectMapper.Map<KeyValuePair<string, DeveloperTypeDto>, DeveloperTypeResponse>).ToList();
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
            var rslt = ObjectMapper.Map<DeveloperTypeDto, DeveloperTypeResponse>(await _redisService.Get(DeveloperTypeGroup, code.ToString()));

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
                await _redisService.Set(DeveloperTypeGroup, mdl.Code.ToString(), ObjectMapper.Map<DeveloperType, DeveloperTypeDto>(mdl));
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
                await _redisService.Set(DeveloperTypeGroup, mdl.Code.ToString(), ObjectMapper.Map<DeveloperType, DeveloperTypeDto>(mdl));
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
            var task = _redisService.DeleteAll(DeveloperTypeGroup);
            var mdls = await _repository.GetAll();
            var rslt = await task;

            return mdls.IsNotEmptyAndNull() ? rslt && await _redisService.SetBulk(DeveloperTypeGroup, mdls.ToDictionary(x => x.Code.ToString(), ObjectMapper.Map<DeveloperType, DeveloperTypeDto>)) : rslt;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDbToRedisDeveloperTypeService-Exception");
            throw;
        }
    }
    #endregion
}
