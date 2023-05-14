using Microsoft.EntityFrameworkCore;
using static Volo.Abp.Check;

namespace YANLib.EntityFrameworkCore;

public static class YANLibDbContextModelCreatingExtensions
{
    public static void ConfigureYANLib(this ModelBuilder builder) => NotNull(builder, nameof(builder));
}
