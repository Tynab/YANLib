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
    public async Task<ActionResult<PagedResultDto<DeveloperResponse>>> GetAll([FromQuery] DeveloperListQuery query, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("GetAll-DeveloperController: {Query}", query.Serialize());

        return Ok(await _service.GetAllAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            query.PageNumber,
            query.PageSize,
            $"{nameof(DeveloperResponse.Name)} {Ascending},{nameof(DeveloperResponse.CreatedAt)} {Descending}"
        )), cancellationToken));
    }

    [HttpGet("{id:guid}")]
    [SwaggerOperation(
        Summary = "Lấy lập trình viên theo khóa",
        Description = "Lấy thông tin lập trình viên theo khóa"
    )]
    [ProducesResponseType(typeof(DeveloperResponse), Status200OK)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<DeveloperResponse>> Get([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Get-DeveloperController: {Id}", id);

        var result = await _service.GetAsync(id, cancellationToken);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpGet("id-card/{idCard}")]
    [SwaggerOperation(
        Summary = "Lấy lập trình viên theo mã định danh",
        Description = "Lấy thông tin lập trình viên theo mã định danh"
    )]
    [ProducesResponseType(typeof(DeveloperResponse), Status200OK)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<DeveloperResponse>> GetByIdCard([FromRoute] string idCard, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("GetByIdCard-DeveloperController: {IdCard}", idCard);

        var result = await _service.GetByIdCard(idCard, cancellationToken);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Thêm mới lập trình viên",
        Description = "Tạo mới một lập trình viên với thông tin được cung cấp"
    )]
    [ProducesResponseType(typeof(DeveloperResponse), Status201Created)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody][Required] DeveloperCreateRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Add-DeveloperController: {Request}", request.Serialize());

        var result = await _service.AddAsync(request, cancellationToken);

        return result.IsNull()
            ? Conflict()
            : CreatedAtAction(nameof(Get), new
            {
                id = result.Id,
                version = "2.0"
            }, result);
    }

    [HttpPatch("id-card/{idCard}")]
    [SwaggerOperation(
        Summary = "Cập nhật lập trình viên",
        Description = "Cập nhật thông tin lập trình viên theo mã định danh"
    )]
    [ProducesResponseType(typeof(DeveloperTypeResponse), Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<DeveloperResponse>> Adjust([FromRoute] string idCard, [FromBody][Required] DeveloperUpdateRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Adjust-DeveloperController: {IdCard} - {Request}", idCard, request.Serialize());

        var result = await _service.AdjustAsync(idCard, request, cancellationToken);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpDelete("id-card/{idCard}")]
    [SwaggerOperation(
        Summary = "Xóa định nghĩa lập trình viên",
        Description = "Xóa lập trình viên theo mã định danh"
    )]
    [ProducesResponseType(Status204NoContent)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] string idCard, [FromQuery][Required] Guid updatedBy, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Delete-DeveloperController: {IdCard} - {UpdatedBy}", idCard, updatedBy);

        var result = await _service.DeleteAsync(idCard, updatedBy, cancellationToken);

        return result ? NoContent() : NotFound();
    }

#if RELEASE
    [Authorize(Roles = "GlobalRole")]
#endif
    [HttpPost("sync-data-to-elasticsearch")]
    [SwaggerOperation(
        Summary = "Đồng bộ tất cả lập trình viên từ Database lên Elasticsearch",
        Description = "Đồng bộ dữ liệu lập trình viên từ cơ sở dữ liệu sang Elasticsearch để cải thiện hiệu suất tìm kiếm"
    )]
    [ProducesResponseType(typeof(bool), Status200OK)]
    public async Task<IActionResult> SyncDataToElasticsearch(CancellationToken cancellationToken = default) => Ok(await _service.SyncDataToElasticsearchAsync(cancellationToken));
}
