using Xunit;
using YANLib.Books;

namespace YANLib.EntityFrameworkCore.Applications.Books;

[Collection(YANLibTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<YANLibEntityFrameworkCoreTestModule>
{

}