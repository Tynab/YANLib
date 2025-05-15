using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;

namespace YANLib.HttpApi.Client.ConsoleTestApp;

public class ConsoleTestAppHostedService(IConfiguration configuration) : IHostedService
{
    private readonly IConfiguration _configuration = configuration;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var application = await AbpApplicationFactory.CreateAsync<YANLibConsoleApiClientModule>(o =>
        {
            _ = o.Services.ReplaceConfiguration(_configuration);
            o.UseAutofac();
        });

        await application.InitializeAsync();

        //var demo = application.ServiceProvider.GetRequiredService<ClientDemoService>();

        //await demo.RunAsync();
        await application.ShutdownAsync();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
