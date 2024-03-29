﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using Volo.Abp;
using static Id_Generator_Snowflake.IdGenerator;

namespace YANLib.Controllers;

[RemoteService]
[ApiExplorerSettings(GroupName = "test")]
[Route("api/id-snowflakes")]
public sealed class IdSnowflakeController(ILogger<IdSnowflakeController> logger) : YANLibController
{
    private readonly ILogger<IdSnowflakeController> _logger = logger;

    [HttpGet("extract")]
    [SwaggerOperation(Summary = "Giải mã Id Snowflake")]
    public IActionResult Extract([Required] string id)
    {
        _logger.LogInformation("ExtractIdSnowflakeController: {Id}", id);

        var tupl = ExtractIdAlphabeticComponents(id);

        return Ok($"Time: {tupl.Item1}\nWorker Id: {tupl.Item2}\nDatacenter Id: {tupl.Item3}");
    }
}
