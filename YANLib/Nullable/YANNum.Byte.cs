namespace YANLib.Nullable;

public static partial class YANNum
{
    /// <summary>
    /// Converts the string representation of a number to its 8-bit unsigned integer equivalent. A return value indicates whether the conversion succeeded or failed.
    /// </summary>
    /// <param name="str">A string containing a number to convert.</param>
    /// <returns>An 8-bit unsigned integer equivalent to the number contained in the string, or null if the conversion failed.</returns>
    public static byte? ParseByte(this string str) => byte.TryParse(str, out var num) ? num : null;
}
