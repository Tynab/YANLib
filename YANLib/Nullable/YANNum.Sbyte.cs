namespace YANLib.Nullable;

public partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a signed byte using the default format.
    /// Returns the parsed <see cref="sbyte"/> value, or <see langword="null"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="sbyte"/> value, or <see langword="null"/> if the parsing fails.</returns>
    public static sbyte? ToSbyte(this string str) => sbyte.TryParse(str, out var num) ? num : null;
}
