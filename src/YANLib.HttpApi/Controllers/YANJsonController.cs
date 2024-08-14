using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using YANLib.Requests;
using YANLib.Services;
using static System.Guid;
using static System.Threading.Tasks.Task;
using static YANLib.Core.YANNum;

namespace YANLib.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = "sample")]
[Route("api/[controller]")]
public sealed class YANJsonController(ILogger<YANJsonController> logger, IYANJsonService service) : YANLibController
{
    private readonly ILogger<YANJsonController> _logger = logger;
    private readonly IYANJsonService _service = service;

    [HttpGet("yan-vs-standards")]
    [SwaggerOperation(Summary = "Đo tốc độ của thư viện YANLib và các chuẩn khác")]
    public async ValueTask<IActionResult> YanVsStandards([Required] uint quantity = 10000, [Required] bool hideSystem = true)
    {
        _logger.LogInformation("YanVsStandards-YANJsonController: {Quantity} - {HideSystem}", quantity, hideSystem);

        return Ok(await _service.YanVsStandards(quantity, hideSystem));
    }

    [HttpGet("flexible-response")]
    [SwaggerOperation(Summary = "Trả về dữ liệu linh hoạt")]
    public async ValueTask<IActionResult> FlexibleResponse()
    {
        var random = GenerateRandomByte(1, byte.MaxValue);

        return await FromResult(random % 2 is 0
            ? Ok(new List<NotificationRequest>
            {
                new($"Hi, YAN-{random}!", NewGuid()),
                new($"Hi, Tynab-{random}!", NewGuid())
            })
            : Ok(new NotificationRequest($"Hello, YAN-{random}!", NewGuid())));
    }
}
