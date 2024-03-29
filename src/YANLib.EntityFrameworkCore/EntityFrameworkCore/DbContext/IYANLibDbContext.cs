﻿using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using YANLib.Entities;
using static YANLib.YANLibConsts.ConnectionStringName;

namespace YANLib.EntityFrameworkCore.DbContext;

[ConnectionStringName(Default)]
public interface IYANLibDbContext : IEfCoreDbContext
{
    public DbSet<Developer> Developers { get; }

    public DbSet<DeveloperType> DeveloperTypes { get; }

    public DbSet<Certificate> Certificates { get; }
}
