using Volo.Abp.Modularity;
using YANLib.Services.v1;

namespace YANLib.Services;

public abstract class DeveloperTypeServiceTests<TStartupModule> : YANLibApplicationTestBase<TStartupModule> where TStartupModule : IAbpModule
{
    private readonly IDeveloperTypeService _developerTypeService;

    public DeveloperTypeServiceTests() => _developerTypeService = GetRequiredService<IDeveloperTypeService>();

    // TODO: Implement your test methods here
}
