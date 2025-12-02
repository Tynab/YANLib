using Localization.Resources.AbpUi;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using YANLib.Localization;

namespace YANLib;

[DependsOn(
    typeof(BaseApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule)
)]
public class BaseHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context) => ConfigureLocalization();

    private void ConfigureLocalization() => Configure<AbpLocalizationOptions>(static o => o.Resources.Get<BaseResource>().AddBaseTypes(typeof(AbpUiResource)));
}
