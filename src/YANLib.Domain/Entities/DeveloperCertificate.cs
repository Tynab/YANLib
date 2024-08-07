using System;

namespace YANLib.Entities;

public sealed class DeveloperCertificate : YANLibDomainEntity
{
    public Guid DeveloperId { get; set; }

    public Guid CertificateId { get; set; }
}
