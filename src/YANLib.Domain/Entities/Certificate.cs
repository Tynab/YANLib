using Id_Generator_Snowflake;
using System.ComponentModel.DataAnnotations.Schema;
using static YANLib.YANLibConsts.SnowflakeId;
using static YANLib.YANLibConsts.SnowflakeId.DatacenterId;

namespace YANLib.Entities;

public sealed class Certificate : YANLibDomainEntity<string>
{
    [Column("Code")]
    public override string Id { get; protected set; }

    public string? Name { get; set; }

    public double? GPA { get; set; }

    public string? Description { get; set; }

    public Certificate()
    {
        IdGenerator idGenerator = new(WorkerId.DeveloperId, YanlibId);

        Id = idGenerator.NextIdAlphabetic();
    }
}
