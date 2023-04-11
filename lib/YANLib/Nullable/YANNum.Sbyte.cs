namespace YANLib.Nullable;

public partial class YANNum
{
    /// <summary>
    /// Converts the specified value to a signed byte (sbyte).
    /// Returns the converted <see cref="sbyte"/> value, or <see langword="default"/> if the conversion fails.
    /// </summary>
    /// <typeparam name="T">The type of the value to be converted, which must be a value type.</typeparam>
    /// <param name="num">The value to be converted.</param>
    /// <returns>The converted <see cref="sbyte"/> value, or <see langword="default"/> if the conversion fails.</returns>
    public static sbyte? ToSbyte<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToSByte(num);
        }
        catch
        {
            return default;
        }
    }

    /// <summary>
    /// Parses the string representation of a signed byte using the default format.
    /// Returns the parsed <see cref="sbyte"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="sbyte"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static sbyte? ToSbyte(this string str) => sbyte.TryParse(str, out var num) ? num : default;

    /// <summary>
    /// Parses the string representation of a signed byte using the default format.
    /// Returns the parsed <see cref="sbyte"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <typeparam name="T">The type of the default value to be returned, which must be a value type.</typeparam>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="sbyte"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static sbyte? ToSbyte<T>(this string str, T dfltVal) where T : struct => sbyte.TryParse(str, out var num) ? num : dfltVal.ToSbyte();

    /// <summary>
    /// Generates a random <see cref="sbyte"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="sbyte"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static sbyte? GenerateRandomSbyte<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToSbyte();
        var maxValue = max.ToSbyte();
        return minValue.HasValue && maxValue.HasValue ? minValue > maxValue ? default : new Random().Next(minValue.Value, maxValue.Value).ToSbyte() : default;
    }

    /// <summary>
    /// Generates a random <see cref="sbyte"/> value between <see cref="sbyte.MinValue"/> and <see cref="sbyte.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="sbyte"/> value between <see cref="sbyte.MinValue"/> and <see cref="sbyte.MaxValue"/>.</returns>
    public static sbyte? GenerateRandomSbyte() => GenerateRandomSbyte(sbyte.MinValue, sbyte.MaxValue);

    /// <summary>
    /// Generates a random <see cref="sbyte"/> value between <see cref="sbyte.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="sbyte"/> value between <see cref="sbyte.MinValue"/> and <paramref name="max"/>.</returns>
    public static sbyte? GenerateRandomSbyte<T>(T max) where T : struct => GenerateRandomSbyte(sbyte.MinValue, max);
}
