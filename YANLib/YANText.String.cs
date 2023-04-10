namespace YANLib;

public static partial class YANText
{
    /// <summary>
    /// Determines whether the specified string is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="str">The string to check.</param>
    /// <returns><see langword="true"/> if the string is <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

    /// <summary>
    /// Determines whether any of the specified strings is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings is <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrEmpty(params string[] strs) => !strs.Any(s => s.HasValue());

    /// <summary>
    /// Determines whether any of the specified strings in the enumerable is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable is <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrEmpty(this IEnumerable<string> strs) => !strs.Any(s => s.HasValue());

    /// <summary>
    /// Determines whether any of the specified strings in the collection is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the collection is <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrEmpty(this ICollection<string> strs) => !strs.Any(s => s.HasValue());

    /// <summary>
    /// Determines whether any of the specified strings in the list is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the list is <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrEmpty(this IList<string> strs) => !strs.Any(s => s.HasValue());

    /// <summary>
    /// Determines whether any of the specified strings in the set is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the set is <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrEmpty(this ISet<string> strs) => !strs.Any(s => s.HasValue());

    /// <summary>
    /// Determines whether any of the specified strings in the read-only collection is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the read-only collection is <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrEmpty(this IReadOnlyCollection<string> strs) => !strs.Any(s => s.HasValue());

    /// <summary>
    /// Determines whether any of the specified strings in the read-only list is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the read-only list is <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrEmpty(this IReadOnlyList<string> strs) => !strs.Any(s => s.HasValue());

    /// <summary>
    /// Determines whether any of the specified strings in the read-only set is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the read-only set is <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrEmpty(this IReadOnlySet<string> strs) => !strs.Any(s => s.HasValue());

    /// <summary>
    /// Determines whether the specified string is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters.
    /// </summary>
    /// <param name="str">The string to check.</param>
    /// <returns><see langword="true"/> if the string is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(this string str) => string.IsNullOrWhiteSpace(str);

    /// <summary>
    /// Determines whether the specified string is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters.
    /// </summary>
    /// <param name="str">The string to check.</param>
    /// <returns><see langword="true"/> if the string is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(params string[] strs) => !strs.Any(s => s.HasCharater());

    /// <summary>
    /// Determines whether any of the specified strings in the enumerable is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(this IEnumerable<string> strs) => !strs.Any(s => s.HasCharater());

    /// <summary>
    /// Determines whether any of the specified strings in the collection is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the collection is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(this ICollection<string> strs) => !strs.Any(s => s.HasCharater());

    /// <summary>
    /// Determines whether any of the specified strings in the set is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the set is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(this ISet<string> strs) => !strs.Any(s => s.HasCharater());

    /// <summary>
    /// Determines whether any of the specified strings in the read-only collection is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the read-only collection is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(this IReadOnlyCollection<string> strs) => !strs.Any(s => s.HasCharater());

    /// <summary>
    /// Determines whether any of the specified strings in the read-only list is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the read-only list is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(this IReadOnlyList<string> strs) => !strs.Any(s => s.HasCharater());

    /// <summary>
    /// Determines whether any of the specified strings in the read-only set is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the read-only set is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(this IReadOnlySet<string> strs) => !strs.Any(s => s.HasCharater());

    /// <summary>
    /// Determines whether the specified string is not <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="str">The string to check.</param>
    /// <returns><see langword="true"/> if the string is not <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool HasValue(this string str) => !string.IsNullOrEmpty(str);

    /// <summary>
    /// Determines whether any of the specified strings is not <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings is not <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool HasValue(params string[] strs) => !strs.Any(s => s.IsNullOrEmpty());

    /// <summary>
    /// Determines whether any of the specified strings in the enumerable is not <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable is not <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool HasValue(this IEnumerable<string> strs) => !strs.Any(s => s.IsNullOrEmpty());

    /// <summary>
    /// Determines whether any of the specified strings in the collection is not <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the collection is not <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool HasValue(this ICollection<string> strs) => !strs.Any(s => s.IsNullOrEmpty());

