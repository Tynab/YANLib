using System;

namespace YANLib.RedisDtos;

public sealed class DeveloperTypeRedisDto
{
    public string Name { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }
}
