using Id_Generator_Snowflake;
using Microsoft.AspNetCore.Mvc;
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

    [HttpGet("generate")]
    [SwaggerOperation(Summary = "Tạo Id Snowflake")]
    public IActionResult Generate([Required] long workerId = 0, [Required] long datacenterId = 0, long? sequence = null, long? timestamp = null)
    {
        _logger.LogInformation("GenerateIdSnowflakeController");

        var idGenerator = sequence.HasValue ? new IdGenerator(workerId, datacenterId, sequence.Value) : new IdGenerator(workerId, datacenterId);

        return Ok(timestamp.HasValue ? idGenerator.NextId(timestamp.Value) : idGenerator.NextId());
    }

    [HttpGet("extract")]
    [SwaggerOperation(Summary = "Giải mã Id Snowflake")]
    public IActionResult Extract([Required] long id, long? sequence = null, long? timestamp = null)
    {
        _logger.LogInformation("ExtractIdSnowflakeController: {Id}", id);

        var (Timestamp, WorkerId, DatacenterId) = sequence.HasValue
            ? timestamp.HasValue
                ? ExtractIdComponents(id, timestamp.Value, sequence.Value)
                : ExtractIdComponents(id, sequence: sequence.Value)
            : timestamp.HasValue
                ? ExtractIdComponents(id, timestamp.Value)
                : ExtractIdComponents(id);

        return Ok($"Time: {Timestamp}\nWorker Id: {WorkerId}\nDatacenter Id: {DatacenterId}");
    }

    [HttpGet("alphabetic/generate")]
    [SwaggerOperation(Summary = "Tạo Id Snowflake Alphabetic")]
    public IActionResult GenerateAlphabetic([Required] long workerId = 0, [Required] long datacenterId = 0, long? sequence = null, long? timestamp = null)
    {
        _logger.LogInformation("GenerateAlphabeticIdSnowflakeController");

        var idGenerator = sequence.HasValue ? new IdGenerator(workerId, datacenterId, sequence.Value) : new IdGenerator(workerId, datacenterId);

        return Ok(timestamp.HasValue ? idGenerator.NextIdAlphabetic(timestamp.Value) : idGenerator.NextIdAlphabetic());
    }

    [HttpGet("alphabetic/extract")]
    [SwaggerOperation(Summary = "Giải mã Id Snowflake Alphabetic")]
    public IActionResult ExtractAlphabetic([Required] string id, long? sequence = null, long? timestamp = null)
    {
        _logger.LogInformation("ExtractAlphabeticIdSnowflakeController: {Id}", id);

        var (Timestamp, WorkerId, DatacenterId) = sequence.HasValue
            ? timestamp.HasValue
                ? ExtractIdAlphabeticComponents(id, timestamp.Value, sequence.Value)
                : ExtractIdAlphabeticComponents(id, sequence: sequence.Value)
            : timestamp.HasValue
                ? ExtractIdAlphabeticComponents(id, timestamp.Value)
                : ExtractIdAlphabeticComponents(id);

        return Ok($"Time: {Timestamp}\nWorker Id: {WorkerId}\nDatacenter Id: {DatacenterId}");
    }
}
