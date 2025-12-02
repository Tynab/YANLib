using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using YANLib.Entities;
using static YANLib.BaseConsts.ConnectionStringName;

namespace YANLib.DbContexts;

[ConnectionStringName(Default)]
public interface IBaseDbContext : IEfCoreDbContext
{
    public DbSet<Sample> Samples { get; }
}
