using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using Volo.Abp;
using static Id_Generator_Snowflake.IdGenerator;

namespace YANLib.Controllers;

[RemoteService]
[ApiExplorerSettings(GroupName = "test")]
[Route("api/yanlib/id-snowflakes")]
public sealed class IdSnowflakeController : YANLibController
{
    private readonly ILogger<IdSnowflakeController> _logger;

    public IdSnowflakeController(ILogger<IdSnowflakeController> logger) => _logger = logger;

    [HttpGet("extract")]
    [SwaggerOperation(Summary = "Giải mã Id Snowflake")]
    public IActionResult Extract([Required] string id)
    {
        _logger.LogInformation("ExtractIdSnowflakeController: {Id}", id);

        var tupl = ExtractIdAlphabeticComponents(id);

        return Ok($"Time: {tupl.Item1}\nWorker Id: {tupl.Item2}\nDatacenter Id: {tupl.Item3}");
    }
}
