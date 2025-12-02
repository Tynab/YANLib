using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using YANLib;
using YANLib.Requests.CreateOrUpdateRequest;
using YANLib.Responses;
using YANLib.Services;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace EOE.CCSBE.Controllers;

[Route("api/[controller]")]
public sealed class SampleRedisController(ILogger<SampleRedisController> logger, ISampleRedisService service) : BaseController
{
    [HttpGet]
    [SwaggerOperation(
        Summary = "Lấy danh sách tất cả mẫu",
        Description = "Trả về danh sách tất cả các mẫu hiện có trong hệ thống."
    )]
    [ProducesResponseType(typeof(List<SampleResponse>), Status200OK)]
    [ProducesResponseType(Status204NoContent)]
    public async Task<ActionResult<List<SampleResponse>>> GetAll(CancellationToken cancellationToken = default) => Ok(await service.GetAllAsync(cancellationToken));

    [HttpGet("{id:guid}")]
    [SwaggerOperation(
        Summary = "Lấy mẫu theo ID",
        Description = "Trả về thông tin chi tiết của một mẫu dựa trên ID được cung cấp."
    )]
    [ProducesResponseType(typeof(SampleResponse), Status200OK)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<SampleResponse>> Get([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Get-SampleRedisController: {Id}", id);

        var result = await service.GetOrAddAsync(id, cancellationToken);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Thêm mẫu mới",
        Description = "Tạo một mẫu mới với thông tin được cung cấp trong yêu cầu."
    )]
    [ProducesResponseType(typeof(SampleResponse), Status201Created)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<ActionResult<SampleResponse>> Add([Required][FromBody] SampleCreateOrUpdateRequest request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Add-SampleRedisController: {Request}", request.Serialize());

        var result = await service.AddAsync(request, cancellationToken);

        return result.IsNull()
            ? Conflict()
            : CreatedAtAction(nameof(Get), new
            {
                id = result.Id
            }, result);
    }

    [HttpPut("{id:guid}")]
    [SwaggerOperation(
        Summary = "Cập nhật mẫu",
        Description = "Cập nhật thông tin của một mẫu hiện có dựa trên ID và dữ liệu được cung cấp trong yêu cầu."
    )]
    [ProducesResponseType(typeof(SampleResponse), Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<SampleResponse>> Update([FromRoute] Guid id, [Required][FromBody] SampleCreateOrUpdateRequest request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Update-SampleRedisController: {Id} - {Request}", id, request.Serialize());

        var result = await service.UpdateAsync(id, request, cancellationToken);

        return result.IsNull() ? NotFound() : Ok(result);
    }

    [HttpDelete("{id:guid}")]
    [SwaggerOperation(
        Summary = "Xóa mẫu",
        Description = "Xóa một mẫu dựa trên ID được cung cấp."
    )]
    [ProducesResponseType(typeof(bool), Status200OK)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Delete-SampleRedisController: {Id}", id);

        var result = await service.DeleteAsync(id, cancellationToken);

        return result ? Ok(result) : NotFound();
    }

    [HttpPost("sync-data-to-redis")]
    [SwaggerOperation(
        Summary = "Đồng bộ dữ liệu sang Redis",
        Description = "Đồng bộ tất cả dữ liệu hiện có trong hệ thống sang Redis để cải thiện hiệu suất truy xuất."
    )]
    [ProducesResponseType(typeof(bool), Status200OK)]
    public async Task<IActionResult> SyncDataToRedis(CancellationToken cancellationToken = default) => Ok(await service.SyncDataToRedisAsync(cancellationToken));
}
