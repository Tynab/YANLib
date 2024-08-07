using System;

namespace YANLib.Responses;

public sealed class DeveloperCertificateResponse : YANLibApplicationResponse
{
    public Guid DeveloperId { get; set; }

    public Guid CertificateId { get; set; }
}
