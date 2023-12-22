using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANNum
{
    public static double? ToDouble(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToDouble(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToDouble();
        }
    }

    public static IEnumerable<double?>? ToDouble(this IEnumerable<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToDouble(dfltVal));

    public static IEnumerable<double?>? ToDouble(this ICollection<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToDouble(dfltVal));

    public static IEnumerable<double?>? ToDouble(this object?[]? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToDouble(dfltVal));
}
