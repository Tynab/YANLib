using System;

namespace YANLib.EsIndices;

public sealed class CertificateEsIndex : YANLibApplicationEsIndex
{
    public Guid CertificateId { get; set; }

    public string? Name { get; set; }

    public double? GPA { get; set; }

    public Guid DeveloperId { get; set; }
}
