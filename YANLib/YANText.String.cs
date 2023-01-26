namespace YANLib;

public static partial class YANText
{
    /// <summary>
    /// Check if string has value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>String has value or not.</returns>
    public static bool HasValue(this string str) => !string.IsNullOrEmpty(str);

    /// <summary>
    /// Check if strings has value.
    /// </summary>
    /// <param name="strs">Input strings.</param>
    /// <returns>Strings has value or not.</returns>
    public static bool HasValues(params string[] strs) => strs.All(s => !string.IsNullOrEmpty(s));

    /// <summary>
    /// Check if string has character.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>String has character or not.</returns>
    public static bool HasCharater(this string str) => !string.IsNullOrWhiteSpace(str);

    /// <summary>
    /// Check if strings has character.
    /// </summary>
    /// <param name="strs">Input strings.</param>
    /// <returns>Strings has value or not.</returns>
    public static bool HasCharaters(params string[] strs)=>strs.All(s => !string.IsNullOrWhiteSpace(s));

    /// <summary>
    /// Get value of string, if string null return empty.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>String value.</returns>
    public static string GetValue(this string str) => str ?? string.Empty;

    /// <summary>
    /// Get value of string, if string null return string default.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <param name="strDflt">Default string.</param>
    /// <returns>String value.</returns>
    public static string GetValue(this string str, string strDflt) => str ?? strDflt;
}
