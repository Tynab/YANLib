using System;

namespace YANLib.Requests.Insert;

public sealed class CertificateInsertRequest : YANLibApplicationInsertRequest
{
    public required string Name { get; set; }

    public double? GPA { get; set; }

    public required Guid DeveloperId { get; set; }
}
