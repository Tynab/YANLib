using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using YANLib.Models;
using static YANLib.YANLibConsts;

namespace YANLib.EntityFrameworkCore.DbContext;

[ConnectionStringName(ConnectionStringName)]
public interface IYANLibDbContext : IEfCoreDbContext
{
    public DbSet<Developer> Developers { get; }
    public DbSet<DeveloperType> DeveloperTypes { get; }
    public DbSet<Certificate> Certificates { get; }
}
