using Volo.Abp.Modularity;

namespace YANLib;

/* Inherit from this class for your domain layer tests. */
public abstract class YANLibDomainTestBase<TStartupModule> : YANLibTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
