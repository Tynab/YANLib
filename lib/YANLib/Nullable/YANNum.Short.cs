using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANNum
{
    public static short? ToShort(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToInt16(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToShort();
        }
    }

    public static IEnumerable<short?>? ToShort(this IEnumerable<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToShort(dfltVal));

    public static IEnumerable<short?>? ToShort(this ICollection<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToShort(dfltVal));

    public static IEnumerable<short?>? ToShort(this object?[]? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToShort(dfltVal));
}
