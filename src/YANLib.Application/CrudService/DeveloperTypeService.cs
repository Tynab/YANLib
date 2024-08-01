using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using YANLib.Entities;
using YANLib.Requests.DeveloperType;
using YANLib.Responses;

namespace YANLib.CrudService;

public class DeveloperTypeService(IRepository<DeveloperType, Guid> repository)
    : CrudAppService<DeveloperType, DeveloperTypeResponse, Guid, PagedAndSortedResultRequestDto, DeveloperTypeCreateRequest, DeveloperTypeUpdateRequest>(repository), IDeveloperTypeService
{ }