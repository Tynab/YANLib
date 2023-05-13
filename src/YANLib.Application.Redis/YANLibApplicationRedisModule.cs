using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace YANLib.Application.Redis;

[DependsOn(
    typeof(YANLibApplicationContractsModule)
    )]
public class YANLibApplicationRedisModule: AbpModule
{
}
