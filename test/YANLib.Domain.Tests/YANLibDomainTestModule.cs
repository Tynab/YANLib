using Volo.Abp.Modularity;

namespace YANLib;

[DependsOn(
    typeof(YANLibDomainModule),
    typeof(YANLibTestBaseModule)
    //typeof(YANLibEntityFrameworkCoreTestModule)
)]
public class YANLibDomainTestModule : AbpModule { }
