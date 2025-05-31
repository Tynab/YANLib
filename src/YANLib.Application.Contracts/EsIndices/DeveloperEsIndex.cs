using Nest;
using System.Collections.Generic;
using YANLib.Attributes;
using YANLib.Responses;

namespace YANLib.EsIndices;

[ElasticsearchIdField(nameof(IdCard))]
public sealed class DeveloperEsIndex : YANLibApplicationEsIndex<string>
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
