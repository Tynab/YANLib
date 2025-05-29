#if RELEASE
using Microsoft.AspNetCore.Authorization;
#endif
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nest;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;
using YANLib.Services.v2;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace YANLib.Controllers.v2;

#if RELEASE
[Authorize(Roles = "GlobalRole, OtherRole")]
#endif
[ApiVersion(2)]
[ApiController]
[Route("api/developers")]
public sealed class DeveloperController(ILogger<DeveloperController> logger, IDeveloperService service) : YANLibController
{
    private readonly ILogger<DeveloperController> _logger = logger;
    private readonly IDeveloperService _service = service;

    //[HttpGet]
    //[SwaggerOperation(Summary = "Lấy tất cả lập trình viên")]
    //[ProducesResponseType(typeof(PagedResultDto<DeveloperTypeResponse>), Status200OK)]
    //[ProducesResponseType(Status400BadRequest)]
    //public async Task<ActionResult<PagedResultDto<DeveloperTypeResponse>>> GetAll([FromQuery] DeveloperTypeListQuery query, CancellationToken cancellationToken = default)
    //{
    //    _logger.LogInformation("GetAll-DeveloperTypeController: {Query}", query.Serialize());

    //    return Ok(await _service.GetAllAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
    //        query.PageNumber,
    //        query.PageSize,
    //        $"{nameof(ProjectResponse.Name)} {Ascending},{nameof(ProjectResponse.CreatedAt)} {Descending}"
    //    )), cancellationToken));
    //}

    [HttpGet("{id:guid}")]
    [SwaggerOperation(Summary = "Lấy lập trình viên theo mã định danh")]
    [ProducesResponseType(typeof(DeveloperResponse), Status200OK)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<DeveloperResponse>> GetAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("GetAsync-DeveloperController: {Id}", id);

        var result = await _service.GetAsync(id, cancellationToken);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới lập trình viên")]
    [ProducesResponseType(typeof(DeveloperResponse), Status201Created)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<IActionResult> Insert([FromBody][Required] DeveloperCreateRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Insert-DeveloperController: {Request}", request.Serialize());

        var result = await _service.InsertAsync(request, cancellationToken);

        return result.IsNull()
            ? Conflict()
            : CreatedAtAction(nameof(GetAsync), new
            {
                id = result.Id,
                version = "2.0"
            }, result);
    }

    [HttpPatch("{id:guid}")]
    [SwaggerOperation(Summary = "Cập nhật lập trình viên")]
    [ProducesResponseType(typeof(DeveloperTypeResponse), Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<DeveloperResponse>> Adjust([FromRoute] Guid id, [FromBody][Required] DeveloperUpdateRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Adjust-DeveloperController: {Id} - {Request}", id, request.Serialize());

        var result = await _service.AdjustAsync(id, request, cancellationToken);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpDelete("{id:guid}")]
    [SwaggerOperation(Summary = "Xóa định nghĩa lập trình viên")]
    [ProducesResponseType(Status204NoContent)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid id, [FromQuery][Required] Guid updatedBy, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Delete-DeveloperTypeController: {Id} - {UpdatedBy}", id, updatedBy);

        var result = await _service.DeleteAsync(id, updatedBy, cancellationToken);

        return result ? NoContent() : NotFound();
    }

#if RELEASE
    [Authorize(Roles = "GlobalRole")]
#endif
    [HttpPost("sync-db-to-es")]
    [SwaggerOperation(Summary = "Đồng bộ tất cả lập trình viên từ Database lên Elasticsearch")]
    [ProducesResponseType(typeof(bool), Status200OK)]
    public async Task<IActionResult> SyncDbToEs(CancellationToken cancellationToken = default) => Ok(await _service.SyncDataToElasticsearchAsync(cancellationToken));
}
