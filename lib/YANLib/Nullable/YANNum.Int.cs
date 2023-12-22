using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANNum
{
    public static int? ToInt(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToInt32(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToInt();
        }
    }

    public static IEnumerable<int?>? ToInt(this IEnumerable<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToInt(dfltVal));

    public static IEnumerable<int?>? ToInt(this ICollection<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToInt(dfltVal));

    public static IEnumerable<int?>? ToInt(this object?[]? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToInt(dfltVal));
}
