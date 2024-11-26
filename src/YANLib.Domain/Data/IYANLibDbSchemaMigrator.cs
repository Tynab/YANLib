using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YANLib.Data;

public interface IYANLibDbSchemaMigrator
{
    public ValueTask MigrateAsync();
}
