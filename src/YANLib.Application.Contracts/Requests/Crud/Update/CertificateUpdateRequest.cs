using System;

namespace YANLib.Requests.Crud.Update;

public sealed class CertificateUpdateRequest : YANLibApplicationUpdateRequest
{
    public required string Code { get; set; }

    public required string Name { get; set; }

    public double? GPA { get; set; }

    public required Guid DeveloperId { get; set; }
}
