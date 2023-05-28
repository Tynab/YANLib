using Volo.Abp.Modularity;

namespace YANLib.Application.Redis;

[DependsOn(
    typeof(YANLibApplicationContractsModule),
    typeof(YANLibDomainModule)
    )]
public class YANLibApplicationRedisModule : AbpModule
{
}
