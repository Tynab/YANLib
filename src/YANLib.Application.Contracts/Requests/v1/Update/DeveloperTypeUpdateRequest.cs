namespace YANLib.Requests.v1.Update;

public sealed class DeveloperTypeUpdateRequest : YANLibApplicationUpdateRequest
{
    public required string Name { get; set; }
}
