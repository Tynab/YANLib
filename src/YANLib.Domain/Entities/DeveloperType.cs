using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace YANLib.Entities;

[Table("DeveloperTypes")]
public sealed class DeveloperType : Entity<int>
{
    [Column("Code")]
    public override int Id { get; protected set; }

    public string Name { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }
}
