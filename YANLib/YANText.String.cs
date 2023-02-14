namespace YANLib;

public static partial class YANText
{
    /// <summary>
    /// Returns a value indicating whether the specified string is not null or an empty string.
    /// </summary>
    /// <param name="str">The string to test.</param>
    /// <returns><see langword="true"/> if the value parameter is not null or an empty; otherwise, <see langword="false"/>.</returns>
    public static bool HasValue(this string str) => !string.IsNullOrEmpty(str);

    /// <summary>
    /// Checks if all the given strings have values (not null or empty).
    /// </summary>
    /// <param name="strs">An array of strings to check.</param>
    /// <returns><see langword="true"/> if all the given strings have values, otherwise <see langword="false"/>.</returns>
    public static bool HasValues(params string[] strs) => strs.All(s => !string.IsNullOrEmpty(s));

    /// <summary>
    /// Determines whether the specified string contains any non-whitespace characters.
    /// </summary>
    /// <param name="str">The string to check for non-whitespace characters.</param>
    /// <returns><see langword="true"/> if the string contains non-whitespace characters; otherwise, <see langword="false"/>.</returns>
    public static bool HasCharater(this string str) => !string.IsNullOrWhiteSpace(str);

    /// <summary>
    /// Returns a value indicating whether all the specified strings are not null, empty, or contain only whitespace characters.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings are not null, empty, or contain only whitespace characters; otherwise, <see langword="false"/>.</returns>
    public static bool HasCharaters(params string[] strs) => strs.All(s => !string.IsNullOrWhiteSpace(s));

    /// <summary>
    /// Gets the value of the string or returns an empty string if it is null.
    /// </summary>
    /// <param name="str">The string to get the value of.</param>
    /// <returns>The value of the string or an empty string if it is null.</returns>
    public static string GetValue(this string str) => str ?? string.Empty;

    /// <summary>
    /// Gets the value of the string or returns a default string if the input is null.
    /// </summary>
    /// <param name="str">The input string to check.</param>
    /// <param name="strDflt">The default string to return if the input string is null.</param>
    /// <returns>The input string if it's not null, otherwise the default string.</returns>
    public static string GetValue(this string str, string strDflt) => str ?? strDflt;
}
