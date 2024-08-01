﻿using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using YANLib.Entities;
using YANLib.Requests.DeveloperType;
using YANLib.Responses;

namespace YANLib.CrudService;

public class DeveloperTypeService(IRepository<DeveloperType, Guid> repository)
    : CrudAppService<DeveloperType, DeveloperTypeResponse, Guid, PagedAndSortedResultRequestDto, DeveloperTypeCreateRequest, DeveloperTypeUpdateRequest>(repository), IDeveloperTypeService
{ }
//    ILogger<DeveloperTypeService> logger,
//    IRepository<DeveloperType, int> repository,
//    IRedisService<DeveloperTypeDto> redisService
//) : YANLibAppService, IDeveloperTypeService
//{
//    private readonly ILogger<DeveloperTypeService> _logger = logger;
//    private readonly IRepository<DeveloperType, int> _repository = repository;
//    private readonly IRedisService<DeveloperTypeDto> _redisService = redisService;

//    public async ValueTask<List<DeveloperTypeResponse>> GetAll()
//    {
//        try
//        {
//            return (await _redisService.GetAll(DeveloperTypeGroup)).Select(ObjectMapper.Map<KeyValuePair<string, DeveloperTypeDto>, DeveloperTypeResponse>).ToList();
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, "GetAllDeveloperTypeService-Exception");

//            throw;
//        }
//    }

//    public async ValueTask<DeveloperTypeResponse> Get(int code)
//    {
//        try
//        {
//            var rslt = ObjectMapper.Map<DeveloperTypeDto, DeveloperTypeResponse>(await _redisService.Get(DeveloperTypeGroup, code.ToString()));

//            if (rslt is not null)
//            {
//                rslt.Code = code;
//            }

//            return rslt;
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, "GetDeveloperTypeService-Exception: {Code}", code);

//            throw;
//        }
//    }

//    public async ValueTask<DeveloperTypeResponse> Create(DeveloperTypeCreateRequest request)
//    {
//        try
//        {
//            var dto = await _redisService.Get(DeveloperTypeGroup, request.Code.ToString());

//            if (dto is not null)
//            {
//                throw new BusinessException(EXIST_ID).WithData("Code", request.Code);
//            }

//            var ent = ObjectMapper.Map<DeveloperTypeCreateRequest, DeveloperType>(request);

//            ent.CreatedAt = Now;

//            var mdl = await _repository.InsertAsync(ent);

//            if (mdl is not null)
//            {
//                _ = await _redisService.Set(DeveloperTypeGroup, mdl.Id.ToString(), ObjectMapper.Map<DeveloperType, DeveloperTypeDto>(mdl));
//            }

//            return ObjectMapper.Map<DeveloperType, DeveloperTypeResponse>(mdl);
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, "CreateDeveloperTypeService-Exception: {Request}", request.Serialize());

//            throw;
//        }
//    }

//    public async ValueTask<DeveloperTypeResponse> Update(int code, DeveloperTypeUpdateRequest request)
//    {
//        try
//        {
//            var dto = await _redisService.Get(DeveloperTypeGroup, code.ToString()) ?? throw new BusinessException(NOT_FOUND_DEV_TYPE).WithData("Code", code);

//            request.Name = request.Name.IsWhiteSpaceOrNull() ? dto.Name : request.Name;
//            request.IsActive ??= dto.IsActive;

//            var ent = ObjectMapper.Map<(int, DeveloperTypeUpdateRequest), DeveloperType>((code, request));

//            ent.CreatedAt = dto.CreatedAt;
//            ent.UpdatedAt = Now;

//            var mdl = await _repository.UpdateAsync(ent);

//            if (mdl is not null)
//            {
//                _ = await _redisService.Set(DeveloperTypeGroup, mdl.Id.ToString(), ObjectMapper.Map<DeveloperType, DeveloperTypeDto>(mdl));
//            }

//            return ObjectMapper.Map<DeveloperType, DeveloperTypeResponse>(mdl);
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, "UpdateDeveloperTypeService-Exception: {Request}", request.Serialize());

//            throw;
//        }
//    }

//    public async ValueTask<bool> SyncDbToRedis()
//    {
//        try
//        {
//            var clnTask = _redisService.DeleteAll(DeveloperTypeGroup).AsTask();
//            var mdlsTask = _repository.GetListAsync();

//            await WhenAll(clnTask, mdlsTask);

//            var rslt = await clnTask;
//            var mdls = await mdlsTask;

//            return mdls.IsNotEmptyAndNull() ? rslt && await _redisService.SetBulk(DeveloperTypeGroup, mdls.ToDictionary(x => x.Id.ToString(), ObjectMapper.Map<DeveloperType, DeveloperTypeDto>)) : rslt;
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, "SyncDbToRedisDeveloperTypeService-Exception");

//            throw;
//        }
//    }
//}