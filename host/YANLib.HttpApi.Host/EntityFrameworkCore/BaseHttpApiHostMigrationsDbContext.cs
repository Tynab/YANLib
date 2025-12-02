using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using YANLib;

namespace YANLib.EntityFrameworkCore;

public class BaseHttpApiHostMigrationsDbContext(DbContextOptions<BaseHttpApiHostMigrationsDbContext> options) : AbpDbContext<BaseHttpApiHostMigrationsDbContext>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureBaseBE();
    }
}
