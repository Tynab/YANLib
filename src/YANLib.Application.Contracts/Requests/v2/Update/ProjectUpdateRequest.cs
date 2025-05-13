namespace YANLib.Requests.v2.Update;

public sealed class ProjectUpdateRequest : YANLibApplicationUpdateRequest
{
    public string? Name { get; set; }

    public string? Description { get; set; }
}
