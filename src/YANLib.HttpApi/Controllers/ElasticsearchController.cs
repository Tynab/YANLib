using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp;
using YANLib.Core;
using YANLib.EsIndices;
using YANLib.EsServices;

namespace YANLib.Controllers;

[RemoteService]
[ApiExplorerSettings(GroupName = "sample")]
[Route("api/yanlib/es")]
public sealed class ElasticsearchController(ILogger<ElasticsearchController> logger, IDeveloperEsService developerEsService) : YANLibController
{
    private readonly ILogger<ElasticsearchController> _logger = logger;
    private readonly IDeveloperEsService _developerEsService = developerEsService;

    [HttpGet("developers/{id}")]
    [SwaggerOperation(Summary = "Lấy Developer theo Id trên Elasticsearch")]
    public async ValueTask<IActionResult> Get(string id)
    {
        _logger.LogInformation("GetElasticsearchController: {Id}", id);

        return Ok(await _developerEsService.Get(id));
    }

    [HttpPost("developers")]
    [SwaggerOperation(Summary = "Thêm mới Developer trên Elasticsearch")]
    public async ValueTask<IActionResult> Set([Required] DeveloperIndex request)
    {
        _logger.LogInformation("SetElasticsearchController: {Request}", request.Serialize());

        return Ok(await _developerEsService.Set(request));
    }
}
