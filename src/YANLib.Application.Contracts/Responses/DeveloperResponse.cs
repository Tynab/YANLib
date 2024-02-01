using System;
using System.Collections.Generic;

namespace YANLib.Responses;

public sealed record DeveloperResponse
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Phone { get; set; }

    public string IdCard { get; set; }

    public bool IsActive { get; set; }

    public int Version { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DeveloperTypeResponse DeveloperType { get; set; }

    public List<CertificateResponse> Certificates { get; set; }
}
