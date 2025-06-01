using YANLib.Attributes;

namespace YANLib.ListQueries.v2;

public sealed class SearchTextListQuery : YANLibApplicationListQuery
{
    [RequiredAttributeWithPropertyName]
    public string? SearchText { get; set; }
}
