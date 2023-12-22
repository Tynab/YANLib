using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANNum
{
    public static sbyte ToSbyte(this object? val, object? dfltVal = null)
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

    public static IEnumerable<sbyte>? ToSbytes(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToSbyte(dfltVal));

    public static IEnumerable<sbyte>? ToSbytes(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToSbyte(dfltVal));

    public static IEnumerable<sbyte>? ToSbytes(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToSbyte(dfltVal));

    public static sbyte GenerateRandomSbyte(object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? sbyte.MinValue : min.ToSbyte();
        var maxValue = max.IsNull() ? sbyte.MaxValue : max.ToSbyte();

        return minValue > maxValue ? default : new Random().Next(minValue, maxValue).ToSbyte();
    }

    public static IEnumerable<sbyte> GenerateRandomSbytes(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomSbyte(min, max));
}
