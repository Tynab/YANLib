using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YANLib.Requests.Certificate;

public sealed class CertificateUpdateRequest : YANLibUpdateRequest
{
    public required string Code { get; set; }

    public required string Name { get; set; }

    public double? GPA { get; set; }

    public required Guid DeveloperId { get; set; }
}
