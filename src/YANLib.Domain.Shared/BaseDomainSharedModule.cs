using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using YANLib.Localization;

namespace YANLib;

[DependsOn(
    typeof(AbpValidationModule)
)]
public class BaseDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(static o => o.FileSets.AddEmbedded<BaseDomainSharedModule>());

        Configure<AbpLocalizationOptions>(static o =>
        {
            _ = o.Resources.Add<BaseResource>("vi").AddBaseTypes(typeof(AbpValidationResource)).AddVirtualJson("/Localization/YANLib");
            o.DefaultResourceType = typeof(BaseResource);
        });

        Configure<AbpExceptionLocalizationOptions>(static o => o.MapCodeNamespace("YANLib", typeof(BaseResource)));
    }
}
