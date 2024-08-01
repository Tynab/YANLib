using System;
using Volo.Abp.Domain.Entities;

namespace YANLib.Entities;

public class YANLibDomainEntity : Entity<Guid>
{
    public Guid CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }
}
