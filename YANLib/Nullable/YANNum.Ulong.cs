namespace YANLib.Nullable;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a non-negative integer using the default format.
    /// Returns the parsed <see cref="ulong"/> value, or <see langword="null"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="ulong"/> value, or <see langword="null"/> if the parsing fails.</returns>
    public static ulong? ParseUlong(this string str) => ulong.TryParse(str, out var num) ? num : null;
}
