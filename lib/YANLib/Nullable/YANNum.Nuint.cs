using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANNum
{
    public static nuint? ToNuint(this object? val, object? dfltVal = null)
    {
        try
        {
            return new UIntPtr(Convert.ToUInt64(val));
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToNuint();
        }
    }

    public static IEnumerable<nuint?>? ToNuint(this IEnumerable<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToNuint(dfltVal));

    public static IEnumerable<nuint?>? ToNuint(this ICollection<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToNuint(dfltVal));

    public static IEnumerable<nuint?>? ToNuint(this object?[]? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToNuint(dfltVal));
}
