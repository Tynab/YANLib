﻿#if RELEASE
using YANLib.Utilities;
#endif

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Threading.Tasks;
using YANLib.ServiceDefaults;
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
            .MinimumLevel.Override("Microsoft", Information).MinimumLevel.Override("Microsoft.EntityFrameworkCore", Warning).Enrich.FromLogContext().WriteTo.Async(static c => c.Console()).CreateLogger();

        try
        {
            Log.Information("Starting YANLib.HttpApi.Host.");

            var builder = CreateBuilder(args);

#if RELEASE
            await builder.Configuration.AddConfigFromAws(builder.Environment.EnvironmentName);
#endif
            _ = builder.Host.AddAppSettingsSecretsJson().UseAutofac().UseSerilog(static (t, f) => f.Enrich.FromLogContext().ReadFrom.Configuration(t.Configuration));
            _ = builder.AddServiceDefaults();
            _ = await builder.AddApplicationAsync<YANLibHttpApiHostModule>();

            var app = builder.Build();

            _ = app.MapDefaultEndpoints();
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
