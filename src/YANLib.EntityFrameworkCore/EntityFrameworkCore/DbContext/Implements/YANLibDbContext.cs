using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using YANLib.Models;
using static YANLib.YANLibConsts;

namespace YANLib.EntityFrameworkCore.DbContext.Implements;

public class YANLibDbContext : AbpDbContext<YANLibDbContext>, IYANLibDbContext
{
    public DbSet<Developer> Developers { get; set; }
    public DbSet<DeveloperType> DeveloperTypes { get; set; }
    public DbSet<Certificate> Certificates { get; set; }

    public YANLibDbContext(DbContextOptions<YANLibDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        _ = builder.HasDefaultSchema(DbSchema);
        builder.ConfigureYANLib();
    }
}
