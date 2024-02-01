using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using YANLib.Entities;
using static YANLib.YANLibConsts.ConnectionStringName;
using static YANLib.YANLibConsts.DbSchema;

namespace YANLib.EntityFrameworkCore.DbContext.Implements;

[ConnectionStringName(Default)]
public class YANLibDbContext : AbpDbContext<YANLibDbContext>, IYANLibDbContext
{
    public YANLibDbContext(DbContextOptions<YANLibDbContext> options) : base(options)
    {
    }

    public DbSet<Developer> Developers { get; set; }

    public DbSet<DeveloperType> DeveloperTypes { get; set; }

    public DbSet<Certificate> Certificates { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        _ = builder.HasDefaultSchema(Sample);
        builder.ConfigureYANLib();
    }
}
