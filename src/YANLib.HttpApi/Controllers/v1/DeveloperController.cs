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
    [SwaggerOperation(Summary = "Lấy tất cả lập trình viên")]
    [ProducesResponseType(typeof(PagedResultDto<DeveloperResponse>), Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<ActionResult<PagedResultDto<DeveloperResponse>>> GetAll([FromQuery] DeveloperListQuery query)
    {
        _logger.LogInformation("GetAll-DeveloperCrudController: {Query}", query.Serialize());

        return Ok(await _service.GetListAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            query.PageNumber,
            query.PageSize,
            $"{nameof(DeveloperResponse.Name)} {Ascending},{nameof(DeveloperResponse.CreatedAt)} {Descending}"
        ))));
    }

    [HttpGet("{id:guid}")]
    [SwaggerOperation(Summary = "Lấy lập trình viên theo mã")]
    [ProducesResponseType(typeof(DeveloperResponse), Status200OK)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<DeveloperResponse>> Get([FromRoute] Guid id)
    {
        _logger.LogInformation("Get-DeveloperCrudController: {Id}", id);

        var result = await _service.GetAsync(id);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới lập trình viên")]
    [ProducesResponseType(typeof(DeveloperResponse), Status201Created)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody][Required] DeveloperCreateRequest request)
    {
        _logger.LogInformation("Create-DeveloperCrudController: {Request}", request.Serialize());

        var result = await _service.CreateAsync(request);

        return CreatedAtAction(nameof(Get), new
        {
            id = result.Id,
            version = "1.0"
        }, result);
    }

    [HttpPut("{id:guid}")]
    [SwaggerOperation(Summary = "Cập nhật lập trình viên")]
    [ProducesResponseType(typeof(DeveloperResponse), Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<DeveloperResponse>> Update([FromRoute] Guid id, [FromBody][Required] DeveloperUpdateRequest request)
    {
        _logger.LogInformation("Update-DeveloperCrudController: {Id} - {Request}", id, request.Serialize());

        var result = await _service.UpdateAsync(id, request);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpDelete("{id:guid}")]
    [SwaggerOperation(Summary = "Xóa lập trình viên")]
    [ProducesResponseType(Status204NoContent)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        _logger.LogInformation("Delete-DeveloperCrudController: {Id}", id);
        await _service.DeleteAsync(id);

        return NoContent();
    }
}
