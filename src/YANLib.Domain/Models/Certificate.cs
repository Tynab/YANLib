using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YANLib.Models;

[Table("Certificates")]
public sealed class Certificate
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double? GPA { get; set; }
    public Guid DeveloperId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}
