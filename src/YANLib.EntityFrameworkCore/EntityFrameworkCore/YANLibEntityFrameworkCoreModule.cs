﻿using YANLib.EntityFrameworkCore.DbContext.Implements;

namespace YANLib.EntityFrameworkCore;

[DependsOn(
    typeof(YANLibDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class YANLibEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        _ = context.Services.AddAbpDbContext<YANLibDbContext>(o => { });
        _ = context.Services.AddAbpDbContext<YANLibDbContext>(o => o.AddDefaultRepository<DeveloperType>());
    }
}
