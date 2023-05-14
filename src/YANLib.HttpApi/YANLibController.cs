using Volo.Abp.AspNetCore.Mvc;
using YANLib.Localization;

namespace YANLib;

public abstract class YANLibController : AbpControllerBase
{
    protected YANLibController() => LocalizationResource = typeof(YANLibResource);
}
