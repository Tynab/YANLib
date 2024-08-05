﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using YANLib.Services;

namespace YANLib.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = "test")]
[Route("api/json")]
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
}
