using Id_Generator_Snowflake;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
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

    public async ValueTask<CertificateResponse?> Insert(CertificateInsertRequest request)
    {
        try
        {
            var dto = ObjectMapper.Map<CertificateInsertRequest, Certificate>(request);

            dto.Code = _idGenerator.NextIdAlphabetic();

            var ent = await _repository.InsertAsync(dto);

            return ent.IsNull()
                ? default
                : await _esService.Set(ObjectMapper.Map<Certificate, CertificateEsIndex>(ent))
                ? ObjectMapper.Map<Certificate, CertificateResponse>(ent)
                : throw new BusinessException(INTERNAL_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Insert-CertificateService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async ValueTask<CertificateResponse?> Modify(string code, CertificateModifyRequest dto)
    {
        try
        {
            _ = await _esService.Get(code) ?? throw new BusinessException(NOT_FOUND_DEV).WithData("Code", code);

            var ent = await _repository.Modify(ObjectMapper.Map<CertificateModifyRequest, CertificateDto>(dto));

            return ent.IsNull()
                ? default
                : await _esService.Set(ObjectMapper.Map<Certificate, CertificateEsIndex>(ent))
                ? ObjectMapper.Map<Certificate, CertificateResponse>(ent)
                : throw new BusinessException(INTERNAL_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Modify-CertificateService-Exception: {Code} - {Dto}", code, dto.Serialize());

            throw;
        }
    }

    public async ValueTask<CertificateResponse?> Delete(string code, Guid updatedBy)
    {
        try
        {
            var mdl = await _esService.Get(code) ?? throw new BusinessException(NOT_FOUND_DEV).WithData("Code", code);

            var ent = await _repository.Modify(new CertificateDto
            {
                Id = mdl.CertificateId,
                UpdatedBy = updatedBy,
                IsDeleted = true,
            });

            if (ent.IsNull())
            {
                return default;
            }

            _ = await _esService.Delete(code);

            return ObjectMapper.Map<Certificate, CertificateResponse>(ent);
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
