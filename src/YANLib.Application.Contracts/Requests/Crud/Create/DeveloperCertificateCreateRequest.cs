using System;

namespace YANLib.Requests.Crud.Create;

public sealed class DeveloperCertificateCreateRequest : YANLibApplicationCreateRequest
{
    public required Guid DeveloperId { get; set; }

    public required Guid CertificateId { get; set; }
}
