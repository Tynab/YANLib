using System.ComponentModel.DataAnnotations.Schema;
using YANLib.Snowflake;
using static YANLib.YANLibConsts.DbSchema;
using static YANLib.YANLibConsts.SnowflakeId;
using static YANLib.YANLibConsts.SnowflakeId.DatacenterId;

namespace YANLib.Entities;

[Table(nameof(Project), Schema = Sample)]
public sealed class Project : YANLibDomainEntity<string>
{
    public Project()
    {
        IdGenerator idGenerator = new(WorkerId.DeveloperId, YanlibId);

        Id = idGenerator.NextIdAlphabetic();
    }

    public string? Name { get; set; }

    public string? Description { get; set; }
}
