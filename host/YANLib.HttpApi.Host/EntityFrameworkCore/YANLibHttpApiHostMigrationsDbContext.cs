using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace YANLib.EntityFrameworkCore;

public class YANLibHttpApiHostMigrationsDbContext(DbContextOptions<YANLibHttpApiHostMigrationsDbContext> options) : AbpDbContext<YANLibHttpApiHostMigrationsDbContext>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureYANLib();
    }
}
