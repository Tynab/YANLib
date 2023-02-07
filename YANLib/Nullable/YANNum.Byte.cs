namespace YANLib.Nullable;

public static partial class YANNum
{
    /// <summary>
    /// Try parse <see cref="string"/> to <see cref="byte"/>, if failed return null.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Byte number.</returns>
    public static byte? ParseByte(this string str) => byte.TryParse(str, out var num) ? num : null;
}
