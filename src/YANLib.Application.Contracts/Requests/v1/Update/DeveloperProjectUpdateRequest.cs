using System;

namespace YANLib.Requests.v1.Update;

public sealed class DeveloperProjectUpdateRequest : YANLibApplicationUpdateRequest
{
    public required Guid DeveloperId { get; set; }

    public required string ProjectId { get; set; }
}
