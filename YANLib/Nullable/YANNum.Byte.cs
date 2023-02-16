namespace YANLib.Nullable;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a byte using the default format. Returns the parsed <see cref="byte"/> value, or <see langword="null"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="byte"/> value, or <see langword="null"/> if the parsing fails.</returns>
    public static byte? ParseByte(this string str) => byte.TryParse(str, out var num) ? num : null;
}
