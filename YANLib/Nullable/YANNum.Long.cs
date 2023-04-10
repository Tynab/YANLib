namespace YANLib.Nullable;

public partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a long using the default format.
    /// Returns the parsed <see cref="long"/> value, or <see langword="null"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="long"/> value, or <see langword="null"/> if the parsing fails.</returns>
    public static long? ToLong(this string str) => long.TryParse(str, out var num) ? num : null;
}
