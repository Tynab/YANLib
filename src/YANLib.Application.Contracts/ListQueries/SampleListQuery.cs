using YANLib;

namespace YANLib.ListQueries;

public sealed class SampleListQuery : BaseListQuery
{
    public DateTime? DateFrom { get; set; }

    public DateTime? DateTo { get; set; }

    public bool? IsActive { get; set; }
}
