using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANNum
{
    public static ushort? ToUshort(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToUInt16(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToUshort();
        }
    }

    public static IEnumerable<ushort?>? ToUshort(this IEnumerable<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToUshort(dfltVal));

    public static IEnumerable<ushort?>? ToUshort(this ICollection<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToUshort(dfltVal));

    public static IEnumerable<ushort?>? ToUshort(this object?[]? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToUshort(dfltVal));
}
