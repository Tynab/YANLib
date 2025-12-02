using YANLib;
using YANLib.Enums;

namespace YANLib.Requests.CreateOrUpdateRequest;

public sealed class SampleCreateOrUpdateRequest : BaseCreateOrUpdateRequest
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public SampleType? Type { get; set; }
}
