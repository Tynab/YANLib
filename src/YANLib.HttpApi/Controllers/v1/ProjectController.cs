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
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace YANLib.Controllers.v1;

#if RELEASE
[Authorize(Roles = "GlobalRole, OtherRole")]
#endif
[ApiVersion(1, Deprecated = true)]
[ApiController]
[Route("api/projects")]
public sealed class ProjectController(ILogger<ProjectController> logger, IProjectService service) : YANLibController
{
    private readonly ILogger<ProjectController> _logger = logger;
    private readonly IProjectService _service = service;

    [HttpGet]
    [SwaggerOperation(Summary = "Lấy tất cả chứng chỉ")]
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
    [SwaggerOperation(Summary = "Lấy chứng chỉ theo mã")]
    [ProducesResponseType(typeof(ProjectResponse), Status200OK)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<ProjectResponse>> Get([FromRoute] string id)
    {
        _logger.LogInformation("Get-ProjectController: {Id}", id);

        var result = await _service.GetAsync(id);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới chứng chỉ")]
    [ProducesResponseType(typeof(DeveloperResponse), Status201Created)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody][Required] ProjectCreateRequest input)
    {
        _logger.LogInformation("Create-ProjectController: {Input}", input.Serialize());

        var result = await _service.CreateAsync(input);

        return CreatedAtAction(nameof(Get), new
        {
            id = result.Id,
            version = "1.0"
        }, result);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Cập nhật chứng chỉ")]
    [ProducesResponseType(typeof(ProjectResponse), Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<ProjectResponse>> Update([FromRoute] string id, [FromBody][Required] ProjectUpdateRequest input)
    {
        _logger.LogInformation("Update-ProjectController: {Id} - {Input}", id, input.Serialize());

        var result = await _service.UpdateAsync(id, input);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Xóa chứng chỉ")]
    [ProducesResponseType(Status204NoContent)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<IActionResult> Delete(string id)
    {
        _logger.LogInformation("Delete-ProjectController: {Id}", id);
        await _service.DeleteAsync(id);

        return NoContent();
    }
}
