using Xunit;
using YANLib.Domain;

namespace YANLib.EntityFrameworkCore.Domains;

[Collection(YANLibTestConsts.CollectionDefinitionName)]
public class EFCoreDeveloperDomainTests : DeveloperDomainTests<YANLibEntityFrameworkCoreTestModule> { }
