namespace YANLib.Nullable;

public partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a float using the default format. Returns the parsed <see cref="float"/> value, or <see langword="null"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="float"/> value, or <see langword="null"/> if the parsing fails.</returns>
    public static float? ParseFloat(this string str) => float.TryParse(str, out var num) ? num : null;
}
