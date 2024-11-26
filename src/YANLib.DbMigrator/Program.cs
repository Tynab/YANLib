using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using static Serilog.Events.LogEventLevel;
using static System.DateTime;
using static Microsoft.Extensions.Hosting.Host;

namespace YANLib.DbMigrator;

public class Program
{
    static async Task Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration().MinimumLevel.Information().MinimumLevel.Override("Microsoft", Warning).MinimumLevel.Override("Volo.Abp", Warning)
#if DEBUG
            .MinimumLevel.Override("YANLib", Debug)
#else
            .MinimumLevel.Override("YANLib", Information)
#endif
            .Enrich.FromLogContext().WriteTo.Async(c => c.File($"Logs/{Today:yyyy-MM-dd}.log")).WriteTo.Async(c => c.Console()).CreateLogger();

        await CreateHostBuilder(args).RunConsoleAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
        => CreateDefaultBuilder(args).AddAppSettingsSecretsJson().ConfigureLogging((c, l) => l.ClearProviders()).ConfigureServices((h, s) => s.AddHostedService<DbMigratorHostedService>());
}
