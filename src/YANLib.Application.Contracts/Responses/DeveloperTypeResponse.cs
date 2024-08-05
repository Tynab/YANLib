namespace YANLib.Responses;

public sealed class DeveloperTypeResponse : YANLibApplicationResponse
{
    public long Code { get; set; }

    public string? Name { get; set; }
}
