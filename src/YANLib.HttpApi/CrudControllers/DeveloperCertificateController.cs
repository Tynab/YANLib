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
[Route("api/developer-certificates")]
public sealed class DeveloperCertificateController(ILogger<DeveloperCertificateController> logger, IDeveloperCertificateCrudService service) : YANLibController
{
    private readonly ILogger<DeveloperCertificateController> _logger = logger;
    private readonly IDeveloperCertificateCrudService _service = service;

    [HttpGet]
    [SwaggerOperation(Summary = "Lấy tất cả chứng chỉ của lập trình viên")]
    public async ValueTask<ActionResult<PagedResultDto<DeveloperCertificateResponse>>> GetAll(byte pageNumber = 1, byte pageSize = 10) => Ok(await _service.GetListAsync(new PagedAndSortedResultRequestDto
    {
        SkipCount = (pageNumber - 1) * pageSize,
        MaxResultCount = pageSize
    }));

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Lấy chứng chỉ của lập trình viên theo Id")]
    public async ValueTask<ActionResult<DeveloperCertificateResponse>> Get(Guid id)
    {
        _logger.LogInformation("Get-DeveloperCertificateCrudController: {Id}", id);

        return Ok(await _service.GetAsync(id));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới chứng chỉ của lập trình viên")]
    public async ValueTask<ActionResult<DeveloperCertificateResponse>> Create(DeveloperCertificateCreateRequest request)
    {
        _logger.LogInformation("Create-DeveloperCertificateCrudController: {Request}", request.Serialize());

        return Ok(await _service.CreateAsync(request));
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Cập nhật chứng chỉ của lập trình viên")]
    public async ValueTask<ActionResult<DeveloperCertificateResponse>> Update(Guid id, DeveloperCertificateUpdateRequest request)
    {
        _logger.LogInformation("Update-DeveloperCertificateCrudController: {Id} - {Request}", id, request.Serialize());

        return Ok(await _service.UpdateAsync(id, request));
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Xóa chứng chỉ của lập trình viên")]
    public async ValueTask<IActionResult> Delete(Guid id)
    {
        _logger.LogInformation("Delete-DeveloperCertificateCrudController: {Id}", id);
        await _service.DeleteAsync(id);

        return Ok();
    }
}
