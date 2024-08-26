using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.Core;
using YANLib.Requests.Insert;
using YANLib.Requests.Modify;
using YANLib.Responses;
using YANLib.Services;

namespace YANLib.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = "sample")]
[Route("api/[controller]")]
public sealed class CertificateController(ILogger<CertificateController> logger, ICertificateService service) : YANLibController
{
    private readonly ILogger<CertificateController> _logger = logger;
    private readonly ICertificateService _service = service;

    [HttpGet]
    [SwaggerOperation(Summary = "Lấy danh sách chứng chỉ")]
    public async ValueTask<ActionResult<PagedResultDto<CertificateResponse>>> GetAll(byte pageNumber = 1, byte pageSize = 10)
    {
        _logger.LogInformation("GetAll-CardCertificateController: {PageNumber} - {PageSize}", pageNumber, pageSize);

        return Ok(await _service.GetAll(new PagedAndSortedResultRequestDto
        {
            SkipCount = (pageNumber - 1) * pageSize,
            MaxResultCount = pageSize,
            Sorting = $"{nameof(DeveloperTypeResponse.Name)} ASC,{nameof(DeveloperTypeResponse.CreatedAt)} DESC"
        }));
    }

    [HttpGet("{code}")]
    [SwaggerOperation(Summary = "Lấy chứng chỉ theo mã")]
    public async ValueTask<IActionResult> GetByCode(string code)
    {
        _logger.LogInformation("GetByCode-CardCertificateController: {Code}", code);

        return Ok(await _service.GetByCode(code));
    }

    [HttpGet("get-by-name")]
    [SwaggerOperation(Summary = "Lấy danh sách chứng chỉ theo tên")]
    public async ValueTask<IActionResult> GetByName([Required] string name)
    {
        _logger.LogInformation("GetByName-CardCertificateController: {Name}", name);

        return Ok(await _service.GetByName(name));
    }

    [HttpGet("search-by-name")]
    [SwaggerOperation(Summary = "Tìm kiếm chứng chỉ theo tên")]
    public async ValueTask<IActionResult> SearchByName([Required] string searchText)
    {
        _logger.LogInformation("SearchByName-CardCertificateController: {SearchText}", searchText);

        return Ok(await _service.SearchByName(searchText));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới chứng chỉ")]
    public async ValueTask<IActionResult> Insert([Required] CertificateInsertRequest request)
    {
        _logger.LogInformation("Insert-CertificateController: {Request}", request.Serialize());

        return Ok(await _service.Insert(request));
    }

    [HttpPatch("{code}")]
    [SwaggerOperation(Summary = "Cập nhật chứng chỉ")]
    public async ValueTask<IActionResult> Modify(string code, [Required] CertificateModifyRequest request)
    {
        _logger.LogInformation("Modify-CertificateController: {Code} - {Request}", code, request.Serialize());

        return Ok(await _service.Modify(code, request));
    }

    [HttpPost("sync-db-to-es")]
    [SwaggerOperation(Summary = "Đồng bộ tất cả chứng chỉ từ Database sang Elasticsearch")]
    public async ValueTask<IActionResult> SyncDbToEs() => Ok(await _service.SyncDbToEs());
}
