using System.Threading.Tasks;

namespace YANLib.Data;

public interface IYANLibDbSchemaMigrator
{
    public Task MigrateAsync();
}
