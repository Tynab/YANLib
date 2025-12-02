namespace YANLib.Options;

public sealed class JwtOption
{
    public string? Issuer { get; set; }

    public string? Audience { get; set; }

    public string? Secret { get; set; }
}
