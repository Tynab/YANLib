using Nest;

namespace YANLib.EsIndices;

public sealed class CertificateEsIndex : YANLibApplicationEsIndex<DocumentPath<CertificateEsIndex>>
{
    [Keyword]
    public string? Name { get; set; }

    public double? GPA { get; set; }

    public string? Description { get; set; }
}
