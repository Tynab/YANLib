using static System.Linq.Enumerable;

namespace YANLib;

public static partial class YANNum
{

    public static byte ToByte(this object? num, object? dfltVal = null)
    {
        try
        {
            return Convert.ToByte(num);
        }
        catch
        {
            return dfltVal is null ? default : dfltVal.ToByte();
        }
    }

    public static IEnumerable<byte>? ToByte(this IEnumerable<object?> nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(n => n.ToByte(dfltVal));

    public static byte GenerateRandomByte(object? min = null, object? max = null)
    {
        var minValue = min is null ? byte.MinValue : min.ToByte();
        var maxValue = max is null ? byte.MaxValue : max.ToByte();

        return minValue > maxValue ? default : new Random().Next(minValue, maxValue).ToByte();
    }

    public static IEnumerable<byte> GenerateRandomBytes(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomByte(min, max));
}
