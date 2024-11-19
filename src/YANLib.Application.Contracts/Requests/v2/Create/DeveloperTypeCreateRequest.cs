namespace YANLib.Requests.v2.Create;

public sealed class DeveloperTypeCreateRequest : YANLibApplicationCreateRequest
{
    public required string Name { get; set; }
}
