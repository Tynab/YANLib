using Volo.Abp.Modularity;

namespace YANLib.Application.Redis;

[DependsOn(
    typeof(YANLibApplicationContractsModule)
    )]
public class YANLibApplicationRedisModule : AbpModule
{
}
