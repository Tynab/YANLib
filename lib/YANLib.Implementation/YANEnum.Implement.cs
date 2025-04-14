using static System.Enum;

namespace YANLib.Implementation;

internal static partial class YANEnum
{
    internal static T? ParseEnum<T>(this string? input) where T : struct => input.IsNullWhiteSpace() ? default : TryParse<T>(input, out var result) ? result : default;

    internal static IEnumerable<T?>? ParseEnums<T>(this IEnumerable<string?>? input) where T : struct => input.IsNullEmpty() ? default : input.Select(x => x.ParseEnum<T>());

    internal static IEnumerable<T?>? ParseEnums<T>(params string?[]? input) where T : struct => input.IsNullEmpty() ? default : input.Select(x => x.ParseEnum<T>());
}
