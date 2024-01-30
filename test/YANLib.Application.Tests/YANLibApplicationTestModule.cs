using Volo.Abp.Modularity;

namespace YANLib;

[DependsOn(
    typeof(YANLibApplicationModule),
    typeof(YANLibDomainTestModule)
)]
public class YANLibApplicationTestModule : AbpModule
{
}
