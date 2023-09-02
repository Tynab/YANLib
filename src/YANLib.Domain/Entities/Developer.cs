using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace YANLib.Entities;

[Table("Developers")]
public sealed class Developer : Entity<string>
{
    public Developer()
    {
    }

    public Developer(string id) => Id = id;

    public string Name { get; set; }
    public string Phone { get; set; }
    public string IdCard { get; set; }
    public int DeveloperTypeCode { get; set; }
    public bool IsActive { get; set; }
    public int Version { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}
