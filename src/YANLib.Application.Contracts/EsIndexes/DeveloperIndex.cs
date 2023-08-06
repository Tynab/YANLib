using Nest;
using System;
using System.Collections.Generic;
using YANLib.Responses;

namespace YANLib.EsIndexes;

public sealed class DeveloperIndex
{
    public string Id { get; set; }
    [Keyword]
    public string DeveloperId { get; set; }
    public string Name { get; set; }
    [Keyword]
    public string Phone { get; set; }
    public string IdCard { get; set; }
    public bool IsActive { get; set; }
    public int Version { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    [Nested]
    public DeveloperTypeResponse DeveloperType { get; set; }
    [Nested]
    public List<CertificateResponse> Certificates { get; set; }
}
