using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Data;
using YANLib.Data;
using static System.Threading.Tasks.Task;

namespace YANLib.DbMigrator;

public class DbMigratorHostedService(IHostApplicationLifetime hostApplicationLifetime, IConfiguration configuration) : IHostedService
{
    private readonly IHostApplicationLifetime _hostApplicationLifetime = hostApplicationLifetime;
    private readonly IConfiguration _configuration = configuration;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var application = await AbpApplicationFactory.CreateAsync<YANLibDbMigratorModule>(o =>
        {
            _ = o.Services.ReplaceConfiguration(_configuration);
            o.UseAutofac();
            _ = o.Services.AddLogging(c => c.AddSerilog());
            o.AddDataMigrationEnvironment();
        });

        await application.InitializeAsync();
        await application.ServiceProvider.GetRequiredService<YANLibDbMigrationService>().MigrateAsync();
        await application.ShutdownAsync();
        _hostApplicationLifetime.StopApplication();
    }

    public Task StopAsync(CancellationToken cancellationToken) => CompletedTask;
}
