using System;

namespace YANLib.Entities;

public sealed class DeveloperCertificate : YANLibDomainEntity<Guid>
{
    public Guid DeveloperId { get; set; }

    public required string CertificateCode { get; set; }
}
