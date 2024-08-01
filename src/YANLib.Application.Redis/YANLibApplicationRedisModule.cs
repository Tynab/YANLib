using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Modularity;
using YANLib.ConnectionFactory;
using YANLib.Options;
using YANLib.RedisDtos;
using YANLib.Services;
using YANLib.Services.Implements;

namespace YANLib;

[DependsOn(
    typeof(YANLibApplicationContractsModule),
    typeof(YANLibDomainModule)
)]
public class YANLibApplicationRedisModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        Configure<RedisOptions>(o => o.RedisConnectionString = configuration["Redis:Configuration"]);
        _ = context.Services.AddSingleton<IRedisService<DeveloperTypeDto>, RedisService<DeveloperTypeDto>>();
    }

    public override void OnApplicationShutdown(ApplicationShutdownContext context) => context.ServiceProvider.GetRequiredService<IRedisConnectionFactory>().Connection().CloseAsync();
}
