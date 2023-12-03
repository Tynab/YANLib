using static System.Linq.Enumerable;

namespace YANLib;

public static partial class YANNum
{
    public static sbyte ToSbyte(this object? num, object? dfltVal = null)
    {
        try
        {
            return Convert.ToSByte(num);
        }
        catch
        {
            return dfltVal is null ? default : dfltVal.ToSbyte();
        }
    }

    public static IEnumerable<sbyte>? ToSbyte(this IEnumerable<object?> nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(n => n.ToSbyte(dfltVal));

    public static sbyte GenerateRandomSbyte(object? min = null, object? max = null)
    {
        var minValue = min is null ? sbyte.MinValue : min.ToSbyte();
        var maxValue = max is null ? sbyte.MaxValue : max.ToSbyte();

        return minValue > maxValue ? default : new Random().Next(minValue, maxValue).ToSbyte();
    }

    public static IEnumerable<sbyte> GenerateRandomSbytes(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomSbyte(min, max));
}
