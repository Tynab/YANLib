using System;
using System.ComponentModel;
using Volo.Abp.Domain.Entities;

namespace YANLib;

public class YANLibDomainEntity : Entity<Guid>
{
    public Guid CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    [DefaultValue(true)]
    public bool IsActive { get; set; } = true;

    [DefaultValue(false)]
    public bool IsDeleted { get; set; } = false;
}
