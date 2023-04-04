namespace YANLib.Nullable;

public partial class YANNum
{
    /// <summary>
    /// Parses the string representation of an integer using the default format. Returns the parsed <see cref="int"/> value, or <see langword="null"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="int"/> value, or <see langword="null"/> if the parsing fails.</returns>
    public static int? ParseInt(this string str) => int.TryParse(str, out var num) ? num : null;
}
