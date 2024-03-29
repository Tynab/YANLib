﻿using Microsoft.Extensions.DependencyInjection;
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
    public override void ConfigureServices(ServiceConfigurationContext context) => context.Services.AddMongoDbContext<YANLibMongoDbContext>(o => { });
}
