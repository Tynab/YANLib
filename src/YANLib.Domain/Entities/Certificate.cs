using Id_Generator_Snowflake;
using System;
using static YANLib.YANLibConsts.SnowflakeId;
using static YANLib.YANLibConsts.SnowflakeId.DatacenterId;

namespace YANLib.Entities;

public sealed class Certificate : YANLibDomainEntity
{
    public string? Code { get; set; }

    public string? Name { get; set; }

    public double? GPA { get; set; }

    public Guid DeveloperId { get; set; }

    public Certificate()
    {
        IdGenerator idGenerator = new(WorkerId.DeveloperId, YanlibId);

        Code = idGenerator.NextIdAlphabetic();
    }
}
