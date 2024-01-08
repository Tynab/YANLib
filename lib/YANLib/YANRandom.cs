using YANLib.Core;

namespace YANLib;

public static partial class YANRandom
{

    public static int NextInt32(this Random rnd) => rnd.Next(0, 1 << 4) << 28 | rnd.Next(0, 1 << 28);

    public static decimal NextDecimal(this Random rnd) => new(rnd.NextInt32(), rnd.NextInt32(), rnd.NextInt32(), rnd.Next(2) is 1, (byte)rnd.Next(29));

    public static float NextSingle(this Random rnd, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? float.MinValue : min.ToFloat();
        var maxValue = max.IsNull() ? float.MaxValue : max.ToFloat();

        return minValue < maxValue ? rnd.NextSingle() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : default;
    }

    public static double NextDouble(this Random rnd, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? double.MinValue : min.ToDouble();
        var maxValue = max.IsNull() ? double.MaxValue : max.ToDouble();

        return minValue < maxValue ? rnd.NextDouble() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : default;
    }

    public static decimal NextDecimal(this Random rnd, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? decimal.MinValue : min.ToDecimal();
        var maxValue = max.IsNull() ? decimal.MaxValue : max.ToDecimal();

        return minValue < maxValue ? rnd.NextDecimal() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : default;
    }
}
