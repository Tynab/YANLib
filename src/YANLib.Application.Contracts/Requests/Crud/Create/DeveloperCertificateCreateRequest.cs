using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YANLib.Requests.Crud.Create;

public sealed class DeveloperCertificateCreateRequest : YANLibApplicationCreateRequest
{
    public required Guid DeveloperId { get; set; }

    public required Guid CertificateId { get; set; }
}
