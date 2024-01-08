namespace YANLib;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration().MinimumLevel.Information().Enrich.FromLogContext().WriteTo.Async(c => c.Console()).CreateLogger();

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
