using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.Core;
using YANLib.CrudServices;
using YANLib.Requests.Crud.Create;
using YANLib.Requests.Crud.Update;
using YANLib.Responses;

namespace YANLib.CrudControllers;

[ApiController]
[ApiExplorerSettings(GroupName = "crud")]
[Route("api/certificates")]
public sealed class CertificateController(ILogger<CertificateController> logger, ICertificateCrudService service) : YANLibController
{
    private readonly ILogger<CertificateController> _logger = logger;
    private readonly ICertificateCrudService _service = service;

    [HttpGet]
    public async ValueTask<ActionResult<PagedResultDto<CertificateResponse>>> GetAll() => Ok(await _service.GetListAsync(new PagedAndSortedResultRequestDto()));

    [HttpGet("{id}")]
    public async ValueTask<ActionResult<CertificateResponse>> Get(Guid id)
    {
        _logger.LogInformation("Get-CertificateCrudController: {Id}", id);

        return Ok(await _service.GetAsync(id));
    }

    [HttpPost]
    public async ValueTask<ActionResult<CertificateResponse>> Create(CertificateCreateRequest request)
    {
        _logger.LogInformation("Create-CertificateCrudController: {Request}", request.Serialize());

        return Ok(await _service.CreateAsync(request));
    }

    [HttpPut("{id}")]
    public async ValueTask<ActionResult<CertificateResponse>> Update(Guid id, CertificateUpdateRequest request)
    {
        _logger.LogInformation("Update-CertificateCrudController: {Id} - {Request}", id, request.Serialize());

        return Ok(await _service.UpdateAsync(id, request));
    }

    [HttpDelete("{id}")]
    public async ValueTask<IActionResult> Delete(Guid id)
    {
        _logger.LogInformation("Delete-CertificateCrudController: {Id}", id);
        await _service.DeleteAsync(id);

        return Ok();
    }
}
