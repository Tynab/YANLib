using Xunit;
using YANLib.Domain;

namespace YANLib.EntityFrameworkCore.Domains;

[Collection(YANLibTestConsts.CollectionDefinitionName)]
public class EFCoreDeveloperTypeDomainTests : DeveloperTypeDomainTests<YANLibEntityFrameworkCoreTestModule> { }
