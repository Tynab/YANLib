using Localization.Resources.AbpUi;
using Volo.Abp.Account;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using YANLib.Localization;

namespace YANLib;

[DependsOn(
    typeof(AbpAspNetCoreMvcModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpAccountHttpApiModule),
    typeof(YANLibApplicationContractsModule)
)]
public class YANLibHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context) => ConfigureLocalization();

    private void ConfigureLocalization() => Configure<AbpLocalizationOptions>(o => o.Resources.Get<YANLibResource>().AddBaseTypes(typeof(AbpUiResource)));
}
