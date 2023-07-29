using System.ComponentModel.DataAnnotations;

namespace YANLib.Requests;

public class CertificateRipRequest
{
    [Required]
    public string Name { get; set; }
    public double? GPA { get; set; }
}
