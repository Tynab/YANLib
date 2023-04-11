using Microsoft.AspNetCore.Mvc;
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
    [HttpPost("serialize")]
    public async ValueTask<IActionResult> Serialize([FromBody] JsonDto request) => Ok(await _yanJsonService.Serialize(request));

    [HttpPost("serialize-camel")]
    public async ValueTask<IActionResult> SerializeCamel([FromBody] JsonDto request) => Ok(await _yanJsonService.SerializeCamel(request));

    [HttpGet("deserialize")]
    public async ValueTask<IActionResult> Deserialize(byte quantity = 1) => Ok(await _yanJsonService.Deserialize(quantity));
    #endregion
}
