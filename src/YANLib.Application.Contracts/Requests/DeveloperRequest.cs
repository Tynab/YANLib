using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YANLib.Requests;

public sealed class DeveloperRequest
{
    [Required]
    public string Name { get; set; }
    public string Phone { get; set; }
    [Required]
    public string IdCard { get; set; }
    [Required]
    public int DeveloperTypeCode { get; set; }
    public List<CertificateRipRequest> Certificates { get; set; }
}
