using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using YANLib.DbContext.Implements;

namespace YANLib;

[DependsOn(
    typeof(YANLibDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class YANLibEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context) => context.Services.AddAbpDbContext<YANLibDbContext>(o => { });
}
