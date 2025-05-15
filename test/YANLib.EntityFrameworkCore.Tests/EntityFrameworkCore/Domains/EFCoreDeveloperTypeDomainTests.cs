using Xunit;
using YANLib.DeveloperType;

namespace YANLib.EntityFrameworkCore.Domains;

[Collection(YANLibTestConsts.CollectionDefinitionName)]
public class EFCoreDeveloperTypeDomainTests : DeveloperTypeDomainTests<YANLibEntityFrameworkCoreTestModule>
{
}
