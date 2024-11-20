using System;

namespace YANLib.Responses;

public sealed class DeveloperCertificateResponse : YANLibApplicationResponse<Guid>
{
    public DeveloperResponse? Developer { get; set; }

    public CertificateResponse? Certificate { get; set; }
}
