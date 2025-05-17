using Volo.Abp.Modularity;

namespace YANLib;

public abstract class YANLibDomainTestBase<TStartupModule> : YANLibTestBase<TStartupModule> where TStartupModule : IAbpModule { }
