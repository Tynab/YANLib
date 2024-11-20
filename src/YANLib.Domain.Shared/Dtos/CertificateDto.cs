using System;

namespace YANLib.Dtos;

public sealed class CertificateDto : YANLibDomainDto<string>
{
    public string? Name { get; set; }

    public double? GPA { get; set; }
}
