namespace YANLib.Nullable;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a non-negative integer using the default format.
    /// Returns the parsed <see cref="nuint"/> value, or <see langword="null"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="nuint"/> value, or <see langword="null"/> if the parsing fails.</returns>
    public static nuint? ToNuint(this string str) => nuint.TryParse(str, out var num) ? num : null;
}
