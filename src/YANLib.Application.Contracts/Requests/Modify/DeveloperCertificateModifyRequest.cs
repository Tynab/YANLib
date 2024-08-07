namespace YANLib.Requests.Modify;

public sealed class DeveloperCertificateModifyRequest : YANLibApplicationModifyRequest
{
    public required string DeveloperIdCard { get; set; }

    public required long CertificateCode { get; set; }
}
