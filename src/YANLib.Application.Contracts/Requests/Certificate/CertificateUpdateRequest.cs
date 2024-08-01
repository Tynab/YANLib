using System;

namespace YANLib.Requests.Certificate;

public sealed class CertificateUpdateRequest : YANLibApplicationUpdateRequest
{
    public required string Code { get; set; }

    public string Name { get; set; }

    public double? GPA { get; set; }

    public required Guid DeveloperId { get; set; }
}
