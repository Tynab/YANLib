﻿using Id_Generator_Snowflake;
using Microsoft.Extensions.Logging;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using YANLib.Core;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.EsIndices;
using YANLib.EsServices;
using YANLib.Repositories;
using YANLib.Requests.Insert;
using YANLib.Requests.Modify;
using YANLib.Responses;
using static System.Threading.Tasks.Task;
using static YANLib.YANLibConsts.SnowflakeId.DatacenterId;
using static YANLib.YANLibConsts.SnowflakeId.WorkerId;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Services;

public class CertificateService(ILogger<CertificateService> logger, ICertificateRepository repository, ICertificateEsService esService) : YANLibAppService, ICertificateService
{
    private readonly ILogger<CertificateService> _logger = logger;
    private readonly ICertificateRepository _repository = repository;
    private readonly ICertificateEsService _esService = esService;
    private readonly IdGenerator _idGenerator = new(DeveloperId, YanlibId);

    public async ValueTask<PagedResultDto<CertificateResponse>> GetAll(PagedAndSortedResultRequestDto dto)
    {
        try
        {
            var res = await _esService.GetAll(dto);

            return new(res.Total, ObjectMapper.Map<List<CertificateEsIndex>, List<CertificateResponse>>([.. res.Documents]));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAll-CertificateService-Exception: {DTO}", dto.Serialize());

            throw;
        }
    }

    public async ValueTask<CertificateResponse?> GetByCode(string code)
    {
        try
        {
            var mdl = await _esService.Get(code);

            return mdl.IsNull() ? default : ObjectMapper.Map<CertificateEsIndex, CertificateResponse>(mdl);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByCode-CertificateService-Exception: {Code}", code);

            throw;
        }
    }

    public async ValueTask<IReadOnlyCollection<CertificateResponse>> GetByName(string name)
    {
        try
        {
            return (await _esService.GetByName(name)).Select(ObjectMapper.Map<CertificateEsIndex, CertificateResponse>).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByName-CertificateService-Exception: {Name}", name);

            throw;
        }
    }

    public async ValueTask<IReadOnlyCollection<CertificateResponse>> SearchByName(string searchText)
    {
        try
        {
            return (await _esService.SearchByName(searchText)).Select(ObjectMapper.Map<CertificateEsIndex, CertificateResponse>).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchByName-CertificateService-Exception: {SearchText}", searchText);

            throw;
        }
    }

    public async ValueTask<CertificateResponse?> Insert(CertificateInsertRequest request)
    {
        try
        {
            var ent = await _repository.InsertAsync(ObjectMapper.Map<(string Code, CertificateInsertRequest Request), Certificate>((_idGenerator.NextIdAlphabetic(), request)));

            return ent.IsNotNull() && await _esService.Set(ObjectMapper.Map<Certificate, CertificateEsIndex>(ent))
                ? ObjectMapper.Map<Certificate, CertificateResponse>(ent)
                : throw new EntityNotFoundException(typeof(CertificateResponse));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Insert-CertificateService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async ValueTask<CertificateResponse?> Modify(string code, CertificateModifyRequest request)
    {
        try
        {
            var dto = await _esService.Get(code) ?? throw new BusinessException(NOT_FOUND_DEV).WithData("Code", code);
            var ent = await _repository.Modify(ObjectMapper.Map<(Guid Id, CertificateModifyRequest Request), CertificateDto>((dto.CertificateId, request)));

            return ent.IsNotNull() && await _esService.Set(ObjectMapper.Map<Certificate, CertificateEsIndex>(ent))
                ? ObjectMapper.Map<Certificate, CertificateResponse>(ent)
                : throw new EntityNotFoundException(typeof(CertificateResponse), dto.CertificateId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Modify-CertificateService-Exception: {Code} - {Dto}", code, request.Serialize());

            throw;
        }
    }

    public async ValueTask<bool> Delete(string code, Guid updatedBy)
    {
        try
        {
            return (await _repository.Modify(new CertificateDto
            {
                Id = (await _esService.Get(code) ?? throw new BusinessException(NOT_FOUND_DEV).WithData("Code", code)).CertificateId,
                UpdatedBy = updatedBy,
                IsDeleted = true,
            })).IsNotNull() && await _esService.Delete(code);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Delete-CertificateService-Exception: {Code} - {UpdatedBy}", code, updatedBy);

            throw;
        }
    }

    public async ValueTask<bool> SyncDbToEs()
    {
        try
        {
            var clnTask = _esService.DeleteAll().AsTask();
            var mdlsTask = _repository.GetListAsync(x => x.IsDeleted == false);

            await WhenAll(clnTask, mdlsTask);

            var rslt = await clnTask;
            var mdls = await mdlsTask;
            var datas = new List<CertificateEsIndex>();
            var semSlim = new SemaphoreSlim(1);

            await WhenAll(mdls.Select(async x =>
            {
                var dto = ObjectMapper.Map<Certificate, CertificateEsIndex>(x);

                await semSlim.WaitAsync();

                try
                {
                    datas.Add(dto);
                }
                finally
                {
                    _ = semSlim.Release();
                }
            }));

            return mdls.IsEmptyOrNull() ? rslt : rslt && await _esService.SetBulk(datas);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDbToEs-CertificateService-Exception");

            throw;
        }
    }
}
