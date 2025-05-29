#if RELEASE
using Microsoft.AspNetCore.Authorization;
#endif
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.ListQueries.v2;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;
using YANLib.Services.v2;
using static Microsoft.AspNetCore.Http.StatusCodes;
using static Nest.SortOrder;

namespace YANLib.Controllers.v2;

#if RELEASE
[Authorize(Roles = "GlobalRole, OtherRole")]
#endif
[ApiVersion(2)]
[ApiController]
[Route("api/developer-types")]
public sealed class DeveloperTypeController(ILogger<DeveloperTypeController> logger, IDeveloperTypeService service) : YANLibController
{
    private readonly ILogger<DeveloperTypeController> _logger = logger;
    private readonly IDeveloperTypeService _service = service;

    [HttpGet]
    [SwaggerOperation(Summary = "Lấy danh sách định nghĩa loại lập trình viên")]
    [ProducesResponseType(typeof(PagedResultDto<DeveloperTypeResponse>), Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<ActionResult<PagedResultDto<DeveloperTypeResponse>>> GetAll([FromQuery] DeveloperTypeListQuery query, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("GetAll-DeveloperTypeController: {Query}", query.Serialize());

        return Ok(await _service.GetAllAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            query.PageNumber,
            query.PageSize,
            $"{nameof(DeveloperTypeResponse.Name)} {Ascending},{nameof(DeveloperTypeResponse.CreatedAt)} {Descending}"
        )), cancellationToken));
    }

    [HttpGet("{id:long}")]
    [SwaggerOperation(Summary = "Lấy định nghĩa loại lập trình viên theo mã")]
    [ProducesResponseType(typeof(DeveloperTypeResponse), Status200OK)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<DeveloperTypeResponse>> Get([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Get-DeveloperTypeController: {Id}", id);

        var result = await _service.GetAsync(id, cancellationToken);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới định nghĩa loại lập trình viên")]
    [ProducesResponseType(typeof(DeveloperTypeResponse), Status201Created)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<IActionResult> Insert([FromBody][Required] DeveloperTypeCreateRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Insert-DeveloperTypeController: {Request}", request.Serialize());

        var result = await _service.InsertAsync(request, cancellationToken);

        return result.IsNull()
            ? Conflict()
            : CreatedAtAction(nameof(Get), new
            {
                id = result.Id,
                version = "2.0"
            }, result);
    }

    [HttpPatch("{id:long}")]
    [SwaggerOperation(Summary = "Cập nhật định nghĩa loại lập trình viên")]
    [ProducesResponseType(typeof(DeveloperTypeResponse), Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<DeveloperTypeResponse>> Modify([FromRoute] long id, [FromBody][Required] DeveloperTypeUpdateRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Modify-DeveloperTypeController: {Id} - {Request}", id, request.Serialize());

        var result = await _service.ModifyAsync(id, request, cancellationToken);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpDelete("{id:long}")]
    [SwaggerOperation(Summary = "Xóa định nghĩa loại lập trình viên")]
    [ProducesResponseType(Status204NoContent)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] long id, [FromQuery][Required] Guid updatedBy, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Delete-DeveloperTypeController: {Id} - {UpdatedBy}", id, updatedBy);

        var result = await _service.DeleteAsync(id, updatedBy, cancellationToken);

        return result ? NoContent() : NotFound();
    }

#if RELEASE
    [Authorize(Roles = "GlobalRole, OtherRole")]
#endif
    [HttpPost("sync-db-to-redis")]
    [SwaggerOperation(Summary = "Đồng bộ tất cả định nghĩa loại lập trình viên từ Database sang Redis")]
    [ProducesResponseType(typeof(bool), Status200OK)]
    public async Task<IActionResult> SyncDbToRedis(CancellationToken cancellationToken = default) => Ok(await _service.SyncDataToRedisAsync(cancellationToken));
}
