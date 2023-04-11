using YANLib.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace YANLib;

[DependsOn(
    typeof(YANLibEntityFrameworkCoreTestModule)
    )]
public class YANLibDomainTestModule : AbpModule
{

}
