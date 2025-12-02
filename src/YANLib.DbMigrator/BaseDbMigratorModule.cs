using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace YANLib.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BaseEntityFrameworkCoreModule),
    typeof(BaseApplicationContractsModule)
)]
public class BaseDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context) => Configure<AbpDbContextOptions>(static o => o.UseNpgsql());
}
