namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Try parse string to float, if failed return 0.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Float number.</returns>
    public static float ParseFloat(this string str)
    {
        _ = float.TryParse(str, out var num);
        return num;
    }

    /// <summary>
    /// Try parse string to float, if failed return default value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <param name="dfltVal">Default value.</param>
    /// <returns>Float number.</returns>
    public static float ParseFloat(this string str, float dfltVal) => float.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Try parse string to float, if failed return min value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Float number.</returns>
    public static float ParseFloatMin(this string str) => float.TryParse(str, out var num) ? num : float.MinValue;

    /// <summary>
    /// Try parse string to float, if failed return max value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Float number.</returns>
    public static float ParseFloatMax(this string str) => float.TryParse(str, out var num) ? num : float.MaxValue;

    /// <summary>
    /// Generate random float number.
    /// </summary>
    /// <returns>Float random number.</returns>
    public static float RandomNumberFloat() => new Random().NextSingle();

    /// <summary>
    /// Generate random float number with max value.
    /// </summary>
    /// <param name="max">The exclusive upper bound of the random number to be generated. <paramref name="max"/> must be greater than or equal to 0. If not, the inclusive lower bound of the random number flexible to <see cref="float.MinValue"/>.</param>
    /// <returns>Float random number.</returns>
    public static float RandomNumberFloat(float max)
    {
        var rnd = new Random();
        return max < 0 ? rnd.NextSingle(float.MinValue, max) : rnd.NextSingle(0, max);
    }

    /// <summary>
    /// Generate random float number with min and max value.
    /// </summary>
    /// <param name="min">The inclusive lower bound of the random number returned.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. <paramref name="max"/> must be greater than or equal to <paramref name="min"/>. If not, return 0.</param>
    /// <returns>Float random number.</returns>
    public static float RandomNumberFloat(float min, float max) => min > max ? 0 : new Random().NextSingle(min, max);
}
