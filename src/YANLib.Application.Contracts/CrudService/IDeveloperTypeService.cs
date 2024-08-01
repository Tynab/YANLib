using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using YANLib.Requests.DeveloperType;
using YANLib.Responses;

namespace YANLib.CrudService;

public interface IDeveloperTypeService : ICrudAppService<DeveloperTypeResponse, Guid, PagedAndSortedResultRequestDto, DeveloperTypeCreateRequest, DeveloperTypeUpdateRequest> { }
