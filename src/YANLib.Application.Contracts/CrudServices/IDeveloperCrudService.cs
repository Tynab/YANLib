using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using YANLib.Requests.Crud.Create;
using YANLib.Requests.Crud.Update;
using YANLib.Responses;

namespace YANLib.CrudServices;

public interface IDeveloperCrudService : ICrudAppService<DeveloperResponse, Guid, PagedAndSortedResultRequestDto, DeveloperCreateRequest, DeveloperUpdateRequest> { }
