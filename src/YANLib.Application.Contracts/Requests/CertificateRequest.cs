using System;
using System.ComponentModel.DataAnnotations;

namespace YANLib.Requests;

public class CertificateRequest : CertificateRipRequest
{
    [Required]
    public Guid DeveloperId { get; set; }
}
