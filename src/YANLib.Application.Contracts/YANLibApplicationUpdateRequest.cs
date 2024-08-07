using System;
using System.ComponentModel;
using static System.DateTime;

namespace YANLib;

public class YANLibApplicationUpdateRequest
{
    public required Guid CreatedBy { get; set; }

    public required DateTime CreatedAt { get; set; }

    public required Guid UpdatedBy { get; set; }

    public required DateTime UpdatedAt { get; set; } = UtcNow;

    [DefaultValue(true)]
    public required bool IsActive { get; set; } = true;

    [DefaultValue(false)]
    public required bool IsDeleted { get; set; } = false;
}
