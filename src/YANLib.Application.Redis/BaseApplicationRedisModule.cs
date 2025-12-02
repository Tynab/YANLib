using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Modularity;
using YANLib.ConnectionFactories;
using YANLib.ConnectionFactories.Implements;
using YANLib.Services;
using YANLib.Services.Implements;

namespace YANLib;

[DependsOn(
    typeof(BaseApplicationContractsModule),
    typeof(BaseDomainModule)
)]
public class BaseApplicationRedisModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        Configure<RedisOptions>(o => o.RedisConnectionString = configuration["Redis:Configuration"]);
        _ = context.Services.AddSingleton(typeof(IRedisService<>), typeof(RedisService<>));
    }

    public override void OnApplicationShutdown(ApplicationShutdownContext context)
    {
        if (context.ServiceProvider.GetService<IRedisConnectionFactory>() is not RedisConnectionFactory factory || !factory.HasConnection)
        {
            return;
        }

        var conn = factory.Connection();

        if (conn.IsConnected)
        {
            conn.CloseAsync().GetAwaiter().GetResult();
        }
    }
}
