namespace YANLib;

public static partial class YANText
{
    /// <summary>
    /// Determines whether the specified string is not <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="str">The string to check.</param>
    /// <returns><see langword="true"/> if the string is not <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool HasValue(this string str) => !string.IsNullOrEmpty(str);

    /// <summary>
    /// Determines whether all the specified strings are not <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings are not <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool HasValues(params string[] strs) => strs.All(s => !string.IsNullOrEmpty(s));

    /// <summary>
    /// Determines whether the specified string is not <see langword="null"/>, <see cref="string.Empty"/>, or consists only of whitespace characters.
    /// </summary>
    /// <param name="str">The string to check.</param>
    /// <returns><see langword="true"/> if the string is not <see langword="null"/>, <see cref="string.Empty"/>, or consists only of whitespace characters; otherwise, <see langword="false"/>.</returns>
    public static bool HasCharater(this string str) => !string.IsNullOrWhiteSpace(str);

    /// <summary>
    /// Determines whether all the specified strings are not <see langword="null"/>, <see cref="string.Empty"/>, or consist only of whitespace characters.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings are not <see langword="null"/>, <see cref="string.Empty"/>, or consist only of whitespace characters; otherwise, <see langword="false"/>.</returns>
    public static bool HasCharaters(params string[] strs) => strs.All(s => !string.IsNullOrWhiteSpace(s));

    /// <summary>
    /// Returns the non-null string value or <see cref="string.Empty"/> if it is <see langword="null"/>.
    /// </summary>
    /// <param name="str">The string to retrieve the value from.</param>
    /// <returns>The non-null string value or <see cref="string.Empty"/> if it is <see langword="null"/>.</returns>
    public static string GetValue(this string str) => str ?? string.Empty;

    /// <summary>
    /// Returns the non-null string value or the default value if it is <see langword="null"/>.
    /// </summary>
    /// <param name="str">The string to retrieve the value from.</param>
    /// <param name="dfltVal">The default value to return if the string is <see langword="null"/>.</param>
    /// <returns>The non-null string value or the default value if it is <see langword="null"/>.</returns>
    public static string GetValue(this string str, string dfltVal) => str ?? dfltVal;
}
