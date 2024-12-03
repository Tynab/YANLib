using Volo.Abp.Modularity;

namespace YANLib;

[DependsOn(
    typeof(YANLibApplicationContractsModule),
    typeof(YANLibDomainModule)
)]
public class YANLibApplicationElasticsearchModule : AbpModule
{
}
