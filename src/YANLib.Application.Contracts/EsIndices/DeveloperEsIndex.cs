using Nest;
using System.Collections.Generic;
using YANLib.Responses;

namespace YANLib.EsIndices;

public sealed class DeveloperEsIndex : YANLibApplicationEsIndex<DocumentPath<DeveloperEsIndex>>
{
    public string? Name { get; set; }

    [Keyword]
    public string? Phone { get; set; }

    [Keyword]
    public string? DeveloperIdCard { get; set; }

    [Nested]
    public DeveloperTypeResponse? DeveloperType { get; set; }

    [Nested]
    public List<CertificateResponse>? Certificates { get; set; }
}
