using Volo.Abp.Modularity;
using YANLib.EntityFrameworkCore;

namespace YANLib;

[DependsOn(
    typeof(YANLibEntityFrameworkCoreTestModule)
)]
public class YANLibDomainTestModule : AbpModule { }
