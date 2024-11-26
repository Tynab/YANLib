using Id_Generator_Snowflake;
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
            _logger.LogError(ex, "Get-CertificateService-Exception: {Id}", id);

            throw;
        }
    }

    public async ValueTask<PagedResultDto<CertificateResponse>> GetByName(PagedAndSortedResultRequestDto input, string name)
    {
        try
        {
            return ObjectMapper.Map<PagedResultDto<CertificateEsIndex>, PagedResultDto<CertificateResponse>>(await _esService.SearchWithKeywords(input, name, nameof(CertificateEsIndex.Name)));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByName-CertificateService-Exception: {Input} - {Name}", input.Serialize(), name);

            throw;
        }
    }

    public async ValueTask<PagedResultDto<CertificateResponse>> SearchNameByText(PagedAndSortedResultRequestDto input, string searchString)
    {
        try
        {
            return ObjectMapper.Map<PagedResultDto<CertificateEsIndex>, PagedResultDto<CertificateResponse>>(await _esService.SearchWithWildcard(input, searchString, nameof(CertificateEsIndex.Name)));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchNameByText-CertificateService-Exception: {Input} - {SearchString}", input.Serialize(), searchString);

            throw;
        }
    }
    
    public async ValueTask<PagedResultDto<CertificateResponse>> SearchDescriptionByText(PagedAndSortedResultRequestDto input, string searchString)
    {
        try
        {
            return ObjectMapper.Map<PagedResultDto<CertificateEsIndex>, PagedResultDto<CertificateResponse>>(await _esService.SearchWithPhrasePrefix(input, searchString, nameof(CertificateEsIndex.Description)));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchDescriptionByText-CertificateService-Exception: {Input} - {SearchString}", input.Serialize(), searchString);

            throw;
        }
    }
    
    public async ValueTask<PagedResultDto<CertificateResponse>> SearchDescriptionByWords(PagedAndSortedResultRequestDto input, string searchWords)
    {
        try
        {
            return ObjectMapper.Map<PagedResultDto<CertificateEsIndex>, PagedResultDto<CertificateResponse>>(await _esService.SearchWithExactPhrase(input, searchWords, nameof(CertificateEsIndex.Name), nameof(CertificateEsIndex.Description)));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchDescriptionByWords-CertificateService-Exception: {Input} - {SearchWords}", input.Serialize(), searchWords);

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
