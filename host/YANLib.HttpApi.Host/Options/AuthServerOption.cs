namespace YANLib.Options;

public sealed class AuthServerOption
{
    public string? Authority { get; set; }

    public bool RequireHttpsMetadata { get; set; } = true;

    public string? SwaggerClientId { get; set; }
}
