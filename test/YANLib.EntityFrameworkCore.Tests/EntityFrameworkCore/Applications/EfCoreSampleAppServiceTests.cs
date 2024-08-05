using Xunit;
using YANLib.Samples;

namespace YANLib.EntityFrameworkCore.Applications;

[Collection(YANLibTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<YANLibEntityFrameworkCoreTestModule>
{

}
