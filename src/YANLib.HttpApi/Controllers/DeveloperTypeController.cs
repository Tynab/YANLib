using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.Core;
using YANLib.Requests.Insert;
using YANLib.Requests.Modify;
using YANLib.Responses;
using YANLib.Services;

namespace YANLib.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = "sample")]
[Route("api/[controller]")]
public sealed class DeveloperTypeController(ILogger<DeveloperTypeController> logger, IDeveloperTypeService service) : YANLibController
{
    private readonly ILogger<DeveloperTypeController> _logger = logger;
    private readonly IDeveloperTypeService _service = service;

    [HttpGet]
    [SwaggerOperation(Summary = "Lấy tất cả định nghĩa loại lập trình viên")]
    public async ValueTask<ActionResult<PagedResultDto<DeveloperTypeResponse>>> GetAll(byte pageNumber = 1, byte pageSize = 10) => Ok(await _service.GetAll(new PagedAndSortedResultRequestDto
    {
        SkipCount = (pageNumber - 1) * pageSize,
        MaxResultCount = pageSize,
        Sorting = $"{nameof(DeveloperTypeResponse.Name)} ASC,{nameof(DeveloperTypeResponse.CreatedAt)} DESC"
    }));

    [HttpGet("{code}")]
    [SwaggerOperation(Summary = "Lấy định nghĩa loại lập trình viên theo Code")]
    public async ValueTask<ActionResult<DeveloperTypeResponse>> Get(long code)
    {
        _logger.LogInformation("Get-DeveloperTypeController: {Code}", code);

        return Ok(await _service.Get(code));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới định nghĩa loại lập trình viên")]
    public async ValueTask<ActionResult<DeveloperTypeResponse>> Insert([Required] DeveloperTypeInsertRequest request)
    {
        _logger.LogInformation("Insert-DeveloperTypeController: {Request}", request.Serialize());

        return Ok(await _service.Insert(request));
    }

    [HttpPatch("{code}")]
    [SwaggerOperation(Summary = "Cập nhật định nghĩa loại lập trình viên")]
    public async ValueTask<ActionResult<DeveloperTypeResponse>> Modify(long code, [Required] DeveloperTypeModifyRequest request)
    {
        _logger.LogInformation("Modify-DeveloperTypeController: {Code} - {Request}", code, request.Serialize());

        return Ok(await _service.Modify(code, request));
    }

    [HttpDelete("{code}")]
    [SwaggerOperation(Summary = "Xóa định nghĩa loại lập trình viên")]
    public async ValueTask<IActionResult> Delete(long code, [Required] Guid updatedBy)
    {
        _logger.LogInformation("Delete-DeveloperTypeController: {Code} - {UpdatedBy}", code, updatedBy);

        return Ok(await _service.Delete(code, updatedBy));
    }

    [HttpPost("sync-db-to-redis")]
    [SwaggerOperation(Summary = "Đồng bộ tất cả định nghĩa loại lập trình viên từ Database sang Redis")]
    public async ValueTask<IActionResult> SyncDbToRedis() => Ok(await _service.SyncDbToRedis());
}
