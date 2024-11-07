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
using System.Threading.Tasks;
using Volo.Abp;
using YANLib.Core;
using YANLib.Requests.Insert;
using YANLib.Requests.Modify;
using YANLib.Responses;
using YANLib.Services.v2;

namespace YANLib.Controllers.v2;

#if RELEASE
[Authorize(Roles = "GlobalRole, OtherRole")]
#endif
[Area("DeveloperCertificates")]
//[RemoteService(Name = "DeveloperCertificates")]
[ApiVersion(2)]
[ApiController]
[Route("api/developer-certificates")]
public sealed class DeveloperCertificateController(ILogger<DeveloperCertificateController> logger, IDeveloperCertificateService service) : YANLibController
{
    private readonly ILogger<DeveloperCertificateController> _logger = logger;
    private readonly IDeveloperCertificateService _service = service;

    [HttpGet("get-by-developer")]
    [SwaggerOperation(Summary = "Lấy tất cả chứng chỉ của lập trình viên theo mã định danh")]
    public async ValueTask<ActionResult<IEnumerable<DeveloperCertificateResponse>>> GetByDeveloper([Required] string idCard)
    {
        _logger.LogInformation("GetByDeveloper-DeveloperCertificateController: {IdCard}", idCard);

        return Ok(await _service.GetByDeveloper(idCard));
    }

    [HttpGet("get-by-developer-and-certificate")]
    [SwaggerOperation(Summary = "Lấy chứng chỉ của lập trình viên theo mã định danh và mã chứng chỉ")]
    public async ValueTask<ActionResult<DeveloperCertificateResponse>> GetByDeveloperAndCertificate([Required] string idCard, [Required] long code)
    {
        _logger.LogInformation("GetByDeveloperAndCertificate-DeveloperCertificateController: {IdCard} - {Code}", idCard, code);

        return Ok(await _service.GetByDeveloperAndCertificate(idCard, code));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới chứng chỉ của lập trình viên")]
    public async ValueTask<ActionResult<DeveloperCertificateResponse>> Insert(DeveloperCertificateInsertRequest request)
    {
        _logger.LogInformation("Insert-DeveloperCertificateController: {Request}", request.Serialize());

        return Ok(await _service.Insert(request));
    }

    [HttpPatch]
    [SwaggerOperation(Summary = "Cập nhật chứng chỉ của lập trình viên")]
    public async ValueTask<ActionResult<DeveloperCertificateResponse>> Modify(DeveloperCertificateModifyRequest request)
    {
        _logger.LogInformation("Modify-DeveloperCertificateController: {Request}", request.Serialize());

        return Ok(await _service.Modify(request));
    }

    [HttpDelete]
    [SwaggerOperation(Summary = "Xóa chứng chỉ của lập trình viên")]
    public async ValueTask<ActionResult<DeveloperCertificateResponse>> Delete([Required] string idCard, [Required] long code, [Required] Guid updatedBy)
    {
        _logger.LogInformation("Delete-DeveloperCertificateController: {IdCard} - {Code} - {UpdatedBy}", idCard, code, updatedBy);

        return Ok(await _service.Delete(idCard, code, updatedBy));
    }

#if RELEASE
[Authorize(Roles = "GlobalRole")]
#endif
    [HttpPost("sync-db-to-redis")]
    [SwaggerOperation(Summary = "Đồng bộ tất cả chứng chỉ của lập trình viên từ Database sang Redis")]
    public async ValueTask<IActionResult> SyncDbToRedis() => Ok(await _service.SyncDbToRedis());

#if RELEASE
[Authorize(Roles = "GlobalRole")]
#endif
    [HttpPost("sync-db-to-redis-by-developer")]
    [SwaggerOperation(Summary = "Đồng bộ chứng chỉ của lập trình viên từ Database sang Redis theo mã định danh")]
    public async ValueTask<IActionResult> SyncDbToRedisByDeveloper([Required] string idCard)
    {
        _logger.LogInformation("SyncDbToRedisByDeveloper-DeveloperCertificateController: {IdCard}", idCard);

        return Ok(await _service.SyncDbToRedisByDeveloper(idCard));
    }
}
