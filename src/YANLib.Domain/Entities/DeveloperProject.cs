using System;

namespace YANLib.Entities;

public sealed class DeveloperProject : YANLibDomainEntity<Guid>
{
    public Guid DeveloperId { get; set; }

    public required string ProjectId { get; set; }
}
