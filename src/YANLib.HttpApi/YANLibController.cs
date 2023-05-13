using YANLib.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace YANLib;

/* Inherit your controllers from this class.
 */
public abstract class YANLibController : AbpControllerBase
{
    protected YANLibController()
    {
        LocalizationResource = typeof(YANLibResource);
    }
}
