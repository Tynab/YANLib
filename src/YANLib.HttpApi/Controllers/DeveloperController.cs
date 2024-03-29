﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp;
using YANLib.Core;
using YANLib.Requests.Developer;
using YANLib.Services;

namespace YANLib.Controllers;

[RemoteService]
[ApiExplorerSettings(GroupName = "sample")]
[Route("api/developers")]
public sealed class DeveloperController(ILogger<DeveloperController> logger, IDeveloperService service) : YANLibController
{
    private readonly ILogger<DeveloperController> _logger = logger;
    private readonly IDeveloperService _service = service;

    [HttpGet("{idCard}")]
    [SwaggerOperation(Summary = "Lấy Developer theo Id Card")]
    public async ValueTask<IActionResult> GetByIdCard(string idCard)
    {
        _logger.LogInformation("GetByIdCardDeveloperController: {IdCard}", idCard);

        return Ok(await _service.GetByIdCard(idCard));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới Developer")]
    public async ValueTask<IActionResult> Create([Required] DeveloperCreateRequest request)
    {
        _logger.LogInformation("CreateDeveloperController: {Request}", request.Serialize());

        return Ok(await _service.Create(request));
    }

    [HttpPatch("{idCard}")]
    [SwaggerOperation(Summary = "Cập nhật Developer")]
    public async ValueTask<IActionResult> Adjust(string idCard, [Required] DeveloperUpdateRequest request)
    {
        _logger.LogInformation("AdjustDeveloperController: {IdCard} - {Request}", idCard, request.Serialize());

        return Ok(await _service.Adjust(idCard, request));
    }

    [HttpGet("get-by-phone")]
    [SwaggerOperation(Summary = "Lấy tất cả Developers theo Phone")]
    public async ValueTask<IActionResult> GetByPhone([Required] string phone)
    {
        _logger.LogInformation("GetByPhoneDeveloperController: {Phone}", phone);

        return Ok(await _service.GetByPhone(phone));
    }

    [HttpGet("search-by-phone")]
    [SwaggerOperation(Summary = "Tìm tất cả Developers theo Phone")]
    public async ValueTask<IActionResult> SearchByPhone([Required] string searchText)
    {
        _logger.LogInformation("SearchByPhoneDeveloperController: {SearchText}", searchText);

        return Ok(await _service.SearchByPhone(searchText));
    }

    [HttpPost("sync-db-to-es")]
    [SwaggerOperation(Summary = "Đồng bộ tất cả Developers từ Database lên Elasticsearch")]
    public async ValueTask<IActionResult> SyncDbToEs() => Ok(await _service.SyncDbToEs());
}
