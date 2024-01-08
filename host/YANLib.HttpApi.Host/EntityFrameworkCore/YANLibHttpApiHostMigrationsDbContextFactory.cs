namespace YANLib.EntityFrameworkCore;

public class YANLibHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<YANLibHttpApiHostMigrationsDbContext>
{
    public YANLibHttpApiHostMigrationsDbContext CreateDbContext(string[] args) => new(new DbContextOptionsBuilder<YANLibHttpApiHostMigrationsDbContext>()
        .UseSqlServer(new ConfigurationBuilder().SetBasePath(GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false).Build().GetConnectionString("Default")).Options);
}
