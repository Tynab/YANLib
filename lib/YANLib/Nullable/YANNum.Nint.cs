using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANNum
{
    public static nint? ToNint(this object? val, object? dfltVal = null)
    {
        try
        {
            return new IntPtr(Convert.ToInt64(val));
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToNint();
        }
    }

    public static IEnumerable<nint?>? ToNint(this IEnumerable<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToNint(dfltVal));

    public static IEnumerable<nint?>? ToNint(this ICollection<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToNint(dfltVal));

    public static IEnumerable<nint?>? ToNint(this object?[]? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToNint(dfltVal));
}
