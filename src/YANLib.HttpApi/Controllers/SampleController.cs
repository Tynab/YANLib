using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using YANLib;
using YANLib.Requests;
using YANLib.Responses;
using YANLib.Services;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace EOE.CCSBE.Controllers;

[Route("api/[controller]")]
public sealed class SampleController(ILogger<SampleController> logger, ISampleService service) : BaseController
{
    [HttpPost("send")]
    [SwaggerOperation(
        Summary = "Gửi mẫu ngay lập tức",
        Description = "Gửi mẫu ngay lập tức với thông tin được cung cấp trong yêu cầu."
    )]
    [ProducesResponseType(Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<IActionResult> Send([Required][FromBody] SampleRequest request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Send-SampleController: {Request}", request.Serialize());

        await service.Send(request, cancellationToken);

        return Ok();
    }

    [HttpPost("schedule")]
    [SwaggerOperation(
        Summary = "Lên lịch gửi mẫu",
        Description = "Lên lịch gửi mẫu với thông tin được cung cấp trong yêu cầu."
    )]
    [ProducesResponseType(Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<IActionResult> Schedule([Required][FromBody] SampleRequest request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Schedule-SampleController: {Request}", request.Serialize());

        await service.Schedule(request, cancellationToken);

        return Ok();
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Lấy danh sách mẫu",
        Description = "Lấy danh sách mẫu với phân trang và sắp xếp dựa trên các tham số truy vấn."
    )]
    [ProducesResponseType(typeof(PagedResultDto<SampleResponse>), Status200OK)]
    public async Task<ActionResult<PagedResultDto<SampleResponse>>> GetList([FromQuery] BaseListQuery listQuery, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("GetList-SampleController: {ListQuery}", listQuery.Serialize());

        return Ok(await service.GetList(listQuery, cancellationToken));
    }

    [HttpGet("item")]
    [SwaggerOperation(
        Summary = "Lấy mẫu cụ thể",
        Description = "Lấy mẫu cụ thể dựa trên các tham số truy vấn."
    )]
    [ProducesResponseType(typeof(SampleResponse), Status200OK)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<SampleResponse>> Get([FromQuery] BaseListQuery listQuery, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Get-SampleController: {ListQuery}", listQuery.Serialize());

        var result = await service.Get(listQuery, cancellationToken);

        return result.IsNull() ? NotFound() : Ok(result);
    }
}
