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

    public override async Task<DeveloperProjectResponse> CreateAsync(DeveloperProjectCreateRequest input)
    {
        try
        {
            _ = await _developerRepository.FindAsync(x => x.Id == input.DeveloperId) ?? throw new EntityNotFoundException(typeof(Developer), input.DeveloperId);
            _ = await _projectRepository.FindAsync(x => x.Id == input.ProjectId) ?? throw new EntityNotFoundException(typeof(Project), input.ProjectId);

            return await base.CreateAsync(input);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Create-DeveloperProjectService: {Input}", input.Serialize());

            throw;
        }
    }

    public override async Task<DeveloperProjectResponse> UpdateAsync(Guid id, DeveloperProjectUpdateRequest input)
    {
        try
        {
            _ = await _developerRepository.FindAsync(x => x.Id == input.DeveloperId) ?? throw new EntityNotFoundException(typeof(Developer), input.DeveloperId);
            _ = await _projectRepository.FindAsync(x => x.Id == input.ProjectId) ?? throw new EntityNotFoundException(typeof(Project), input.ProjectId);

            return await base.UpdateAsync(id, input);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Update-DeveloperProjectService: {Id} - {Input}", id, input.Serialize());

            throw;
        }
    }
}
