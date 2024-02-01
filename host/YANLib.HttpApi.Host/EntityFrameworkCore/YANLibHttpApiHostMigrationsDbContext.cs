using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace YANLib.EntityFrameworkCore;

public class YANLibHttpApiHostMigrationsDbContext : AbpDbContext<YANLibHttpApiHostMigrationsDbContext>
{
    public YANLibHttpApiHostMigrationsDbContext(DbContextOptions<YANLibHttpApiHostMigrationsDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ConfigureYANLib();
    }
}
