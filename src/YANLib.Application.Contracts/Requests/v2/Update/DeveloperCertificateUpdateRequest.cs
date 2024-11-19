namespace YANLib.Requests.v2.Update;

public sealed class DeveloperCertificateUpdateRequest : YANLibApplicationUpdateRequest
{
    public required string DeveloperIdCard { get; set; }

    public required long CertificateCode { get; set; }
}
