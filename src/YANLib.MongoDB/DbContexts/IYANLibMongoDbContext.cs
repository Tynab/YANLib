using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace YANLib.MongoDB.DbContexts;

[ConnectionStringName("Default")]
public interface IYANLibMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
    * IMongoCollection<Question> Questions { get; }
    */
}
