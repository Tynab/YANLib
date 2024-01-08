namespace YANLib.Controllers;

[RemoteService]
[ApiExplorerSettings(GroupName = "test")]
[Route("api/yanlib/id-snowflakes")]
public sealed class IdSnowflakeController(ILogger<IdSnowflakeController> logger) : YANLibController
{
    #region Fields
    private readonly ILogger<IdSnowflakeController> _logger = logger;
    #endregion

    #region Methods
    [HttpGet("extract")]
    [SwaggerOperation(Summary = "Giải mã Id Snowflake")]
    public IActionResult Extract([Required] string id)
    {
        _logger.LogInformation("ExtractIdSnowflakeController: {Id}", id);

        var tupl = ExtractIdAlphabeticComponents(id);

        return Ok($"Time: {tupl.Item1}\nWorker Id: {tupl.Item2}\nDatacenter Id: {tupl.Item3}");
    }
    #endregion
}
