using System;

namespace YANLib.Dtos;

public class YANLibDomainDto
{
    public Guid Id { get; set; }

    public Guid UpdatedBy { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }
}
