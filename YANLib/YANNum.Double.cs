namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a double using the default format.
    /// Returns the parsed <see cref="double"/> value, or 0 if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="double"/> value, or 0 if the parsing fails.</returns>
    public static double ParseDouble(this string str)
    {
        _ = double.TryParse(str, out var num);
        return num;
    }

    /// <summary>
    /// Parses the string representation of a double using the default format.
    /// Returns the parsed <see cref="double"/> value, or the specified default value <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="double"/> value, or the specified default value <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static double ParseDouble(this string str, double dfltVal) => double.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Parses the string representation of a double using the default format.
    /// Returns the parsed <see cref="double"/> value, or <see cref="double.MinValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="double"/> value, or <see cref="double.MinValue"/> if the parsing fails.</returns>
    public static double ParseDoubleMin(this string str) => double.TryParse(str, out var num) ? num : double.MinValue;

    /// <summary>
    /// Parses the string representation of a double using the default format.
    /// Returns the parsed <see cref="double"/> value, or <see cref="double.MaxValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="double"/> value, or <see cref="double.MaxValue"/> if the parsing fails.</returns>
    public static double ParseDoubleMax(this string str) => double.TryParse(str, out var num) ? num : double.MaxValue;

    /// <summary>
    /// Generate random double number.
    /// </summary>
    /// <returns>Double random number.</returns>
    public static double RandomNumberDouble() => new Random().NextDouble();

    /// <summary>
    /// Generate random double number with max value.
    /// </summary>
    /// <param name="max">The exclusive upper bound of the random number to be generated.
    /// <paramref name="max"/> must be greater than or equal to 0.
    /// If not, the inclusive lower bound of the random number flexible to <see cref="double.MinValue"/>.</param>
    /// <returns>Double random number.</returns>
    public static double RandomNumberDouble(double max)
    {
        var rnd = new Random();
        return max < 0 ? rnd.NextDouble(double.MinValue, max) : rnd.NextDouble(0, max);
    }

    /// <summary>
    /// Generate random double number with min and max value.
    /// </summary>
    /// <param name="min">The inclusive lower bound of the random number returned.</param>
    /// <param name="max">The exclusive upper bound of the random number returned.
    /// <paramref name="max"/> must be greater than or equal to <paramref name="min"/>.
    /// If not, return 0.</param>
    /// <returns>Double random number.</returns>
    public static double RandomNumberDouble(double min, double max) => min > max ? 0 : new Random().NextDouble(min, max);
}
