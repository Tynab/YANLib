using System;
using YANLib.Attributes;

namespace YANLib.ListQueries.v2;

public sealed class DeveloperProjectListQuery : YANLibApplicationListQuery
{
    [RequiredAttributeWithPropertyName]
    public Guid DeveloperId { get; set; }
}
