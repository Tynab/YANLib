#if RELEASE
using Microsoft.AspNetCore.Authorization;
#endif
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.Core;
using YANLib.Requests.v1.Create;
using YANLib.Requests.v1.Update;
using YANLib.Responses;
using YANLib.Services.v1;
using static Nest.SortOrder;

namespace YANLib.Controllers.v1;

#if RELEASE
[Authorize(Roles = "GlobalRole, OtherRole")]
#endif
[ApiVersion(1, Deprecated = true)]
[ApiController]
[Route("api/developer-types")]
public sealed class DeveloperTypeController(ILogger<DeveloperTypeController> logger, IDeveloperTypeService service) : YANLibController
{
    private readonly ILogger<DeveloperTypeController> _logger = logger;
    private readonly IDeveloperTypeService _service = service;

    [HttpGet]
    [SwaggerOperation(Summary = "Lấy tất cả định nghĩa loại lập trình viên")]
    public async ValueTask<ActionResult<PagedResultDto<DeveloperTypeResponse>>> GetAll(byte pageNumber = 1, byte pageSize = 10)
    {
        _logger.LogInformation("GetAll-DeveloperTypeController: {PageNumber} - {PageSize}", pageNumber, pageSize);

        return Ok(await _service.GetListAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            pageNumber,
            pageSize,
            $"{nameof(CertificateResponse.Name)} {Ascending},{nameof(CertificateResponse.CreatedAt)} {Descending}"
        ))));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Lấy định nghĩa loại lập trình viên theo Id")]
    public async ValueTask<ActionResult<DeveloperTypeResponse>> Get(Guid id)
    {
        _logger.LogInformation("Get-DeveloperTypeCrudController: {Id}", id);

        return Ok(await _service.GetAsync(id));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới định nghĩa loại lập trình viên")]
    public async ValueTask<ActionResult<DeveloperTypeResponse>> Create(DeveloperTypeCreateRequest request)
    {
        _logger.LogInformation("Create-DeveloperTypeCrudController: {Request}", request.Serialize());

        return Ok(await _service.CreateAsync(request));
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Cập nhật định nghĩa loại lập trình viên")]
    public async ValueTask<ActionResult<DeveloperTypeResponse>> Update(Guid id, DeveloperTypeUpdateRequest request)
    {
        _logger.LogInformation("Update-DeveloperTypeCrudController: {Id} - {Request}", id, request.Serialize());

        return Ok(await _service.UpdateAsync(id, request));
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Xóa định nghĩa loại lập trình viên")]
    public async ValueTask<IActionResult> Delete(Guid id)
    {
        _logger.LogInformation("Delete-DeveloperTypeCrudController: {Id}", id);
        await _service.DeleteAsync(id);

        return Ok();
    }
}
