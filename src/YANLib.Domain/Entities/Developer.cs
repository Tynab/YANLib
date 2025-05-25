using System;
using static System.Guid;

namespace YANLib.Entities;

public sealed class Developer : YANLibDomainEntity<Guid>
{
    public Developer() => Id = NewGuid();

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? IdCard { get; set; }

    public long DeveloperTypeCode { get; set; }

    public int RawVersion { get; set; } = 1;
}
