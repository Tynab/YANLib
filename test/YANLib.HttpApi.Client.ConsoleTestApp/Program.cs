using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp;
using YANLib.HttpApi.Client.ConsoleTestApp;

using var application = await AbpApplicationFactory.CreateAsync<YANLibConsoleApiClientModule>(static o =>
{
    var builder = new ConfigurationBuilder();

    _ = builder.AddJsonFile("appsettings.json", false);
    _ = builder.AddJsonFile("appsettings.Development.json", true);
    _ = o.Services.ReplaceConfiguration(builder.Build());
    o.UseAutofac();
});

await application.InitializeAsync();

//var demo = application.ServiceProvider.GetRequiredService<ClientDemoService>();
//await demo.RunAsync();

Console.WriteLine("Press ENTER to stop application...");
Console.ReadLine();

await application.ShutdownAsync();
