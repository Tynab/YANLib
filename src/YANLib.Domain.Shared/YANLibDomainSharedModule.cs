using Volo.Abp.BackgroundJobs;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using YANLib.Localization;

namespace YANLib;

[DependsOn(
    typeof(AbpValidationModule),
    typeof(AbpIdentityDomainSharedModule),
    typeof(AbpBackgroundJobsDomainSharedModule)
)]
public class YANLibDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(o => o.FileSets.AddEmbedded<YANLibDomainSharedModule>());

        Configure<AbpLocalizationOptions>(o =>
        {
            _ = o.Resources.Add<YANLibResource>("vi").AddBaseTypes(typeof(AbpValidationResource)).AddVirtualJson("/Localization/YANLib");
            o.DefaultResourceType = typeof(YANLibResource);
        });

        Configure<AbpExceptionLocalizationOptions>(o => o.MapCodeNamespace("YANLib", typeof(YANLibResource)));
    }
}
