using System;

namespace YANLib.RedisDtos;

public sealed class DeveloperTypeRedisDto
{
    public string Name { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
