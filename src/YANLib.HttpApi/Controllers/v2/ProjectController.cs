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
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;
using YANLib.Services.v2;
using static Nest.SortOrder;

namespace YANLib.Controllers.v2;

#if RELEASE
[Authorize(Roles = "GlobalRole, OtherRole")]
#endif
[ApiVersion(2)]
[ApiController]
[Route("api/projects")]
public sealed class ProjectController(ILogger<ProjectController> logger, IProjectService service) : YANLibController
{
    private readonly ILogger<ProjectController> _logger = logger;
    private readonly IProjectService _service = service;

    [HttpGet]
    [SwaggerOperation(Summary = "Lấy danh sách chứng chỉ")]
    public async ValueTask<ActionResult<PagedResultDto<ProjectResponse>>> GetAll(byte pageNumber = 1, byte pageSize = 10)
    {
        _logger.LogInformation("GetAll-ProjectController: {PageNumber} - {PageSize}", pageNumber, pageSize);

        return Ok(await _service.GetAll(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            pageNumber,
            pageSize,
            $"{nameof(ProjectResponse.Name)} {Ascending},{nameof(ProjectResponse.CreatedAt)} {Descending}"
        ))));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Lấy chứng chỉ theo mã")]
    public async ValueTask<IActionResult> Get(string id)
    {
        _logger.LogInformation("Get-ProjectController: {Id}", id);

        return Ok(await _service.Get(id));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới chứng chỉ")]
    public async ValueTask<IActionResult> Insert([Required] ProjectCreateRequest request)
    {
        _logger.LogInformation("Insert-ProjectController: {Request}", request.Serialize());

        return Ok(await _service.Insert(request));
    }

    [HttpPatch("{id}")]
    [SwaggerOperation(Summary = "Cập nhật chứng chỉ")]
    public async ValueTask<IActionResult> Modify(string id, [Required] ProjectUpdateRequest request)
    {
        _logger.LogInformation("Modify-ProjectController: {Id} - {Request}", id, request.Serialize());

        return Ok(await _service.Modify(id, request));
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Xóa chứng chỉ")]
    public async ValueTask<IActionResult> Delete(string id, [Required] Guid updatedBy)
    {
        _logger.LogInformation("Delete-ProjectController: {Id} - {UpdatedBy}", id, updatedBy);

        return Ok(await _service.Delete(id, updatedBy));
    }

#if RELEASE
[Authorize(Roles = "GlobalRole")]
#endif
    [HttpPost("sync-db-to-es")]
    [SwaggerOperation(Summary = "Đồng bộ tất cả chứng chỉ từ Database sang Elasticsearch")]
    public async ValueTask<IActionResult> SyncDbToEs() => Ok(await _service.SyncDbToEs());

    [HttpGet("search-with-wild-card")]
    [SwaggerOperation(Summary = "Tìm kiếm chứng chỉ theo ký tự đại diện trong tên hoặc mô tả")]
    public async ValueTask<IActionResult> SearchWithWildcard([Required] string searchText = "pro*", byte pageNumber = 1, byte pageSize = 10)
    {
        _logger.LogInformation("SearchWithWildcard-ProjectController: {SearchText} - {PageNumber} - {PageSize}", searchText, pageNumber, pageSize);

        return Ok(await _service.SearchWithWildcard(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            pageNumber,
            pageSize,
            $"{nameof(ProjectResponse.GPA)} {Descending},{nameof(ProjectResponse.CreatedAt)} {Descending}"
        )), searchText));
    }

    [HttpGet("search-with-phrase-prefix")]
    [SwaggerOperation(Summary = "Tìm kiếm chứng chỉ theo cụm từ đầu tiên trong tên hoặc mô tả")]
    public async ValueTask<IActionResult> SearchWithPhrasePrefix([Required] string searchText = "proficien", byte pageNumber = 1, byte pageSize = 10)
    {
        _logger.LogInformation("SearchWithPhrasePrefix-ProjectController: {SearchText} - {PageNumber} - {PageSize}", searchText, pageNumber, pageSize);

        return Ok(await _service.SearchWithPhrasePrefix(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            pageNumber,
            pageSize,
            $"{nameof(ProjectResponse.Name)} {Ascending},{nameof(ProjectResponse.CreatedAt)} {Descending}"
        )), searchText));
    }

    [HttpGet("search-with-exact-phrase")]
    [SwaggerOperation(Summary = "Tìm kiếm chứng chỉ theo cụm từ chính xác trong tên hoặc mô tả")]
    public async ValueTask<IActionResult> SearchWithExactPhrase([Required] string searchText = "data analysis", byte pageNumber = 1, byte pageSize = 10)
    {
        _logger.LogInformation("SearchWithExactPhrase-ProjectController: {SearchText} - {PageNumber} - {PageSize}", searchText, pageNumber, pageSize);

        return Ok(await _service.SearchWithExactPhrase(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            pageNumber,
            pageSize,
            $"{nameof(ProjectResponse.Name)} {Ascending},{nameof(ProjectResponse.CreatedAt)} {Descending}"
        )), searchText));
    }

    [HttpGet("search-with-keywords")]
    [SwaggerOperation(Summary = "Tìm kiếm chứng chỉ theo từ khóa trong tên hoặc mô tả")]
    public async ValueTask<IActionResult> SearchWithKeywords([Required] string searchText = "programming web", byte pageNumber = 1, byte pageSize = 10)
    {
        _logger.LogInformation("SearchWithKeywords-ProjectController: {SearchText} - {PageNumber} - {PageSize}", searchText, pageNumber, pageSize);

        return Ok(await _service.SearchWithKeywords(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            pageNumber,
            pageSize,
            $"{nameof(ProjectResponse.Name)} {Ascending},{nameof(ProjectResponse.CreatedAt)} {Descending}"
        )), searchText));
    }
}
