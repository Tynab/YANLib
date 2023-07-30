using System.ComponentModel.DataAnnotations;

namespace YANLib.Requests;

public sealed class CertificateFullRequest : CertificateRipRequest
{
    public string Id { get; set; }
    [Required]
    public string DeveloperId { get; set; }
}
