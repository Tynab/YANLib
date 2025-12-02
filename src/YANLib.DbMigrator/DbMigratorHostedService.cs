using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Volo.Abp;
using Volo.Abp.Data;
using YANLib.Data;
using static System.Threading.Tasks.Task;

namespace YANLib.DbMigrator;

public class DbMigratorHostedService(IHostApplicationLifetime hostApplicationLifetime, IConfiguration configuration) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var application = await AbpApplicationFactory.CreateAsync<BaseDbMigratorModule>(o =>
        {
            _ = o.Services.ReplaceConfiguration(configuration);
            o.UseAutofac();
            _ = o.Services.AddLogging(c => c.AddSerilog());
            o.AddDataMigrationEnvironment();
        });

        await application.InitializeAsync();
        await application.ServiceProvider.GetRequiredService<BaseDbMigrationService>().MigrateAsync();
        await application.ShutdownAsync();

        hostApplicationLifetime.StopApplication();
    }

    public Task StopAsync(CancellationToken cancellationToken) => CompletedTask;
}
