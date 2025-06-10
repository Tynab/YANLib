#if RELEASE
using Microsoft.AspNetCore.Authorization;
#endif
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.ListQueries.v1;
using YANLib.Requests.v1.Create;
using YANLib.Requests.v1.Update;
using YANLib.Responses;
using YANLib.Services.v1;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace YANLib.Controllers.v1;

#if RELEASE
[Authorize(Roles = "GlobalRole, OtherRole")]
#endif
[ApiVersion(1, Deprecated = true)]
[ApiController]
[Route("api/[controller]")]
public sealed class DeveloperProjectController(ILogger<DeveloperProjectController> logger, IDeveloperProjectService service) : YANLibController
{
    private readonly ILogger<DeveloperProjectController> _logger = logger;
    private readonly IDeveloperProjectService _service = service;

    [HttpGet]
    [SwaggerOperation(
        Summary = "Lấy tất cả dự án của lập trình viên",
        Description = "Lấy danh sách dự án của lập trình viên với phân trang và sắp xếp"
    )]
    [ProducesResponseType(typeof(PagedResultDto<DeveloperProjectResponse>), Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<ActionResult<PagedResultDto<DeveloperProjectResponse>>> GetAll([FromQuery] DeveloperProjectListQuery query)
    {
        _logger.LogInformation("GetAll-DeveloperProjectController: {Query}", query.Serialize());

        return Ok(await _service.GetListAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize), PagedAndSortedResultRequestDto>((query.PageNumber, query.PageSize))));
    }

    [HttpGet("{id:guid}")]
    [SwaggerOperation(
        Summary = "Lấy dự án của lập trình viên theo khóa",
        Description = "Lấy thông tin dự án của lập trình viên theo khóa"
    )]
    [ProducesResponseType(typeof(DeveloperProjectResponse), Status200OK)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<DeveloperProjectResponse>> Get([FromRoute] Guid id)
    {
        _logger.LogInformation("Get-DeveloperProjectController: {Id}", id);

        var result = await _service.GetAsync(id);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Thêm mới dự án của lập trình viên",
        Description = "Tạo mới một dự án của lập trình viên với thông tin được cung cấp"
    )]
    [ProducesResponseType(typeof(DeveloperResponse), Status201Created)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody][Required] DeveloperProjectCreateRequest request)
    {
        _logger.LogInformation("Create-DeveloperProjectController: {Request}", request.Serialize());

        var result = await _service.CreateAsync(request);

        return CreatedAtAction(nameof(Get), new
        {
            id = result.Id,
            version = "1.0"
        }, result);
    }

    [HttpPut("{id:guid}")]
    [SwaggerOperation(
        Summary = "Cập nhật dự án của lập trình viên",
        Description = "Cập nhật thông tin dự án của lập trình viên theo khóa"
    )]
    [ProducesResponseType(typeof(DeveloperResponse), Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<DeveloperProjectResponse>> Update([FromRoute] Guid id, [FromBody][Required] DeveloperProjectUpdateRequest request)
    {
        _logger.LogInformation("Update-DeveloperProjectController: {Id} - {Request}", id, request.Serialize());

        var result = await _service.UpdateAsync(id, request);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpDelete("{id:guid}")]
    [SwaggerOperation(
        Summary = "Xóa dự án của lập trình viên",
        Description = "Xóa dự án của lập trình viên theo khóa"
    )]
    [ProducesResponseType(Status204NoContent)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        _logger.LogInformation("Delete-DeveloperProjectController: {Id}", id);

        await _service.DeleteAsync(id);

        return NoContent();
    }
}
