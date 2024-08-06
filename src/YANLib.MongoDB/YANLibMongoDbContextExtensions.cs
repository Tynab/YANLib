using Volo.Abp.MongoDB;
using static Volo.Abp.Check;

namespace YANLib.MongoDB;

public static class YANLibMongoDbContextExtensions
{
    public static void ConfigureYANLib(this IMongoModelBuilder builder) => NotNull(builder, nameof(builder));
}
