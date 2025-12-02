using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace YANLib;

[DependsOn(
    typeof(BaseDomainSharedModule),
    typeof(AbpDddDomainModule)
)]
public class BaseDomainModule : AbpModule
{
}
