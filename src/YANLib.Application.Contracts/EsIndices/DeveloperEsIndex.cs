using Nest;
using System;
using System.Collections.Generic;
using YANLib.Responses;

namespace YANLib.EsIndices;

public sealed class DeveloperEsIndex : YANLibApplicationEsIndex
{
    public string Name { get; set; }

    [Keyword]
    public string Phone { get; set; }

    public Guid DeveloperId { get; set; }

    [Nested]
    public DeveloperTypeResponse DeveloperType { get; set; }

    [Nested]
    public List<CertificateResponse> Certificates { get; set; }
}
