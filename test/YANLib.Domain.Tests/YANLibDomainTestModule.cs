using Volo.Abp.Modularity;

namespace YANLib;

[DependsOn(
    typeof(YANLibDomainModule),
    typeof(YANLibTestBaseModule)
)]
public class YANLibDomainTestModule : AbpModule
{

}
