using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using static System.Threading.Tasks.Task;

namespace YANLib;

public class YANLibTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    public Task SeedAsync(DataSeedContext context) => CompletedTask;
}
