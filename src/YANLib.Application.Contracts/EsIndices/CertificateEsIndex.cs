using Nest;
using System;

namespace YANLib.EsIndices;

public sealed class CertificateEsIndex : YANLibApplicationEsIndex
{
    [Keyword]
    public string? Name { get; set; }

    public double? GPA { get; set; }

    [Text]
    public string? Description { get; set; }
}
