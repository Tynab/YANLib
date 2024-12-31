using System;

namespace YANLib.Requests.v1.Update;

public sealed class DeveloperCertificateUpdateRequest : YANLibApplicationUpdateRequest
{
    public required Guid DeveloperId { get; set; }

    public required string CertificateCode { get; set; }
}
