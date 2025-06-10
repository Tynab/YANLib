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
[Route("api/[controller]")]
public sealed class ProjectController(ILogger<ProjectController> logger, IProjectService service) : YANLibController
{
    private readonly ILogger<ProjectController> _logger = logger;
    private readonly IProjectService _service = service;

    [HttpGet]
    [SwaggerOperation(
        Summary = "Lấy tất cả chứng chỉ",
        Description = "Lấy danh sách chứng chỉ với phân trang và sắp xếp"
    )]
    [ProducesResponseType(typeof(PagedResultDto<ProjectResponse>), Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<ActionResult<PagedResultDto<ProjectResponse>>> GetAll([FromQuery] ProjectListQuery query)
    {
        _logger.LogInformation("GetAll-ProjectController: {Query}", query.Serialize());

        return Ok(await _service.GetListAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            query.PageNumber,
            query.PageSize,
            $"{nameof(ProjectResponse.Name)} {Ascending},{nameof(ProjectResponse.CreatedAt)} {Descending}"
        ))));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Lấy chứng chỉ theo khóa",
        Description = "Lấy thông tin chứng chỉ theo khóa"
    )]
    [ProducesResponseType(typeof(ProjectResponse), Status200OK)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<ProjectResponse>> Get([FromRoute] string id)
    {
        _logger.LogInformation("Get-ProjectController: {Id}", id);

        var result = await _service.GetAsync(id);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Thêm mới chứng chỉ",
        Description = "Tạo mới một chứng chỉ với thông tin được cung cấp"
    )]
    [ProducesResponseType(typeof(DeveloperResponse), Status201Created)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody][Required] ProjectCreateRequest request)
    {
        _logger.LogInformation("Create-ProjectController: {Request}", request.Serialize());

        var result = await _service.CreateAsync(request);

        return CreatedAtAction(nameof(Get), new
        {
            id = result.Id,
            version = "1.0"
        }, result);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Cập nhật chứng chỉ",
        Description = "Cập nhật thông tin chứng chỉ theo khóa"
    )]
    [ProducesResponseType(typeof(ProjectResponse), Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<ProjectResponse>> Update([FromRoute] string id, [FromBody][Required] ProjectUpdateRequest request)
    {
        _logger.LogInformation("Update-ProjectController: {Id} - {Request}", id, request.Serialize());

        var result = await _service.UpdateAsync(id, request);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Xóa chứng chỉ",
        Description = "Xóa chứng chỉ theo khóa"
    )]
    [ProducesResponseType(Status204NoContent)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<IActionResult> Delete(string id)
    {
        _logger.LogInformation("Delete-ProjectController: {Id}", id);

        await _service.DeleteAsync(id);

        return NoContent();
    }
}
