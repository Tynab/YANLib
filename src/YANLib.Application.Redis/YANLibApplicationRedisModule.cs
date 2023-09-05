using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Modularity;
using YANLib.Application.Redis.ConnectionFactory;
using YANLib.Application.Redis.Services;
using YANLib.Application.Redis.Services.Implements;
using YANLib.RedisDtos;

namespace YANLib.Application.Redis;

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
        _ = context.Services.AddSingleton<IRedisService<DeveloperTypeDto>, DeveloperTypeRedisService>();
    }

    public override void OnApplicationShutdown(ApplicationShutdownContext context) => context.ServiceProvider.GetRequiredService<IRedisConnectionFactory>().Connection().CloseAsync();
}
