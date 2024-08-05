using Xunit;

namespace YANLib.EntityFrameworkCore.Domains;

[Collection(YANLibTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<YANLibEntityFrameworkCoreTestModule>
{

}
