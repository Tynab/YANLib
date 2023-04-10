namespace YANLib.Nullable;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of an integer using the default format.
    /// Returns the parsed <see cref="nint"/> value, or <see langword="null"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="nint"/> value, or <see langword="null"/> if the parsing fails.</returns>
    public static nint? ToNint(this string str) => nint.TryParse(str, out var num) ? num : null;
}
