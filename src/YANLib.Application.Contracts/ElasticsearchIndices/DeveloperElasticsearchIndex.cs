using Nest;
using System.Collections.Generic;
using YANLib.Responses;

namespace YANLib.ElasticsearchIndices;

public sealed class DeveloperElasticsearchIndex : YANLibApplicationEsIndex<DocumentPath<DeveloperElasticsearchIndex>>
{
    public string? Name { get; set; }

    [Keyword]
    public string? Phone { get; set; }

    [Keyword]
    public string? IdCard { get; set; }

    [Nested]
    public DeveloperTypeResponse? DeveloperType { get; set; }

    [Nested]
    public List<ProjectResponse>? Projects { get; set; }
}
