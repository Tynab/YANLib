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
public sealed class ProjectController(ILogger<ProjectController> logger, IProjectService service) : YANLibController
{
    private readonly ILogger<ProjectController> _logger = logger;
    private readonly IProjectService _service = service;

    [HttpGet]
    [SwaggerOperation(
        Summary = "Lấy danh sách chứng chỉ",
        Description = "Lấy danh sách chứng chỉ với phân trang và sắp xếp"
    )]
    [ProducesResponseType(typeof(PagedResultDto<ProjectResponse>), Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<ActionResult<PagedResultDto<ProjectResponse>>> GetAll([FromQuery] ProjectListQuery query, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("GetAll-ProjectController: {Query}", query.Serialize());

        return Ok(await _service.GetAllAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            query.PageNumber,
            query.PageSize,
            $"{nameof(ProjectResponse.Name)} {Ascending},{nameof(ProjectResponse.CreatedAt)} {Descending}"
        )), cancellationToken));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Lấy chứng chỉ theo khóa",
        Description = "Lấy thông tin chứng chỉ theo khóa"
    )]
    [ProducesResponseType(typeof(ProjectResponse), Status200OK)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<DeveloperResponse>> Get([FromRoute] string id, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Get-ProjectController: {Id}", id);

        var result = await _service.GetAsync(id, cancellationToken);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Thêm mới chứng chỉ",
        Description = "Tạo mới một chứng chỉ với thông tin được cung cấp"
    )]
    [ProducesResponseType(typeof(ProjectResponse), Status201Created)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody][Required] ProjectCreateRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Add-ProjectController: {Request}", request.Serialize());

        var result = await _service.AddAsync(request, cancellationToken);

        return result.IsNull()
            ? Conflict()
            : CreatedAtAction(nameof(Get), new
            {
                id = result.Id,
                version = "2.0"
            }, result);
    }

    [HttpPatch("{id}")]
    [SwaggerOperation(
        Summary = "Cập nhật chứng chỉ",
        Description = "Cập nhật thông tin chứng chỉ theo khóa"
    )]
    [ProducesResponseType(typeof(ProjectResponse), Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<DeveloperResponse>> Modify([FromRoute] string id, [FromBody][Required] ProjectUpdateRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Modify-ProjectController: {Id} - {Request}", id, request.Serialize());

        var result = await _service.ModifyAsync(id, request, cancellationToken);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Xóa chứng chỉ",
        Description = "Xóa chứng chỉ theo khóa"
    )]
    [ProducesResponseType(Status204NoContent)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] string id, [FromQuery][Required] Guid updatedBy, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Delete-ProjectController: {Id} - {UpdatedBy}", id, updatedBy);

        var result = await _service.DeleteAsync(id, updatedBy, cancellationToken);

        return result ? NoContent() : NotFound();
    }

#if RELEASE
    [Authorize(Roles = "GlobalRole")]
#endif
    [HttpPost("sync-data-to-elasticsearch")]
    [SwaggerOperation(
        Summary = "Đồng bộ tất cả chứng chỉ từ Database sang Elasticsearch",
        Description = "Đồng bộ dữ liệu chứng chỉ từ cơ sở dữ liệu sang Elasticsearch để cải thiện hiệu suất tìm kiếm"
    )]
    [ProducesResponseType(typeof(bool), Status200OK)]
    public async Task<IActionResult> SyncDataToElasticsearch(CancellationToken cancellationToken = default) => Ok(await _service.SyncDataToElasticsearchAsync(cancellationToken));

    [HttpGet("search-with-wild-card")]
    [SwaggerOperation(
        Summary = "Tìm kiếm chứng chỉ theo ký tự đại diện trong tên hoặc mô tả",
        Description = "Sử dụng ký tự đại diện (*) để tìm kiếm các chứng chỉ có tên hoặc mô tả phù hợp với mẫu tìm kiếm"
    )]
    [ProducesResponseType(typeof(PagedResultDto<ProjectResponse>), Status200OK)]
    public async Task<IActionResult> SearchWithWildcard([Required] string searchText = "trend*", byte pageNumber = 1, byte pageSize = 10, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("SearchWithWildcard-ProjectController: {SearchText} - {PageNumber} - {PageSize}", searchText, pageNumber, pageSize);

        return Ok(await _service.SearchWithWildcardAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            pageNumber,
            pageSize,
            $"{nameof(ProjectResponse.Name)} {Ascending},{nameof(ProjectResponse.CreatedAt)} {Descending}"
        )), searchText, cancellationToken));
    }

    [HttpGet("search-with-phrase-prefix")]
    [SwaggerOperation(
        Summary = "Tìm kiếm chứng chỉ theo cụm từ đầu tiên trong tên hoặc mô tả",
        Description = "Tìm kiếm các chứng chỉ có tên hoặc mô tả bắt đầu bằng cụm từ đã cho"
    )]
    [ProducesResponseType(typeof(PagedResultDto<ProjectResponse>), Status200OK)]
    public async Task<IActionResult> SearchWithPhrasePrefix([Required] string searchText = "customer ins", byte pageNumber = 1, byte pageSize = 10, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("SearchWithPhrasePrefix-ProjectController: {SearchText} - {PageNumber} - {PageSize}", searchText, pageNumber, pageSize);

        return Ok(await _service.SearchWithPhrasePrefixAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            pageNumber,
            pageSize,
            $"{nameof(ProjectResponse.Name)} {Ascending},{nameof(ProjectResponse.CreatedAt)} {Descending}"
        )), searchText, cancellationToken));
    }

    [HttpGet("search-with-exact-phrase")]
    [SwaggerOperation(
        Summary = "Tìm kiếm chứng chỉ theo cụm từ chính xác trong tên hoặc mô tả",
        Description = "Tìm kiếm các chứng chỉ có tên hoặc mô tả chứa cụm từ chính xác đã cho"
    )]
    [ProducesResponseType(typeof(PagedResultDto<ProjectResponse>), Status200OK)]
    public async Task<IActionResult> SearchWithExactPhrase([Required] string searchText = "trends in", byte pageNumber = 1, byte pageSize = 10, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("SearchWithExactPhrase-ProjectController: {SearchText} - {PageNumber} - {PageSize}", searchText, pageNumber, pageSize);

        return Ok(await _service.SearchWithExactPhraseAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            pageNumber,
            pageSize,
            $"{nameof(ProjectResponse.Name)} {Ascending},{nameof(ProjectResponse.CreatedAt)} {Descending}"
        )), searchText, cancellationToken));
    }

    [HttpGet("search-with-keywords")]
    [SwaggerOperation(
        Summary = "Tìm kiếm chứng chỉ theo từ khóa trong tên hoặc mô tả",
        Description = "Tìm kiếm các chứng chỉ có tên hoặc mô tả chứa từ khóa đã cho, hỗ trợ phân trang và sắp xếp"
    )]
    [ProducesResponseType(typeof(PagedResultDto<ProjectResponse>), Status200OK)]
    public async Task<IActionResult> SearchWithKeywords([Required] string searchText = "trends analytics", byte pageNumber = 1, byte pageSize = 10, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("SearchWithKeywords-ProjectController: {SearchText} - {PageNumber} - {PageSize}", searchText, pageNumber, pageSize);

        return Ok(await _service.SearchWithKeywordsAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            pageNumber,
            pageSize,
            $"{nameof(ProjectResponse.Name)} {Ascending},{nameof(ProjectResponse.CreatedAt)} {Descending}"
        )), searchText, cancellationToken));
    }
}
