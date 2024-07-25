using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YANLib.Entities;

[Table("Certificates")]
public sealed class Certificate
{
    [Key]
    public string Id { get; set; }

    public string Name { get; set; }

    public double? GPA { get; set; }

    public string DeveloperId { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }
}
