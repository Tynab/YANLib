using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using YANLib.Domains;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.EsIndices;
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
    IElasticsearchService<DeveloperEsIndex> esService,
    IDeveloperTypeService developerTypeService,
    IProjectRepository projectRepository
) : YANLibAppService, IDeveloperService
{
    private readonly ILogger<DeveloperService> _logger = logger;
    private readonly IDeveloperRepository _repository = repository;
    private readonly IElasticsearchService<DeveloperEsIndex> _esService = esService;
    private readonly IDeveloperTypeService _developerTypeService = developerTypeService;
    private readonly IProjectRepository _projectRepository = projectRepository;

    public async Task<PagedResultDto<DeveloperResponse>> GetAllAsync(PagedAndSortedResultRequestDto input, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return ObjectMapper.Map<PagedResultDto<DeveloperEsIndex>, PagedResultDto<DeveloperResponse>>(await _esService.GetAllAsync(input, cancellationToken));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAllAsync-DeveloperService-Exception: {Input}", input.Serialize());

            throw;
        }
    }

    public async Task<DeveloperResponse?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var dto = await _esService.GetAsync(id, cancellationToken);

            return dto.IsNull() ? throw new EntityNotFoundException(typeof(DeveloperEsIndex), id) : ObjectMapper.Map<DeveloperEsIndex, DeveloperResponse>(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAsync-DeveloperService-Exception: {Id}", id);

            throw;
        }
    }

    public async Task<DeveloperResponse?> InsertAsync(DeveloperCreateRequest request, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            if ((await _esService.GetAsync(request.IdCard, cancellationToken)).IsNotNull())
            {
                throw new BusinessException(EXIST_ID_CARD).WithData("IdCard", request.IdCard);
            }

            var entityTask = _repository.InsertAsync(ObjectMapper.Map<DeveloperCreateRequest, Developer>(request), cancellationToken: cancellationToken);
            var devTypeTask = _developerTypeService.GetAsync(request.DeveloperTypeCode, cancellationToken);

            _ = await WhenAny(entityTask, devTypeTask);

            var entity = await entityTask;

            if (entity.IsNull())
            {
                throw new BusinessException(SQL_SERVER_ERROR);
            }

            var result = ObjectMapper.Map<(DeveloperTypeResponse? DeveloperType, Developer Entity), DeveloperResponse>((await devTypeTask, entity));

            return await _esService.SetAsync(ObjectMapper.Map<DeveloperResponse, DeveloperEsIndex>(result), cancellationToken) ? result : throw new BusinessException(ES_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "InsertAsync-DeveloperService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async Task<DeveloperResponse?> AdjustAsync(string idCard, DeveloperUpdateRequest request, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var entity = await _repository.AdjustAsync(ObjectMapper.Map<DeveloperUpdateRequest, Developer>(request), cancellationToken);

            if (entity.IsNull())
            {
                throw new BusinessException(SQL_SERVER_ERROR);
            }

            var result = ObjectMapper.Map<Developer, DeveloperResponse>(entity);

            result.DeveloperType = await _developerTypeService.GetAsync(entity.DeveloperTypeCode, cancellationToken);

            return await _esService.SetAsync(ObjectMapper.Map<DeveloperResponse, DeveloperEsIndex>(result), cancellationToken) ? result : throw new BusinessException(ES_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "AdjustAsync-DeveloperService-Exception: {IdCard} - {Request}", idCard, request.Serialize());

            throw;
        }
    }

    public async Task<bool> DeleteAsync(string idCard, Guid updatedBy, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var dto = await _esService.GetAsync(idCard, cancellationToken) ?? throw new EntityNotFoundException(typeof(DeveloperEsIndex));

            return (await _repository.ModifyAsync(new DeveloperDto
            {
                Id = dto.Id.Parse<Guid>(),
                UpdatedBy = updatedBy,
                IsDeleted = true,
            }, cancellationToken)).IsNull() ? throw new BusinessException(SQL_SERVER_ERROR) : await _esService.DeleteAsync(idCard, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteAsync-DeveloperService-Exception: {IdCard} - {UpdatedBy}", idCard, updatedBy);

            throw;
        }
    }

    public async Task<bool> SyncDataToElasticsearchAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var cleanTask = _esService.DeleteAllAsync(ElasticsearchIndex.Developer, cancellationToken);
            var entitiesTask = _repository.GetListAsync(x => !x.IsDeleted, cancellationToken: cancellationToken);

            _ = await WhenAny(cleanTask, entitiesTask);

            var result = await cleanTask;
            var entities = await entitiesTask;

            if (entities.IsNullEmpty())
            {
                return result;
            }

            var datas = new List<DeveloperEsIndex>();
            var slim = new SemaphoreSlim(1);

            await WhenAll(entities.Select(async x =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                var dto = ObjectMapper.Map<Developer, DeveloperEsIndex>(x);

                await slim.WaitAsync(cancellationToken);

                try
                {
                    //dto.Certificates = new List<CertificateResponse>(ObjectMapper.Map<List<Certificate>, List<CertificateResponse>>(await _certificateRepository.GetListAsync(y => y.DeveloperId == x.Id && y.IsDeleted == false)));
                    datas.Add(dto);
                }
                finally
                {
                    _ = slim.Release();
                }
            }));

            return result && await _esService.SetBulkAsync(datas, ElasticsearchIndex.Developer, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SyncDataToElasticsearchAsync-DeveloperService-Exception");

            throw;
        }
    }
}
