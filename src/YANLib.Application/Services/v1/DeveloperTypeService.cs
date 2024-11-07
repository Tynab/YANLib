using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using YANLib.Entities;
using YANLib.Requests.Crud.Create;
using YANLib.Requests.Crud.Update;
using YANLib.Responses;

namespace YANLib.Services.v1;

public class DeveloperTypeService(IRepository<DeveloperType, Guid> repository) : CrudAppService<DeveloperType, DeveloperTypeResponse, Guid, PagedAndSortedResultRequestDto, DeveloperTypeCreateRequest, DeveloperTypeUpdateRequest>(repository), IDeveloperTypeService { }
