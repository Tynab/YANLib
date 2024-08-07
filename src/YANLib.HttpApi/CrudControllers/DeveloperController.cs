using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.Core;
using YANLib.CrudServices;
using YANLib.Requests.Crud.Create;
using YANLib.Requests.Crud.Update;
using YANLib.Responses;

namespace YANLib.CrudControllers;

[ApiController]
[ApiExplorerSettings(GroupName = "crud")]
[Route("api/developers")]
public sealed class DeveloperController(ILogger<DeveloperController> logger, IDeveloperCrudService service) : YANLibController
{
    private readonly ILogger<DeveloperController> _logger = logger;
    private readonly IDeveloperCrudService _service = service;

    [HttpGet]
    [SwaggerOperation(Summary = "Lấy tất cả lập trình viên")]
    public async ValueTask<ActionResult<PagedResultDto<DeveloperResponse>>> GetAll() => Ok(await _service.GetListAsync(new PagedAndSortedResultRequestDto()));

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Lấy lập trình viên theo Id")]
    public async ValueTask<ActionResult<DeveloperResponse>> Get(Guid id)
    {
        _logger.LogInformation("Get-DeveloperCrudController: {Id}", id);

        return Ok(await _service.GetAsync(id));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới lập trình viên")]
    public async ValueTask<ActionResult<DeveloperResponse>> Create(DeveloperCreateRequest request)
    {
        _logger.LogInformation("Create-DeveloperCrudController: {Request}", request.Serialize());

        return Ok(await _service.CreateAsync(request));
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Cập nhật lập trình viên")]
    public async ValueTask<ActionResult<DeveloperResponse>> Update(Guid id, DeveloperUpdateRequest request)
    {
        _logger.LogInformation("Update-DeveloperCrudController: {Id} - {Request}", id, request.Serialize());

        return Ok(await _service.UpdateAsync(id, request));
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Xóa lập trình viên")]
    public async ValueTask<IActionResult> Delete(Guid id)
    {
        _logger.LogInformation("Delete-DeveloperCrudController: {Id}", id);
        await _service.DeleteAsync(id);

        return Ok();
    }
}
