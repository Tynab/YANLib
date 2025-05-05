using Volo.Abp.Modularity;

namespace YANLib;

public abstract class YANLibApplicationTestBase<TStartupModule> : YANLibTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
