using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace YANLib;

[DependsOn(
    typeof(YANLibDomainSharedModule),
    typeof(AbpDddDomainModule)
)]
public class YANLibDomainModule : AbpModule { }
