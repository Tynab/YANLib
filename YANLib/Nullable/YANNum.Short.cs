namespace YANLib.Nullable;

public partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a short using the default format.
    /// Returns the parsed <see cref="short"/> value, or <see langword="null"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="short"/> value, or <see langword="null"/> if the parsing fails.</returns>
    public static short? ParseShort(this string str) => short.TryParse(str, out var num) ? num : null;
}
