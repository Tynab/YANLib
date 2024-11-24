#if RELEASE
using Microsoft.AspNetCore.Authorization;
#endif
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.Core;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;
using YANLib.Services.v2;
using static Nest.SortOrder;

namespace YANLib.Controllers.v2;

#if RELEASE
[Authorize(Roles = "GlobalRole, OtherRole")]
#endif
[ApiVersion(2)]
[ApiController]
[Route("api/certificates")]
public sealed class CertificateController(ILogger<CertificateController> logger, ICertificateService service) : YANLibController
{
    private readonly ILogger<CertificateController> _logger = logger;
    private readonly ICertificateService _service = service;

    [HttpGet]
    [SwaggerOperation(Summary = "Lấy danh sách chứng chỉ")]
    public async ValueTask<ActionResult<PagedResultDto<CertificateResponse>>> GetAll(byte pageNumber = 1, byte pageSize = 10)
    {
        _logger.LogInformation("GetAll-CardCertificateController: {PageNumber} - {PageSize}", pageNumber, pageSize);

        return Ok(await _service.GetAll(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            pageNumber,
            pageSize,
            $"{nameof(CertificateResponse.Name)} {Ascending},{nameof(CertificateResponse.CreatedAt)} {Descending}"
        ))));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Lấy chứng chỉ theo mã")]
    public async ValueTask<IActionResult> Get(string id)
    {
        _logger.LogInformation("Get-CardCertificateController: {Id}", id);

        return Ok(await _service.Get(id));
    }

    [HttpGet("get-by-name")]
    [SwaggerOperation(Summary = "Lấy danh sách chứng chỉ theo tên")]
    public async ValueTask<IActionResult> GetByName([Required] string name, byte pageNumber = 1, byte pageSize = 10)
    {
        _logger.LogInformation("GetByName-CardCertificateController: {Name} - {PageNumber} - {PageSize}", name, pageNumber, pageSize);

        return Ok(await _service.GetByName(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            pageNumber,
            pageSize,
            $"{nameof(CertificateResponse.GPA)} {Descending},{nameof(CertificateResponse.CreatedAt)} {Descending}"
        )), name));
    }

    [HttpGet("search-by-name")]
    [SwaggerOperation(Summary = "Tìm kiếm chứng chỉ theo tên")]
    public async ValueTask<IActionResult> SearchByName([Required] string searchString, byte pageNumber = 1, byte pageSize = 10)
    {
        _logger.LogInformation("SearchByName-CardCertificateController: {SearchText}", searchString);

        return Ok(await _service.SearchByName(searchString));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới chứng chỉ")]
    public async ValueTask<IActionResult> Insert([Required] CertificateCreateRequest request)
    {
        _logger.LogInformation("Insert-CertificateController: {Request}", request.Serialize());

        return Ok(await _service.Insert(request));
    }

    [HttpPatch("{id}")]
    [SwaggerOperation(Summary = "Cập nhật chứng chỉ")]
    public async ValueTask<IActionResult> Modify(string id, [Required] CertificateUpdateRequest request)
    {
        _logger.LogInformation("Modify-CertificateController: {Id} - {Request}", id, request.Serialize());

        return Ok(await _service.Modify(id, request));
    }

#if RELEASE
[Authorize(Roles = "GlobalRole")]
#endif
    [HttpPost("sync-db-to-es")]
    [SwaggerOperation(Summary = "Đồng bộ tất cả chứng chỉ từ Database sang Elasticsearch")]
    public async ValueTask<IActionResult> SyncDbToEs() => Ok(await _service.SyncDbToEs());
}
