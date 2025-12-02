using Volo.Abp;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.BackgroundWorkers.Hangfire;
using Volo.Abp.FluentValidation;
using Volo.Abp.Modularity;
using YANLib.BackgroundWorkers;

namespace YANLib;

[DependsOn(
    typeof(BaseDomainModule),
    typeof(BaseApplicationContractsModule),
    typeof(BaseApplicationEsModule),
    typeof(BaseApplicationRedisModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule),
    typeof(AbpFluentValidationModule),
    typeof(AbpBackgroundWorkersHangfireModule)
)]
public class BaseApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context) => Configure<AbpAutoMapperOptions>(static o => o.AddMaps<BaseApplicationModule>());

    public override async Task OnApplicationInitializationAsync(ApplicationInitializationContext context) => await context.AddBackgroundWorkerAsync<SampleWorker>();
}
