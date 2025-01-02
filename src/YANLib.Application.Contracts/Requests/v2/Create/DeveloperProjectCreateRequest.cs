using System;

namespace YANLib.Requests.v2.Create;

public sealed class DeveloperProjectCreateRequest : YANLibApplicationCreateRequest
{
    public required Guid DeveloperId { get; set; }

    public required string ProjectId { get; set; }
}
