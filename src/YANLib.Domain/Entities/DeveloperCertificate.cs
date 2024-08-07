using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace YANLib.Entities;

public sealed class DeveloperCertificate : YANLibDomainEntity
{
    public Guid DeveloperId { get; set; }

    public Guid CertificateId { get; set; }
}
