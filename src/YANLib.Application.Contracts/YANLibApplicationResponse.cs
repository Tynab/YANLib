using System;
using Volo.Abp.Application.Dtos;

namespace YANLib;

public class YANLibApplicationResponse : AuditedEntityDto<Guid>
{
    public Guid CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }
}
