using Microsoft.EntityFrameworkCore;
using static Volo.Abp.Check;

namespace YANLib;

public static class BaseDbContextModelCreatingExtensions
{
    public static void ConfigureBaseBE(this ModelBuilder builder) => NotNull(builder, nameof(builder));
}
