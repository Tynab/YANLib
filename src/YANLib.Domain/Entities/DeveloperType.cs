using Id_Generator_Snowflake;
using static YANLib.Constants.YANLibConsts.SnowflakeId.DatacenterId;
using static YANLib.Constants.YANLibConsts.SnowflakeId.WorkerId;

namespace YANLib.Entities;

public sealed class DeveloperType : YANLibDomainEntity
{
    public long Code { get; set; }

    public string Name { get; set; }

    public DeveloperType()
    {
        IdGenerator idGenerator = new(DeveloperId, YanlibId);

        Code = idGenerator.NextId();
    }
}
