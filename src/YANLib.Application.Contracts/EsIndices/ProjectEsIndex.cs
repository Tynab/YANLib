using Nest;

namespace YANLib.EsIndices;

public sealed class ProjectEsIndex : YANLibApplicationEsIndex<DocumentPath<ProjectEsIndex>>
{
    [Keyword]
    public string? Name { get; set; }

    public double? GPA { get; set; }

    public string? Description { get; set; }
}
