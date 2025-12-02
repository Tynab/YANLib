using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using YANLib.Services;
using YANLib.Services.Implements;

namespace YANLib;

[DependsOn(
    typeof(BaseApplicationContractsModule),
    typeof(BaseDomainModule)
)]
public class BaseApplicationEsModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context) => context.Services.AddSingleton(typeof(IEsService<,>), typeof(EsService<,>));
}
