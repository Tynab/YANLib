using System;

namespace YANLib.Responses;

public sealed record CertificateResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public double? GPA { get; set; }
    public string DeveloperId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
