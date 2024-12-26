using Id_Generator_Snowflake;
using static YANLib.YANLibConsts.SnowflakeId;
using static YANLib.YANLibConsts.SnowflakeId.DatacenterId;

namespace YANLib.Entities;

public sealed class Certificate : YANLibDomainEntity<string>
{
    public string? Name { get; set; }

    public double? GPA { get; set; }

    public string? Description { get; set; }

    public Certificate()
    {
        IdGenerator idGenerator = new(WorkerId.DeveloperId, YanlibId);

        Id = idGenerator.NextIdAlphabetic();
    }
}
