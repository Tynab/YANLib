using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace YANLib.MongoDB.DbContext;

[ConnectionStringName("Default")]
public interface IYANLibMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
    * IMongoCollection<Question> Questions { get; }
    */
}
