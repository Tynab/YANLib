﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using YANLib.Application.Redis.Services;
using YANLib.Entities;
using YANLib.RedisDtos;
using YANLib.Requests;
using YANLib.Responses;
using static System.DateTime;
using static YANLib.YANLibConsts.RedisConstant;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Services;

public class DeveloperTypeService : YANLibAppService, IDeveloperTypeService
{
    #region Fields
    private readonly ILogger<DeveloperTypeService> _logger;
    private readonly IRepository<DeveloperType, int> _repository;
    private readonly IRedisService<DeveloperTypeDto> _redisService;
    #endregion

    #region Constructors
    public DeveloperTypeService(
        ILogger<DeveloperTypeService> logger,
        IRepository<DeveloperType, int> repository,
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
            var dto = await _redisService.Get(DeveloperTypeGroup, request.Code.ToString());

            if (dto is not null)
            {
                throw new BusinessException(EXIST_ID).WithData("Code", request.Code);
            }

            var ent = ObjectMapper.Map<DeveloperTypeRequest, DeveloperType>(request);

            ent.CreatedDate = Now;

            var mdl = await _repository.InsertAsync(ent);

            if (mdl is not null)
            {
                await _redisService.Set(DeveloperTypeGroup, mdl.Id.ToString(), ObjectMapper.Map<DeveloperType, DeveloperTypeDto>(mdl));
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
            var dto = await _redisService.Get(DeveloperTypeGroup, request.Code.ToString()) ?? throw new BusinessException(NOT_FOUND_DEV_TYPE).WithData("Code", request.Code);
            var ent = ObjectMapper.Map<DeveloperTypeRequest, DeveloperType>(request);

            ent.CreatedDate = dto.CreatedDate;
            ent.ModifiedDate = Now;

            var mdl = await _repository.UpdateAsync(ent);

            if (mdl is not null)
            {
                await _redisService.Set(DeveloperTypeGroup, mdl.Id.ToString(), ObjectMapper.Map<DeveloperType, DeveloperTypeDto>(mdl));
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
            var mdls = await _repository.GetListAsync();
            var rslt = await task;

            return mdls.IsNotEmptyAndNull() ? rslt && await _redisService.SetBulk(DeveloperTypeGroup, mdls.ToDictionary(x => x.Id.ToString(), ObjectMapper.Map<DeveloperType, DeveloperTypeDto>)) : rslt;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDbToRedisDeveloperTypeService-Exception");
            throw;
        }
    }
    #endregion
}
