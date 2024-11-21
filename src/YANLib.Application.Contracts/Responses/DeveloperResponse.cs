using System;
using System.Collections.Generic;

namespace YANLib.Responses;

public sealed class DeveloperResponse : YANLibApplicationResponse<Guid>
{
    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? IdCard { get; set; }

    public DeveloperTypeResponse? DeveloperType { get; set; }

    public List<CertificateResponse?>? Certificates { get; set; }
}
