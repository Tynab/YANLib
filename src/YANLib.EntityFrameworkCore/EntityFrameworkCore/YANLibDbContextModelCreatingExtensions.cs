namespace YANLib.EntityFrameworkCore;

public static class YANLibDbContextModelCreatingExtensions
{
    public static void ConfigureYANLib(this ModelBuilder builder) => NotNull(builder, nameof(builder));
}
