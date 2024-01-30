using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
using YANLib.Entities;
using YANLib.EntityFrameworkCore.DbContext.Implements;

namespace YANLib.EntityFrameworkCore;

[DependsOn(
    typeof(YANLibDomainModule),
    typeof(AbpEntityFrameworkCoreModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpBackgroundJobsEntityFrameworkCoreModule)
)]
public class YANLibEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        _ = context.Services.AddAbpDbContext<YANLibDbContext>(o => { });
        _ = context.Services.AddAbpDbContext<YANLibDbContext>(o => o.AddDefaultRepository<DeveloperType>());
    }
}
