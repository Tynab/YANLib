using System;

namespace YANLib.Responses;

public sealed class CertificateResponse : YANLibResponse
{
    public string Code { get; set; }

    public string Name { get; set; }

    public double? GPA { get; set; }

    public Guid DeveloperId { get; set; }
}
