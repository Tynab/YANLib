namespace YANLib.Requests.v1.Update;

public sealed class DeveloperTypeUpdateRequest : YANLibApplicationUpdateRequest
{
    public required long Code { get; set; }

    public required string Name { get; set; }
}
