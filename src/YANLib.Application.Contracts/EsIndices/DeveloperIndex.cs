using Nest;
using System;
using System.Collections.Generic;
using YANLib.Responses;

namespace YANLib.EsIndices;

public sealed class DeveloperIndex
{
    public string Id { get; set; }

    [Keyword]
    public string DeveloperId { get; set; }

    public string Name { get; set; }

    [Keyword]
    public string Phone { get; set; }

    public string IdCard { get; set; }

    public int Version { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [Nested]
    public DeveloperTypeResponse DeveloperType { get; set; }

    [Nested]
    public List<CertificateResponse> Certificates { get; set; }
}
