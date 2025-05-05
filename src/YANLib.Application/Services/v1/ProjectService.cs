using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using YANLib.Entities;
using YANLib.Requests.v1.Create;
using YANLib.Requests.v1.Update;
using YANLib.Responses;

namespace YANLib.Services.v1;

public class ProjectService(IRepository<Project, string> repository) : CrudAppService<Project, ProjectResponse, string, PagedAndSortedResultRequestDto, ProjectCreateRequest, ProjectUpdateRequest>(repository), IProjectService { }
