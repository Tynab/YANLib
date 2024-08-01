using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace YANLib.Entities;

public sealed class Developer : YANLibDomainEntity
{
    public string Name { get; set; }

    public string Phone { get; set; }

    public string IdCard { get; set; }

    public Guid DeveloperTypeId { get; set; }

    public int Version { get; set; }

    [ForeignKey(nameof(DeveloperTypeId))]
    public DeveloperType DeveloperType { get; set; }
}
