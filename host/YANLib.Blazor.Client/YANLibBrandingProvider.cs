using Microsoft.Extensions.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;
using YANLib.Localization;

namespace YANLib.Blazor.Client;

[Dependency(ReplaceServices = true)]
public class YANLibBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<YANLibResource> _localizer;

    public YANLibBrandingProvider(IStringLocalizer<YANLibResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
