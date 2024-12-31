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
using YANLib.Core;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Services.v2;

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

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Lấy Developer theo mã định danh")]
    public async ValueTask<IActionResult> GetByIdCard(Guid id)
    {
        _logger.LogInformation("GetById-CardDeveloperController: {Id}", id);

        return Ok(await _service.Get(id));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới lập trình viên")]
    public async ValueTask<IActionResult> Insert([Required] DeveloperCreateRequest request)
    {
        _logger.LogInformation("Insert-DeveloperController: {Request}", request.Serialize());

        return Ok(await _service.Insert(request));
    }

    [HttpPatch("{idCard}")]
    [SwaggerOperation(Summary = "Cập nhật lập trình viên")]
    public async ValueTask<IActionResult> Adjust(string idCard, [Required] DeveloperUpdateRequest request)
    {
        _logger.LogInformation("Adjust-DeveloperController: {IdCard} - {Request}", idCard, request.Serialize());

        return Ok(await _service.Adjust(idCard, request));
    }

#if RELEASE
[Authorize(Roles = "GlobalRole")]
#endif
    [HttpPost("sync-db-to-es")]
    [SwaggerOperation(Summary = "Đồng bộ tất cả Developers từ Database lên Elasticsearch")]
    public async ValueTask<IActionResult> SyncDbToEs() => Ok(await _service.SyncDbToEs());
}
