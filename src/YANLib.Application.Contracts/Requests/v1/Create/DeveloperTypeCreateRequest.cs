namespace YANLib.Requests.v1.Create;

public sealed class DeveloperTypeCreateRequest : YANLibApplicationCreateRequest
{
    public required string Name { get; set; }
}
