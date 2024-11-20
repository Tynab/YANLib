using System;

namespace YANLib.Dtos;

public class DeveloperCertificateDto : YANLibDomainDto<Guid>
{
    public Guid DeveloperId { get; set; }

    public string? CertificateId { get; set; }
}
