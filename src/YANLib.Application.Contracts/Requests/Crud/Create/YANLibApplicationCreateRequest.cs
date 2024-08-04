using System;
using System.ComponentModel;
using static System.DateTime;

namespace YANLib.Requests.Crud.Create;

public class YANLibApplicationCreateRequest
{
    public required Guid CreatedBy { get; set; }

    public required DateTime CreatedAt { get; set; } = UtcNow;

    [DefaultValue(true)]
    public required bool IsActive { get; set; } = true;

    [DefaultValue(false)]
    public required bool IsDeleted { get; set; } = false;
}
