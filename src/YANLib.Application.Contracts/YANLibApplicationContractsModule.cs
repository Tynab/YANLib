using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace YANLib;

[DependsOn(
    typeof(YANLibDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
)]
public class YANLibApplicationContractsModule : AbpModule { }
