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
    /// Returns a random <see cref="float"/> value between the specified minimum and maximum values.
    /// </summary>
    /// <param name="rnd">The <see cref="Random"/> object.</param>
    /// <param name="minValue">The minimum <see cref="float"/> value.</param>
    /// <param name="maxValue">The maximum <see cref="float"/> value.</param>
    /// <returns>A random <see cref="float"/> value between <paramref name="minValue"/> and <paramref name="maxValue"/>.</returns>
    public static float NextSingle(this Random rnd, float minValue, float maxValue) => minValue < maxValue ? rnd.NextSingle() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : 0;

    /// <summary>
    /// Returns a random <see cref="float"/> value between 0 and the specified maximum value.
    /// </summary>
    /// <param name="rnd">The <see cref="Random"/> object.</param>
    /// <param name="maxValue">The maximum <see cref="float"/> value.</param>
    /// <returns>A random <see cref="float"/> value between 0 and <paramref name="maxValue"/>.</returns>
    public static float NextSingle(this Random rnd, float maxValue) => maxValue > 0 ? rnd.NextSingle(0, maxValue) : 0;

    /// <summary>
    /// Returns a random <see cref="double"/> value between the specified minimum and maximum values.
    /// </summary>
    /// <param name="rnd">The <see cref="Random"/> object.</param>
    /// <param name="minValue">The minimum <see cref="double"/> value.</param>
    /// <param name="maxValue">The maximum <see cref="double"/> value.</param>
    /// <returns>A random <see cref="double"/> value between <paramref name="minValue"/> and <paramref name="maxValue"/>.</returns>
    public static double NextDouble(this Random rnd, double minValue, double maxValue) => minValue < maxValue ? rnd.NextDouble() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : 0;

    /// <summary>
    /// Returns a random <see cref="double"/> value between 0 and the specified maximum value.
    /// </summary>
    /// <param name="rnd">The <see cref="Random"/> object.</param>
    /// <param name="maxValue">The maximum <see cref="double"/> value.</param>
    /// <returns>A random <see cref="double"/> value between 0 and <paramref name="maxValue"/>.</returns>
    public static double NextDouble(this Random rnd, double maxValue) => maxValue > 0 ? rnd.NextDouble(0, maxValue) : 0;

    /// <summary>
    /// Returns a random <see cref="decimal"/> value between the specified minimum and maximum values.
    /// </summary>
    /// <param name="rnd">The <see cref="Random"/> object.</param>
    /// <param name="minValue">The minimum <see cref="decimal"/> value.</param>
    /// <param name="maxValue">The maximum <see cref="decimal"/> value.</param>
    /// <returns>A random <see cref="decimal"/> value between <paramref name="minValue"/> and <paramref name="maxValue"/>.</returns>
    public static decimal NextDecimal(this Random rnd, decimal minValue, decimal maxValue) => minValue < maxValue ? rnd.NextDecimal() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : 0;

    /// <summary>
    /// Returns a random <see cref="decimal"/> value less than the specified maximum value.
    /// </summary>
    /// <param name="rnd">The <see cref="Random"/> object.</param>
    /// <param name="maxValue">The maximum <see cref="decimal"/> value.</param>
    /// <returns>A random <see cref="decimal"/> value between 0 and <paramref name="maxValue"/>.</returns>
    public static decimal NextDecimal(this Random rnd, decimal maxValue) => maxValue > 0 ? rnd.NextDecimal(0, maxValue) : 0;
}
