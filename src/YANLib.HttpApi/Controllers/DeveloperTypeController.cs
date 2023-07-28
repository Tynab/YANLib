using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp;
using YANLib.Requests;
using YANLib.Services;

namespace YANLib.Controllers;

[RemoteService]
[ApiExplorerSettings(GroupName = "sample")]
[Route("api/yanlib/developer-types")]
public sealed class DeveloperTypeController : YANLibController
{
    #region Fields
    private readonly ILogger<DeveloperTypeController> _logger;
    private readonly IDeveloperTypeService _service;
    #endregion

    #region Constructors
    public DeveloperTypeController(ILogger<DeveloperTypeController> logger, IDeveloperTypeService service)
    {
        _logger = logger;
        _service = service;
    }
    #endregion

    #region Methods
    [HttpGet]
    [SwaggerOperation(Summary = "Tìm tất cả định nghĩa Developer Types")]
    public async ValueTask<IActionResult> GetAll() => Ok(await _service.GetAll());

    [HttpGet("{code}")]
    [SwaggerOperation(Summary = "Tìm định nghĩa Developer Type theo Code")]
    public async ValueTask<IActionResult> Get([Required] int code)
    {
        _logger.LogInformation("GetDeveloperTypeController: {Code}", code);

        return Ok(await _service.Get(code));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới định nghĩa Developer Type")]
    public async ValueTask<IActionResult> Insert([Required] DeveloperTypeRequest request)
    {
        _logger.LogInformation("InsertDeveloperTypeController: {Request}", request.CamelSerialize());

        return Ok(await _service.Insert(request));
    }

    [HttpPut]
    [SwaggerOperation(Summary = "Cập nhật định nghĩa Developer Type")]
    public async ValueTask<IActionResult> Update([Required] DeveloperTypeRequest request)
    {
        _logger.LogInformation("UpdateDeveloperTypeController: {Request}", request.CamelSerialize());

        return Ok(await _service.Update(request));
    }

    [SwaggerOperation(Summary = "Đồng bộ tất cả định nghĩa Developer Types từ Database sang Redis")]
    [HttpPost("sync-db-to-redis")]
    public async ValueTask<IActionResult> SyncDbToRedis() => Ok(await _service.SyncDbToRedis());
    #endregion
}
