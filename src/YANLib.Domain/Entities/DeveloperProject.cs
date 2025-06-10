using System;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Guid;
using static YANLib.YANLibConsts.DbSchema;

namespace YANLib.Entities;

[Table(nameof(DeveloperProject), Schema = Sample)]
public sealed class DeveloperProject : YANLibDomainEntity<Guid>
{
    public DeveloperProject() => Id = NewGuid();

    public Guid DeveloperId { get; set; }

    public required string ProjectId { get; set; }
}
