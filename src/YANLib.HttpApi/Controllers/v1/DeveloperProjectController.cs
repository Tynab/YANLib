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
using YANLib.ListQueries;
using YANLib.Responses;
using YANLib.Services.v1;

namespace YANLib.Controllers.v1;

#if RELEASE
[Authorize(Roles = "GlobalRole, OtherRole")]
#endif
[ApiVersion(1, Deprecated = true)]
[ApiController]
[Route("api/developer-projects")]
public sealed class DeveloperProjectController(ILogger<DeveloperProjectController> logger, IDeveloperProjectService service) : YANLibController
{
    private readonly ILogger<DeveloperProjectController> _logger = logger;
    private readonly IDeveloperProjectService _service = service;

    [HttpGet]
    [SwaggerOperation(Summary = "Lấy tất cả dự án của lập trình viên")]
    [ProducesResponseType(typeof(PagedResultDto<DeveloperProjectResponse>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<PagedResultDto<DeveloperProjectResponse>>> GetAll([FromQuery] DeveloperProjectListQuery query)
    {
        _logger.LogInformation("GetAll-DeveloperProjectController: {Query}", query.Serialize());

        return Ok(await _service.GetListAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize), PagedAndSortedResultRequestDto>((query.PageNumber, query.PageSize))));
    }

    [HttpGet("{id:guid}")]
    [SwaggerOperation(Summary = "Lấy dự án của lập trình viên theo Id")]
    [ProducesResponseType(typeof(DeveloperProjectResponse), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<DeveloperProjectResponse>> Get([FromRoute] Guid id)
    {
        _logger.LogInformation("Get-DeveloperProjectController: {Id}", id);

        var result = await _service.GetAsync(id);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới dự án của lập trình viên")]
    [ProducesResponseType(typeof(DeveloperResponse), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody][Required] Requests.v1.Create.DeveloperProjectCreateRequest input)
    {
        _logger.LogInformation("Create-DeveloperProjectController: {Input}", input.Serialize());

        var result = await _service.CreateAsync(input);

        return CreatedAtAction(nameof(Get), new
        {
            id = result.Id,
            version = "1.0"
        }, result);
    }

    [HttpPut("{id:guid}")]
    [SwaggerOperation(Summary = "Cập nhật dự án của lập trình viên")]
    [ProducesResponseType(typeof(DeveloperResponse), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<DeveloperProjectResponse>> Update([FromRoute] Guid id, [FromBody][Required] Requests.v1.Update.DeveloperProjectUpdateRequest input)
    {
        _logger.LogInformation("Update-DeveloperProjectController: {Id} - {Input}", id, input.Serialize());

        var result = await _service.UpdateAsync(id, input);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpDelete("{id:guid}")]
    [SwaggerOperation(Summary = "Xóa dự án của lập trình viên")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        _logger.LogInformation("Delete-DeveloperProjectController: {Id}", id);
        await _service.DeleteAsync(id);

        return NoContent();
    }
}
