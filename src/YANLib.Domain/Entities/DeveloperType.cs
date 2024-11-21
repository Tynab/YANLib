using Id_Generator_Snowflake;
using System.ComponentModel.DataAnnotations.Schema;
using static YANLib.YANLibConsts.SnowflakeId.DatacenterId;
using static YANLib.YANLibConsts.SnowflakeId.WorkerId;
using static System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;

namespace YANLib.Entities;

public sealed class DeveloperType : YANLibDomainEntity<long>
{
    [Column("Code")]
    [DatabaseGenerated(None)]
    public override long Id { get; protected set; }

    public string? Name { get; set; }

    public DeveloperType()
    {
        IdGenerator idGenerator = new(DeveloperId, YanlibId);

        Id = idGenerator.NextId();
    }
}
