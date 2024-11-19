namespace YANLib.Requests.v1.Create;

public sealed class DeveloperTypeCreateRequest : YANLibApplicationCreateRequest
{
    public required long Code { get; set; }

    public required string Name { get; set; }
}
