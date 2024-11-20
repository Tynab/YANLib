using Id_Generator_Snowflake;
using static YANLib.YANLibConsts.SnowflakeId.DatacenterId;
using static YANLib.YANLibConsts.SnowflakeId.WorkerId;

namespace YANLib.Entities;

public sealed class DeveloperType : YANLibDomainEntity<long>
{
    public string? Name { get; set; }

    public DeveloperType()
    {
        IdGenerator idGenerator = new(DeveloperId, YanlibId);

        Id = idGenerator.NextId();
    }
}
