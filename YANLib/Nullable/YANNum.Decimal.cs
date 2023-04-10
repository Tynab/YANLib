namespace YANLib.Nullable;

public partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a decimal using the default format.
    /// Returns the parsed <see cref="decimal"/> value, or <see langword="null"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="decimal"/> value, or <see langword="null"/> if the parsing fails.</returns>
    public static decimal? ToDecimal(this string str) => decimal.TryParse(str, out var num) ? num : null;
}
