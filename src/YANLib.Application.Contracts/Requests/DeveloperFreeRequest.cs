using System.Collections.Generic;

namespace YANLib.Requests;

public sealed class DeveloperFreeRequest
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public int DeveloperTypeCode { get; set; }
    public List<CertificateRequest> Certificates { get; set; }
}
