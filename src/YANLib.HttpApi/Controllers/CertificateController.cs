using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp;
using YANLib.Requests;
using YANLib.Services;

namespace YANLib.Controllers;

[RemoteService]
[ApiExplorerSettings(GroupName = "sample")]
[Route("api/yanlib/certificates")]
public sealed class CertificateController : YANLibController
{
    #region Fields
    private readonly ILogger<CertificateController> _logger;
    private readonly ICertificateService _service;
    #endregion

    #region Constructors
    public CertificateController(ILogger<CertificateController> logger, ICertificateService service)
    {
        _logger = logger;
        _service = service;
    }
    #endregion

    #region Methods
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Tìm Certificate theo Id")]
    public async ValueTask<IActionResult> Get([Required] Guid id)
    {
        _logger.LogInformation("GetCertificateController: {Id}", id);

        return Ok(await _service.Get(id));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới Certificate")]
    public async ValueTask<IActionResult> Insert([Required] CertificateRequest request)
    {
        _logger.LogInformation("InsertCertificateController: {Request}", request.CamelSerialize());

        return Ok(await _service.Insert(request));
    }

    [HttpPut]
    [SwaggerOperation(Summary = "Cập nhật Certificate")]
    public async ValueTask<IActionResult> Update([Required] CertificateFullRequest request)
    {
        _logger.LogInformation("UpdateCertificateController: {Request}", request.CamelSerialize());

        return Ok(await _service.Update(request));
    }

    [HttpGet("get-by-developer-id")]
    [SwaggerOperation(Summary = "Tìm tất cả Certificates theo Developer Id")]
    public async ValueTask<IActionResult> GetByDeveloperId([Required] Guid developerId)
    {
        _logger.LogInformation("GetByDeveloperIdCertificateController: {developerId}", developerId);

        return Ok(await _service.GetByDeveloperId(developerId));
    }
    #endregion
}
