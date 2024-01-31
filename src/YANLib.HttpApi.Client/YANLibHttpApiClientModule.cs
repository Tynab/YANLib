using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.Http.Client;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace YANLib;

[DependsOn(
    typeof(AbpHttpClientModule),
    typeof(AbpIdentityHttpApiClientModule),
    typeof(AbpAccountHttpApiClientModule),
    typeof(YANLibApplicationContractsModule)
)]
public class YANLibHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "Default";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        _ = context.Services.AddHttpClientProxies(typeof(YANLibApplicationContractsModule).Assembly, RemoteServiceName);
        Configure<AbpVirtualFileSystemOptions>(o => o.FileSets.AddEmbedded<YANLibHttpApiClientModule>());
    }
}
