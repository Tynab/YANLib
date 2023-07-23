using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp;
using YANLib.Services;

namespace YANLib.Controllers;

[RemoteService]
[ApiExplorerSettings(GroupName = "json")]
[Route("api/yanlib/yanjson")]
public class YANJsonController : YANLibController
{
    #region Fields
    private readonly ILogger<YANJsonController> _logger;
    private readonly IYANJsonService _service;
    #endregion

    #region Constructors
    public YANJsonController(ILogger<YANJsonController> logger, IYANJsonService service)
    {
        _logger = logger;
        _service = service;
    }
    #endregion

    #region Methods
    [HttpGet("yan-vs-standards")]
    [SwaggerOperation(Summary = "Đo tốc độ của thư viện YANLib và các chuẩn khác")]
    public async ValueTask<IActionResult> YanVsStandards([Required] uint quantity = 10000, [Required] bool hideSystem = true)
    {
        _logger.LogInformation("YanVsStandardsYANJsonController: {Quantity} - {HideSystem}", quantity, hideSystem);

        return Ok(await _service.YanVsStandards(quantity, hideSystem));
    }
    #endregion
}
