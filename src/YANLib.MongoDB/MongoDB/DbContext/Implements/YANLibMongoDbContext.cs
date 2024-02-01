using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace YANLib.MongoDB.DbContext.Implements;

[ConnectionStringName("Default")]
public class YANLibMongoDbContext : AbpMongoDbContext, IYANLibMongoDbContext
{
    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);
        modelBuilder.ConfigureYANLib();
    }
}
