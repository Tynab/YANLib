using Microsoft.Extensions.DependencyInjection;
using Polly;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;
using static System.TimeSpan;

namespace YANLib.HttpApi.Client.ConsoleTestApp;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(YANLibHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
)]
public class YANLibConsoleApiClientModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
        => PreConfigure<AbpHttpClientBuilderOptions>(static o => o.ProxyClientBuildActions.Add(static (r, c) => c.AddTransientHttpErrorPolicy(static p => p.WaitAndRetryAsync(3, static i => FromSeconds(2.Pow(i))))));
}
