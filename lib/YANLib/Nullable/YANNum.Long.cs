using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANNum
{
    public static long? ToLong(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToInt64(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToLong();
        }
    }

    public static IEnumerable<long?>? ToLong(this IEnumerable<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToLong(dfltVal));

    public static IEnumerable<long?>? ToLong(this ICollection<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToLong(dfltVal));

    public static IEnumerable<long?>? ToLong(this object?[]? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToLong(dfltVal));
}
