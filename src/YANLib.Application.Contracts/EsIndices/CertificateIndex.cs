using System;

namespace YANLib.EsIndices;

public sealed class CertificateIndex : YANLibApplicationEsIndex
{
    public string Name { get; set; }

    public Guid CertificateId { get; set; }
}
