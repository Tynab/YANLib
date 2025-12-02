using Volo.Abp.DependencyInjection;
using static System.Threading.Tasks.Task;

namespace YANLib.Data;

public class NullBaseDbSchemaMigrator : IBaseDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync() => CompletedTask;
}
