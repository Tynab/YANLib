using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using YANLib.DbContexts.Implements;
using YANLib.Entities;

namespace YANLib;

[DependsOn(
    typeof(BaseDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class BaseEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        _ = context.Services.AddAbpDbContext<BaseDbContext>(static o =>
        {
            _ = o.AddDefaultRepositories(includeAllEntities: true);
            _ = o.AddRepository<Sample, BaseRepository<Sample>>();
        });

        Configure<AbpDbContextOptions>(static o => o.UseNpgsql());

        _ = context.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
    }
}
