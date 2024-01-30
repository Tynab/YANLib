using Microsoft.Extensions.DependencyInjection;
using Polly;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;
using static System.Math;
using static System.TimeSpan;

namespace YANLib.HttpApi.Client.ConsoleTestApp;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(YANLibHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
)]
public class YANLibConsoleApiClientModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context) => PreConfigure<AbpHttpClientBuilderOptions>(o => o.ProxyClientBuildActions.Add((r, c) => c.AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.WaitAndRetryAsync(3, i => FromSeconds(Pow(2, i))))));
}
