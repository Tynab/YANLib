using System.ComponentModel.DataAnnotations;

namespace YANLib.Requests;

public sealed class CertificateRipRequest
{
    [Required]
    public string Name { get; set; }
    public double? GPA { get; set; }
}
