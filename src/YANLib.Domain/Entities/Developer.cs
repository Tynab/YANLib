using System;

namespace YANLib.Entities;

public sealed class Developer : YANLibDomainEntity<Guid>
{
    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? IdCard { get; set; }

    public long DeveloperTypeCode { get; set; }

    public int Version { get; set; }
}
