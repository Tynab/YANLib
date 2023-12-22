using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANNum
{
    public static uint? ToUint(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToUInt32(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToUint();
        }
    }

    public static IEnumerable<uint?>? ToUint(this IEnumerable<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToUint(dfltVal));

    public static IEnumerable<uint?>? ToUint(this ICollection<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToUint(dfltVal));

    public static IEnumerable<uint?>? ToUint(this object?[]? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToUint(dfltVal));
}
