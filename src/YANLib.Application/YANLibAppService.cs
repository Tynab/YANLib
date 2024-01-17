using Volo.Abp.Application.Services;
using YANLib.Localization;

namespace YANLib;

public abstract class YANLibAppService : ApplicationService
{
    protected YANLibAppService() => LocalizationResource = typeof(YANLibResource);
}
