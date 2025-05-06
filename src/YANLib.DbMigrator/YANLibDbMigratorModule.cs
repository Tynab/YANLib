using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace YANLib.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(YANLibEntityFrameworkCoreModule),
    typeof(YANLibApplicationContractsModule)
)]
public class YANLibDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context) => Configure<AbpDbContextOptions>(static o => o.UseSqlServer());
}
