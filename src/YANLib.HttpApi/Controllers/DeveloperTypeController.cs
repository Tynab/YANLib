using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp;
using YANLib.Core;
using YANLib.Requests.Insert;
using YANLib.Requests.Modify;
using YANLib.Responses;
using YANLib.Services;

namespace YANLib.Controllers;

[RemoteService]
[ApiExplorerSettings(GroupName = "sample")]
[Route("api/developer-types")]
public sealed class DeveloperTypeController(ILogger<DeveloperTypeController> logger, IDeveloperTypeService service) : YANLibController
{
    private readonly ILogger<DeveloperTypeController> _logger = logger;
    private readonly IDeveloperTypeService _service = service;

    [HttpGet]
    [SwaggerOperation(Summary = "Lấy tất cả định nghĩa Developer Types")]
    public async ValueTask<ActionResult<IEnumerable<DeveloperTypeResponse>>> GetAll() => Ok(await _service.GetAll());

    [HttpGet("{code}")]
    [SwaggerOperation(Summary = "Lấy định nghĩa Developer Type theo Code")]
    public async ValueTask<ActionResult<DeveloperTypeResponse>> Get(long code)
    {
        _logger.LogInformation("GetDeveloperTypeController: {Code}", code);

        return Ok(await _service.Get(code));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới định nghĩa Developer Type")]
    public async ValueTask<ActionResult<DeveloperTypeResponse>> Insert([Required] DeveloperTypeInsertRequest request)
    {
        _logger.LogInformation("InsertDeveloperTypeController: {Request}", request.Serialize());

        return Ok(await _service.Insert(request));
    }

    [HttpPatch("{code}")]
    [SwaggerOperation(Summary = "Cập nhật định nghĩa Developer Type")]
    public async ValueTask<ActionResult<DeveloperTypeResponse>> Modify(long code, [Required] DeveloperTypeModifyRequest request)
    {
        _logger.LogInformation("ModifyDeveloperTypeController: {Code} - {Request}", code, request.Serialize());

        return Ok(await _service.Modify(code, request));
    }

    [HttpDelete("{code}")]
    [SwaggerOperation(Summary = "Xóa định nghĩa Developer Type")]
    public async ValueTask<ActionResult<DeveloperTypeResponse>> Delete(long code, [Required] Guid updatedBy)
    {
        _logger.LogInformation("DeleteDeveloperTypeController: {Code} - {UpdatedBy}", code, updatedBy);

        return Ok(await _service.Delete(code, updatedBy));
    }

    [HttpPost("sync-db-to-redis")]
    [SwaggerOperation(Summary = "Đồng bộ tất cả định nghĩa Developer Types từ Database sang Redis")]
    public async ValueTask<IActionResult> SyncDbToRedis() => Ok(await _service.SyncDbToRedis());
}
