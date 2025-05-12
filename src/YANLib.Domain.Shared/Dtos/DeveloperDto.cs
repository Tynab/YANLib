using System;

namespace YANLib.Dtos;

public sealed class DeveloperDto : YANLibDomainDto<Guid>
{
    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? IdCard { get; set; }

    public long? DeveloperTypeCode { get; set; }
}
