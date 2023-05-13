using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace YANLib.EntityFrameworkCore.DbContext;

[ConnectionStringName("Default")]
public interface IYANLibDbContext : IEfCoreDbContext
{
}
