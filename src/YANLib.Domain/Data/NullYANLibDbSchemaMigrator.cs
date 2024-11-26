using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using static System.Threading.Tasks.ValueTask;

namespace YANLib.Data;

public class NullYANLibDbSchemaMigrator : IYANLibDbSchemaMigrator, ITransientDependency
{
    public ValueTask MigrateAsync() => CompletedTask;
}
