using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using YANLib.DbContexts;
using YANLib.Entities;
using static YANLib.BaseConsts.ConnectionStringName;

namespace YANLib.DbContexts.Implements;

[ConnectionStringName(Default)]
public class BaseDbContext(DbContextOptions<BaseDbContext> options) : AbpDbContext<BaseDbContext>(options), IBaseDbContext
{
    public DbSet<Sample> Samples { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureBaseBE();
    }
}
