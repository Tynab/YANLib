using System;

namespace YANLib.Requests.v2.Update;

public sealed class CertificateUpdateRequest : YANLibApplicationUpdateRequest
{
    public string? Name { get; set; }

    public double? GPA { get; set; }

    public Guid? DeveloperId { get; set; }
}
