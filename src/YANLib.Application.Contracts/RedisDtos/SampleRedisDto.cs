using YANLib;
using YANLib.Enums;

namespace YANLib.RedisDtos;

public sealed class SampleRedisDto : BaseRedisDto
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public SampleType? Type { get; set; }
}
