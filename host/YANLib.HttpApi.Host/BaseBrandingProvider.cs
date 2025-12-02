using Microsoft.Extensions.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;
using YANLib.Localization;

namespace YANLib;

[Dependency(ReplaceServices = true)]
public class BaseBrandingProvider(IStringLocalizer<BaseResource> localizer) : DefaultBrandingProvider
{
    public override string AppName => localizer["AppName"];
}
