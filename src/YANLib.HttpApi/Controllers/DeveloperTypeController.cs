namespace YANLib.Controllers;

[RemoteService]
[ApiExplorerSettings(GroupName = "sample")]
[Route("api/yanlib/developer-types")]
public sealed class DeveloperTypeController(ILogger<DeveloperTypeController> logger, IDeveloperTypeService service) : YANLibController
{
    #region Fields
    private readonly ILogger<DeveloperTypeController> _logger = logger;
    private readonly IDeveloperTypeService _service = service;
    #endregion

    #region Methods
    [HttpGet]
    [SwaggerOperation(Summary = "Lấy tất cả định nghĩa Developer Types")]
    public async ValueTask<IActionResult> GetAll() => Ok(await _service.GetAll());

    [HttpGet("{code}")]
    [SwaggerOperation(Summary = "Lấy định nghĩa Developer Type theo Code")]
    public async ValueTask<IActionResult> Get(int code)
    {
        _logger.LogInformation("GetDeveloperTypeController: {Code}", code);

        return Ok(await _service.Get(code));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm mới định nghĩa Developer Type")]
    public async ValueTask<IActionResult> Create([Required] DeveloperTypeCreateRequest request)
    {
        _logger.LogInformation("CreateDeveloperTypeController: {Request}", request.Serialize());

        return Ok(await _service.Create(request));
    }

    [HttpPut("{code}")]
    [SwaggerOperation(Summary = "Cập nhật định nghĩa Developer Type")]
    public async ValueTask<IActionResult> Update(int code, [Required] DeveloperTypeUpdateRequest request)
    {
        _logger.LogInformation("UpdateDeveloperTypeController: {Code} - {Request}", code, request.Serialize());

        return Ok(await _service.Update(code, request));
    }

    [SwaggerOperation(Summary = "Đồng bộ tất cả định nghĩa Developer Types từ Database sang Redis")]
    [HttpPost("sync-db-to-redis")]
    public async ValueTask<IActionResult> SyncDbToRedis() => Ok(await _service.SyncDbToRedis());
    #endregion
}
