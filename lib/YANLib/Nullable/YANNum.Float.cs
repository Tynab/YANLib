using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANNum
{
    public static float? ToFloat(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToSingle(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToFloat();
        }
    }

    public static IEnumerable<float?>? ToFloat<T>(this IEnumerable<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToFloat(dfltVal));

    public static IEnumerable<float?>? ToFloat<T>(this ICollection<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToFloat(dfltVal));

    public static IEnumerable<float?>? ToFloat<T>(this object?[]? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToFloat(dfltVal));
}
