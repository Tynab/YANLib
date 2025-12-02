using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace YANLib;

[DependsOn(
    typeof(BaseDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
)]
public class BaseApplicationContractsModule : AbpModule
{
}
