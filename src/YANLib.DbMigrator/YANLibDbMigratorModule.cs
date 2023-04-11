using YANLib.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace YANLib.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(YANLibEntityFrameworkCoreModule),
    typeof(YANLibApplicationContractsModule)
    )]
public class YANLibDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
