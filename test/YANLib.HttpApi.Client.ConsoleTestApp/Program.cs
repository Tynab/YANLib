using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using static Microsoft.Extensions.Hosting.Host;

namespace YANLib.HttpApi.Client.ConsoleTestApp;

internal class Program
{
    private static async Task Main(string[] args) => await CreateHostBuilder(args).RunConsoleAsync();

    public static IHostBuilder CreateHostBuilder(string[] args) => CreateDefaultBuilder(args).AddAppSettingsSecretsJson().ConfigureServices(static (h, s) => s.AddHostedService<ConsoleTestAppHostedService>());
}
