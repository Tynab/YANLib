using System.ComponentModel.DataAnnotations.Schema;
using YANLib.Snowflake;
using static System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;
using static YANLib.YANLibConsts.SnowflakeId.DatacenterId;
using static YANLib.YANLibConsts.SnowflakeId.WorkerId;

namespace YANLib.Entities;

public sealed class DeveloperType : YANLibDomainEntity<long>
{
    public DeveloperType()
    {
        IdGenerator idGenerator = new(DeveloperId, YanlibId);

        Id = idGenerator.NextId();
    }

    [Column("Code")]
    [DatabaseGenerated(None)]
    public override long Id { get; protected set; }

    public string? Name { get; set; }
}
