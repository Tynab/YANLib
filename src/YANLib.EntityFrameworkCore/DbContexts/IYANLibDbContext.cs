using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using YANLib.Entities;
using static YANLib.YANLibConsts.ConnectionStringName;

namespace YANLib.DbContexts;

[ConnectionStringName(Default)]
public interface IYANLibDbContext : IEfCoreDbContext
{
    public DbSet<Developer>? Developers { get; }

    public DbSet<DeveloperType>? DeveloperTypes { get; }

    public DbSet<Certificate>? Certificates { get; }

    public DbSet<DeveloperCertificate>? DeveloperCertificates { get; }
}
