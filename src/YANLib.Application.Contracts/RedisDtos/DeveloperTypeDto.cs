using System;

namespace YANLib.RedisDtos;

public sealed class DeveloperTypeDto : YANLibApplicationRedisDto
{
    public string Name { get; set; }

    public Guid DeveloperTypeId { get; set; }
}
