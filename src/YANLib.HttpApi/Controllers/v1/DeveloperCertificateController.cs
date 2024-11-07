#if RELEASE
using Microsoft.AspNetCore.Authorization;
#endif
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using YANLib.Core;
using YANLib.Requests.Crud.Create;
using YANLib.Requests.Crud.Update;
using YANLib.Responses;
using YANLib.Services.v1;

namespace YANLib.Controllers.v1;

#if RELEASE
[Authorize(Roles = "GlobalRole, OtherRole")]
#endif
[Area("DeveloperCertificates")]
//[RemoteService(Name = "DeveloperCertificates")]
[ApiVersion(1, Deprecated = true)]
[ApiController]
[Route("api/developer-certificates")]
public sealed class DeveloperCertificateController(ILogger<DeveloperCertificateController> logger, IDeveloperCertificateService service) : YANLibController
{
    private readonly ILogger<DeveloperCertificateController> _logger = logger;
    private readonly IDeveloperCertificateService _service = service;

    [HttpGet]
    [SwaggerOperation(Summary = "Lấy tất cả chứng chỉ của lập trình viên")]
    public async ValueTask<ActionResult<PagedResultDto<DeveloperCertificateResponse>>> GetAll(byte pageNumber = 1, byte pageSize = 10)
    {
        _logger.LogInformation("GetAll-DeveloperCertificateCrudController: {PageNumber} - {PageSize}", pageNumber, pageSize);

        return Ok(await _service.GetListAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize), PagedAndSortedResultRequestDto>((pageNumber, pageSize))));
    }

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
