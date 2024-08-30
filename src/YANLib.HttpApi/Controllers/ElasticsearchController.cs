#if RELEASE
using Microsoft.AspNetCore.Authorization;
#endif
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using YANLib.Core;
using YANLib.EsIndices;
using YANLib.EsServices;

namespace YANLib.Controllers;

#if RELEASE
[Authorize(Roles = "GlobalRole, OtherRole")]
#endif
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

    [HttpPost("developers/bulk")]
    [SwaggerOperation(Summary = "Thêm mới lập trình viên theo danh sách trên Elasticsearch")]
    public async ValueTask<IActionResult> SetDeveloperBulk([Required] List<DeveloperEsIndex> requests)
    {
        _logger.LogInformation("SetDeveloperBulk-ElasticsearchController: {Requests}", requests.Serialize());

        return Ok(await _developerEsService.SetBulk(requests));
    }

    [HttpDelete("developers/{id}")]
    [SwaggerOperation(Summary = "Xóa lập trình viên theo Id trên Elasticsearch")]
    public async ValueTask<IActionResult> DeleteDeveloper(string id)
    {
        _logger.LogInformation("DeleteDeveloper-ElasticsearchController: {Id}", id);

        return Ok(await _developerEsService.Delete(id));
    }

    [HttpDelete("developers")]
    [SwaggerOperation(Summary = "Xóa tất cả lập trình viên trên Elasticsearch")]
    public async ValueTask<IActionResult> DeleteAllDeveloper()
    {
        _logger.LogInformation("DeleteAllDeveloper-ElasticsearchController");

        return Ok(await _developerEsService.DeleteAll());
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

    [HttpPost("certificates/bulk")]
    [SwaggerOperation(Summary = "Thêm mới chứng chỉ theo danh sách trên Elasticsearch")]
    public async ValueTask<IActionResult> SetCertificateBulk([Required] List<CertificateEsIndex> requests)
    {
        _logger.LogInformation("SetCertificateBulk-ElasticsearchController: {Requests}", requests.Serialize());

        return Ok(await _certificateEsService.SetBulk(requests));
    }

    [HttpDelete("certificates/{id}")]
    [SwaggerOperation(Summary = "Xóa chứng chỉ theo Id trên Elasticsearch")]
    public async ValueTask<IActionResult> DeleteCertificate(string id)
    {
        _logger.LogInformation("DeleteCertificate-ElasticsearchController: {Id}", id);

        return Ok(await _certificateEsService.Delete(id));
    }

    [HttpDelete("certificates")]
    [SwaggerOperation(Summary = "Xóa tất cả chứng chỉ trên Elasticsearch")]
    public async ValueTask<IActionResult> DeleteAllCertificate()
    {
        _logger.LogInformation("DeleteAllCertificate-ElasticsearchController");

        return Ok(await _certificateEsService.DeleteAll());
    }
}
