namespace YANLib.Responses;

public sealed class ProjectResponse : YANLibApplicationResponse<string>
{
    public string? Name { get; set; }

    public double? GPA { get; set; }

    public string? Description { get; set; }
}
