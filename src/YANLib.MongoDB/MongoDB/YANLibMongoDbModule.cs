using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Identity.MongoDB;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;
using YANLib.MongoDB.DbContext.Implements;

namespace YANLib.MongoDB;

[DependsOn(
    typeof(YANLibDomainModule),
    typeof(AbpMongoDbModule),
    typeof(AbpIdentityMongoDbModule)
)]
public class YANLibMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context) => context.Services.AddMongoDbContext<YANLibMongoDbContext>(o => { });
}
