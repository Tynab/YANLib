using System;

namespace YANLib.Entities;

public sealed class Certificate : YANLibDomainEntity
{
    public string Code { get; set; }

    public string Name { get; set; }

    public double? GPA { get; set; }

    public Guid DeveloperId { get; set; }
}
