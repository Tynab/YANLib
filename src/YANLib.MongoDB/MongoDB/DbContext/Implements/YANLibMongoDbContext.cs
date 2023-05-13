using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.MongoDB;
using YANLib.MongoDB.DbContext;

namespace YANLib.MongoDB.DbContext.Implements;

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
