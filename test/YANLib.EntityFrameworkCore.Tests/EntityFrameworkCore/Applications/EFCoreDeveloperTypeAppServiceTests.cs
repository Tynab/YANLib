using Xunit;
using YANLib.Services;

namespace YANLib.EntityFrameworkCore.Applications.Services;

[Collection(YANLibTestConsts.CollectionDefinitionName)]
public class EFCoreDeveloperTypeAppServiceTests : DeveloperTypeServiceTests<YANLibEntityFrameworkCoreTestModule> { }
