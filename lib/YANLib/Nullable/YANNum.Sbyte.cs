using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANNum
{
    public static sbyte? ToSbyte(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToSByte(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToSbyte();
        }
    }

    public static IEnumerable<sbyte?>? ToSbyte(this IEnumerable<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToSbyte(dfltVal));

    public static IEnumerable<sbyte?>? ToSbyte(this ICollection<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToSbyte(dfltVal));

    public static IEnumerable<sbyte?>? ToSbyte(this object?[]? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToSbyte(dfltVal));
}
