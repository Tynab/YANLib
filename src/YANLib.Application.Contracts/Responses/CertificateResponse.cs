using System;

namespace YANLib.Responses;

public sealed class CertificateResponse : YANLibApplicationResponse<string>
{
    public string? Name { get; set; }

    public double? GPA { get; set; }
}
