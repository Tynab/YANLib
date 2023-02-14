namespace YANLib;

public static partial class YANRandom
{
    /// <summary>
    /// Extension method that generates a random 32-bit signed integer using the <see cref="Random.Next(int, int)"/> method.
    /// </summary>
    /// <param name="rnd">The <see cref="Random"/> instance to use for generating the random number.</param>
    /// <returns>A random 32-bit signed integer.</returns>
    public static int NextInt32(this Random rnd) => rnd.Next(0, 1 << 4) << 28 | rnd.Next(0, 1 << 28);

    /// <summary>
    /// Generates a random decimal value.
    /// </summary>
    /// <param name="rnd"><see cref="Random"/> object to generate the decimal value.</param>
    /// <returns>A random decimal value.</returns>
    public static decimal NextDecimal(this Random rnd) => new(rnd.NextInt32(), rnd.NextInt32(), rnd.NextInt32(), rnd.Next(2) == 1, (byte)rnd.Next(29));

    /// <summary>
    /// Generates a random floating-point number within the specified range.
    /// </summary>
    /// <param name="rnd">The <see cref="Random"/> object to use as the source of randomness.</param>
    /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
    /// <param name="maxValue">The exclusive upper bound of the random number returned.</param>
    /// <returns>A random floating-point number that is greater than or equal to <paramref name="minValue"/>, and less than <paramref name="maxValue"/>.</returns>
    public static float NextSingle(this Random rnd, float minValue, float maxValue) => minValue < maxValue ? rnd.NextSingle() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : 0;

    /// <summary>
    /// Generates a random floating-point number less than the specified maximum value.
    /// </summary>
    /// <param name="rnd">The <see cref="Random"/> object to use as the source of randomness.</param>
    /// <param name="maxValue">The exclusive upper bound of the random number returned. Must be greater than 0.</param>
    /// <returns>A random floating-point number that is greater than or equal to 0, and less than <paramref name="maxValue"/>.</returns>
    public static float NextSingle(this Random rnd, float maxValue) => maxValue > 0 ? rnd.NextSingle(0, maxValue) : 0;

    /// <summary>
    /// Generates a random floating-point number within the specified range.
    /// </summary>
    /// <param name="rnd">The <see cref="Random"/> object to use as the source of randomness.</param>
    /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
    /// <param name="maxValue">The exclusive upper bound of the random number returned.</param>
    /// <returns>A random floating-point number that is greater than or equal to <paramref name="minValue"/>, and less than <paramref name="maxValue"/>.</returns>
    public static double NextDouble(this Random rnd, double minValue, double maxValue) => minValue < maxValue ? rnd.NextDouble() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : 0;

    /// <summary>
    /// Generates a random floating-point number less than the specified maximum value.
    /// </summary>
    /// <param name="rnd">The <see cref="Random"/> object to use as the source of randomness.</param>
    /// <param name="maxValue">The exclusive upper bound of the random number returned. Must be greater than 0.</param>
    /// <returns>A random floating-point number that is greater than or equal to 0, and less than <paramref name="maxValue"/>.</returns>
    public static double NextDouble(this Random rnd, double maxValue) => maxValue > 0 ? rnd.NextDouble(0, maxValue) : 0;

    /// <summary>
    /// Generates a random decimal number within the specified range.
    /// </summary>
    /// <param name="rnd">The <see cref="Random"/> object to use as the source of randomness.</param>
    /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
    /// <param name="maxValue">The exclusive upper bound of the random number returned.</param>
    /// <returns>A random decimal number that is greater than or equal to <paramref name="minValue"/>, and less than <paramref name="maxValue"/>.</returns>
    public static decimal NextDecimal(this Random rnd, decimal minValue, decimal maxValue) => minValue < maxValue ? rnd.NextDecimal() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : 0;

    /// <summary>
    /// Generates a random decimal number less than the specified maximum value.
    /// </summary>
    /// <param name="rnd">The <see cref="Random"/> object to use as the source of randomness.</param>
    /// <param name="maxValue">The exclusive upper bound of the random number returned. Must be greater than 0.</param>
    /// <returns>A random decimal number that is greater than or equal to 0, and less than <paramref name="maxValue"/>.</returns>
    public static decimal NextDecimal(this Random rnd, decimal maxValue) => maxValue > 0 ? rnd.NextDecimal(0, maxValue) : 0;
}
