namespace YANLib.Responses;

public sealed class DeveloperTypeResponse : YANLibApplicationResponse<long>
{
    public string? Name { get; set; }
}
