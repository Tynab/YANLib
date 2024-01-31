namespace YANLib.Requests;

public sealed class CertificateRequest
{
    public required string Id { get; set; }

    public required string Name { get; set; }

    public double? GPA { get; set; }

    public required string DeveloperId { get; set; }
}
