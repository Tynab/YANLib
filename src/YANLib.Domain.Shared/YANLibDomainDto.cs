using System;
using System.ComponentModel;

namespace YANLib;

public class YANLibDomainDto
{
    public Guid Id { get; set; }

    public Guid UpdatedBy { get; set; }

    [DefaultValue(true)]
    public bool? IsActive { get; set; } = true;

    [DefaultValue(false)]
    public bool? IsDeleted { get; set; } = false;
}
