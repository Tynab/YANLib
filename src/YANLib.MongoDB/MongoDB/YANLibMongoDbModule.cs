using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;
using YANLib.MongoDB.DbContext.Implements;

namespace YANLib.MongoDB;

[DependsOn(
    typeof(YANLibDomainModule),
    typeof(AbpMongoDbModule)
    )]
public class YANLibMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<YANLibMongoDbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, MongoQuestionRepository>();
             */
        });
    }
}
