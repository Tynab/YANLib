﻿#if RELEASE
using Microsoft.AspNetCore.Authorization;
#endif
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.Requests.v1.Create;
using YANLib.Requests.v1.Update;
using YANLib.Responses;
using YANLib.Services.v1;
using static Nest.SortOrder;

namespace YANLib.Controllers.v1;

#if RELEASE
[Authorize(Roles = "GlobalRole, OtherRole")]
#endif
[ApiVersion(1, Deprecated = true)]
[ApiController]
[Route("api/developers")]
public sealed class DeveloperController(ILogger<DeveloperController> logger, IDeveloperService service) : YANLibController
{
    private readonly ILogger<DeveloperController> _logger = logger;
    private readonly IDeveloperService _service = service;

    [HttpGet]
    [SwaggerOperation(Summary = "Lấy tất cả lập trình viên")]
    public async ValueTask<ActionResult<PagedResultDto<DeveloperResponse>>> GetAll(byte pageNumber = 1, byte pageSize = 10)
    {
        _logger.LogInformation("GetAll-DeveloperCrudController: {PageNumber} - {PageSize}", pageNumber, pageSize);

        return Ok(await _service.GetListAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            pageNumber,
            pageSize,
            $"{nameof(ProjectResponse.Name)} {Ascending},{nameof(ProjectResponse.CreatedAt)} {Descending}"
        ))));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Lấy lập trình viên theo Id")]
    public async ValueTask<ActionResult<DeveloperResponse>> Get(Guid id)
    {
        _logger.LogInformation("Get-DeveloperCrudController: {Id}", id);

        return Ok(await _service.GetAsync(id));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới lập trình viên")]
    public async ValueTask<ActionResult<DeveloperResponse>> Create(DeveloperCreateRequest input)
    {
        _logger.LogInformation("Create-DeveloperCrudController: {Input}", input.Serialize());

        return Ok(await _service.CreateAsync(input));
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Cập nhật lập trình viên")]
    public async ValueTask<ActionResult<DeveloperResponse>> Update(Guid id, DeveloperUpdateRequest input)
    {
        _logger.LogInformation("Update-DeveloperCrudController: {Id} - {Input}", id, input.Serialize());

        return Ok(await _service.UpdateAsync(id, input));
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Xóa lập trình viên")]
    public async ValueTask<IActionResult> Delete(Guid id)
    {
        _logger.LogInformation("Delete-DeveloperCrudController: {Id}", id);
        await _service.DeleteAsync(id);

        return Ok();
    }
}
