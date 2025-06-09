using System;

namespace YANLib;

public class YANLibApplicationResponse<TKey> where TKey : notnull, IEquatable<TKey>
{
    public required TKey Id { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }
}
