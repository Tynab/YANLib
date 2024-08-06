using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public async ValueTask<ActionResult<PagedResultDto<DeveloperResponse>>> GetAll() => Ok(await _service.GetListAsync(new PagedAndSortedResultRequestDto()));

    [HttpGet("{id}")]
    public async ValueTask<ActionResult<DeveloperResponse>> Get(Guid id)
    {
        _logger.LogInformation("GetDeveloperCrudController: {Id}", id);

        return Ok(await _service.GetAsync(id));
    }

    [HttpPost]
    public async ValueTask<ActionResult<DeveloperResponse>> Create(DeveloperCreateRequest request)
    {
        _logger.LogInformation("CreateDeveloperCrudController: {Request}", request.Serialize());

        return Ok(await _service.CreateAsync(request));
    }

    [HttpPut("{id}")]
    public async ValueTask<ActionResult<DeveloperResponse>> Update(Guid id, DeveloperUpdateRequest request)
    {
        _logger.LogInformation("UpdateDeveloperCrudController: {Id} - {Request}", id, request.Serialize());

        return Ok(await _service.UpdateAsync(id, request));
    }

    [HttpDelete("{id}")]
    public async ValueTask<IActionResult> Delete(Guid id)
    {
        _logger.LogInformation("DeleteDeveloperCrudController: {Id}", id);
        await _service.DeleteAsync(id);

        return Ok();
    }
}
