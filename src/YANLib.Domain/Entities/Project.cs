using YANLib.Snowflake;
using static YANLib.YANLibConsts.SnowflakeId;
using static YANLib.YANLibConsts.SnowflakeId.DatacenterId;

namespace YANLib.Entities;

public sealed class Project : YANLibDomainEntity<string>
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public Project()
    {
        IdGenerator idGenerator = new(WorkerId.DeveloperId, YanlibId);

        Id = idGenerator.NextIdAlphabetic();
    }
}
