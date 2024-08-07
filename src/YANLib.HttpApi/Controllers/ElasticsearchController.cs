using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using YANLib.Core;
using YANLib.EsIndices;
using YANLib.EsServices;

namespace YANLib.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = "sample")]
[Route("api/[controller]")]
public sealed class ElasticsearchController(ILogger<ElasticsearchController> logger, IDeveloperEsService developerEsService, ICertificateEsService certificateEsService) : YANLibController
{
    private readonly ILogger<ElasticsearchController> _logger = logger;
    private readonly IDeveloperEsService _developerEsService = developerEsService;
    private readonly ICertificateEsService _certificateEsService = certificateEsService;

    [HttpGet("developers/{id}")]
    [SwaggerOperation(Summary = "Lấy lập trình viên theo Id trên Elasticsearch")]
    public async ValueTask<ActionResult<DeveloperEsIndex>> GetDeveloper(string id)
    {
        _logger.LogInformation("GetDeveloper-ElasticsearchController: {Id}", id);

        return Ok(await _developerEsService.Get(id));
    }

    [HttpPost("developers")]
    [SwaggerOperation(Summary = "Thêm mới lập trình viên trên Elasticsearch")]
    public async ValueTask<IActionResult> SetDeveloper([Required] DeveloperEsIndex request)
    {
        _logger.LogInformation("SetDeveloper-ElasticsearchController: {Request}", request.Serialize());

        return Ok(await _developerEsService.Set(request));
    }

    [HttpGet("certificates/{id}")]
    [SwaggerOperation(Summary = "Lấy chứng chỉ theo Id trên Elasticsearch")]
    public async ValueTask<ActionResult<CertificateEsIndex>> GetCertificate(string id)
    {
        _logger.LogInformation("GetCertificate-ElasticsearchController: {Id}", id);

        return Ok(await _certificateEsService.Get(id));
    }

    [HttpPost("certificates")]
    [SwaggerOperation(Summary = "Thêm mới chứng chỉ trên Elasticsearch")]
    public async ValueTask<IActionResult> SetCertificate([Required] CertificateEsIndex request)
    {
        _logger.LogInformation("SetCertificate-ElasticsearchController: {Request}", request.Serialize());

        return Ok(await _certificateEsService.Set(request));
    }
}
