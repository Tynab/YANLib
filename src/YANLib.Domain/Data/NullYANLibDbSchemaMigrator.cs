using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using static System.Threading.Tasks.Task;

namespace YANLib.Data;

public class NullYANLibDbSchemaMigrator : IYANLibDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync() => CompletedTask;
}
