using YANLib.Application.Redis.ConnectionFactory;
using YANLib.Application.Redis.Services;
using YANLib.Application.Redis.Services.Implements;

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
        _ = context.Services.AddSingleton<IRedisService<DeveloperTypeRedisDto>, DeveloperTypeRedisService>();
    }

    public override void OnApplicationShutdown(ApplicationShutdownContext context) => context.ServiceProvider.GetRequiredService<IRedisConnectionFactory>().Connection().CloseAsync();
}
