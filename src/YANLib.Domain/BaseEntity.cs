using System.ComponentModel;
using Volo.Abp.Domain.Entities;
using static System.DateTime;

namespace YANLib;

public class BaseEntity : Entity<Guid>
{
    public Guid CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; } = UtcNow;

    public Guid UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; } = UtcNow;

    [DefaultValue(true)]
    public bool IsActive { get; set; } = true;

    [DefaultValue(false)]
    public bool IsDeleted { get; set; } = false;
}
