using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using static System.IO.Directory;

namespace YANLib.EntityFrameworkCore;

public class BaseHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<BaseHttpApiHostMigrationsDbContext>
{
    public BaseHttpApiHostMigrationsDbContext CreateDbContext(string[] args) => new(
        new DbContextOptionsBuilder<BaseHttpApiHostMigrationsDbContext>().UseNpgsql(
            new ConfigurationBuilder().SetBasePath(GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false).Build().GetConnectionString("Default")
        ).Options
    );
}
