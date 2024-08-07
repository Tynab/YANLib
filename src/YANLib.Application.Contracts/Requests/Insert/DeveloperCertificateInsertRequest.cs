namespace YANLib.Requests.Insert;

public sealed class DeveloperCertificateInsertRequest : YANLibApplicationInsertRequest
{
    public required string DeveloperIdCard { get; set; }

    public required long CertificateCode { get; set; }
}
