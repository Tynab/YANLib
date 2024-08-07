using System;

namespace YANLib.Requests.Crud.Update;

public sealed class DeveloperCertificateUpdateRequest : YANLibApplicationUpdateRequest
{
    public required Guid DeveloperId { get; set; }

    public required Guid CertificateId { get; set; }
}
