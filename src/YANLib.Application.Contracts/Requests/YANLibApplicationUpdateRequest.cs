using System;
using System.ComponentModel;

namespace YANLib.Requests;

public class YANLibApplicationUpdateRequest
{
    public Guid UpdatedBy { get; set; }

    [DefaultValue(true)]
    public bool? IsActive { get; set; }
}
