using System;

namespace YANLib.Requests.v2.Create;

public sealed class CertificateCreateRequest : YANLibApplicationCreateRequest
{
    public required string Name { get; set; }

    public double? GPA { get; set; }

    public string? Description { get; set; }
}
