#if RELEASE
using Microsoft.AspNetCore.Authorization;
#endif
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
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
[Route("api/[controller]")]
public sealed class DeveloperTypeController(ILogger<DeveloperTypeController> logger, IDeveloperTypeService service) : YANLibController
{
    private readonly ILogger<DeveloperTypeController> _logger = logger;
    private readonly IDeveloperTypeService _service = service;

    [HttpGet]
    [SwaggerOperation(
        Summary = "Lấy danh sách định nghĩa loại lập trình viên",
        Description = "Lấy tất cả định nghĩa loại lập trình viên"
    )]
    [ProducesResponseType(typeof(List<DeveloperTypeResponse?>), Status200OK)]
    [ProducesResponseType(Status204NoContent)]
    public async Task<ActionResult<List<DeveloperTypeResponse?>?>> GetAll(CancellationToken cancellationToken = default) => Ok(await _service.GetAllAsync(cancellationToken));

    [HttpGet("{code:long}")]
    [SwaggerOperation(
        Summary = "Lấy định nghĩa loại lập trình viên theo mã",
        Description = "Lấy thông tin định nghĩa loại lập trình viên theo mã"
    )]
    [ProducesResponseType(typeof(DeveloperTypeResponse), Status200OK)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<DeveloperTypeResponse>> Get([FromRoute] long code, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Get-DeveloperTypeController: {Code}", code);

        var result = await _service.GetOrAddAsync(code, cancellationToken);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Thêm mới định nghĩa loại lập trình viên",
        Description = "Tạo mới một định nghĩa loại lập trình viên với thông tin được cung cấp"
    )]
    [ProducesResponseType(typeof(DeveloperTypeResponse), Status201Created)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody][Required] DeveloperTypeCreateRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Add-DeveloperTypeController: {Request}", request.Serialize());

        var result = await _service.AddAsync(request, cancellationToken);

        return result.IsNull()
            ? Conflict()
            : CreatedAtAction(nameof(Get), new
            {
                id = result.Id,
                version = "2.0"
            }, result);
    }

    [HttpPatch("{code:long}")]
    [SwaggerOperation(
        Summary = "Cập nhật định nghĩa loại lập trình viên",
        Description = "Cập nhật thông tin định nghĩa loại lập trình viên theo mã"
    )]
    [ProducesResponseType(typeof(DeveloperTypeResponse), Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<DeveloperTypeResponse>> Modify([FromRoute] long code, [FromBody][Required] DeveloperTypeUpdateRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Modify-DeveloperTypeController: {Code} - {Request}", code, request.Serialize());

        var result = await _service.ModifyAsync(code, request, cancellationToken);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpDelete("{code:long}")]
    [SwaggerOperation(
        Summary = "Xóa định nghĩa loại lập trình viên",
        Description = "Xóa định nghĩa loại lập trình viên theo mã"
    )]
    [ProducesResponseType(Status204NoContent)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] long code, [FromQuery][Required] Guid updatedBy, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Delete-DeveloperTypeController: {Code} - {UpdatedBy}", code, updatedBy);

        var result = await _service.DeleteAsync(code, updatedBy, cancellationToken);

        return result ? NoContent() : NotFound();
    }

#if RELEASE
    [Authorize(Roles = "GlobalRole, OtherRole")]
#endif
    [HttpPost("sync-data-to-redis")]
    [SwaggerOperation(
        Summary = "Đồng bộ tất cả định nghĩa loại lập trình viên từ Database sang Redis",
        Description = "Đồng bộ tất cả định nghĩa loại lập trình viên từ Database sang Redis để cải thiện hiệu suất truy xuất dữ liệu"
    )]
    [ProducesResponseType(typeof(bool), Status200OK)]
    public async Task<IActionResult> SyncDataToRedis(CancellationToken cancellationToken = default) => Ok(await _service.SyncDataToRedisAsync(cancellationToken));
}
