using Nest;
using YANLib;
using YANLib.Enums;

namespace YANLib.EsIndices;

public sealed class SampleEsIndex : BaseEsIndex<Guid>
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    [Keyword]
    public SampleType? Type { get; set; }
}
