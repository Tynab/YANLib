using System;

namespace YANLib.Requests.v1.Create;

public sealed class DeveloperCertificateCreateRequest : YANLibApplicationCreateRequest
{
    public required Guid DeveloperId { get; set; }

    public required string CertificateId { get; set; }
}
