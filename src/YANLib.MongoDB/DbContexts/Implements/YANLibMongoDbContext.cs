using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace YANLib.MongoDB.DbContexts.Implements;

[ConnectionStringName("Default")]
public class YANLibMongoDbContext : AbpMongoDbContext, IYANLibMongoDbContext
{
    /* Add mongo collections here. Example:
    * public IMongoCollection<Question> Questions => Collection<Question>();
    */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);
        modelBuilder.ConfigureYANLib();
    }
}
