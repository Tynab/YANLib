namespace YANLib;

public static partial class YANRandom
{
    /// <summary>
    /// Returns a random 32-bit signed integer value.
    /// </summary>
    /// <param name="rnd">The <see cref="Random"/> object.</param>
    /// <returns>A 32-bit signed integer value between 0 and 2,147,483,647 (inclusive).</returns>
    public static int NextInt32(this Random rnd) => rnd.Next(0, 1 << 4) << 28 | rnd.Next(0, 1 << 28);

    /// <summary>
    /// Returns the next random <see cref="decimal"/> value.
    /// </summary>
    /// <param name="rnd">The <see cref="Random"/> object.</param>
    /// <returns>A random <see cref="decimal"/> value.</returns>
    public static decimal NextDecimal(this Random rnd) => new(rnd.NextInt32(), rnd.NextInt32(), rnd.NextInt32(), rnd.Next(2) == 1, (byte)rnd.Next(29));

    /// <summary>
    /// Returns a random <see cref="float"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="rnd">The <see cref="Random"/> object.</param>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="float"/> value between <paramref name="minValue"/> and <paramref name="maxValue"/>.</returns>
    public static float NextSingle<T1, T2>(this Random rnd, T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToFloat();
        var maxValue = max.ToFloat();
        return minValue < maxValue ? rnd.NextSingle() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : default;
    }

    /// <summary>
    /// Returns a random <see cref="double"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="rnd">The <see cref="Random"/> object.</param>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="double"/> value between <paramref name="minValue"/> and <paramref name="maxValue"/>.</returns>
    public static double NextDouble<T1, T2>(this Random rnd, T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToDouble();
        var maxValue = max.ToDouble();
        return minValue < maxValue ? rnd.NextDouble() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : default;
    }

    /// <summary>
    /// Returns a random <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="rnd">The <see cref="Random"/> object.</param>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="decimal"/> value between <paramref name="minValue"/> and <paramref name="maxValue"/>.</returns>
    public static decimal NextDecimal<T1, T2>(this Random rnd, T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToDecimal();
        var maxValue = max.ToDecimal();
        return minValue < maxValue ? rnd.NextDecimal() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : default;
    }
}
