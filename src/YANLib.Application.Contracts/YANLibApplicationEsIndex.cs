using Nest;
using System;

namespace YANLib;

public class YANLibApplicationEsIndex<TId>
{
    public required TId Id { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    [Keyword]
    public bool IsActive { get; set; }
}
