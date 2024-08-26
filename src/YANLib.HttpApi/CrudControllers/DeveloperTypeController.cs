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
[Route("api/developer-types")]
public sealed class DeveloperTypeController(ILogger<DeveloperTypeController> logger, IDeveloperTypeCrudService service) : YANLibController
{
    private readonly ILogger<DeveloperTypeController> _logger = logger;
    private readonly IDeveloperTypeCrudService _service = service;

    [HttpGet]
    [SwaggerOperation(Summary = "Lấy tất cả định nghĩa loại lập trình viên")]
    public async ValueTask<ActionResult<PagedResultDto<DeveloperTypeResponse>>> GetAll(byte pageNumber = 1, byte pageSize = 10)
    {
        _logger.LogInformation("GetAll-DeveloperTypeController: {PageNumber} - {PageSize}", pageNumber, pageSize);

        return Ok(await _service.GetListAsync(new PagedAndSortedResultRequestDto
        {
            SkipCount = (pageNumber - 1) * pageSize,
            MaxResultCount = pageSize,
            Sorting = $"{nameof(DeveloperResponse.Name)} ASC,{nameof(DeveloperResponse.CreatedAt)} DESC"
        }));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Lấy định nghĩa loại lập trình viên theo Id")]
    public async ValueTask<ActionResult<DeveloperTypeResponse>> Get(Guid id)
    {
        _logger.LogInformation("Get-DeveloperTypeCrudController: {Id}", id);

        return Ok(await _service.GetAsync(id));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới định nghĩa loại lập trình viên")]
    public async ValueTask<ActionResult<DeveloperTypeResponse>> Create(DeveloperTypeCreateRequest request)
    {
        _logger.LogInformation("Create-DeveloperTypeCrudController: {Request}", request.Serialize());

        return Ok(await _service.CreateAsync(request));
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Cập nhật định nghĩa loại lập trình viên")]
    public async ValueTask<ActionResult<DeveloperTypeResponse>> Update(Guid id, DeveloperTypeUpdateRequest request)
    {
        _logger.LogInformation("Update-DeveloperTypeCrudController: {Id} - {Request}", id, request.Serialize());

        return Ok(await _service.UpdateAsync(id, request));
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Xóa định nghĩa loại lập trình viên")]
    public async ValueTask<IActionResult> Delete(Guid id)
    {
        _logger.LogInformation("Delete-DeveloperTypeCrudController: {Id}", id);
        await _service.DeleteAsync(id);

        return Ok();
    }
}
