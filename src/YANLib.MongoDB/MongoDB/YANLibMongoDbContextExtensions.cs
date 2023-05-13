using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.MongoDB;
using Volo.Abp;

namespace YANLib.MongoDB;

public static class YANLibMongoDbContextExtensions
{
    public static void ConfigureYANLib(this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
