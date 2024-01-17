using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp;
using YANLib.Services;

namespace YANLib.Controllers;

[RemoteService]
[ApiExplorerSettings(GroupName = "test")]
[Route("api/yanlib/json")]
public sealed class YANJsonController(ILogger<YANJsonController> logger, IYANJsonService service) : YANLibController
{
    private readonly ILogger<YANJsonController> _logger = logger;
    private readonly IYANJsonService _service = service;

    [HttpGet("yan-vs-standards")]
    [SwaggerOperation(Summary = "Đo tốc độ của thư viện YANLib và các chuẩn khác")]
    public async ValueTask<IActionResult> YanVsStandards([Required] uint quantity = 10000, [Required] bool hideSystem = true)
    {
        _logger.LogInformation("YanVsStandardsYANJsonController: {Quantity} - {HideSystem}", quantity, hideSystem);

        return Ok(await _service.YanVsStandards(quantity, hideSystem));
    }

    [HttpGet("serialize")]
    [SwaggerOperation(Summary = "Test serialize cho 1 class mẫu có 1 property Id")]
    public async ValueTask<IActionResult> JsonSerialize([Required] Guid id)
    {
        _logger.LogInformation("JsonSerializeYANJsonController: {Id}", id);

        return Ok(await _service.JsonSerialize(id));
    }

    [HttpGet("serialize-optional-name")]
    [SwaggerOperation(Summary = "Test serialize cho 1 class mẫu có 1 property Id có tên tùy chỉnh")]
    public async ValueTask<IActionResult> JsonSerializeOptionalName([Required] Guid idOptionalName)
    {
        _logger.LogInformation("JsonSerializeOptionalNameYANJsonController: {IdOptionalName}", idOptionalName);

        return Ok(await _service.JsonSerializeOptionalName(idOptionalName));
    }

    [HttpGet("deserialize")]
    [SwaggerOperation(Summary = "Test deserialize cho 1 class mẫu có 1 property Id")]
    public async ValueTask<IActionResult> JsonDeserialize([Required] string json)
    {
        _logger.LogInformation("JsonDeserializeYANJsonController: {JSON}", json);

        return Ok(await _service.JsonDeserialize(json));
    }

    [HttpGet("deserialize-optional-name")]
    [SwaggerOperation(Summary = "Test serialize cho 1 class mẫu có property Id có tên tùy chỉnh")]
    public async ValueTask<IActionResult> JsonDeserializeOptionalName([Required] string json)
    {
        _logger.LogInformation("JsonDeserializeOptionalNameYANJsonController: {JSON}", json);

        return Ok(await _service.JsonDeserializeOptionalName(json));
    }
}
