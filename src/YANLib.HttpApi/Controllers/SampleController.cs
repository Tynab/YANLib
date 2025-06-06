﻿using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using YANLib.Requests;
using YANLib.Services;
using static System.Guid;
using static System.Threading.Tasks.Task;
using static YANLib.YANRandom;

namespace YANLib.Controllers;

[ApiVersion(1, Deprecated = true)]
[ApiVersion(2)]
[ApiController]
[Route("api/v{v:apiVersion}/[controller]")]
public sealed class SampleController(ILogger<SampleController> logger, ISampleService service) : YANLibController
{
    private readonly ILogger<SampleController> _logger = logger;
    private readonly ISampleService _service = service;

    [MapToApiVersion(1)]
    [HttpGet("test")]
    [SwaggerOperation(Summary = "Đo tốc độ xử lý JSON của thư viện YANLib và các chuẩn khác")]
    public async Task<IActionResult> Test([Required] uint quantity = 10000, [Required] bool hideSystem = true)
    {
        _logger.LogInformation("JsonTest-SampleController: {Quantity} - {HideSystem}", quantity, hideSystem);

        return Ok(await _service.Test(quantity, hideSystem));
    }

    [MapToApiVersion(2)]
    [HttpGet("test")]
    [SwaggerOperation(Summary = "Trả về dữ liệu linh hoạt")]
    public async Task<IActionResult> TestV2() => GenerateRandom<byte>(min: 1, max: 8) switch
    {
        1 => await FromResult(Ok(GenerateRandom<bool>())),
        2 => await FromResult(Ok(GenerateRandom<char>())),
        3 => await FromResult(Ok(GenerateRandom<string>())),
        4 => await FromResult(Ok(GenerateRandom<short>())),
        5 => await FromResult(Ok(GenerateRandom<float>())),
        6 => await FromResult(Ok(new List<NotificationRequest>
        {
            new("Hi, YAN!", NewGuid()),
            new("Hi, Tynab!", NewGuid())
        })),
        _ => await FromResult(Ok(new NotificationRequest("Hello, World!", NewGuid())))
    };
}
