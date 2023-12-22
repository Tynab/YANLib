using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANNum
{

    public static byte ToByte(this object? val, object? dfltVal = null)
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

    public static IEnumerable<byte>? ToBytes(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToByte(dfltVal));

    public static IEnumerable<byte>? ToBytes(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToByte(dfltVal));

    public static IEnumerable<byte>? ToBytes(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToByte(dfltVal));

    public static byte GenerateRandomByte(object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? byte.MinValue : min.ToByte();
        var maxValue = max.IsNull() ? byte.MaxValue : max.ToByte();

        return minValue > maxValue ? default : new Random().Next(minValue, maxValue).ToByte();
    }

    public static IEnumerable<byte> GenerateRandomBytes(object? min = null, object? max = null, object? size = null) => Range(0, (int)size.ToUint()).Select(i => GenerateRandomByte(min, max));
}
