using System;

namespace YANLib.Entities;

public sealed class DeveloperCertificate : YANLibDomainEntity<Guid>
{
    public Guid DeveloperId { get; set; }

    public required string CertificateId { get; set; }
}
