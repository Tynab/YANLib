using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YANLib.Entities;

[Table("DeveloperTypes")]
public sealed class DeveloperType
{
    [Key]
    public int Code { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}
