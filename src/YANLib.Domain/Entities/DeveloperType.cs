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
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}
