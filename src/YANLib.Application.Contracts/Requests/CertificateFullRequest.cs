using System;
using System.ComponentModel.DataAnnotations;

namespace YANLib.Requests;

public sealed class CertificateFullRequest : CertificateRequest
{
    [Required]
    public Guid Id { get; set; }
}
