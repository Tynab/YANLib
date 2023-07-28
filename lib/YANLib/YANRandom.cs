namespace YANLib;

public static partial class YANRandom
{

    public static int NextInt32(this Random rnd) => rnd.Next(0, 1 << 4) << 28 | rnd.Next(0, 1 << 28);

    public static decimal NextDecimal(this Random rnd) => new(rnd.NextInt32(), rnd.NextInt32(), rnd.NextInt32(), rnd.Next(2) is 1, (byte)rnd.Next(29));

    public static float NextSingle<T1, T2>(this Random rnd, T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToFloat();
        var maxValue = max.ToFloat();

        return minValue < maxValue ? rnd.NextSingle() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : default;
    }

    public static double NextDouble<T1, T2>(this Random rnd, T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToDouble();
        var maxValue = max.ToDouble();

        return minValue < maxValue ? rnd.NextDouble() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : default;
    }

    public static decimal NextDecimal<T1, T2>(this Random rnd, T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToDecimal();
        var maxValue = max.ToDecimal();

        return minValue < maxValue ? rnd.NextDecimal() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : default;
    }
}
