using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANNum
{
    public static ulong? ToUlong(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToUInt64(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToUlong();
        }
    }

    public static IEnumerable<ulong?>? ToUlong(this IEnumerable<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToUlong(dfltVal));

    public static IEnumerable<ulong?>? ToUlong(this ICollection<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToUlong(dfltVal));

    public static IEnumerable<ulong?>? ToUlong(this object?[]? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToUlong(dfltVal));
}
