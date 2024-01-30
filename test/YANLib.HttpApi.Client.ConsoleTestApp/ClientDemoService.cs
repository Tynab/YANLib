using System.Threading.Tasks;
using Volo.Abp.Account;
using Volo.Abp.DependencyInjection;
using static System.Console;

namespace YANLib.HttpApi.Client.ConsoleTestApp;

public class ClientDemoService : ITransientDependency
{
    private readonly IProfileAppService _profileAppService;

    public ClientDemoService(IProfileAppService profileAppService) => _profileAppService = profileAppService;

    public async Task RunAsync()
    {
        var output = await _profileAppService.GetAsync();

        WriteLine($"UserName : {output.UserName}");
        WriteLine($"Email    : {output.Email}");
        WriteLine($"Name     : {output.Name}");
        WriteLine($"Surname  : {output.Surname}");
    }
}
