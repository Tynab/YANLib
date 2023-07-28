using System;

namespace YANLib.DTOs;

public sealed class DeveloperTypeRedis
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}
