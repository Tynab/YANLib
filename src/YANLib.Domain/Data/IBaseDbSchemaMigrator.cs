namespace YANLib.Data;

public interface IBaseDbSchemaMigrator
{
    public Task MigrateAsync();
}
