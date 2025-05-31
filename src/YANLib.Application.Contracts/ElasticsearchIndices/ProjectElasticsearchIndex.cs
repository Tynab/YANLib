using Nest;
using System.Collections.Generic;

namespace YANLib.ElasticsearchIndices;

public sealed class ProjectElasticsearchIndex : YANLibApplicationEsIndex<string>
{
    [Keyword]
    public string? Name { get; set; }

    public string? Description { get; set; }

    [Nested]
    public List<DeveloperElasticsearchIndex>? Developers { get; set; }
}
