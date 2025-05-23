﻿#if RELEASE
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
    public async Task<ActionResult<PagedResultDto<ProjectResponse>>> GetAll(byte pageNumber = 1, byte pageSize = 10)
    {
        _logger.LogInformation("GetAll-ProjectController: {PageNumber} - {PageSize}", pageNumber, pageSize);

        return Ok(await _service.GetAllAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            pageNumber,
            pageSize,
            $"{nameof(ProjectResponse.Name)} {Ascending},{nameof(ProjectResponse.CreatedAt)} {Descending}"
        ))));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Lấy chứng chỉ theo mã")]
    public async Task<IActionResult> Get(string id)
    {
        _logger.LogInformation("Get-ProjectController: {Id}", id);

        return Ok(await _service.GetAsync(id));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới chứng chỉ")]
    public async Task<IActionResult> Insert([Required] ProjectCreateRequest request)
    {
        _logger.LogInformation("Insert-ProjectController: {Request}", request.Serialize());

        return Ok(await _service.InsertAsync(request));
    }

    [HttpPatch("{id}")]
    [SwaggerOperation(Summary = "Cập nhật chứng chỉ")]
    public async Task<IActionResult> Modify(string id, [Required] ProjectUpdateRequest request)
    {
        _logger.LogInformation("Modify-ProjectController: {Id} - {Request}", id, request.Serialize());

        return Ok(await _service.ModifyAsync(id, request));
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Xóa chứng chỉ")]
    public async Task<IActionResult> Delete(string id, [Required] Guid updatedBy)
    {
        _logger.LogInformation("Delete-ProjectController: {Id} - {UpdatedBy}", id, updatedBy);

        return Ok(await _service.DeleteAsync(id, updatedBy));
    }

#if RELEASE
    [Authorize(Roles = "GlobalRole")]
#endif
    [HttpPost("sync-db-to-es")]
    [SwaggerOperation(Summary = "Đồng bộ tất cả chứng chỉ từ Database sang Elasticsearch")]
    public async Task<IActionResult> SyncDbToEs() => Ok(await _service.SyncDataToElasticsearchAsync());

    [HttpGet("search-with-wild-card")]
    [SwaggerOperation(Summary = "Tìm kiếm chứng chỉ theo ký tự đại diện trong tên hoặc mô tả")]
    public async Task<IActionResult> SearchWithWildcard([Required] string searchText = "pro*", byte pageNumber = 1, byte pageSize = 10)
    {
        _logger.LogInformation("SearchWithWildcard-ProjectController: {SearchText} - {PageNumber} - {PageSize}", searchText, pageNumber, pageSize);

        return Ok(await _service.SearchWithWildcardAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            pageNumber,
            pageSize,
            $"{nameof(ProjectResponse.Name)} {Ascending},{nameof(ProjectResponse.CreatedAt)} {Descending}"
        )), searchText));
    }

    [HttpGet("search-with-phrase-prefix")]
    [SwaggerOperation(Summary = "Tìm kiếm chứng chỉ theo cụm từ đầu tiên trong tên hoặc mô tả")]
    public async Task<IActionResult> SearchWithPhrasePrefix([Required] string searchText = "proficien", byte pageNumber = 1, byte pageSize = 10)
    {
        _logger.LogInformation("SearchWithPhrasePrefix-ProjectController: {SearchText} - {PageNumber} - {PageSize}", searchText, pageNumber, pageSize);

        return Ok(await _service.SearchWithPhrasePrefixAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            pageNumber,
            pageSize,
            $"{nameof(ProjectResponse.Name)} {Ascending},{nameof(ProjectResponse.CreatedAt)} {Descending}"
        )), searchText));
    }

    [HttpGet("search-with-exact-phrase")]
    [SwaggerOperation(Summary = "Tìm kiếm chứng chỉ theo cụm từ chính xác trong tên hoặc mô tả")]
    public async Task<IActionResult> SearchWithExactPhrase([Required] string searchText = "data analysis", byte pageNumber = 1, byte pageSize = 10)
    {
        _logger.LogInformation("SearchWithExactPhrase-ProjectController: {SearchText} - {PageNumber} - {PageSize}", searchText, pageNumber, pageSize);

        return Ok(await _service.SearchWithExactPhraseAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            pageNumber,
            pageSize,
            $"{nameof(ProjectResponse.Name)} {Ascending},{nameof(ProjectResponse.CreatedAt)} {Descending}"
        )), searchText));
    }

    [HttpGet("search-with-keywords")]
    [SwaggerOperation(Summary = "Tìm kiếm chứng chỉ theo từ khóa trong tên hoặc mô tả")]
    public async Task<IActionResult> SearchWithKeywords([Required] string searchText = "programming web", byte pageNumber = 1, byte pageSize = 10)
    {
        _logger.LogInformation("SearchWithKeywords-ProjectController: {SearchText} - {PageNumber} - {PageSize}", searchText, pageNumber, pageSize);

        return Ok(await _service.SearchWithKeywordsAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            pageNumber,
            pageSize,
            $"{nameof(ProjectResponse.Name)} {Ascending},{nameof(ProjectResponse.CreatedAt)} {Descending}"
        )), searchText));
    }
}
