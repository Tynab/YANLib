#if RELEASE
using Microsoft.AspNetCore.Authorization;
#endif
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using YANLib.Requests.v1.Create;
using YANLib.Requests.v1.Update;
using YANLib.Responses;
using YANLib.Services.v1;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace YANLib.Controllers.v1;

#if RELEASE
[Authorize(Roles = "GlobalRole, OtherRole")]
#endif
[ApiVersion(1, Deprecated = true)]
[ApiController]
[Route("api/[controller]")]
public sealed class DeveloperTypeController(ILogger<DeveloperTypeController> logger, IDeveloperTypeService service) : YANLibController
{
    private readonly ILogger<DeveloperTypeController> _logger = logger;
    private readonly IDeveloperTypeService _service = service;

    [HttpGet]
    [SwaggerOperation(
        Summary = "Lấy tất cả định nghĩa loại lập trình viên",
        Description = "Lấy danh sách định nghĩa loại lập trình viên"
    )]
    [ProducesResponseType(typeof(List<DeveloperTypeResponse>), Status200OK)]
    [ProducesResponseType(Status204NoContent)]
    public async Task<ActionResult<List<DeveloperTypeResponse>>> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{code:long}")]
    [SwaggerOperation(
        Summary = "Lấy định nghĩa loại lập trình viên theo mã",
        Description = "Lấy thông tin định nghĩa loại lập trình viên theo mã"
    )]
    [ProducesResponseType(typeof(DeveloperTypeResponse), Status200OK)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<DeveloperTypeResponse>> Get([FromRoute] long code)
    {
        _logger.LogInformation("Get-DeveloperTypeController: {Code}", code);

        var result = await _service.GetAsync(code);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Thêm mới định nghĩa loại lập trình viên",
        Description = "Tạo mới một định nghĩa loại lập trình viên với thông tin được cung cấp"
    )]
    [ProducesResponseType(typeof(DeveloperTypeResponse), Status201Created)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody][Required] DeveloperTypeCreateRequest request)
    {
        _logger.LogInformation("Create-DeveloperTypeController: {Request}", request.Serialize());

        var result = await _service.CreateAsync(request);

        return CreatedAtAction(nameof(Get), new
        {
            id = result.Id,
            version = "1.0"
        }, result);
    }

    [HttpPut("{code:long}")]
    [SwaggerOperation(
        Summary = "Cập nhật định nghĩa loại lập trình viên",
        Description = "Cập nhật thông tin định nghĩa loại lập trình viên theo mã"
    )]
    [ProducesResponseType(typeof(DeveloperTypeResponse), Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<DeveloperTypeResponse>> Update([FromRoute] long code, [FromBody][Required] DeveloperTypeUpdateRequest request)
    {
        _logger.LogInformation("Update-DeveloperTypeController: {Code} - {Request}", code, request.Serialize());

        var result = await _service.UpdateAsync(code, request);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpDelete("{code:long}")]
    [SwaggerOperation(
        Summary = "Xóa định nghĩa loại lập trình viên",
        Description = "Xóa định nghĩa loại lập trình viên theo mã"
    )]
    [ProducesResponseType(Status204NoContent)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] long code)
    {
        _logger.LogInformation("Delete-DeveloperTypeController: {Code}", code);

        await _service.DeleteAsync(code);

        return NoContent();
    }
}
