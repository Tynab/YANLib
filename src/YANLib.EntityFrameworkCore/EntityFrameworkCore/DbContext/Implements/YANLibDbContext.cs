using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace YANLib.EntityFrameworkCore.DbContext.Implements;

[ConnectionStringName("Default")]
public class YANLibDbContext : AbpDbContext<YANLibDbContext>, IYANLibDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
    * public DbSet<Question> Questions { get; set; }
    */

    public YANLibDbContext(DbContextOptions<YANLibDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigureYANLib();
    }
}
