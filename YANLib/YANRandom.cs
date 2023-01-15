namespace YANLib;

public static class YANRandom
{
    /// <summary>
    /// Returns a non-negative random integer.
    /// </summary>
    /// <param name="rnd">Random.</param>
    /// <returns>A 32-bit signed integer.</returns>
    public static int NextInt32(this Random rnd) => rnd.Next(0, 1 << 4) << 28 | rnd.Next(0, 1 << 28);

    /// <summary>
    /// Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.
    /// </summary>
    /// <param name="rnd">Random.</param>
    /// <returns>A decimal-precision floating point number that is greater than or equal to 0.0, and less than 1.0.</returns>
    public static decimal NextDecimal(this Random rnd) => new(rnd.NextInt32(), rnd.NextInt32(), rnd.NextInt32(), rnd.Next(2) == 1, (byte)rnd.Next(29));

    /// <summary>
    /// Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.
    /// </summary>
    /// <param name="rnd">Random.</param>
    /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
    /// <param name="maxValue">The exclusive upper bound of the random number returned. <paramref name="maxValue"/> must be greater than or equal to <paramref name="minValue"/>.</param>
    /// <returns>A float-precision floating point number that is greater than or equal to <paramref name="minValue"/> and less than <paramref name="maxValue"/>; that is, the range of return values includes <paramref name="minValue"/> but not <paramref name="maxValue"/>. If minValue equals <paramref name="maxValue"/>, <paramref name="minValue"/> is returned.</returns>
    public static float NextSingle(this Random rnd, float minValue, float maxValue) => minValue < maxValue ? rnd.NextSingle() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : 0;

    /// <summary>
    /// Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.
    /// </summary>
    /// <param name="rnd">Random.</param>
    /// <param name="maxValue">The exclusive upper bound of the random number to be generated. <paramref name="maxValue"/> must be greater than or equal to 0.</param>
    /// <returns>A float-precision floating point number that is greater than or equal to 0, and less than <paramref name="maxValue"/>; that is, the range of return values ordinarily includes 0 but not <paramref name="maxValue"/>. However, if <paramref name="maxValue"/> equals 0, <paramref name="maxValue"/> is returned.</returns>
    public static float NextSingle(this Random rnd, float maxValue) => maxValue > 0 ? rnd.NextSingle(0, maxValue) : 0;

    /// <summary>
    /// Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.
    /// </summary>
    /// <param name="rnd">Random.</param>
    /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
    /// <param name="maxValue">The exclusive upper bound of the random number returned. <paramref name="maxValue"/> must be greater than or equal to <paramref name="minValue"/>.</param>
    /// <returns>A double-precision floating point number that is greater than or equal to <paramref name="minValue"/> and less than <paramref name="maxValue"/>; that is, the range of return values includes <paramref name="minValue"/> but not <paramref name="maxValue"/>. If minValue equals <paramref name="maxValue"/>, <paramref name="minValue"/> is returned.</returns>
    public static double NextDouble(this Random rnd, double minValue, double maxValue) => minValue < maxValue ? rnd.NextDouble() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : 0;

    /// <summary>
    /// Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.
    /// </summary>
    /// <param name="rnd">Random.</param>
    /// <param name="maxValue">The exclusive upper bound of the random number to be generated. <paramref name="maxValue"/> must be greater than or equal to 0.</param>
    /// <returns>A double-precision floating point number that is greater than or equal to 0, and less than <paramref name="maxValue"/>; that is, the range of return values ordinarily includes 0 but not <paramref name="maxValue"/>. However, if <paramref name="maxValue"/> equals 0, <paramref name="maxValue"/> is returned.</returns>
    public static double NextDouble(this Random rnd, double maxValue) => maxValue > 0 ? rnd.NextDouble(0, maxValue) : 0;

    /// <summary>
    /// Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.
    /// </summary>
    /// <param name="rnd">Random.</param>
    /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
    /// <param name="maxValue">The exclusive upper bound of the random number returned. <paramref name="maxValue"/> must be greater than or equal to <paramref name="minValue"/>.</param>
    /// <returns>A decimal-precision floating point number that is greater than or equal to <paramref name="minValue"/> and less than <paramref name="maxValue"/>; that is, the range of return values includes <paramref name="minValue"/> but not <paramref name="maxValue"/>. If minValue equals <paramref name="maxValue"/>, <paramref name="minValue"/> is returned.</returns>
    public static decimal NextDecimal(this Random rnd, decimal minValue, decimal maxValue) => minValue < maxValue ? rnd.NextDecimal() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : 0;

    /// <summary>
    /// Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.
    /// </summary>
    /// <param name="rnd">Random.</param>
    /// <param name="maxValue">The exclusive upper bound of the random number to be generated. <paramref name="maxValue"/> must be greater than or equal to 0.</param>
    /// <returns>A decimal-precision floating point number that is greater than or equal to 0, and less than <paramref name="maxValue"/>; that is, the range of return values ordinarily includes 0 but not <paramref name="maxValue"/>. However, if <paramref name="maxValue"/> equals 0, <paramref name="maxValue"/> is returned.</returns>
    public static decimal NextDecimal(this Random rnd, decimal maxValue) => maxValue > 0 ? rnd.NextDecimal(0, maxValue) : 0;
}
