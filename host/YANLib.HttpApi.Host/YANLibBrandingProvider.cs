using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace YANLib;

[Dependency(ReplaceServices = true)]
public class YANLibBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "YANLib";
}
