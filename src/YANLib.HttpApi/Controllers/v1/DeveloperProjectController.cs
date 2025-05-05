#if RELEASE
using Microsoft.AspNetCore.Authorization;
#endif
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
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
    [SwaggerOperation(Summary = "Lấy tất cả chứng chỉ của lập trình viên")]
    public async ValueTask<ActionResult<PagedResultDto<DeveloperProjectResponse>>> GetAll(byte pageNumber = 1, byte pageSize = 10)
    {
        _logger.LogInformation("GetAll-DeveloperProjectController: {PageNumber} - {PageSize}", pageNumber, pageSize);

        return Ok(await _service.GetListAsync(ObjectMapper.Map<(byte PageNumber, byte PageSize), PagedAndSortedResultRequestDto>((pageNumber, pageSize))));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Lấy chứng chỉ của lập trình viên theo Id")]
    public async ValueTask<ActionResult<DeveloperProjectResponse>> Get(Guid id)
    {
        _logger.LogInformation("Get-DeveloperProjectController: {Id}", id);

        return Ok(await _service.GetAsync(id));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới chứng chỉ của lập trình viên")]
    public async ValueTask<ActionResult<DeveloperProjectResponse>> Create(Requests.v1.Create.DeveloperProjectCreateRequest input)
    {
        _logger.LogInformation("Create-DeveloperProjectController: {Input}", input.Serialize());

        return Ok(await _service.CreateAsync(input));
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Cập nhật chứng chỉ của lập trình viên")]
    public async ValueTask<ActionResult<DeveloperProjectResponse>> Update(Guid id, Requests.v1.Update.DeveloperProjectUpdateRequest input)
    {
        _logger.LogInformation("Update-DeveloperProjectController: {Id} - {Input}", id, input.Serialize());

        return Ok(await _service.UpdateAsync(id, input));
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Xóa chứng chỉ của lập trình viên")]
    public async ValueTask<IActionResult> Delete(Guid id)
    {
        _logger.LogInformation("Delete-DeveloperProjectController: {Id}", id);
        await _service.DeleteAsync(id);

        return Ok();
    }
}
