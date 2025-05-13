#if RELEASE
using Microsoft.AspNetCore.Authorization;
#endif
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nest;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.Requests.v2.Create;
using YANLib.Responses;
using YANLib.Services.v2;
using static Nest.SortOrder;

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
    [SwaggerOperation(Summary = "Lấy tất cả dự án của lập trình viên theo mã định danh")]
    [ProducesResponseType(typeof(PagedResultDto<DeveloperProjectResponse>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<PagedResultDto<DeveloperProjectResponse>>> GetByDeveloper([Required] Guid developerId, CancellationToken cancellationToken, byte pageNumber = 1, byte pageSize = 10)
    {
        _logger.LogInformation("GetByDeveloper-DeveloperProjectController: {DeveloperId}", developerId);

        return Ok(await _service.GetByDeveloper(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            pageNumber,
            pageSize,
            $"{nameof(DeveloperProjectResponse.CreatedAt)} {Descending}"
        )), developerId, cancellationToken));
    }

    [HttpGet("{developerId:guid}/{projectId}")]
    [SwaggerOperation(Summary = "Lấy dự án của lập trình viên theo mã nhân viên và mã dự án")]
    [ProducesResponseType(typeof(DeveloperProjectResponse), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<DeveloperProjectResponse>> GetByDeveloperAndProject(Guid developerId, string projectId, CancellationToken cancellationToken)
    {
        _logger.LogInformation("GetByDeveloperAndProject-DeveloperProjectController: {DeveloperId} - {ProjectId}", developerId, projectId);

        var result = await _service.GetByDeveloperAndProject(developerId, projectId, cancellationToken);

        return result.IsNull() ? (ActionResult<DeveloperProjectResponse>)NotFound() : Ok(result);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Gán dự án cho lập trình viên")]
    [ProducesResponseType(typeof(DeveloperProjectResponse), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Assign([FromBody][Required] DeveloperProjectCreateRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Assign-DeveloperProjectController: {Request}", request.Serialize());

        var result = await _service.Assign(request, cancellationToken);

        return result.IsNull()
            ? Conflict()
            : CreatedAtAction(nameof(GetByDeveloperAndProject), new
            {
                developerId = result.DeveloperId,
                projectId = result.ProjectId
            }, result);
    }

    [HttpDelete("{developerId:guid}/{projectId}")]
    [SwaggerOperation(Summary = "Gỡ gán dự án cho lập trình viên")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Unassign(Guid developerId, string projectId, [FromQuery][Required] Guid updatedBy, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Unassign-DeveloperProjectController: {DeveloperId} - {ProjectId} - {UpdatedBy}", developerId, projectId, updatedBy);

        return await _service.Unassign(developerId, projectId, updatedBy, cancellationToken) ? NoContent() : NotFound();
    }

#if RELEASE
    [Authorize(Roles = "GlobalRole")]
#endif
    [HttpPost("sync-db-to-redis")]
    [SwaggerOperation(Summary = "Đồng bộ tất cả dự án của lập trình viên từ Database sang Redis")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> SyncDbToRedis(CancellationToken cancellationToken) => Ok(await _service.SyncDbToRedis(cancellationToken));

#if RELEASE
    [Authorize(Roles = "GlobalRole")]
#endif
    [HttpPost("sync-db-to-redis-by-developer")]
    [SwaggerOperation(Summary = "Đồng bộ dự án của lập trình viên từ Database sang Redis theo mã")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> SyncDbToRedisByDeveloper([FromQuery][Required] Guid developerId, CancellationToken cancellationToken)
    {
        _logger.LogInformation("SyncDbToRedisByDeveloper-DeveloperProjectController: {DeveloperId}", developerId);

        return Ok(await _service.SyncDbToRedisByDeveloper(developerId, cancellationToken));
    }
}
