using Id_Generator_Snowflake;
using Microsoft.Extensions.Logging;
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
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;
using static System.Threading.Tasks.Task;
using static YANLib.YANLibConsts.SnowflakeId.DatacenterId;
using static YANLib.YANLibConsts.SnowflakeId.WorkerId;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Services.v2;

public class CertificateService(ILogger<CertificateService> logger, ICertificateRepository repository, ICertificateEsService esService) : YANLibAppService, ICertificateService
{
    private readonly ILogger<CertificateService> _logger = logger;
    private readonly ICertificateRepository _repository = repository;
    private readonly ICertificateEsService _esService = esService;
    private readonly IdGenerator _idGenerator = new(DeveloperId, YanlibId);

    public async ValueTask<PagedResultDto<CertificateResponse>> GetAll(PagedAndSortedResultRequestDto input)
    {
        try
        {
            return ObjectMapper.Map<PagedResultDto<CertificateEsIndex>, PagedResultDto<CertificateResponse>>(await _esService.GetAll(input));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAll-CertificateService-Exception: {Input}", input.Serialize());

            throw;
        }
    }

    public async ValueTask<CertificateResponse?> Get(string id)
    {
        try
        {
            var dto = await _esService.Get(id);

            return dto.IsNull() ? default : ObjectMapper.Map<CertificateEsIndex, CertificateResponse>(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByCode-CertificateService-Exception: {Id}", id);

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

    public async ValueTask<CertificateResponse?> Insert(CertificateCreateRequest request)
    {
        try
        {
            var entity = await _repository.InsertAsync(ObjectMapper.Map<(string Id, CertificateCreateRequest Request), Certificate>((_idGenerator.NextIdAlphabetic(), request)));

            return entity.IsNotNull() && await _esService.Set(ObjectMapper.Map<Certificate, CertificateEsIndex>(entity))
                ? ObjectMapper.Map<Certificate, CertificateResponse>(entity)
                : throw new EntityNotFoundException(typeof(Certificate));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Insert-CertificateService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async ValueTask<CertificateResponse?> Modify(string id, CertificateUpdateRequest request)
    {
        try
        {
            var dto = await _esService.Get(id) ?? throw new EntityNotFoundException(typeof(CertificateEsIndex), id);
            var entity = await _repository.Modify(ObjectMapper.Map<(string Id, CertificateUpdateRequest Request), CertificateDto>((id, request)));

            return entity.IsNotNull() && await _esService.Set(ObjectMapper.Map<Certificate, CertificateEsIndex>(entity))
                ? ObjectMapper.Map<Certificate, CertificateResponse>(entity)
                : throw new EntityNotFoundException(typeof(Certificate), id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Modify-CertificateService-Exception: {Id} - {Dto}", id, request.Serialize());

            throw;
        }
    }

    public async ValueTask<bool> Delete(string id, Guid updatedBy)
    {
        try
        {
            return (await _repository.Modify(new CertificateDto
            {
                Id = (await _esService.Get(id) ?? throw new EntityNotFoundException(typeof(CertificateEsIndex), id)).Id,
                UpdatedBy = updatedBy,
                IsDeleted = true,
            })).IsNotNull() && await _esService.Delete(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Delete-CertificateService-Exception: {Id} - {UpdatedBy}", id, updatedBy);

            throw;
        }
    }

    public async ValueTask<bool> SyncDbToEs()
    {
        try
        {
            var cleanTask = _esService.DeleteAll().AsTask();
            var entitiesTask = _repository.GetListAsync(x => !x.IsDeleted);

            await WhenAll(cleanTask, entitiesTask);

            var result = await cleanTask;
            var entities = await entitiesTask;
            var datas = new List<CertificateEsIndex>();
            var semaphoreSlim = new SemaphoreSlim(1);

            await WhenAll(entities.Select(async x =>
            {
                var dto = ObjectMapper.Map<Certificate, CertificateEsIndex>(x);

                await semaphoreSlim.WaitAsync();

                try
                {
                    datas.Add(dto);
                }
                finally
                {
                    _ = semaphoreSlim.Release();
                }
            }));

            return entities.IsEmptyOrNull() ? result : result && await _esService.SetBulk(datas);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDbToEs-CertificateService-Exception");

            throw;
        }
    }
}
