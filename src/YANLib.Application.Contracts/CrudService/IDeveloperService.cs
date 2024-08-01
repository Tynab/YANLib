using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using YANLib.Requests.Developer;
using YANLib.Responses;

namespace YANLib.CrudService;

public interface IDeveloperService : ICrudAppService<DeveloperResponse, Guid, PagedAndSortedResultRequestDto, DeveloperCreateRequest, DeveloperUpdateRequest> { }
