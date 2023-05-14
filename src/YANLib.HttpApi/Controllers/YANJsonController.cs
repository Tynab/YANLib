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
    [HttpGet("duo-vs-standards")]
    [SwaggerOperation(Summary = "Deserialize speed test (Duo vs Standards)")]
    public async ValueTask<IActionResult> DuoVsStandards([Required] uint quantity = 10000, [Required] bool hideSystem = true) => Ok(await _service.DuoVsStandards(quantity, hideSystem));

    [HttpPost("serialize")]
    [SwaggerOperation(Summary = "Serialize n-1 Pascal case")]
    public IActionResult Serialize([Required] List<JsonDto> request) => Ok(request.Serialize());

    [HttpPost("camel-serialize")]
    [SwaggerOperation(Summary = "Serialize n-1 Camel case")]
    public IActionResult SerializeCamel([Required] List<JsonDto> request) => Ok(request.CamelSerialize());

    [HttpGet("standard-deserialize/{text}")]
    [SwaggerOperation(Summary = "Deserialize 1-1 ignore case")]
    public IActionResult DeserializeStandard([Required] string text = "{\"Id\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\"}") => Ok(text.StandardDeserialize<JsonDto>());

    [HttpGet("deserialize/{text}")]
    [SwaggerOperation(Summary = "Deserialize 1-1 Pascal case")]
    public IActionResult Deserializes([Required] string text = "{\"Id\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\"}") => Ok(text.Deserialize<JsonDto>());

    [HttpPost("serializes")]
    [SwaggerOperation(Summary = "Serialize n-n Pascal case")]
    public IActionResult Serializes([Required] List<JsonDto> request) => Ok(request.Serializes());

    [HttpPost("camel-serializes")]
    [SwaggerOperation(Summary = "Serialize n-n Camel case")]
    public IActionResult SerializeCamels([Required] List<JsonDto> request) => Ok(request.CamelSerializes());

    [HttpPost("deserializes")]
    [SwaggerOperation(Summary = "Deserialize n-n Pascal case")]
    public IActionResult Deserializes([Required] List<string> text) => Ok(text.Deserializes<JsonDto>());

    [HttpPost("standard-deserializes")]
    [SwaggerOperation(Summary = "Deserialize n-n ignore case")]
    public IActionResult DeserializeStandards([Required] List<string> text) => Ok(text.StandardDeserializes<JsonDto>());
    #endregion
}
