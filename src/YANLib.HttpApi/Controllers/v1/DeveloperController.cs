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
using static Nest.SortOrder;

namespace YANLib.Controllers.v1;

#if RELEASE
[Authorize(Roles = "GlobalRole, OtherRole")]
#endif
[ApiVersion(1, Deprecated = true)]
[ApiController]
[Route("api/[controller]")]
public sealed class DeveloperController(ILogger<DeveloperController> logger, IDeveloperService service) : YANLibController
{
    private readonly ILogger<DeveloperController> _logger = logger;
    private readonly IDeveloperService _service = service;

    [HttpGet]
    [SwaggerOperation(
        Summary = "Lấy tất cả lập trình viên",
        Description = "Lấy danh sách lập trình viên với phân trang và sắp xếp"
    )]
    [ProducesResponseType(typeof(PagedResultDto<DeveloperResponse>), Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<ActionResult<PagedResultDto<DeveloperResponse>>> GetAll([FromQuery] DeveloperListQuery query)
    {
        _logger.LogInformation("GetAll-DeveloperController: {Query}", query.Serialize());

        return Ok(await _service.GetListAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            query.PageNumber,
            query.PageSize,
            $"{nameof(DeveloperResponse.Name)} {Ascending},{nameof(DeveloperResponse.CreatedAt)} {Descending}"
        ))));
    }

    [HttpGet("{id:guid}")]
    [SwaggerOperation(
        Summary = "Lấy lập trình viên theo khóa",
        Description = "Lấy thông tin lập trình viên theo khóa"
    )]
    [ProducesResponseType(typeof(DeveloperResponse), Status200OK)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<DeveloperResponse>> Get([FromRoute] Guid id)
    {
        _logger.LogInformation("Get-DeveloperController: {Id}", id);

        var result = await _service.GetAsync(id);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Thêm mới lập trình viên",
        Description = "Tạo mới một lập trình viên với thông tin được cung cấp"
    )]
    [ProducesResponseType(typeof(DeveloperResponse), Status201Created)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody][Required] DeveloperCreateRequest request)
    {
        _logger.LogInformation("Create-DeveloperController: {Request}", request.Serialize());

        var result = await _service.CreateAsync(request);

        return CreatedAtAction(nameof(Get), new
        {
            id = result.Id,
            version = "1.0"
        }, result);
    }

    [HttpPut("{id:guid}")]
    [SwaggerOperation(
        Summary = "Cập nhật lập trình viên",
        Description = "Cập nhật thông tin lập trình viên theo khóa"
    )]
    [ProducesResponseType(typeof(DeveloperResponse), Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<DeveloperResponse>> Update([FromRoute] Guid id, [FromBody][Required] DeveloperUpdateRequest request)
    {
        _logger.LogInformation("Update-DeveloperController: {Id} - {Request}", id, request.Serialize());

        var result = await _service.UpdateAsync(id, request);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpDelete("{id:guid}")]
    [SwaggerOperation(
        Summary = "Xóa lập trình viên",
        Description = "Xóa lập trình viên theo khóa"
    )]
    [ProducesResponseType(Status204NoContent)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        _logger.LogInformation("Delete-DeveloperController: {Id}", id);

        await _service.DeleteAsync(id);

        return NoContent();
    }
}
