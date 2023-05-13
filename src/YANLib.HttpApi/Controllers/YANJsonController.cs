using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp;
using YANLib.Dtos;
using YANLib.Services;

namespace YANLib.Controllers;

[RemoteService]
[ApiExplorerSettings(GroupName = "json")]
[Route("api/tynab/yanlib/yanjson")]
public class YANJsonController : YANLibController
{
    #region Fields
    private readonly IYANJsonService _service;
    #endregion

    #region Constructors
    public YANJsonController(IYANJsonService service) => _service = service;
    #endregion

    #region Methods
    [HttpGet("duo-vs-standard/{quantity}")]
    [SwaggerOperation(Summary = "Deserialize speed test (Duo vs Standard)")]
    public async ValueTask<IActionResult> DuoVsStandard([Required] uint quantity = 10000) => Ok(await _service.DuoVsStandard(quantity));

    [HttpPost("serialize")]
    [SwaggerOperation(Summary = "Serialize n-1 Pascal case")]
    public IActionResult Serialize([Required] List<JsonDto> request) => Ok(request.Serialize());

    [HttpPost("camel-serialize")]
    [SwaggerOperation(Summary = "Serialize n-1 Camel case")]
    public IActionResult SerializeCamel([Required] List<JsonDto> request) => Ok(request.SerializeCamel());

    [HttpGet("deserialize/{text}")]
    [SwaggerOperation(Summary = "Deserialize 1-1 Pascal case")]
    public IActionResult Deserializes([Required] string text = "{\"Id\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\"}") => Ok(text.Deserialize<JsonDto>());

    [HttpGet("camel-deserialize/{text}")]
    [SwaggerOperation(Summary = "Deserialize 1-1 Camel case")]
    public IActionResult DeserializeCamel([Required] string text = "{\"id\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\"}") => Ok(text.DeserializeCamel<JsonDto>());

    [HttpGet("standard-deserialize/{text}")]
    [SwaggerOperation(Summary = "Deserialize 1-1 ignore case")]
    public IActionResult DeserializeStandard([Required] string text = "{\"Id\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\"}") => Ok(text.DeserializeStandard<JsonDto>());

    [HttpGet("duo-deserialize/{text}")]
    [SwaggerOperation(Summary = "Deserialize 1-1 ignore case (Pascal priority)")]
    public IActionResult DeserializeDuo([Required] string text = "{\"Id\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\"}") => Ok(text.DeserializeDuo<JsonDto>());

    [HttpGet("duo-camel-priority-deserialize/{text}")]
    [SwaggerOperation(Summary = "Deserialize 1-1 ignore case (Camel priority)")]
    public IActionResult DeserializeDuoCamelPriority([Required] string text = "{\"Id\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\"}") => Ok(text.DeserializeDuoCamelPriority<JsonDto>());

    [HttpPost("serializes")]
    [SwaggerOperation(Summary = "Serialize n-n Pascal case")]
    public IActionResult Serializes([Required] List<JsonDto> request) => Ok(request.Serializes());

    [HttpPost("camel-serializes")]
    [SwaggerOperation(Summary = "Serialize n-n Camel case")]
    public IActionResult SerializeCamels([Required] List<JsonDto> request) => Ok(request.SerializeCamels());

    [HttpPost("deserializes")]
    [SwaggerOperation(Summary = "Deserialize n-n Pascal case")]
    public IActionResult Deserializes([Required] List<string> text) => Ok(text.Deserializes<JsonDto>());

    [HttpPost("camel-deserializes")]
    [SwaggerOperation(Summary = "Deserialize n-n Camel case")]
    public IActionResult DeserializeCamels([Required] List<string> text) => Ok(text.DeserializeCamels<JsonDto>());

    [HttpPost("standard-deserializes")]
    [SwaggerOperation(Summary = "Deserialize n-n ignore case")]
    public IActionResult DeserializeStandards([Required] List<string> text) => Ok(text.DeserializeStandards<JsonDto>());

    [HttpPost("duo-deserializes")]
    [SwaggerOperation(Summary = "Deserialize n-n ignore case (Pascal priority)")]
    public IActionResult DeserializeDuos([Required] List<string> text) => Ok(text.DeserializeDuos<JsonDto>());

    [HttpPost("duo-camel-priority-deserializes")]
    [SwaggerOperation(Summary = "Deserialize n-n ignore case (Camel priority)")]
    public IActionResult DeserializeDuoCamelPriorities([Required] List<string> text) => Ok(text.DeserializeDuoCamelPriorities<JsonDto>());
    #endregion
}
