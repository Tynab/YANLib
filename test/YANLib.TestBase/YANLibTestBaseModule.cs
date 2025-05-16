using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Authorization;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using static Volo.Abp.Threading.AsyncHelper;

namespace YANLib;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpTestBaseModule),
    typeof(AbpAuthorizationModule),
    typeof(AbpBackgroundJobsAbstractionsModule)
)]
public class YANLibTestBaseModule : AbpModule
{
    private static bool _dataSeeded = false;
    private static readonly object _lockObject = new();

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(static o => o.IsJobExecutionEnabled = false);
        _ = context.Services.AddAlwaysAllowAuthorization();
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context) => SeedTestData(context);

    private static void SeedTestData(ApplicationInitializationContext context)
    {
        if (_dataSeeded)
        {
            return;
        }

        lock (_lockObject)
        {
            if (_dataSeeded)
            {
                return;
            }

            RunSync(async () =>
            {
                using var scope = context.ServiceProvider.CreateScope();

                await scope.ServiceProvider.GetRequiredService<IDataSeeder>().SeedAsync();
            });

            _dataSeeded = true;
        }
    }
}
