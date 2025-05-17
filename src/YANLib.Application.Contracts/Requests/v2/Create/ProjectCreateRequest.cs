namespace YANLib.Requests.v2.Create;

public sealed class ProjectCreateRequest : YANLibApplicationCreateRequest
{
    public required string Name { get; set; }

    public string? Description { get; set; }
}
