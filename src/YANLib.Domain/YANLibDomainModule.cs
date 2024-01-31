using Volo.Abp.BackgroundJobs;
using Volo.Abp.Domain;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace YANLib;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AbpIdentityDomainModule),
    typeof(AbpBackgroundJobsDomainModule),
    typeof(YANLibDomainSharedModule)
)]
public class YANLibDomainModule : AbpModule
{
}
