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
using static YANLib.Core.YANBool;
using static YANLib.Core.YANNum;
using static YANLib.Core.YANText;

namespace YANLib.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = "sample")]
[Route("api/[controller]")]
public sealed class SampleController(ILogger<SampleController> logger, ISampleService service) : YANLibController
{
    private readonly ILogger<SampleController> _logger = logger;
    private readonly ISampleService _service = service;

    [HttpGet("json-test")]
    [SwaggerOperation(Summary = "Đo tốc độ xử lý JSON của thư viện YANLib và các chuẩn khác")]
    public async ValueTask<IActionResult> JsonTest([Required] uint quantity = 10000, [Required] bool hideSystem = true)
    {
        _logger.LogInformation("JsonTest-SampleController: {Quantity} - {HideSystem}", quantity, hideSystem);

        return Ok(await _service.JsonTest(quantity, hideSystem));
    }

    [HttpGet("flexible-response")]
    [SwaggerOperation(Summary = "Trả về dữ liệu linh hoạt")]
    public async ValueTask<IActionResult> FlexibleResponse() => (GenerateRandomByte(1, byte.MaxValue) % 7) switch
    {
        1 => await FromResult(Ok(GenerateRandomBool())),
        2 => await FromResult(Ok(GenerateRandomCharacter())),
        3 => await FromResult(Ok(GenerateRandomString())),
        4 => await FromResult(Ok(GenerateRandomByte())),
        5 => await FromResult(Ok(GenerateRandomFloat())),
        6 => await FromResult(Ok(new List<NotificationRequest>
        {
            new("Hi, YAN!", NewGuid()),
            new("Hi, Tynab!", NewGuid())
        })),
        _ => await FromResult(Ok(new NotificationRequest("Hello, World!", NewGuid())))
    };
}
