using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace YANLib.MongoDB.DbContext;

[ConnectionStringName("Default")]
public interface IYANLibMongoDbContext : IAbpMongoDbContext
{
}
