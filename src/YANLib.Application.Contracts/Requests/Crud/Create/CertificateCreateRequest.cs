using System;

namespace YANLib.Requests.Crud.Create;

public sealed class CertificateCreateRequest : YANLibApplicationCreateRequest
{
    public required string Code { get; set; }

    public required string Name { get; set; }

    public double? GPA { get; set; }

    public required Guid DeveloperId { get; set; }
}
