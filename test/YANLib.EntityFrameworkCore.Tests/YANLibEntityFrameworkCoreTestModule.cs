using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;
using YANLib.DbContexts.Implements;

namespace YANLib;

[DependsOn(
    typeof(YANLibEntityFrameworkCoreModule),
    typeof(YANLibApplicationTestModule),
    typeof(AbpEntityFrameworkCoreSqliteModule)
)]
public class YANLibEntityFrameworkCoreTestModule : AbpModule
{
    private SqliteConnection? _sqliteConnection;

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        _ = context.Services.AddAlwaysDisableUnitOfWorkTransaction();

        ConfigureInMemorySqlite(context.Services);
    }

    private void ConfigureInMemorySqlite(IServiceCollection services)
    {
        _sqliteConnection = CreateDatabaseAndGetConnection();
        _ = services.Configure<AbpDbContextOptions>(o => o.Configure(c => c.DbContextOptions.UseSqlite(_sqliteConnection)));
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        base.OnApplicationInitialization(context);

        SeedTestData(context);
    }

    private static void SeedTestData(ApplicationInitializationContext context)
    {
        using var scope = context.ServiceProvider.CreateScope();

        var dataSeeder = scope.ServiceProvider.GetRequiredService<IDataSeeder>();

        dataSeeder.SeedAsync().GetAwaiter().GetResult();
    }

    public override void OnApplicationShutdown(ApplicationShutdownContext context) => _sqliteConnection?.Dispose();

    private static SqliteConnection CreateDatabaseAndGetConnection()
    {
        var connection = new SqliteConnection("Data Source=:memory:");

        connection.Open();

        var options = new DbContextOptionsBuilder<YANLibDbContext>().UseSqlite(connection).Options;

        using (var context = new YANLibDbContext(options))
        {
            context.GetService<IRelationalDatabaseCreator>().CreateTables();
        }

        return connection;
    }
}
