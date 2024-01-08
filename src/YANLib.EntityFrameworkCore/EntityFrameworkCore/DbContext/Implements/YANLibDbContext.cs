namespace YANLib.EntityFrameworkCore.DbContext.Implements;

[ConnectionStringName(Default)]
public class YANLibDbContext(DbContextOptions<YANLibDbContext> options) : AbpDbContext<YANLibDbContext>(options), IYANLibDbContext
{
    #region Properties
    public DbSet<Developer> Developers { get; set; }

    public DbSet<DeveloperType> DeveloperTypes { get; set; }

    public DbSet<Certificate> Certificates { get; set; }
    #endregion

    #region Overridden
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        _ = builder.HasDefaultSchema(Sample);
        builder.ConfigureYANLib();
    }
    #endregion
}
