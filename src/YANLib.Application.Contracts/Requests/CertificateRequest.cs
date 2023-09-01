using System.ComponentModel.DataAnnotations;

namespace YANLib.Requests;

public sealed class CertificateRequest
{
    public string Id { get; set; }
    [Required]
    public string Name { get; set; }
    public double? GPA { get; set; }
    [Required]
    public string DeveloperId { get; set; }
}
