using System;

namespace YANLib.Requests.v1.Update;

public sealed class CertificateUpdateRequest : YANLibApplicationUpdateRequest
{
    public required string Name { get; set; }

    public double? GPA { get; set; }

    public string? Description { get; set; }
}
