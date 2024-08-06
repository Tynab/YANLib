using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using YANLib.Core;
using YANLib.Requests.Insert;
using YANLib.Requests.Modify;
using YANLib.Services;

namespace YANLib.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = "sample")]
[Route("api/[controller]")]
public sealed class DeveloperController(ILogger<DeveloperController> logger, IDeveloperService service) : YANLibController
{
    private readonly ILogger<DeveloperController> _logger = logger;
    private readonly IDeveloperService _service = service;

    [HttpGet("{idCard}")]
    [SwaggerOperation(Summary = "Lấy Developer theo Id Card")]
    public async ValueTask<IActionResult> GetByIdCard(string idCard)
    {
        _logger.LogInformation("GetById-CardDeveloperController: {IdCard}", idCard);

        return Ok(await _service.GetByIdCard(idCard));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới Developer")]
    public async ValueTask<IActionResult> Insert([Required] DeveloperInsertRequest request)
    {
        _logger.LogInformation("Insert-DeveloperController: {Request}", request.Serialize());

        return Ok(await _service.Insert(request));
    }

    [HttpPatch("{idCard}")]
    [SwaggerOperation(Summary = "Cập nhật Developer")]
    public async ValueTask<IActionResult> Adjust(string idCard, [Required] DeveloperModifyRequest request)
    {
        _logger.LogInformation("Adjust-DeveloperController: {IdCard} - {Request}", idCard, request.Serialize());

        return Ok(await _service.Adjust(idCard, request));
    }

    [HttpGet("get-by-phone")]
    [SwaggerOperation(Summary = "Lấy tất cả Developers theo Phone")]
    public async ValueTask<IActionResult> GetByPhone([Required] string phone)
    {
        _logger.LogInformation("GetByPhone-DeveloperController: {Phone}", phone);

        return Ok(await _service.GetByPhone(phone));
    }

    [HttpGet("search-by-phone")]
    [SwaggerOperation(Summary = "Tìm tất cả Developers theo Phone")]
    public async ValueTask<IActionResult> SearchByPhone([Required] string searchText)
    {
        _logger.LogInformation("SearchByPhone-DeveloperController: {SearchText}", searchText);

        return Ok(await _service.SearchByPhone(searchText));
    }

    [HttpPost("sync-db-to-es")]
    [SwaggerOperation(Summary = "Đồng bộ tất cả Developers từ Database lên Elasticsearch")]
    public async ValueTask<IActionResult> SyncDbToEs() => Ok(await _service.SyncDbToEs());
}
