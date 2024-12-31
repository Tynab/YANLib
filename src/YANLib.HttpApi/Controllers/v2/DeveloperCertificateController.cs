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
using YANLib.Core;
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
[Route("api/developer-certificates")]
public sealed class DeveloperCertificateController(ILogger<DeveloperCertificateController> logger, IDeveloperCertificateService service) : YANLibController
{
    private readonly ILogger<DeveloperCertificateController> _logger = logger;
    private readonly IDeveloperCertificateService _service = service;

    [HttpGet("get-by-developer")]
    [SwaggerOperation(Summary = "Lấy tất cả chứng chỉ của lập trình viên theo mã định danh")]
    public async ValueTask<ActionResult<PagedResultDto<DeveloperCertificateResponse>>> GetByDeveloper([Required] Guid developerId, byte pageNumber = 1, byte pageSize = 10)
    {
        _logger.LogInformation("GetByDeveloper-DeveloperCertificateController: {DeveloperId}", developerId);

        return Ok(await _service.GetByDeveloper(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            pageNumber,
            pageSize,
            $"{nameof(DeveloperCertificateResponse.CreatedAt)} {Descending}"
        )), developerId));
    }

    [HttpGet("get-by-developer-and-certificate")]
    [SwaggerOperation(Summary = "Lấy chứng chỉ của lập trình viên theo mã định danh và mã chứng chỉ")]
    public async ValueTask<ActionResult<DeveloperCertificateResponse>> GetByDeveloperAndCertificate([Required] Guid developerId, [Required] string certificateCode)
    {
        _logger.LogInformation("GetByDeveloperAndCertificate-DeveloperCertificateController: {DeveloperId} - {CertificateCode}", developerId, certificateCode);

        return Ok(await _service.GetByDeveloperAndCertificate(developerId, certificateCode));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới chứng chỉ của lập trình viên")]
    public async ValueTask<ActionResult<DeveloperCertificateResponse>> Insert(DeveloperCertificateCreateRequest request)
    {
        _logger.LogInformation("Insert-DeveloperCertificateController: {Request}", request.Serialize());

        return Ok(await _service.Insert(request));
    }

    [HttpPatch]
    [SwaggerOperation(Summary = "Cập nhật chứng chỉ của lập trình viên")]
    public async ValueTask<ActionResult<DeveloperCertificateResponse>> Modify(DeveloperCertificateUpdateRequest request)
    {
        _logger.LogInformation("Modify-DeveloperCertificateController: {Request}", request.Serialize());

        return Ok(await _service.Modify(request));
    }

    [HttpDelete]
    [SwaggerOperation(Summary = "Xóa chứng chỉ của lập trình viên")]
    public async ValueTask<ActionResult<DeveloperCertificateResponse>> Delete([Required] Guid developerId, [Required] string certificateCode, [Required] Guid updatedBy)
    {
        _logger.LogInformation("Delete-DeveloperCertificateController: {DeveloperId} - {CertificateCode} - {UpdatedBy}", developerId, certificateCode, updatedBy);

        return Ok(await _service.Delete(developerId, certificateCode, updatedBy));
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
    public async ValueTask<IActionResult> SyncDbToRedisByDeveloper([Required] Guid developerId)
    {
        _logger.LogInformation("SyncDbToRedisByDeveloper-DeveloperCertificateController: {DeveloperId}", developerId);

        return Ok(await _service.SyncDbToRedisByDeveloper(developerId));
    }
}
