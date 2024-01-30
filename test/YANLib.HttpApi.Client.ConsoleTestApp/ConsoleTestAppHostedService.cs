using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using static System.Threading.Tasks.Task;
using static Volo.Abp.AbpApplicationFactory;

namespace YANLib.HttpApi.Client.ConsoleTestApp;

public class ConsoleTestAppHostedService : IHostedService
{
    private readonly IConfiguration _configuration;

    public ConsoleTestAppHostedService(IConfiguration configuration) => _configuration = configuration;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var application = await CreateAsync<YANLibConsoleApiClientModule>(o =>
        {
            _ = o.Services.ReplaceConfiguration(_configuration);
            o.UseAutofac();
        });

        await application.InitializeAsync();

        var demo = application.ServiceProvider.GetRequiredService<ClientDemoService>();

        await demo.RunAsync();
        await application.ShutdownAsync();
    }

    public Task StopAsync(CancellationToken cancellationToken) => CompletedTask;
}
