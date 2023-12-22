using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANNum
{
    public static decimal? ToDecimal(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToDecimal(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToDecimal();
        }
    }

    public static IEnumerable<decimal?>? ToDecimals(this IEnumerable<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToDecimal(dfltVal));

    public static IEnumerable<decimal?>? ToDecimals(this ICollection<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToDecimal(dfltVal));

    public static IEnumerable<decimal?>? ToDecimals(this object?[]? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToDecimal(dfltVal));
}
