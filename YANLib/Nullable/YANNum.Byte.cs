namespace YANLib.Nullable;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a byte using the default format.
    /// Returns the parsed <see cref="byte"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="byte"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static byte? ToByte(this string str) => byte.TryParse(str, out var num) ? num : default;

    /// <summary>
    /// Converts the specified value to a byte.
    /// Returns the converted <see cref="byte"/> value, or <see langword="default"/> if the conversion fails.
    /// </summary>
    /// <typeparam name="T">The type of the value to be converted, which must be a value type.</typeparam>
    /// <param name="num">The value to be converted.</param>
    /// <returns>The converted <see cref="byte"/> value, or <see langword="default"/> if the conversion fails.</returns>
    public static byte? ToByte<T>(this T? num) where T : struct
    {
        try
        {
            return Convert.ToByte(num);
        }
        catch
        {
            return default;
        }
    }
}
