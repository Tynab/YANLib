using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Builder.WebApplication;
using static Serilog.Events.LogEventLevel;
using static System.DateTime;

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
            .MinimumLevel.Override("Microsoft", Information).MinimumLevel.Override("Microsoft.EntityFrameworkCore", Warning).Enrich.FromLogContext().WriteTo.Async(c => c.File($"Logs/{Now:yyyy-MM-dd}.log")).WriteTo.Async(c => c.Console()).CreateLogger();

        try
        {
            Log.Information("Starting YANLib.HttpApi.Host.");
            var builder = CreateBuilder(args);
            builder.Host.AddAppSettingsSecretsJson().UseAutofac().UseSerilog();
            await builder.AddApplicationAsync<YANLibHttpApiHostModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
