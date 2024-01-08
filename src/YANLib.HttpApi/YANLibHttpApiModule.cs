namespace YANLib;

[DependsOn(
    typeof(YANLibApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule)
)]
public class YANLibHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context) => ConfigureLocalization();

    private void ConfigureLocalization() => Configure<AbpLocalizationOptions>(o => o.Resources.Get<YANLibResource>().AddBaseTypes(typeof(AbpUiResource)));
}
