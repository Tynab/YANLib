#if RELEASE
using Microsoft.AspNetCore.Authorization;
#endif
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
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
[Route("api/certificates")]
public sealed class CertificateController(ILogger<CertificateController> logger, ICertificateService service) : YANLibController
{
    private readonly ILogger<CertificateController> _logger = logger;
    private readonly ICertificateService _service = service;

    [HttpGet]
    [SwaggerOperation(Summary = "Lấy tất cả chứng chỉ")]
    public async ValueTask<ActionResult<PagedResultDto<CertificateResponse>>> GetAll(byte pageNumber = 1, byte pageSize = 10)
    {
        _logger.LogInformation("GetAll-CertificateCrudController: {PageNumber} - {PageSize}", pageNumber, pageSize);

        return Ok(await _service.GetListAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            pageNumber,
            pageSize,
            $"{nameof(CertificateResponse.Name)} {Ascending},{nameof(CertificateResponse.CreatedAt)} {Descending}"
        ))));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Lấy chứng chỉ theo Id")]
    public async ValueTask<ActionResult<CertificateResponse>> Get(string id)
    {
        _logger.LogInformation("Get-CertificateCrudController: {Id}", id);

        return Ok(await _service.GetAsync(id));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới chứng chỉ")]
    public async ValueTask<ActionResult<CertificateResponse>> Create(CertificateCreateRequest input)
    {
        _logger.LogInformation("Create-CertificateCrudController: {Input}", input.Serialize());

        return Ok(await _service.CreateAsync(input));
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Cập nhật chứng chỉ")]
    public async ValueTask<ActionResult<CertificateResponse>> Update(string id, CertificateUpdateRequest input)
    {
        _logger.LogInformation("Update-CertificateCrudController: {Id} - {Input}", id, input.Serialize());

        return Ok(await _service.UpdateAsync(id, input));
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Xóa chứng chỉ")]
    public async ValueTask<IActionResult> Delete(string id)
    {
        _logger.LogInformation("Delete-CertificateCrudController: {Id}", id);
        await _service.DeleteAsync(id);

        return Ok();
    }
}
