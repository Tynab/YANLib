using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using YANLib.Entities;
using YANLib.Requests.v1.Create;
using YANLib.Requests.v1.Update;
using YANLib.Responses;

namespace YANLib.Services.v1;

public class DeveloperTypeService(ILogger<DeveloperTypeService> logger, IRepository<DeveloperType, long> repository)
    : CrudAppService<DeveloperType, DeveloperTypeResponse, long, PagedAndSortedResultRequestDto, DeveloperTypeCreateRequest, DeveloperTypeUpdateRequest>(repository), IDeveloperTypeService
{
    private readonly ILogger<DeveloperTypeService> _logger = logger;
    private readonly IRepository<DeveloperType, long> _repository = repository;

    public async Task<List<DeveloperTypeResponse>> GetAllAsync()
    {
        try
        {
            return ObjectMapper.Map<List<DeveloperType>, List<DeveloperTypeResponse>>(await _repository.GetListAsync());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAllAsync-DeveloperTypeService-Exception");

            throw;
        }
    }
}
