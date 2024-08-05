using Volo.Abp.AspNetCore.Components;
using YANLib.Localization;

namespace YANLib.Blazor.Client;

public abstract class YANLibComponentBase : AbpComponentBase
{
    protected YANLibComponentBase()
    {
        LocalizationResource = typeof(YANLibResource);
    }
}
