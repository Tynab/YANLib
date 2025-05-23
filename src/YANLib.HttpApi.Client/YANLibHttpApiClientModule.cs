﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace YANLib;

[DependsOn(
    typeof(YANLibApplicationContractsModule),
    typeof(AbpHttpClientModule)
)]
public class YANLibHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "Default";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        _ = context.Services.AddHttpClientProxies(typeof(YANLibApplicationContractsModule).Assembly, RemoteServiceName);
        Configure<AbpVirtualFileSystemOptions>(static o => o.FileSets.AddEmbedded<YANLibHttpApiClientModule>());
    }
}
