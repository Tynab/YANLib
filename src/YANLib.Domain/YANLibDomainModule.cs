using Volo.Abp.BackgroundJobs;
using Volo.Abp.Domain;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace YANLib;

[DependsOn(
    typeof(YANLibDomainSharedModule),
    typeof(AbpDddDomainModule),
    typeof(AbpIdentityDomainModule),
    typeof(AbpBackgroundJobsDomainModule)
)]
public class YANLibDomainModule : AbpModule
{
}
