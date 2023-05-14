using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.FluentValidation;
using Volo.Abp.Modularity;

namespace YANLib;

[DependsOn(
    typeof(YANLibDomainModule),
    typeof(YANLibApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule),
    typeof(AbpFluentValidationModule)
    )]
public class YANLibApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context) => Configure<AbpAutoMapperOptions>(o => o.AddMaps<YANLibApplicationModule>());
}
