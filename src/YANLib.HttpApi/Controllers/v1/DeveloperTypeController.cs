#if RELEASE
using Microsoft.AspNetCore.Authorization;
#endif
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.ListQueries.v1;
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
[Route("api/developer-types")]
public sealed class DeveloperTypeController(ILogger<DeveloperTypeController> logger, IDeveloperTypeService service) : YANLibController
{
    private readonly ILogger<DeveloperTypeController> _logger = logger;
    private readonly IDeveloperTypeService _service = service;

    [HttpGet]
    [SwaggerOperation(Summary = "Lấy tất cả định nghĩa loại lập trình viên")]
    [ProducesResponseType(typeof(PagedResultDto<DeveloperTypeResponse>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<PagedResultDto<DeveloperTypeResponse>>> GetAll([FromQuery] DeveloperTypeListQuery query)
    {
        _logger.LogInformation("GetAll-DeveloperTypeController: {Query}", query.Serialize());

        return Ok(await _service.GetListAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            query.PageNumber,
            query.PageSize,
            $"{nameof(ProjectResponse.Name)} {Ascending},{nameof(ProjectResponse.CreatedAt)} {Descending}"
        ))));
    }

    [HttpGet("{id:long}")]
    [SwaggerOperation(Summary = "Lấy định nghĩa loại lập trình viên theo mã")]
    [ProducesResponseType(typeof(DeveloperTypeResponse), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<DeveloperTypeResponse>> Get([FromRoute] long id)
    {
        _logger.LogInformation("Get-DeveloperTypeCrudController: {Id}", id);

        var result = await _service.GetAsync(id);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới định nghĩa loại lập trình viên")]
    [ProducesResponseType(typeof(DeveloperTypeResponse), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody][Required] DeveloperTypeCreateRequest request)
    {
        _logger.LogInformation("Create-DeveloperTypeCrudController: {Request}", request.Serialize());

        var result = await _service.CreateAsync(request);

        return CreatedAtAction(nameof(Get), new
        {
            id = result.Id,
            version = "1.0"
        }, result);
    }

    [HttpPut("{id:long}")]
    [SwaggerOperation(Summary = "Cập nhật định nghĩa loại lập trình viên")]
    [ProducesResponseType(typeof(DeveloperTypeResponse), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<DeveloperTypeResponse>> Update([FromRoute] long id, [FromBody][Required] DeveloperTypeUpdateRequest request)
    {
        _logger.LogInformation("Update-DeveloperTypeCrudController: {Id} - {Request}", id, request.Serialize());

        var result = await _service.UpdateAsync(id, request);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpDelete("{id:long}")]
    [SwaggerOperation(Summary = "Xóa định nghĩa loại lập trình viên")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        _logger.LogInformation("Delete-DeveloperTypeCrudController: {Id}", id);
        await _service.DeleteAsync(id);

        return NoContent();
    }
}
