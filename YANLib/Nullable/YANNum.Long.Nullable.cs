namespace YANLib.Nullable;

public partial class YANNum
{
    /// <summary>
    /// Tries to parse the string representation of a long. Returns the parsed <see cref="long"/> value, or <paramref name="dfltVal"/> if the parsing fails. If <paramref name="dfltVal"/> is not specified or <see langword="null"/>, returns <see langword="null"/> instead.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to return if the parsing fails. This parameter is optional.</param>
    /// <returns>The parsed <see cref="long"/> value, <paramref name="dfltVal"/> if the parsing succeeds, or <see langword="null"/> if <paramref name="dfltVal"/> is not specified or <see langword="null"/>.</returns>
    public static long? ParseLong(this string str, long? dfltVal) => long.TryParse(str, out var num) ? num : dfltVal;
}
