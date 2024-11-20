using Nest;
using System;

namespace YANLib.EsIndices;

public sealed class CertificateEsIndex : YANLibApplicationEsIndex
{
    public string? CertificateId { get; set; }

    [Keyword]
    public string? Name { get; set; }

    public double? GPA { get; set; }

    public Guid DeveloperId { get; set; }
}
