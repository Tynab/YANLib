using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.EsIndices;
using YANLib.Repositories;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;
using static System.Threading.Tasks.Task;
using static YANLib.YANLibConsts;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Services.v2;

public class DeveloperService(
    ILogger<DeveloperService> logger,
    IDeveloperRepository repository,
    IEsService<DeveloperEsIndex> esService,
    IDeveloperTypeService developerTypeService,
    IProjectRepository projectRepository
) : YANLibAppService, IDeveloperService
{
    private readonly ILogger<DeveloperService> _logger = logger;
    private readonly IDeveloperRepository _repository = repository;
    private readonly IEsService<DeveloperEsIndex> _esService = esService;
    private readonly IDeveloperTypeService _developerTypeService = developerTypeService;
    private readonly IProjectRepository _projectRepository = projectRepository;

    public async ValueTask<PagedResultDto<DeveloperResponse>> GetAll(PagedAndSortedResultRequestDto input)
    {
        try
        {
            return ObjectMapper.Map<PagedResultDto<DeveloperEsIndex>, PagedResultDto<DeveloperResponse>>(await _esService.GetAll(input));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAll-DeveloperService-Exception: {Input}", input.Serialize());

            throw;
        }
    }

    public async ValueTask<DeveloperResponse?> Get(Guid id)
    {
        try
        {
            var dto = await _esService.Get(id);

            return dto.IsNull() ? throw new EntityNotFoundException(typeof(DeveloperEsIndex), id) : ObjectMapper.Map<DeveloperEsIndex, DeveloperResponse>(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Get-DeveloperService-Exception: {Id}", id);

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

            var entityTask = _repository.InsertAsync(ObjectMapper.Map<DeveloperCreateRequest, Developer>(request));
            var devTypeTask = _developerTypeService.Get(request.DeveloperTypeCode).AsTask();

            _ = await WhenAny(entityTask, devTypeTask);

            var entity = await entityTask;

            if (entity.IsNull())
            {
                throw new BusinessException(SQL_SERVER_ERROR);
            }

            var result = ObjectMapper.Map<(DeveloperTypeResponse? DeveloperType, Developer Entity), DeveloperResponse>((await devTypeTask, entity));

            return await _esService.Set(ObjectMapper.Map<DeveloperResponse, DeveloperEsIndex>(result)) ? result : throw new BusinessException(ES_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Insert-DeveloperService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async ValueTask<DeveloperResponse?> Adjust(string idCard, DeveloperUpdateRequest request)
    {
        try
        {
            var dto = await _esService.Get(idCard) ?? throw new EntityNotFoundException(typeof(DeveloperEsIndex));
            var model = ObjectMapper.Map<DeveloperEsIndex, Developer>(dto);

            model.Name = request.Name ?? model.Name;
            model.Phone = request.Phone ?? model.Phone;
            model.IdCard = idCard;
            model.DeveloperTypeCode = request.DeveloperTypeCode ?? model.DeveloperTypeCode;
            model.IsActive = request.IsActive ?? model.IsActive;

            var entity = await _repository.Adjust(model);

            if (entity.IsNull())
            {
                throw new BusinessException(SQL_SERVER_ERROR);
            }

            var result = ObjectMapper.Map<Developer, DeveloperResponse>(entity);

            result.DeveloperType = await _developerTypeService.Get(model.DeveloperTypeCode);

            return await _esService.Set(ObjectMapper.Map<DeveloperResponse, DeveloperEsIndex>(result)) ? result : throw new BusinessException(ES_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Adjust-DeveloperService-Exception: {IdCard} - {Request}", idCard, request.Serialize());

            throw;
        }
    }

    public async ValueTask<bool> Delete(string idCard, Guid updatedBy)
    {
        try
        {
            var dto = await _esService.Get(idCard) ?? throw new EntityNotFoundException(typeof(DeveloperEsIndex));

            return (await _repository.Modify(new DeveloperDto
            {
                Id = dto.Id.Parse<Guid>(),
                UpdatedBy = updatedBy,
                IsDeleted = true,
            })).IsNull() ? throw new BusinessException(SQL_SERVER_ERROR) : await _esService.Delete(idCard);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Delete-DeveloperService-Exception: {IdCard} - {UpdatedBy}", idCard, updatedBy);

            throw;
        }
    }

    public async ValueTask<bool> SyncDbToEs()
    {
        try
        {
            var cleanTask = _esService.DeleteAll(ElasticsearchIndex.Developer).AsTask();
            var entitiesTask = _repository.GetListAsync(x => !x.IsDeleted);

            _ = await WhenAny(cleanTask, entitiesTask);

            var result = await cleanTask;
            var entities = await entitiesTask;

            if (entities.IsNullEmpty())
            {
                return result;
            }

            var datas = new List<DeveloperEsIndex>();
            var ss = new SemaphoreSlim(1);

            await WhenAll(entities.Select(async x =>
            {
                var dto = ObjectMapper.Map<Developer, DeveloperEsIndex>(x);

                await ss.WaitAsync();

                try
                {
                    //dto.Certificates = new List<CertificateResponse>(ObjectMapper.Map<List<Certificate>, List<CertificateResponse>>(await _certificateRepository.GetListAsync(y => y.DeveloperId == x.Id && y.IsDeleted == false)));
                    datas.Add(dto);
                }
                finally
                {
                    _ = ss.Release();
                }
            }));

            return result && await _esService.SetBulk(datas, ElasticsearchIndex.Developer);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDbToEs-DeveloperService-Exception");

            throw;
        }
    }
}
