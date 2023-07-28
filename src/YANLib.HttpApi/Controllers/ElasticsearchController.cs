using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp;
using YANLib.EsIndexs;
using YANLib.EsServices;

namespace YANLib.Controllers;

[RemoteService]
[ApiExplorerSettings(GroupName = "sample")]
[Route("api/yanlib/es")]
public sealed class ElasticsearchController : YANLibController
{
    #region Fields
    private readonly ILogger<ElasticsearchController> _logger;
    private readonly IDeveloperEsService _developerEsService;
    #endregion

    #region Constructors
    public ElasticsearchController(ILogger<ElasticsearchController> logger, IDeveloperEsService developerEsService)
    {
        _logger = logger;
        _developerEsService = developerEsService;
    }
    #endregion

    #region Methods
    [HttpGet("developers/{id}")]
    [SwaggerOperation(Summary = "Tìm Developer theo Id trên Elasticsearch")]
    public async ValueTask<IActionResult> Get([Required] string id)
    {
        _logger.LogInformation("GetElasticsearchController: {Id}", id);

        return Ok(await _developerEsService.Get(id));
    }

    [HttpPost("developers")]
    [SwaggerOperation(Summary = "Thêm mới Developer trên Elasticsearch")]
    public async ValueTask<IActionResult> Set([Required] DeveloperIndex request)
    {
        _logger.LogInformation("SetElasticsearchController: {Request}", request.CamelSerialize());

        return Ok(await _developerEsService.Set(request));
    }
    #endregion
}
