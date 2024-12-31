using System;

namespace YANLib.Responses;

public sealed class DeveloperCertificateResponse : YANLibApplicationResponse<Guid>
{
    public Guid DeveloperId { get; set; }

    public required string CertificateCode { get; set; }
}