    /// <summary>
    /// Determines whether any of the specified strings in the set is not <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the set is not <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool HasValue(this ISet<string> strs) => !strs.Any(s => s.IsNullOrEmpty());

    /// <summary>
    /// Determines whether any of the specified strings in the read-only collection is not <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the read-only collection is not <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool HasValue(this IReadOnlyCollection<string> strs) => !strs.Any(s => s.IsNullOrEmpty());

    /// <summary>
    /// Determines whether any of the specified strings in the read-only list is not <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the read-only list is not <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool HasValue(this IReadOnlyList<string> strs) => !strs.Any(s => s.IsNullOrEmpty());

    /// <summary>
    /// Determines whether any of the specified strings in the read-only set is not <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the read-only set is not <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool HasValue(this IReadOnlySet<string> strs) => !strs.Any(s => s.IsNullOrEmpty());

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
    public static bool HasCharater(params string[] strs) => !strs.Any(s => s.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether all the specified strings in the enumerable are not <see langword="null"/>, <see cref="string.Empty"/>, or consist only of whitespace characters.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings in the enumerable are not <see langword="null"/>, <see cref="string.Empty"/>, or consist only of whitespace characters; otherwise, <see langword="false"/>.</returns>
    public static bool HasCharater(this IEnumerable<string> strs) => !strs.Any(s => s.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether all the specified strings in the collection are not <see langword="null"/>, <see cref="string.Empty"/>, or consist only of whitespace characters.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings in the collection are not <see langword="null"/>, <see cref="string.Empty"/>, or consist only of whitespace characters; otherwise, <see langword="false"/>.</returns>
    public static bool HasCharater(this ICollection<string> strs) => !strs.Any(s => s.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether all the specified strings in the set are not <see langword="null"/>, <see cref="string.Empty"/>, or consist only of whitespace characters.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings in the set are not <see langword="null"/>, <see cref="string.Empty"/>, or consist only of whitespace characters; otherwise, <see langword="false"/>.</returns>
    public static bool HasCharater(this ISet<string> strs) => !strs.Any(s => s.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether all the specified strings in the read-only collection are not <see langword="null"/>, <see cref="string.Empty"/>, or consist only of whitespace characters.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings in the read-only collection are not <see langword="null"/>, <see cref="string.Empty"/>, or consist only of whitespace characters; otherwise, <see langword="false"/>.</returns>
    public static bool HasCharater(this IReadOnlyCollection<string> strs) => !strs.Any(s => s.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether all the specified strings in the read-only list are not <see langword="null"/>, <see cref="string.Empty"/>, or consist only of whitespace characters.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings in the read-only list are not <see langword="null"/>, <see cref="string.Empty"/>, or consist only of whitespace characters; otherwise, <see langword="false"/>.</returns>
    public static bool HasCharater(this IReadOnlyList<string> strs) => !strs.Any(s => s.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether all the specified strings in the read-only set are not <see langword="null"/>, <see cref="string.Empty"/>, or consist only of whitespace characters.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings in the read-only set are not <see langword="null"/>, <see cref="string.Empty"/>, or consist only of whitespace characters; otherwise, <see langword="false"/>.</returns>
    public static bool HasCharater(this IReadOnlySet<string> strs) => !strs.Any(s => s.IsNullOrWhiteSpace());

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

    /// <summary>
    /// Returns the non-null string value or the default value if it is <see langword="null"/>.
    /// </summary>
    /// <param name="str">The string to retrieve the value from.</param>
    /// <param name="dfltVal">The default character value to return if the string is <see langword="null"/>.</param>
    /// <returns>The non-null string value or the default value if it is <see langword="null"/>. If the default character value is not a valid character, an empty string is returned.</returns>
    public static string GetValue(this string str, char dfltVal) => str ?? (dfltVal.HasCharater() ? dfltVal.ToString() : string.Empty);
}
