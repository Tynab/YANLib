using System;

namespace YANLib.Requests.Modify;

public sealed class CertificateModifyRequest : YANLibApplicationModifyRequest
{
    public string Name { get; set; }

    public double? GPA { get; set; }

    public Guid? DeveloperId { get; set; }
}
