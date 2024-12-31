using System;

namespace YANLib.Requests.v2.Create;

public sealed class DeveloperCertificateCreateRequest : YANLibApplicationCreateRequest
{
    public required Guid DeveloperId { get; set; }

    public required string CertificateCode { get; set; }
}
