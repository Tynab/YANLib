using Volo.Abp.AspNetCore.Mvc;
using YANLib.Localization;

namespace YANLib;

public abstract class BaseController : AbpControllerBase
{
    protected BaseController() => LocalizationResource = typeof(BaseResource);
}
