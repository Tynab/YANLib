using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace YANLib.EntityFrameworkCore.DbContext;

[ConnectionStringName("Default")]
public interface IYANLibDbContext : IEfCoreDbContext
{
}
