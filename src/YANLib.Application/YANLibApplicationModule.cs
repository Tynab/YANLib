using Volo.Abp.Account;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.FluentValidation;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using YANLib.Application.Redis;

namespace YANLib;

[DependsOn(
    typeof(AbpDddApplicationModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpAccountApplicationModule),
    typeof(AbpAutoMapperModule),
    typeof(AbpFluentValidationModule),
    typeof(YANLibDomainModule),
    typeof(YANLibApplicationContractsModule),
    typeof(YANLibApplicationRedisModule)
)]
public class YANLibApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context) => Configure<AbpAutoMapperOptions>(o => o.AddMaps<YANLibApplicationModule>());
}
