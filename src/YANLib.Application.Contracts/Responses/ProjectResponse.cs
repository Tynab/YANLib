using System.Collections.Generic;

namespace YANLib.Responses;

public sealed class ProjectResponse : YANLibApplicationResponse<string>
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public List<DeveloperResponse>? Developers { get; set; }
}
