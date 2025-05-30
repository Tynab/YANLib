#if RELEASE
using Microsoft.AspNetCore.Authorization;
#endif
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.ListQueries.v2;
using YANLib.Requests.v2.Create;
using YANLib.Responses;
using YANLib.Services.v2;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace YANLib.Controllers.v2;

#if RELEASE
[Authorize(Roles = "GlobalRole, OtherRole")]
#endif
[ApiVersion(2)]
[ApiController]
[Route("api/developer-projects")]
public sealed class DeveloperProjectController(ILogger<DeveloperProjectController> logger, IDeveloperProjectService service) : YANLibController
{
    private readonly ILogger<DeveloperProjectController> _logger = logger;
    private readonly IDeveloperProjectService _service = service;

    [HttpGet]
    [SwaggerOperation(Summary = "Lấy tất cả dự án của lập trình viên theo mã lập trình viên")]
    [ProducesResponseType(typeof(PagedResultDto<DeveloperProjectResponse>), Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<ActionResult<PagedResultDto<DeveloperProjectResponse>>> GetByDeveloper([FromQuery][Required] DeveloperProjectListQuery query, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("GetByDeveloper-DeveloperProjectController: {Query}", query.Serialize());

        return Ok(await _service.GetByDeveloperAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize), PagedAndSortedResultRequestDto>((query.PageNumber, query.PageSize)), query.DeveloperId, cancellationToken));
    }

    [HttpGet("{developerId:guid}/{projectId}")]
    [SwaggerOperation(Summary = "Lấy dự án của lập trình viên theo mã lập trình viên và mã dự án")]
    [ProducesResponseType(typeof(DeveloperProjectResponse), Status200OK)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<DeveloperProjectResponse>> GetByDeveloperAndProject([FromRoute] Guid developerId, [FromRoute] string projectId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("GetByDeveloperAndProject-DeveloperProjectController: {DeveloperId} - {ProjectId}", developerId, projectId);

        var result = await _service.GetByDeveloperAndProjectAsync(developerId, projectId, cancellationToken);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Gán dự án cho lập trình viên")]
    [ProducesResponseType(typeof(DeveloperProjectResponse), Status201Created)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<IActionResult> Assign([FromBody][Required] DeveloperProjectCreateRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Assign-DeveloperProjectController: {Request}", request.Serialize());

        var result = await _service.AssignAsync(request, cancellationToken);

        return result.IsNull()
            ? Conflict()
            : CreatedAtAction(nameof(GetByDeveloperAndProject), new
            {
                developerId = result.DeveloperId,
                projectId = result.ProjectId,
                version = "2.0"
            }, result);
    }

    [HttpDelete("{developerId:guid}/{projectId}")]
    [SwaggerOperation(Summary = "Gỡ gán dự án cho lập trình viên")]
    [ProducesResponseType(Status204NoContent)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<IActionResult> Unassign([FromRoute] Guid developerId, [FromRoute] string projectId, [FromQuery][Required] Guid updatedBy, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Unassign-DeveloperProjectController: {DeveloperId} - {ProjectId} - {UpdatedBy}", developerId, projectId, updatedBy);

        return await _service.UnassignAsync(developerId, projectId, updatedBy, cancellationToken) ? NoContent() : NotFound();
    }

#if RELEASE
    [Authorize(Roles = "GlobalRole")]
#endif
    [HttpPost("sync-data-to-redis")]
    [SwaggerOperation(Summary = "Đồng bộ tất cả dự án của lập trình viên từ Database sang Redis")]
    [ProducesResponseType(typeof(bool), Status200OK)]
    public async Task<IActionResult> SyncDataToRedis(CancellationToken cancellationToken = default) => Ok(await _service.SyncDataToRedisAsync(cancellationToken));

#if RELEASE
    [Authorize(Roles = "GlobalRole")]
#endif
    [HttpPost("sync-data-to-redis-by-developer")]
    [SwaggerOperation(Summary = "Đồng bộ dự án của lập trình viên từ Database sang Redis theo mã")]
    [ProducesResponseType(typeof(bool), Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<IActionResult> SyncDataToRedisByDeveloper([FromQuery][Required] Guid developerId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("SyncDbToRedisByDeveloper-DeveloperProjectController: {DeveloperId}", developerId);

        return Ok(await _service.SyncDataToRedisByDeveloperAsync(developerId, cancellationToken));
    }
}
