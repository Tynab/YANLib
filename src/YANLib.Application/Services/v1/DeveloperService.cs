using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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

public class DeveloperService(
    ILogger<DeveloperService> logger,
    IRepository<Developer, Guid> repository,
    IRepository<DeveloperType, long> developerTypeRepository,
    IRepository<DeveloperProject, Guid> developerProjectRepository,
    IRepository<Project, string> projectRepository
) : CrudAppService<Developer, DeveloperResponse, Guid, PagedAndSortedResultRequestDto, DeveloperCreateRequest, DeveloperUpdateRequest>(repository), IDeveloperService
{
    private readonly ILogger<DeveloperService> _logger = logger;
    private readonly IRepository<DeveloperType, long> _developerTypeRepository = developerTypeRepository;
    private readonly IRepository<DeveloperProject, Guid> _developerProjectRepository = developerProjectRepository;
    private readonly IRepository<Project, string> _projectRepository = projectRepository;

    public override async Task<PagedResultDto<DeveloperResponse>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        try
        {
            var result = await base.GetListAsync(input);
            var developerTypeIds = result.Items.Where(x => x.DeveloperType.IsNotNull()).Select(x => x.DeveloperType!.Id).Distinct();
            var developerTypes = await _developerTypeRepository.GetListAsync(x => developerTypeIds.Contains(x.Id));
            var developerIds = result.Items.Select(x => x.Id).Distinct();
            var developerProjects = await _developerProjectRepository.GetListAsync(x => developerIds.Contains(x.DeveloperId));
            var projectIds = developerProjects.Select(x => x.ProjectId).Distinct();
            var projects = await _projectRepository.GetListAsync(x => projectIds.Contains(x.Id));

            foreach (var item in result.Items)
            {
                item.DeveloperType = ObjectMapper.Map<DeveloperType?, DeveloperTypeResponse?>(developerTypes.FirstOrDefault(x => x.Id == item.DeveloperType?.Id));
                item.Projects = ObjectMapper.Map<List<Project?>, List<ProjectResponse?>>([.. developerProjects.Where(x => x.DeveloperId == item.Id).Select(x => projects.FirstOrDefault(y => y.Id == x.ProjectId))]);
            }

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetList-DeveloperService: {Input}", input.Serialize());

            throw;
        }
    }

    public override async Task<DeveloperResponse> GetAsync(Guid id)
    {
        try
        {
            var result = await base.GetAsync(id);
            var developerProjects = await _developerProjectRepository.GetListAsync(x => x.DeveloperId == id);
            var projects = await _projectRepository.GetListAsync(x => developerProjects.Select(x => x.ProjectId).Distinct().Contains(x.Id));

            result.DeveloperType = ObjectMapper.Map<DeveloperType?, DeveloperTypeResponse?>(await _developerTypeRepository.FindAsync(result.DeveloperType!.Id));
            result.Projects = ObjectMapper.Map<List<Project?>, List<ProjectResponse?>>([.. developerProjects.Select(x => projects.FirstOrDefault(y => y.Id == x.ProjectId))]);

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Get-DeveloperService: {Id}", id);

            throw;
        }
    }

    public override async Task<DeveloperResponse> CreateAsync(DeveloperCreateRequest input)
    {
        try
        {
            var developerType = await _developerTypeRepository.FindAsync(input.DeveloperTypeCode) ?? throw new EntityNotFoundException(typeof(DeveloperType), input.DeveloperTypeCode);
            var result = await base.CreateAsync(input);

            if (developerType.IsNotNull())
            {
                result.DeveloperType = ObjectMapper.Map<DeveloperType?, DeveloperTypeResponse?>(developerType);
            }

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Create-DeveloperService: {Input}", input.Serialize());

            throw;
        }
    }

    public override async Task<DeveloperResponse> UpdateAsync(Guid id, DeveloperUpdateRequest input)
    {
        try
        {
            var developerType = await _developerTypeRepository.FindAsync(input.DeveloperTypeCode) ?? throw new EntityNotFoundException(typeof(DeveloperType), input.DeveloperTypeCode);
            var result = await base.UpdateAsync(id, input);

            if (developerType.IsNotNull())
            {
                result.DeveloperType = ObjectMapper.Map<DeveloperType?, DeveloperTypeResponse?>(developerType);
            }

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Update-DeveloperService: {Id} - {Input}", id, input.Serialize());

            throw;
        }
    }
}
