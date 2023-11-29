using static System.Enum;

namespace YANLib;

public static partial class YANEnum
{
    public static T? ToEnum<T>(this string value) where T : struct => value.IsWhiteSpaceOrNull() ? default : TryParse<T>(value, out var result) ? result : default;

    public static IEnumerable<T?>? ToEnum<T>(this IEnumerable<string> values) where T : struct => values.IsEmptyOrNull() ? default : values.Select(s => s.ToEnum<T>());
}
