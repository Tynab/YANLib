using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YANLib.Requests.Crud.Update;

public sealed class DeveloperCertificateUpdateRequest : YANLibApplicationUpdateRequest
{
    public required Guid DeveloperId { get; set; }

    public required Guid CertificateId { get; set; }
}
