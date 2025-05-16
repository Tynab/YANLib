using Xunit;
using YANLib.Repositories;

namespace YANLib.EntityFrameworkCore.Domains;

[Collection(YANLibTestConsts.CollectionDefinitionName)]
public class EFCoreProjectDomainTests : ProjectDomainTests<YANLibEntityFrameworkCoreTestModule> { }
