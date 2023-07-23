using System;

namespace YANLib.Responses;

public sealed record DeveloperTypeResponse
{
    public int Code { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}
