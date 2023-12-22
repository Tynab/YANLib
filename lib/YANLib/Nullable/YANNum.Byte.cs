using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANNum
{
    public static byte? ToByte(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToByte(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToByte();
        }
    }

    public static IEnumerable<byte?>? ToBytes(this IEnumerable<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToByte(dfltVal));

    public static IEnumerable<byte?>? ToBytes(this ICollection<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToByte(dfltVal));

    public static IEnumerable<byte?>? ToBytes(this object?[]? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToByte(dfltVal));
}
