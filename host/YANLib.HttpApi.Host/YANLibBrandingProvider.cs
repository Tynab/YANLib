using Microsoft.Extensions.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;
using YANLib.Localization;

namespace YANLib;

[Dependency(ReplaceServices = true)]
public class YANLibBrandingProvider(IStringLocalizer<YANLibResource> localizer) : DefaultBrandingProvider
{
    private readonly IStringLocalizer<YANLibResource> _localizer = localizer;

    public override string AppName => _localizer["YANLib"];
}
