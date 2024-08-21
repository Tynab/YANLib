using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using YANLib.Core;
using YANLib.Requests.Insert;
using YANLib.Requests.Modify;
using YANLib.Services;

namespace YANLib.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = "sample")]
[Route("api/[controller]")]
public sealed class CertificateController(ILogger<CertificateController> logger, ICertificateService service) : YANLibController
{
    private readonly ILogger<CertificateController> _logger = logger;
    private readonly ICertificateService _service = service;

    [HttpGet("{code}")]
    [SwaggerOperation(Summary = "Lấy chứng chỉ theo mã")]
    public async ValueTask<IActionResult> GetByCode(string code)
    {
        _logger.LogInformation("GetByCode-CardCertificateController: {Code}", code);

        return Ok(await _service.GetByCode(code));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới chứng chỉ")]
    public async ValueTask<IActionResult> Insert([Required] CertificateInsertRequest request)
    {
        _logger.LogInformation("Insert-CertificateController: {Request}", request.Serialize());

        return Ok(await _service.Insert(request));
    }

    [HttpPatch("{code}")]
    [SwaggerOperation(Summary = "Cập nhật chứng chỉ")]
    public async ValueTask<IActionResult> Modify(string code, [Required] CertificateModifyRequest request)
    {
        _logger.LogInformation("Modify-CertificateController: {Code} - {Request}", code, request.Serialize());

        return Ok(await _service.Modify(code, request));
    }

    [HttpPost("sync-db-to-es")]
    [SwaggerOperation(Summary = "Đồng bộ tất cả chứng chỉ từ Database sang Elasticsearch")]
    public async ValueTask<IActionResult> SyncDbToEs() => Ok(await _service.SyncDbToEs());
}
