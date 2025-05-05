using Xunit;

namespace YANLib.EntityFrameworkCore;

[CollectionDefinition(YANLibTestConsts.CollectionDefinitionName)]
public class YANLibEntityFrameworkCoreCollection : ICollectionFixture<YANLibEntityFrameworkCoreFixture> { }
