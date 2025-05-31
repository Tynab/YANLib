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
using static Microsoft.AspNetCore.Http.StatusCodes;
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
    [ProducesResponseType(typeof(PagedResultDto<DeveloperTypeResponse>), Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<ActionResult<PagedResultDto<DeveloperTypeResponse>>> GetAll([FromQuery] DeveloperTypeListQuery query)
    {
        _logger.LogInformation("GetAll-DeveloperTypeController: {Query}", query.Serialize());

        return Ok(await _service.GetListAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            query.PageNumber,
            query.PageSize,
            $"{nameof(DeveloperTypeResponse.Name)} {Ascending},{nameof(DeveloperTypeResponse.CreatedAt)} {Descending}"
        ))));
    }

    [HttpGet("{code:long}")]
    [SwaggerOperation(Summary = "Lấy định nghĩa loại lập trình viên theo mã")]
    [ProducesResponseType(typeof(DeveloperTypeResponse), Status200OK)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<DeveloperTypeResponse>> Get([FromRoute] long code)
    {
        _logger.LogInformation("Get-DeveloperTypeCrudController: {Code}", code);

        var result = await _service.GetAsync(code);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới định nghĩa loại lập trình viên")]
    [ProducesResponseType(typeof(DeveloperTypeResponse), Status201Created)]
    [ProducesResponseType(Status400BadRequest)]
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

    [HttpPut("{code:long}")]
    [SwaggerOperation(Summary = "Cập nhật định nghĩa loại lập trình viên")]
    [ProducesResponseType(typeof(DeveloperTypeResponse), Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<DeveloperTypeResponse>> Update([FromRoute] long code, [FromBody][Required] DeveloperTypeUpdateRequest request)
    {
        _logger.LogInformation("Update-DeveloperTypeCrudController: {Code} - {Request}", code, request.Serialize());

        var result = await _service.UpdateAsync(code, request);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpDelete("{code:long}")]
    [SwaggerOperation(Summary = "Xóa định nghĩa loại lập trình viên")]
    [ProducesResponseType(Status204NoContent)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] long code)
    {
        _logger.LogInformation("Delete-DeveloperTypeCrudController: {Code}", code);
        await _service.DeleteAsync(code);

        return NoContent();
    }
}
