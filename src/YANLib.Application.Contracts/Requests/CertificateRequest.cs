using System;
using System.ComponentModel.DataAnnotations;

namespace YANLib.Requests;

public class CertificateRequest
{
    [Required]
    public string Name { get; set; }
    public float? GPA { get; set; }
    [Required]
    public Guid DeveloperId { get; set; }
}
