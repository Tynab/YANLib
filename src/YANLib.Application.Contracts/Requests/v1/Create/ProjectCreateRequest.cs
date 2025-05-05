namespace YANLib.Requests.v1.Create;

public sealed class ProjectCreateRequest : YANLibApplicationCreateRequest
{
    public required string Name { get; set; }

    public double? GPA { get; set; }

    public string? Description { get; set; }
}
