#if RELEASE
using Microsoft.AspNetCore.Authorization;
#endif
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
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

    [HttpGet("get-by-developer")]
    [SwaggerOperation(Summary = "Lấy tất cả chứng chỉ của lập trình viên theo mã định danh")]
    public async ValueTask<ActionResult<PagedResultDto<DeveloperProjectResponse>>> GetByDeveloper([Required] Guid developerId, byte pageNumber = 1, byte pageSize = 10)
    {
        _logger.LogInformation("GetByDeveloper-DeveloperProjectController: {DeveloperId}", developerId);

        return Ok(await _service.GetByDeveloper(ObjectMapper.Map<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>((
            pageNumber,
            pageSize,
            $"{nameof(DeveloperProjectResponse.CreatedAt)} {Descending}"
        )), developerId));
    }

    [HttpGet("get-by-developer-and-project")]
    [SwaggerOperation(Summary = "Lấy chứng chỉ của lập trình viên theo mã định danh và mã chứng chỉ")]
    public async ValueTask<ActionResult<DeveloperProjectResponse>> GetByDeveloperAndProject([Required] Guid developerId, [Required] string projectId)
    {
        _logger.LogInformation("GetByDeveloperAndProject-DeveloperProjectController: {DeveloperId} - {ProjectId}", developerId, projectId);

        return Ok(await _service.GetByDeveloperAndProject(developerId, projectId));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới chứng chỉ của lập trình viên")]
    public async ValueTask<ActionResult<DeveloperProjectResponse>> Insert(DeveloperProjectCreateRequest request)
    {
        _logger.LogInformation("Insert-DeveloperProjectController: {Request}", request.Serialize());

        return Ok(await _service.Insert(request));
    }

    [HttpPatch]
    [SwaggerOperation(Summary = "Cập nhật chứng chỉ của lập trình viên")]
    public async ValueTask<ActionResult<DeveloperProjectResponse>> Modify(DeveloperProjectUpdateRequest request)
    {
        _logger.LogInformation("Modify-DeveloperProjectController: {Request}", request.Serialize());

        return Ok(await _service.Modify(request));
    }

    [HttpDelete]
    [SwaggerOperation(Summary = "Xóa chứng chỉ của lập trình viên")]
    public async ValueTask<ActionResult<DeveloperProjectResponse>> Delete([Required] Guid developerId, [Required] string projectId, [Required] Guid updatedBy)
    {
        _logger.LogInformation("Delete-DeveloperProjectController: {DeveloperId} - {ProjectId} - {UpdatedBy}", developerId, projectId, updatedBy);

        return Ok(await _service.Delete(developerId, projectId, updatedBy));
    }

#if RELEASE
    [Authorize(Roles = "GlobalRole")]
#endif
    [HttpPost("sync-db-to-redis")]
    [SwaggerOperation(Summary = "Đồng bộ tất cả chứng chỉ của lập trình viên từ Database sang Redis")]
    public async ValueTask<IActionResult> SyncDbToRedis() => Ok(await _service.SyncDbToRedis());

#if RELEASE
    [Authorize(Roles = "GlobalRole")]
#endif
    [HttpPost("sync-db-to-redis-by-developer")]
    [SwaggerOperation(Summary = "Đồng bộ chứng chỉ của lập trình viên từ Database sang Redis theo mã định danh")]
    public async ValueTask<IActionResult> SyncDbToRedisByDeveloper([Required] Guid developerId)
    {
        _logger.LogInformation("SyncDbToRedisByDeveloper-DeveloperProjectController: {DeveloperId}", developerId);

        return Ok(await _service.SyncDbToRedisByDeveloper(developerId));
    }
}
