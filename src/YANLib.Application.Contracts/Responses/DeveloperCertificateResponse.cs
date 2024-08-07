using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YANLib.Responses;

public sealed class DeveloperCertificateResponse : YANLibApplicationResponse
{
    public Guid DeveloperId { get; set; }

    public Guid CertificateId { get; set; }
}
