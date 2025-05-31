using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using YANLib.Entities;
using YANLib.Requests.v1.Create;
using YANLib.Requests.v1.Update;
using YANLib.Responses;

namespace YANLib.Services.v1;

public class DeveloperProjectService(
    ILogger<DeveloperProjectService> logger,
    IRepository<DeveloperProject, Guid> repository,
    IRepository<Developer, Guid> developerRepository,
    IRepository<Project, string> projectRepository
) : CrudAppService<DeveloperProject, DeveloperProjectResponse, Guid, PagedAndSortedResultRequestDto, DeveloperProjectCreateRequest, DeveloperProjectUpdateRequest>(repository), IDeveloperProjectService
{
    private readonly ILogger<DeveloperProjectService> _logger = logger;
    private readonly IRepository<Developer, Guid> _developerRepository = developerRepository;
    private readonly IRepository<Project, string> _projectRepository = projectRepository;

    public override async Task<DeveloperProjectResponse> CreateAsync(DeveloperProjectCreateRequest request)
    {
        try
        {
            _ = await _developerRepository.FindAsync(x => x.Id == request.DeveloperId) ?? throw new EntityNotFoundException(typeof(Developer), request.DeveloperId);
            _ = await _projectRepository.FindAsync(x => x.Id == request.ProjectId) ?? throw new EntityNotFoundException(typeof(Project), request.ProjectId);

            return await base.CreateAsync(request);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "CreateAsync-DeveloperProjectService: {Request}", request.Serialize());

            throw;
        }
    }

    public override async Task<DeveloperProjectResponse> UpdateAsync(Guid id, DeveloperProjectUpdateRequest request)
    {
        try
        {
            _ = await _developerRepository.FindAsync(x => x.Id == request.DeveloperId) ?? throw new EntityNotFoundException(typeof(Developer), request.DeveloperId);
            _ = await _projectRepository.FindAsync(x => x.Id == request.ProjectId) ?? throw new EntityNotFoundException(typeof(Project), request.ProjectId);

            return await base.UpdateAsync(id, request);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "UpdateAsync-DeveloperProjectService: {Id} - {Request}", id, request.Serialize());

            throw;
        }
    }
}
