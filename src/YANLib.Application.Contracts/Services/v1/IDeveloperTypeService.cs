﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using YANLib.Requests.v1.Create;
using YANLib.Requests.v1.Update;
using YANLib.Responses;

namespace YANLib.Services.v1;

public interface IDeveloperTypeService : ICrudAppService<DeveloperTypeResponse, long, PagedAndSortedResultRequestDto, DeveloperTypeCreateRequest, DeveloperTypeUpdateRequest>
{
    public Task<List<DeveloperTypeResponse>> GetAllAsync();
}
