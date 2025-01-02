using System;

namespace YANLib.Responses;

public sealed class DeveloperProjectResponse : YANLibApplicationResponse<Guid>
{
    public Guid DeveloperId { get; set; }

    public required string ProjectId { get; set; }
}
