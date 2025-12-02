using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using YANLib;
using YANLib.EsIndices;
using YANLib.ListQueries;
using YANLib.Requests.CreateOrUpdateRequest;
using YANLib.Responses;
using YANLib.Services;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace EOE.CCSBE.Controllers;

[Route("api/[controller]")]
public sealed class SampleEsController(ILogger<SampleEsController> logger, ISampleEsService service) : BaseController
{
    [HttpGet]
    [SwaggerOperation(
        Summary = "Lấy danh sách mẫu",
        Description = "Trả về danh sách các mẫu dựa trên các tiêu chí lọc và phân trang được cung cấp. Mặc định sắp xếp theo ngày cập nhật mới nhất."
    )]
    [ProducesResponseType(typeof(PagedResultDto<SampleResponse>), Status200OK)]
    public async Task<ActionResult<PagedResultDto<SampleResponse>>> GetList([FromQuery] SampleListQuery query, CancellationToken cancellationToken = default)
    {
        query.SortField ??= nameof(SampleEsIndex.UpdatedAt);
        query.SortDescending ??= true;

        logger.LogInformation("GetList-SampleEsController: {Query}", query.Serialize());

        return Ok(await service.GetList(query, cancellationToken));
    }

    [HttpGet("{id:guid}")]
    [SwaggerOperation(
        Summary = "Lấy mẫu theo ID",
        Description = "Trả về thông tin chi tiết của một mẫu dựa trên ID được cung cấp."
    )]
    [ProducesResponseType(typeof(SampleResponse), Status200OK)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<SampleResponse>> Get([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Get-SampleEsController: {Id}", id);

        var result = await service.Get(id, cancellationToken);

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
        logger.LogInformation("Add-SampleEsController: {Request}", request.Serialize());

        var result = await service.Add(request, cancellationToken);

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
        logger.LogInformation("Update-SampleEsController: {Id} - {Request}", id, request.Serialize());

        var result = await service.Update(id, request, cancellationToken);

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
        logger.LogInformation("Delete-SampleEsController: {Id}", id);

        var result = await service.Delete(id, cancellationToken);

        return result ? Ok(result) : NotFound();
    }

    [HttpPost("sync-data-to-es")]
    [SwaggerOperation(
        Summary = "Đồng bộ dữ liệu mẫu vào Elasticsearch",
        Description = "Đồng bộ tất cả dữ liệu mẫu hiện có vào Elasticsearch để cải thiện hiệu suất tìm kiếm và truy xuất."
    )]
    [ProducesResponseType(typeof(bool), Status200OK)]
    public async Task<IActionResult> SyncDataToEs(CancellationToken cancellationToken = default) => Ok(await service.SyncDataToEs(cancellationToken));

    [HttpGet("search-with-wild-card")]
    [SwaggerOperation(
        Summary = "Tìm kiếm với ký tự đại diện",
        Description = "Tìm kiếm các mẫu với ký tự đại diện (*) để thay thế cho một hoặc nhiều ký tự trong từ khóa tìm kiếm. Nếu không truyền tham số Search, mặc định sẽ tìm với từ khóa 'trend*'."
    )]
    [ProducesResponseType(typeof(PagedResultDto<SampleResponse>), Status200OK)]
    public async Task<ActionResult<PagedResultDto<SampleResponse>>> SearchWithWildcard([FromQuery] SampleListQuery query, CancellationToken cancellationToken = default)
    {
        query.Search ??= "trend*";

        logger.LogInformation("SearchWithWildcard-SampleEsController: {Query}", query.Serialize());

        return Ok(await service.SearchWithWildcard(query, cancellationToken));
    }

    [HttpGet("search-with-phrase-prefix")]
    [SwaggerOperation(
        Summary = "Tìm kiếm mẫu với cụm từ tiền tố",
        Description = "Tìm kiếm các mẫu với cụm từ tiền tố để tìm các từ bắt đầu bằng cụm từ đó. Nếu không truyền tham số Search, mặc định sẽ tìm với từ khóa 'customer ins'."
    )]
    [ProducesResponseType(typeof(PagedResultDto<SampleResponse>), Status200OK)]
    public async Task<ActionResult<PagedResultDto<SampleResponse>>> SearchWithPhrasePrefix([FromQuery] SampleListQuery query, CancellationToken cancellationToken = default)
    {
        query.Search ??= "customer ins";

        logger.LogInformation("SearchWithPhrasePrefix-SampleEsController: {Query}", query.Serialize());

        return Ok(await service.SearchWithPhrasePrefix(query, cancellationToken));
    }

    [HttpGet("search-with-exact-phrase")]
    [SwaggerOperation(
        Summary = "Tìm kiếm mẫu với cụm từ chính xác",
        Description = "Tìm kiếm các mẫu với cụm từ chính xác để tìm các từ khớp chính xác với cụm từ đó. Nếu không truyền tham số Search, mặc định sẽ tìm với từ khóa 'trends in'."
    )]
    [ProducesResponseType(typeof(PagedResultDto<SampleResponse>), Status200OK)]
    public async Task<ActionResult<PagedResultDto<SampleResponse>>> SearchWithExactPhrase([FromQuery] SampleListQuery query, CancellationToken cancellationToken = default)
    {
        query.Search ??= "trends in";

        logger.LogInformation("SearchWithExactPhrase-SampleEsController: {Query}", query.Serialize());

        return Ok(await service.SearchWithExactPhrase(query, cancellationToken));
    }

    [HttpGet("search-with-keywords")]
    [SwaggerOperation(
        Summary = "Tìm kiếm mẫu với từ khóa",
        Description = "Tìm kiếm các mẫu với từ khóa để tìm các từ khớp với bất kỳ từ nào trong từ khóa đó. Nếu không truyền tham số Search, mặc định sẽ tìm với từ khóa 'trends analytics'."
    )]
    [ProducesResponseType(typeof(PagedResultDto<SampleResponse>), Status200OK)]
    public async Task<ActionResult<PagedResultDto<SampleResponse>>> SearchWithKeywords([FromQuery] SampleListQuery query, CancellationToken cancellationToken = default)
    {
        query.Search ??= "trends analytics";

        logger.LogInformation("SearchWithKeywords-SampleEsController: {Query}", query.Serialize());

        return Ok(await service.SearchWithKeywords(query, cancellationToken));
    }
}
