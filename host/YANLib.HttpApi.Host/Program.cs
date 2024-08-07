using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Builder.WebApplication;
using static Serilog.Events.LogEventLevel;
using static System.StringComparison;

namespace YANLib;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
#if DEBUG
            .MinimumLevel.Debug()
#else
            .MinimumLevel.Information()
#endif
            .MinimumLevel.Override("Microsoft", Information)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", Warning)
            .Enrich.FromLogContext()
            .WriteTo.Async(c => c.Console())
            .CreateLogger();

        try
        {
            Log.Information("Starting YANLib.HttpApi.Host.");

            var builder = CreateBuilder(args);

            _ = builder.Host.AddAppSettingsSecretsJson().UseAutofac().UseSerilog((t, f) => f.Enrich.FromLogContext().ReadFrom.Configuration(t.Configuration));
            _ = await builder.AddApplicationAsync<YANLibHttpApiHostModule>();

            var app = builder.Build();

            await app.InitializeApplicationAsync();
            await app.RunAsync();

            return default;
        }
        catch (Exception ex) when (ex is not HostAbortedException && ex.Source is not "Microsoft.EntityFrameworkCore.Design")
        {
            if (ex.GetType().Name.Equals("StopTheHostException", Ordinal))
            {
                throw;
            }

            Log.Fatal(ex, "Host terminated unexpectedly!");

            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
