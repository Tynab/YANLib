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
[Route("api/developer-types")]
public sealed class DeveloperTypeController(ILogger<DeveloperTypeController> logger, IDeveloperTypeService service) : YANLibController
{
    private readonly ILogger<DeveloperTypeController> _logger = logger;
    private readonly IDeveloperTypeService _service = service;

    [HttpGet]
    [SwaggerOperation(Summary = "Lấy danh sách định nghĩa loại lập trình viên")]
    public async Task<ActionResult<PagedResultDto<DeveloperTypeResponse>>> GetAll(byte pageNumber = 1, byte pageSize = 10)
    {
        _logger.LogInformation("GetAll-DeveloperTypeController: {PageNumber} - {PageSize}", pageNumber, pageSize);

        return Ok(await _service.GetAll(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            pageNumber,
            pageSize,
            $"{nameof(ProjectResponse.Name)} {Ascending},{nameof(ProjectResponse.CreatedAt)} {Descending}"
        ))));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Lấy định nghĩa loại lập trình viên theo mã")]
    public async Task<ActionResult<DeveloperTypeResponse>> Get(long id)
    {
        _logger.LogInformation("Get-DeveloperTypeController: {Id}", id);

        return Ok(await _service.Get(id));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới định nghĩa loại lập trình viên")]
    public async Task<ActionResult<DeveloperTypeResponse>> Insert([Required] DeveloperTypeCreateRequest request)
    {
        _logger.LogInformation("Insert-DeveloperTypeController: {Request}", request.Serialize());

        return Ok(await _service.Insert(request));
    }

    [HttpPatch("{id}")]
    [SwaggerOperation(Summary = "Cập nhật định nghĩa loại lập trình viên")]
    public async Task<ActionResult<DeveloperTypeResponse>> Modify(long id, [Required] DeveloperTypeUpdateRequest request)
    {
        _logger.LogInformation("Modify-DeveloperTypeController: {Id} - {Request}", id, request.Serialize());

        return Ok(await _service.Modify(id, request));
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Xóa định nghĩa loại lập trình viên")]
    public async Task<IActionResult> Delete(long id, [Required] Guid updatedBy)
    {
        _logger.LogInformation("Delete-DeveloperTypeController: {Id} - {UpdatedBy}", id, updatedBy);

        return Ok(await _service.Delete(id, updatedBy));
    }

#if RELEASE
    [Authorize(Roles = "GlobalRole, OtherRole")]
#endif
    [HttpPost("sync-db-to-redis")]
    [SwaggerOperation(Summary = "Đồng bộ tất cả định nghĩa loại lập trình viên từ Database sang Redis")]
    public async Task<IActionResult> SyncDbToRedis() => Ok(await _service.SyncDbToRedis());
}
