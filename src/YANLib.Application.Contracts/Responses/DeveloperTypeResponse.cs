using System;

namespace YANLib.Responses;

public sealed record DeveloperTypeResponse
{
    public int Code { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
