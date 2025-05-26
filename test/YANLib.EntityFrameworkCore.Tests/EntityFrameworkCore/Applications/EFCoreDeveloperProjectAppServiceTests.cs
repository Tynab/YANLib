using Xunit;
using YANLib.Services;

namespace YANLib.EntityFrameworkCore.Applications;

[Collection(YANLibTestConsts.CollectionDefinitionName)]
public class EFCoreDeveloperProjectAppServiceTests : DeveloperProjectAppServiceTests<YANLibEntityFrameworkCoreTestModule> { }
