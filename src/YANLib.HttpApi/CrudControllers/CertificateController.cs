using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
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
    [SwaggerOperation(Summary = "Lấy tất cả chứng chỉ")]
    public async ValueTask<ActionResult<PagedResultDto<CertificateResponse>>> GetAll(byte pageNumber = 1, byte pageSize = 10) => Ok(await _service.GetListAsync(new PagedAndSortedResultRequestDto
    {
        SkipCount = (pageNumber - 1) * pageSize,
        MaxResultCount = pageSize,
        Sorting = $"{nameof(DeveloperResponse.Name)} ASC,{nameof(DeveloperResponse.CreatedAt)} DESC"
    }));

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Lấy chứng chỉ theo Id")]
    public async ValueTask<ActionResult<CertificateResponse>> Get(Guid id)
    {
        _logger.LogInformation("Get-CertificateCrudController: {Id}", id);

        return Ok(await _service.GetAsync(id));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới chứng chỉ")]
    public async ValueTask<ActionResult<CertificateResponse>> Create(CertificateCreateRequest request)
    {
        _logger.LogInformation("Create-CertificateCrudController: {Request}", request.Serialize());

        return Ok(await _service.CreateAsync(request));
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Cập nhật chứng chỉ")]
    public async ValueTask<ActionResult<CertificateResponse>> Update(Guid id, CertificateUpdateRequest request)
    {
        _logger.LogInformation("Update-CertificateCrudController: {Id} - {Request}", id, request.Serialize());

        return Ok(await _service.UpdateAsync(id, request));
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Xóa chứng chỉ")]
    public async ValueTask<IActionResult> Delete(Guid id)
    {
        _logger.LogInformation("Delete-CertificateCrudController: {Id}", id);
        await _service.DeleteAsync(id);

        return Ok();
    }
}
