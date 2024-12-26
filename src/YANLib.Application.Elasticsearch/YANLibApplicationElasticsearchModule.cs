using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using YANLib.Services;
using YANLib.Services.Implements;

namespace YANLib;

[DependsOn(
    typeof(YANLibApplicationContractsModule),
    typeof(YANLibDomainModule)
)]
public class YANLibApplicationElasticsearchModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context) => context.Services.AddSingleton(typeof(IEsService<>), typeof(EsService<>));
}
