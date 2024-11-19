namespace YANLib.Requests.v2.Create;

public sealed class DeveloperCertificateCreateRequest : YANLibApplicationCreateRequest
{
    public required string DeveloperIdCard { get; set; }

    public required long CertificateCode { get; set; }
}
