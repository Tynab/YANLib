﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp;
using YANLib.Requests;
using YANLib.Services;

namespace YANLib.Controllers;

[RemoteService]
[ApiExplorerSettings(GroupName = "sample")]
[Route("api/yanlib/developers")]
public sealed class DeveloperController : YANLibController
{
    #region Fields
    private readonly ILogger<DeveloperController> _logger;
    private readonly IDeveloperService _service;
    #endregion

    #region Constructors
    public DeveloperController(ILogger<DeveloperController> logger, IDeveloperService service)
    {
        _logger = logger;
        _service = service;
    }
    #endregion

    #region Methods
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Tìm Developer theo Id")]
    public async ValueTask<IActionResult> Get([Required] string id)
    {
        _logger.LogInformation("GetDeveloperController: {Id}", id);

        return Ok(await _service.Get(id));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới Developer")]
    public async ValueTask<IActionResult> Insert([Required] DeveloperRequest request)
    {
        _logger.LogInformation("InsertDeveloperController: {Request}", request.CamelSerialize());

        return Ok(await _service.Insert(request));
    }

    [HttpPatch("idCard")]
    [SwaggerOperation(Summary = "Cập nhật Developer")]
    public async ValueTask<IActionResult> Adjust([Required] string idCard, [Required] DeveloperFreeRequest request)
    {
        _logger.LogInformation("AdjustDeveloperController: {IdCard} - {Request}", idCard, request.CamelSerialize());

        return Ok(await _service.Adjust(idCard, request));
    }

    [HttpGet("get-by-id-card")]
    [SwaggerOperation(Summary = "Tìm Developer theo Id Card")]
    public async ValueTask<IActionResult> GetByIdCard([Required] string idCard)
    {
        _logger.LogInformation("GetByIdCardDeveloperController: {IdCard}", idCard);

        return Ok(await _service.GetByIdCard(idCard));
    }

    [HttpGet("get-by-phone")]
    [SwaggerOperation(Summary = "Tìm tất cả Developers theo Phone")]
    public async ValueTask<IActionResult> GetByPhone([Required] string phone)
    {
        _logger.LogInformation("GetByPhoneDeveloperController: {Phone}", phone);

        return Ok(await _service.GetByPhone(phone));
    }

    [HttpPost("sync-db-to-es")]
    [SwaggerOperation(Summary = "Đồng bộ tất cả Developers từ Database lên Elasticsearch")]
    public async ValueTask<IActionResult> SyncDbToEs() => Ok(await _service.SyncDbToEs());
    #endregion
}