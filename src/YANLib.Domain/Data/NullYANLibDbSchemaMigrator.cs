using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace YANLib.Data;

/* This is used if database provider does't define
 * IYANLibDbSchemaMigrator implementation.
 */
public class NullYANLibDbSchemaMigrator : IYANLibDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
