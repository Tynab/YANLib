using System;
using static System.Guid;

namespace YANLib.Entities;

public sealed class DeveloperProject : YANLibDomainEntity<Guid>
{
    public DeveloperProject() => Id = NewGuid();

    public Guid DeveloperId { get; set; }

    public required string ProjectId { get; set; }
}
