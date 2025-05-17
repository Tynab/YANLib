namespace YANLib.Requests.v1.Update;

public sealed class ProjectUpdateRequest : YANLibApplicationUpdateRequest
{
    public required string Name { get; set; }

    public string? Description { get; set; }
}
