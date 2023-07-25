using System;

namespace YANLib.Responses;

public sealed record CertificateResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double? GPA { get; set; }
    public Guid DeveloperId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}
