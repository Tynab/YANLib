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
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;
using static System.Threading.Tasks.Task;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Services.v2;

public class DeveloperService(
    ILogger<DeveloperService> logger,
    IDeveloperRepository repository,
    IDeveloperEsService esService,
    IDeveloperTypeService developerTypeService,
    ICertificateRepository certificateRepository
) : YANLibAppService, IDeveloperService
{
    private readonly ILogger<DeveloperService> _logger = logger;
    private readonly IDeveloperRepository _repository = repository;
    private readonly IDeveloperEsService _esService = esService;
    private readonly IDeveloperTypeService _developerTypeService = developerTypeService;
    private readonly ICertificateRepository _certificateRepository = certificateRepository;

    public async ValueTask<DeveloperResponse?> GetByIdCard(string idCard)
    {
        try
        {
            var dto = await _esService.Get(idCard);

            return dto.IsNull() ? default : ObjectMapper.Map<DeveloperEsIndex, DeveloperResponse>(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByIdCard-DeveloperService-Exception: {IdCard}", idCard);

            throw;
        }
    }

    public async ValueTask<DeveloperResponse?> Insert(DeveloperCreateRequest request)
    {
        try
        {
            if ((await _esService.Get(request.IdCard)).IsNotNull())
            {
                throw new BusinessException(EXIST_ID_CARD).WithData("IdCard", request.IdCard);
            }

            var entTask = _repository.InsertAsync(ObjectMapper.Map<DeveloperCreateRequest, Developer>(request));
            var devTypeTask = _developerTypeService.Get(request.DeveloperTypeCode).AsTask();

            await WhenAll(entTask, devTypeTask);

            var ent = await entTask;
            var devType = await devTypeTask;

            if (ent.IsNull())
            {
                return default;
            }

            var mdl = ObjectMapper.Map<(DeveloperTypeResponse? DeveloperType, Developer Entity), DeveloperResponse>((devType, ent));

            return await _esService.Set(ObjectMapper.Map<DeveloperResponse, DeveloperEsIndex>(mdl)) ? mdl : throw new BusinessException(INTERNAL_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Insert-DeveloperService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async ValueTask<DeveloperResponse?> Adjust(string idCard, DeveloperUpdateRequest dto)
    {
        try
        {
            var mdl = await _esService.Get(idCard) ?? throw new BusinessException(NOT_FOUND_DEV).WithData("IdCard", idCard);
            var ent = ObjectMapper.Map<DeveloperEsIndex, Developer>(mdl);

            ent.Name = dto.Name ?? ent.Name;
            ent.Phone = dto.Phone ?? ent.Phone;
            ent.IdCard = idCard;
            ent.DeveloperTypeCode = dto.DeveloperTypeCode ?? ent.DeveloperTypeCode;
            ent.IsActive = dto.IsActive ?? ent.IsActive;

            var res = await _repository.Adjust(ent);

            if (res.IsNull())
            {
                return default;
            }

            var rslt = ObjectMapper.Map<Developer, DeveloperResponse>(res);

            rslt.DeveloperType = await _developerTypeService.Get(ent.DeveloperTypeCode);

            return await _esService.Set(ObjectMapper.Map<DeveloperResponse, DeveloperEsIndex>(rslt)) ? rslt : throw new BusinessException(INTERNAL_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Adjust-DeveloperService-Exception: {IdCard} - {DTO}", idCard, dto.Serialize());

            throw;
        }
    }

    public async ValueTask<DeveloperResponse?> Delete(string idCard, Guid updatedBy)
    {
        try
        {
            var dto = await _esService.Get(idCard) ?? throw new BusinessException(NOT_FOUND_DEV).WithData("IdCard", idCard);

            var mdl = await _repository.Modify(new DeveloperDto
            {
                Id = dto.DeveloperId,
                UpdatedBy = updatedBy,
                IsDeleted = true,
            });

            if (mdl.IsNull())
            {
                return default;
            }

            _ = await _esService.Delete(idCard);

            return ObjectMapper.Map<Developer, DeveloperResponse>(mdl);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Delete-DeveloperService-Exception: {IdCard} - {UpdatedBy}", idCard, updatedBy);

            throw;
        }
    }

    public async ValueTask<List<DeveloperResponse>> GetByName(string name)
    {
        try
        {
            return ObjectMapper.Map<IEnumerable<DeveloperEsIndex>, IEnumerable<DeveloperResponse>>(await _esService.GetByName(name)).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByName-DeveloperService-Exception: {Name}", name);

            throw;
        }
    }

    public async ValueTask<List<DeveloperResponse>> GetByPhone(string phone)
    {
        try
        {
            return ObjectMapper.Map<IEnumerable<DeveloperEsIndex>, IEnumerable<DeveloperResponse>>(await _esService.GetByPhone(phone)).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByPhone-DeveloperService-Exception: {Phone}", phone);

            throw;
        }
    }

    public async ValueTask<List<DeveloperResponse>> SearchByName(string searchText)
    {
        try
        {
            return ObjectMapper.Map<IEnumerable<DeveloperEsIndex>, IEnumerable<DeveloperResponse>>(await _esService.SearchByName(searchText)).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchByName-DeveloperService-Exception: {SearchText}", searchText);

            throw;
        }
    }

    public async ValueTask<List<DeveloperResponse>> SearchByPhone(string searchText)
    {
        try
        {
            return ObjectMapper.Map<IEnumerable<DeveloperEsIndex>, IEnumerable<DeveloperResponse>>(await _esService.SearchByPhone(searchText)).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchByPhone-DeveloperService-Exception: {SearchText}", searchText);

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
            var datas = new List<DeveloperEsIndex>();
            var semSlim = new SemaphoreSlim(1);

            await WhenAll(mdls.Select(async x =>
            {
                var dto = ObjectMapper.Map<Developer, DeveloperEsIndex>(x);

                await semSlim.WaitAsync();

                try
                {
                    dto.Certificates = new List<CertificateResponse>(ObjectMapper.Map<List<Certificate>, List<CertificateResponse>>(await _certificateRepository.GetListAsync(y => y.DeveloperId == x.Id && y.IsDeleted == false)));
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
            _logger.LogError(ex, "SyncDbToEs-DeveloperService-Exception");

            throw;
        }
    }
}
