namespace YANLib.Nullable;

public partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a double using the default format.
    /// Returns the parsed <see cref="double"/> value, or <see langword="null"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="double"/> value, or <see langword="null"/> if the parsing fails.</returns>
    public static double? ParseDouble(this string str) => double.TryParse(str, out var num) ? num : null;
}
