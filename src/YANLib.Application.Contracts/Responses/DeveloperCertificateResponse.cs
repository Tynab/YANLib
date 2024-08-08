namespace YANLib.Responses;

public sealed class DeveloperCertificateResponse : YANLibApplicationResponse
{
    public string? DeveloperIdCard { get; set; }

    public long CertificateCode { get; set; }
}
