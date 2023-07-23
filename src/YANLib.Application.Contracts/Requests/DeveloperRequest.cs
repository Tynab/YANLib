using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YANLib.Requests;

public sealed class DeveloperRequest
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string IdCard { get; set; }
    [Required]
    public int DeveloperTypeCode { get; set; }
    public List<CertificateRequest> Certificates { get; set; }
}
