using YANLib;
using YANLib.Enums;

namespace YANLib.Responses;

public sealed class SampleResponse : BaseResponse
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public SampleType? Type { get; set; }
}
