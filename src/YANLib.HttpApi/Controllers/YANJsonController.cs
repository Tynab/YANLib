using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YANLib.Dtos;
using YANLib.Services;

namespace YANLib.Controllers;

[Route("api/tynab/yanlib/yanjson")]
public class YANJsonController : YANLibController
{
    #region Fields
    private readonly IYANJsonService _yanJsonService;
    #endregion

    #region Constructors
    public YANJsonController(IYANJsonService yanJsonService) => _yanJsonService = yanJsonService;
    #endregion

    #region Methods
    [HttpPost("serializes")]
    public async ValueTask<IActionResult> Serialize([FromBody] List<JsonTestDto> request) => Ok(await _yanJsonService.Serializes(request));

    [HttpPost("camel-serializes")]
    public async ValueTask<IActionResult> SerializeCamel([FromBody] List<JsonTestDto> request) => Ok(await _yanJsonService.CamelSerializes(request));

    [HttpGet("deserializes")]
    public async ValueTask<IActionResult> Deserialize(byte quantity = 1) => Ok(await _yanJsonService.Deserializes(quantity));
    #endregion
}
