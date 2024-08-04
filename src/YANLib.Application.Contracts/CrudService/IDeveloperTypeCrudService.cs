using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using YANLib.Requests.Crud.Create;
using YANLib.Requests.Crud.Update;
using YANLib.Responses;

namespace YANLib.CrudService;

public interface IDeveloperTypeCrudService : ICrudAppService<DeveloperTypeResponse, Guid, PagedAndSortedResultRequestDto, DeveloperTypeCreateRequest, DeveloperTypeUpdateRequest> { }
