using System.Globalization;
using static System.StringComparison;

namespace YANLib;

public static partial class YANText
{
    /// <summary>
    /// Determines whether the specified string is <see langword="null"/>.
    /// </summary>
    /// <param name="str">The string to check.</param>
    /// <returns><see langword="true"/> if the string is <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNull(this string str) => str is null;

    /// <summary>
    /// Determines whether any of the specified strings in the enumerable is <see langword="null"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable is <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNull(params string[] strs) => strs is not null && !strs.Any(s => s.IsNotNull());

    /// <summary>
    /// Determines whether any of the specified strings in the enumerable is <see langword="null"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable is <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNull(this IEnumerable<string> strs) => strs is not null && !strs.Any(s => s.IsNotNull());

    /// <summary>
    /// Determines whether any of the specified strings in the enumerable is <see langword="null"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable is <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNull(this IReadOnlyCollection<string> strs) => strs is not null && !strs.Any(s => s.IsNotNull());

    /// <summary>
    /// Determines whether any of the specified strings in the enumerable is <see langword="null"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable is <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNull(this IReadOnlyList<string> strs) => strs is not null && !strs.Any(s => s.IsNotNull());

    /// <summary>
    /// Determines whether any of the specified strings in the enumerable is <see langword="null"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable is <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNull(this IReadOnlySet<string> strs) => strs is not null && !strs.Any(s => s.IsNotNull());

    /// <summary>
    /// Determines whether the specified string is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="str">The string to check.</param>
    /// <returns><see langword="true"/> if the string is <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

    /// <summary>
    /// Determines whether any of the specified strings in the enumerable is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable is <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrEmpty(params string[] strs) => strs is not null && !strs.Any(s => s.IsNotNullOrEmpty());

    /// <summary>
    /// Determines whether any of the specified strings in the enumerable is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable is <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrEmpty(this IEnumerable<string> strs) => strs is not null && !strs.Any(s => s.IsNotNullOrEmpty());

    /// <summary>
    /// Determines whether any of the specified strings in the enumerable is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable is <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrEmpty(this IReadOnlyCollection<string> strs) => strs is not null && !strs.Any(s => s.IsNotNullOrEmpty());

    /// <summary>
    /// Determines whether any of the specified strings in the enumerable is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable is <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrEmpty(this IReadOnlyList<string> strs) => strs is not null && !strs.Any(s => s.IsNotNullOrEmpty());

    /// <summary>
    /// Determines whether any of the specified strings in the enumerable is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable is <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrEmpty(this IReadOnlySet<string> strs) => strs is not null && !strs.Any(s => s.IsNotNullOrEmpty());

    /// <summary>
    /// Determines whether the specified string is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters.
    /// </summary>
    /// <param name="str">The string to check.</param>
    /// <returns><see langword="true"/> if the string is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(this string str) => string.IsNullOrWhiteSpace(str);

    /// <summary>
    /// Determines whether any of the specified strings in the enumerable is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(params string[] strs) => strs is not null && !strs.Any(s => s.IsNotNullOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified strings in the enumerable is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(this IEnumerable<string> strs) => strs is not null && !strs.Any(s => s.IsNotNullOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified strings in the enumerable is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(this IReadOnlyCollection<string> strs) => strs is not null && !strs.Any(s => s.IsNotNullOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified strings in the enumerable is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(this IReadOnlyList<string> strs) => strs is not null && !strs.Any(s => s.IsNotNullOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified strings in the enumerable is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable is <see langword="null"/>, <see cref="string.Empty"/>, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(this IReadOnlySet<string> strs) => strs is not null && !strs.Any(s => s.IsNotNullOrWhiteSpace());

    /// <summary>
    /// Determines whether the specified strings are equal, comparing their values.
    /// </summary>
    /// <param name="str1">The first string to compare.</param>
    /// <param name="str2">The second string to compare.</param>
    /// <returns><see langword="true"/> if the strings are equal, comparing their values; otherwise, <see langword="false"/>.</returns>
    public static bool Equals(this string str1, string str2) => str1 == str2;

    /// <summary>
    /// Determines whether any of the specified strings in the enumerable are equal to the first string in the enumerable, comparing their values.
    /// </summary>
    /// <param name="strs">The strings to compare.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable are equal to the first string in the enumerable, comparing their values; otherwise, <see langword="false"/>.</returns>
    public static bool Equals(params string[] strs) => strs is not null && !strs.Any(s => s.NotEquals(strs[0]));

    /// <summary>
    /// Determines whether any of the specified strings in the enumerable are equal to the first string in the enumerable, comparing their values.
    /// </summary>
    /// <param name="strs">The strings to compare.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable are equal to the first string in the enumerable, comparing their values; otherwise, <see langword="false"/>.</returns>
    public static bool Equals(this IEnumerable<string> strs) => strs is not null && !strs.Any(s => s.NotEquals(strs.First()));

    /// <summary>
    /// Determines whether any of the specified strings in the enumerable are equal to the first string in the enumerable, comparing their values.
    /// </summary>
    /// <param name="strs">The strings to compare.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable are equal to the first string in the enumerable, comparing their values; otherwise, <see langword="false"/>.</returns>
    public static bool Equals(this IReadOnlyCollection<string> strs) => strs is not null && !strs.Any(s => s.NotEquals(strs.First()));

    /// <summary>
    /// Determines whether any of the specified strings in the enumerable are equal to the first string in the enumerable, comparing their values.
    /// </summary>
    /// <param name="strs">The strings to compare.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable are equal to the first string in the enumerable, comparing their values; otherwise, <see langword="false"/>.</returns>
    public static bool Equals(this IReadOnlyList<string> strs) => strs is not null && !strs.Any(s => s.NotEquals(strs[0]));

    /// <summary>
    /// Determines whether any of the specified strings in the enumerable are equal to the first string in the enumerable, comparing their values.
    /// </summary>
    /// <param name="strs">The strings to compare.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable are equal to the first string in the enumerable, comparing their values; otherwise, <see langword="false"/>.</returns>
    public static bool Equals(this IReadOnlySet<string> strs) => strs is not null && !strs.Any(s => s.NotEquals(strs.First()));

    /// <summary>
    /// Determines whether the specified strings are equal, ignoring their casing, and comparing their values using ordinal comparison.
    /// </summary>
    /// <param name="str1">The first string to compare.</param>
    /// <param name="str2">The second string to compare.</param>
    /// <returns><see langword="true"/> if the strings are equal, ignoring their casing, and comparing their values using ordinal comparison; otherwise, <see langword="false"/>.</returns>
    public static bool EqualsIgnoreCase(this string str1, string str2) => IsNull(str1, str2) || str1.IsNotNull() && str1.IsNotNull() && string.Equals(str1, str2, OrdinalIgnoreCase);

    /// <summary>
    /// Determines whether the specified strings are equal, ignoring their casing, and comparing their values using ordinal comparison.
    /// </summary>
    /// <param name="strs">The strings to compare.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable are equal to the first string in the enumerable, ignoring their casing, and comparing their values using ordinal comparison; otherwise, <see langword="false"/>.</returns>
    public static bool EqualsIgnoreCase(params string[] strs) => strs is not null && !strs.Any(s => s.NotEqualsIgnoreCase(strs[0]));

    /// <summary>
    /// Determines whether the specified strings are equal, ignoring their casing, and comparing their values using ordinal comparison.
    /// </summary>
    /// <param name="strs">The strings to compare.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable are equal to the first string in the enumerable, ignoring their casing, and comparing their values using ordinal comparison; otherwise, <see langword="false"/>.</returns>
    public static bool EqualsIgnoreCase(this IEnumerable<string> strs) => strs is not null && !strs.Any(s => s.NotEqualsIgnoreCase(strs.First()));

    /// <summary>
    /// Determines whether the specified strings are equal, ignoring their casing, and comparing their values using ordinal comparison.
    /// </summary>
    /// <param name="strs">The strings to compare.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable are equal to the first string in the enumerable, ignoring their casing, and comparing their values using ordinal comparison; otherwise, <see langword="false"/>.</returns>
    public static bool EqualsIgnoreCase(this IReadOnlyCollection<string> strs) => strs is not null && !strs.Any(s => s.NotEqualsIgnoreCase(strs.First()));

    /// <summary>
    /// Determines whether the specified strings are equal, ignoring their casing, and comparing their values using ordinal comparison.
    /// </summary>
    /// <param name="strs">The strings to compare.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable are equal to the first string in the enumerable, ignoring their casing, and comparing their values using ordinal comparison; otherwise, <see langword="false"/>.</returns>
    public static bool EqualsIgnoreCase(this IReadOnlyList<string> strs) => strs is not null && !strs.Any(s => s.NotEqualsIgnoreCase(strs[0]));

    /// <summary>
    /// Determines whether the specified strings are equal, ignoring their casing, and comparing their values using ordinal comparison.
    /// </summary>
    /// <param name="strs">The strings to compare.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable are equal to the first string in the enumerable, ignoring their casing, and comparing their values using ordinal comparison; otherwise, <see langword="false"/>.</returns>
    public static bool EqualsIgnoreCase(this IReadOnlySet<string> strs) => strs is not null && !strs.Any(s => s.NotEqualsIgnoreCase(strs.First()));

    /// <summary>
    /// Determines whether the specified string is not <see langword="null"/>.
    /// </summary>
    /// <param name="str">The string to check.</param>
    /// <returns><see langword="true"/> if the string is not <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNull(this string str) => str is not null;

    /// <summary>
    /// Determines whether the specified strings are not <see langword="null"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings in the enumerable are not <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNull(params string[] strs) => strs is not null && !strs.Any(s => s.IsNull());

    /// <summary>
    /// Determines whether the specified strings are not <see langword="null"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings in the enumerable are not <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNull(this IEnumerable<string> strs) => strs is not null && !strs.Any(s => s.IsNull());

    /// <summary>
    /// Determines whether the specified strings are not <see langword="null"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings in the enumerable are not <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNull(this IReadOnlyCollection<string> strs) => strs is not null && !strs.Any(s => s.IsNull());

    /// <summary>
    /// Determines whether the specified strings are not <see langword="null"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings in the enumerable are not <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNull(this IReadOnlyList<string> strs) => strs is not null && !strs.Any(s => s.IsNull());

    /// <summary>
    /// Determines whether the specified strings are not <see langword="null"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings in the enumerable are not <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNull(this IReadOnlySet<string> strs) => strs is not null && !strs.Any(s => s.IsNull());

    /// <summary>
    /// Determines whether the specified string is not <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="str">The string to check.</param>
    /// <returns><see langword="true"/> if the string is not <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNullOrEmpty(this string str) => !string.IsNullOrEmpty(str);

    /// <summary>
    /// Determines whether any of the specified strings is not <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings is not <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNullOrEmpty(params string[] strs) => strs is not null && !strs.Any(s => s.IsNullOrEmpty());

    /// <summary>
    /// Determines whether any of the specified strings in the enumerable is not <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the enumerable is not <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNullOrEmpty(this IEnumerable<string> strs) => strs is not null && !strs.Any(s => s.IsNullOrEmpty());

    /// <summary>
    /// Determines whether any of the specified strings in the read-only collection is not <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the read-only collection is not <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNullOrEmpty(this IReadOnlyCollection<string> strs) => strs is not null && !strs.Any(s => s.IsNullOrEmpty());

    /// <summary>
    /// Determines whether any of the specified strings in the read-only list is not <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the read-only list is not <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNullOrEmpty(this IReadOnlyList<string> strs) => strs is not null && !strs.Any(s => s.IsNullOrEmpty());

    /// <summary>
    /// Determines whether any of the specified strings in the read-only set is not <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if any of the strings in the read-only set is not <see langword="null"/> or <see cref="string.Empty"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNullOrEmpty(this IReadOnlySet<string> strs) => strs is not null && !strs.Any(s => s.IsNullOrEmpty());

    /// <summary>
    /// Determines whether the specified string is not <see langword="null"/>, <see cref="string.Empty"/>, or consists only of whitespace characters.
    /// </summary>
    /// <param name="str">The string to check.</param>
    /// <returns><see langword="true"/> if the string is not <see langword="null"/>, <see cref="string.Empty"/>, or consists only of whitespace characters; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNullOrWhiteSpace(this string str) => !string.IsNullOrWhiteSpace(str);

    /// <summary>
    /// Determines whether all the specified strings are not <see langword="null"/>, <see cref="string.Empty"/>, or consist only of whitespace characters.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings are not <see langword="null"/>, <see cref="string.Empty"/>, or consist only of whitespace characters; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNullOrWhiteSpace(params string[] strs) => strs is not null && !strs.Any(s => s.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether all the specified strings in the enumerable are not <see langword="null"/>, <see cref="string.Empty"/>, or consist only of whitespace characters.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings in the enumerable are not <see langword="null"/>, <see cref="string.Empty"/>, or consist only of whitespace characters; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNullOrWhiteSpace(this IEnumerable<string> strs) => strs is not null && !strs.Any(s => s.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether all the specified strings in the read-only collection are not <see langword="null"/>, <see cref="string.Empty"/>, or consist only of whitespace characters.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings in the read-only collection are not <see langword="null"/>, <see cref="string.Empty"/>, or consist only of whitespace characters; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNullOrWhiteSpace(this IReadOnlyCollection<string> strs) => strs is not null && !strs.Any(s => s.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether all the specified strings in the read-only list are not <see langword="null"/>, <see cref="string.Empty"/>, or consist only of whitespace characters.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings in the read-only list are not <see langword="null"/>, <see cref="string.Empty"/>, or consist only of whitespace characters; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNullOrWhiteSpace(this IReadOnlyList<string> strs) => strs is not null && !strs.Any(s => s.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether all the specified strings in the read-only set are not <see langword="null"/>, <see cref="string.Empty"/>, or consist only of whitespace characters.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings in the read-only set are not <see langword="null"/>, <see cref="string.Empty"/>, or consist only of whitespace characters; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNullOrWhiteSpace(this IReadOnlySet<string> strs) => strs is not null && !strs.Any(s => s.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether two specified strings are not equal, based on their values.
    /// </summary>
    /// <param name="str1">The first string to compare.</param>
    /// <param name="str2">The second string to compare.</param>
    /// <returns><see langword="true"/> if the two strings are not equal, based on their values; otherwise, <see langword="false"/>.</returns>
    public static bool NotEquals(this string str1, string str2) => str1 != str2;

    /// <summary>
    /// Determines whether all the strings in the specified enumerable are distinct, based on their values.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings in the specified enumerable are distinct, based on their values; otherwise, <see langword="false"/>.</returns>
    public static bool NotEquals(params string[] strs)
    {
        if (strs is null || strs.Length < 2)
        {
            return false;
        }
        var hashSet = new HashSet<string>(strs.Length);
        for (var i = 0; i < strs.Length; i++)
        {
            if (!hashSet.Add(strs[i]))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Determines whether all the strings in the specified enumerable are distinct, based on their values.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings in the specified enumerable are distinct, based on their values; otherwise, <see langword="false"/>.</returns>
    public static bool NotEquals(this IEnumerable<string> strs)
    {
        if (strs is null || strs.Count() < 2)
        {
            return false;
        }
        var hashSet = new HashSet<string>(strs.Count());
        foreach (var str in strs)
        {
            if (!hashSet.Add(str))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Determines whether all the strings in the specified enumerable are distinct, based on their values.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings in the specified enumerable are distinct, based on their values; otherwise, <see langword="false"/>.</returns>
    public static bool NotEquals(this IReadOnlyCollection<string> strs)
    {
        if (strs is null || strs.Count < 2)
        {
            return false;
        }
        var hashSet = new HashSet<string>(strs.Count);
        foreach (var str in strs)
        {
            if (!hashSet.Add(str))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Determines whether all the strings in the specified enumerable are distinct, based on their values.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings in the specified enumerable are distinct, based on their values; otherwise, <see langword="false"/>.</returns>
    public static bool NotEquals(this IReadOnlyList<string> strs)
    {
        if (strs is null || strs.Count < 2)
        {
            return false;
        }
        var hashSet = new HashSet<string>(strs.Count);
        for (var i = 0; i < strs.Count; i++)
        {
            if (!hashSet.Add(strs[i]))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Determines whether all the strings in the specified enumerable are distinct, based on their values.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings in the specified enumerable are distinct, based on their values; otherwise, <see langword="false"/>.</returns>
    public static bool NotEquals(this IReadOnlySet<string> strs)
    {
        if (strs is null || strs.Count < 2)
        {
            return false;
        }
        var hashSet = new HashSet<string>(strs.Count);
        foreach (var str in strs)
        {
            if (!hashSet.Add(str))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Determines whether two specified strings are not equal, ignoring their casing, based on their values using ordinal comparison.
    /// </summary>
    /// <param name="str1">The first string to compare.</param>
    /// <param name="str2">The second string to compare.</param>
    /// <returns><see langword="true"/> if the two strings are not equal, ignoring their casing, based on their values using ordinal comparison; otherwise, <see langword="false"/>.</returns>
    public static bool NotEqualsIgnoreCase(this string str1, string str2) => IsNotNull(str1, str2) && !string.Equals(str1, str2, OrdinalIgnoreCase);

    /// <summary>
    /// Determines whether all the strings in the specified enumerable are distinct, ignoring their casing, based on their values using ordinal comparison.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings in the specified enumerable are distinct, ignoring their casing, based on their values using ordinal comparison; otherwise, <see langword="false"/>.</returns>
    public static bool NotEqualsIgnoreCase(params string[] strs)
    {
        if (strs is null || strs.Length < 1)
        {
            return false;
        }
        var hashSet = new HashSet<string>(strs.Length, StringComparer.OrdinalIgnoreCase);
        for (var i = 0; i < strs.Length; i++)
        {
            if (!hashSet.Add(strs[i]))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Determines whether all the strings in the specified enumerable are distinct, ignoring their casing, based on their values using ordinal comparison.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings in the specified enumerable are distinct, ignoring their casing, based on their values using ordinal comparison; otherwise, <see langword="false"/>.</returns>
    public static bool NotEqualsIgnoreCase(this IEnumerable<string> strs)
    {
        if (strs is null || strs.Count() < 2)
        {
            return false;
        }
        var hashSet = new HashSet<string>(strs.Count(), StringComparer.OrdinalIgnoreCase);
        foreach (var str in strs)
        {
            if (!hashSet.Add(str))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Determines whether all the strings in the specified enumerable are distinct, ignoring their casing, based on their values using ordinal comparison.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings in the specified enumerable are distinct, ignoring their casing, based on their values using ordinal comparison; otherwise, <see langword="false"/>.</returns>
    public static bool NotEqualsIgnoreCase(this IReadOnlyCollection<string> strs)
    {
        if (strs is null || strs.Count < 2)
        {
            return false;
        }
        var hashSet = new HashSet<string>(strs.Count, StringComparer.OrdinalIgnoreCase);
        foreach (var str in strs)
        {
            if (!hashSet.Add(str))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Determines whether all the strings in the specified enumerable are distinct, ignoring their casing, based on their values using ordinal comparison.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings in the specified enumerable are distinct, ignoring their casing, based on their values using ordinal comparison; otherwise, <see langword="false"/>.</returns>
    public static bool NotEqualsIgnoreCase(this IReadOnlyList<string> strs)
    {
        if (strs is null || strs.Count < 2)
        {
            return false;
        }
        var hashSet = new HashSet<string>(strs.Count, StringComparer.OrdinalIgnoreCase);
        for (var i = 0; i < strs.Count; i++)
        {
            if (!hashSet.Add(strs[i]))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Determines whether all the strings in the specified enumerable are distinct, ignoring their casing, based on their values using ordinal comparison.
    /// </summary>
    /// <param name="strs">The strings to check.</param>
    /// <returns><see langword="true"/> if all the strings in the specified enumerable are distinct, ignoring their casing, based on their values using ordinal comparison; otherwise, <see langword="false"/>.</returns>
    public static bool NotEqualsIgnoreCase(this IReadOnlySet<string> strs)
    {
        if (strs is null || strs.Count < 2)
        {
            return false;
        }
        var hashSet = new HashSet<string>(strs.Count, StringComparer.OrdinalIgnoreCase);
        foreach (var str in strs)
        {
            if (!hashSet.Add(str))
            {
                return false;
            }
        }
        return true;
    }

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
    /// <returns>
    /// The non-null string value or the default value if it is <see langword="null"/>.
    /// If the default character value is not a valid character, an empty string is returned.
    /// </returns>
    public static string GetValue(this string str, char dfltVal) => str ?? (dfltVal.IsNotEmpty() ? dfltVal.ToString() : string.Empty);

    /// <summary>
    /// Converts the string to lowercase if it is not empty or whitespace; otherwise, returns the original string.
    /// </summary>
    /// <param name="str">The string to convert to lowercase.</param>
    /// <returns>The lowercase version of the string if it is not empty or whitespace; otherwise, the original string.</returns>
    public static string ToLower(this string str) => str.IsNotNullOrWhiteSpace() ? str.ToLower() : str;

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings converted to lowercase, ignoring their casing, based on their Unicode values.
    /// </summary>
    /// <param name="strs">The strings to convert to lowercase.</param>
    /// <returns>An enumerable of strings converted to lowercase, ignoring their casing, based on their Unicode values.</returns>
    public static IEnumerable<string> ToLower(params string[] strs)
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return ToLower(strs[i]);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings converted to lowercase, ignoring their casing, based on their Unicode values.
    /// </summary>
    /// <param name="strs">The strings to convert to lowercase.</param>
    /// <returns>An enumerable of strings converted to lowercase, ignoring their casing, based on their Unicode values.</returns>
    public static IEnumerable<string> ToLower(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return ToLower(str);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings converted to lowercase, ignoring their casing, based on their Unicode values.
    /// </summary>
    /// <param name="strs">The strings to convert to lowercase.</param>
    /// <returns>An enumerable of strings converted to lowercase, ignoring their casing, based on their Unicode values.</returns>
    public static IEnumerable<string> ToLower(this IReadOnlyCollection<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return ToLower(str);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings converted to lowercase, ignoring their casing, based on their Unicode values.
    /// </summary>
    /// <param name="strs">The strings to convert to lowercase.</param>
    /// <returns>An enumerable of strings converted to lowercase, ignoring their casing, based on their Unicode values.</returns>
    public static IEnumerable<string> ToLower(this IReadOnlyList<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return ToLower(strs[i]);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings converted to lowercase, ignoring their casing, based on their Unicode values.
    /// </summary>
    /// <param name="strs">The strings to convert to lowercase.</param>
    /// <returns>An enumerable of strings converted to lowercase, ignoring their casing, based on their Unicode values.</returns>
    public static IEnumerable<string> ToLower(this IReadOnlySet<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return ToLower(str);
        }
    }

    /// <summary>
    /// Converts the strings in the specified list to lowercase, ignoring their casing, based on their Unicode values.
    /// </summary>
    /// <param name="strs">The list of strings to convert to lowercase.</param>
    public static void ToLowerRef(this IList<string> strs)
    {
        if (strs is not null && strs.Count > 0)
        {
            for (var i = 0; i < strs.Count; i++)
            {
                strs[i] = ToLower(strs[i]);
            }
        }
    }

    /// <summary>
    /// Converts the string to lowercase using the invariant culture, if it is not empty or whitespace; otherwise, returns the original string.
    /// </summary>
    /// <param name="str">The string to convert to lowercase.</param>
    /// <returns>The lowercase version of the string using the invariant culture if it is not empty or whitespace; otherwise, the original string.</returns>
    public static string ToLowerInvariant(this string str) => str.IsNotNullOrWhiteSpace() ? str.ToLower(CultureInfo.InvariantCulture) : str;

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings converted to lowercase, ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="strs">The strings to convert to lowercase.</param>
    /// <returns>An enumerable of strings converted to lowercase, ignoring their casing, based on their Unicode values using the invariant culture.</returns>
    public static IEnumerable<string> ToLowerInvariant(params string[] strs)
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return ToLowerInvariant(strs[i]);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings converted to lowercase, ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="strs">The strings to convert to lowercase.</param>
    /// <returns>An enumerable of strings converted to lowercase, ignoring their casing, based on their Unicode values using the invariant culture.</returns>
    public static IEnumerable<string> ToLowerInvariant(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return ToLowerInvariant(str);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings converted to lowercase, ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="strs">The strings to convert to lowercase.</param>
    /// <returns>An enumerable of strings converted to lowercase, ignoring their casing, based on their Unicode values using the invariant culture.</returns>
    public static IEnumerable<string> ToLowerInvariant(this IReadOnlyCollection<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return ToLowerInvariant(str);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings converted to lowercase, ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="strs">The strings to convert to lowercase.</param>
    /// <returns>An enumerable of strings converted to lowercase, ignoring their casing, based on their Unicode values using the invariant culture.</returns>
    public static IEnumerable<string> ToLowerInvariant(this IReadOnlyList<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return ToLowerInvariant(strs[i]);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings converted to lowercase, ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="strs">The strings to convert to lowercase.</param>
    /// <returns>An enumerable of strings converted to lowercase, ignoring their casing, based on their Unicode values using the invariant culture.</returns>
    public static IEnumerable<string> ToLowerInvariant(this IReadOnlySet<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return ToLowerInvariant(str);
        }
    }

    /// <summary>
    /// Converts all strings in the specified string list to lowercase using the invariant culture, by modifying the list in-place.
    /// </summary>
    /// <param name="strs">The string list to convert to lowercase.</param>
    public static void ToLowerInvariantRef(this IList<string> strs)
    {
        if (strs is not null && strs.Count > 0)
        {
            for (var i = 0; i < strs.Count; i++)
            {
                strs[i] = ToLowerInvariant(strs[i]);
            }
        }
    }

    /// <summary>
    /// Converts the string to uppercase using the invariant culture, if it is not empty or whitespace; otherwise, returns the original string.
    /// </summary>
    /// <param name="str">The string to convert to uppercase.</param>
    /// <returns>The uppercase version of the string using the invariant culture if it is not empty or whitespace; otherwise, the original string.</returns>
    public static string ToUpper(this string str) => str.IsNotNullOrWhiteSpace() ? str.ToUpper() : str;

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings converted to uppercase, ignoring their casing, using the invariant culture.
    /// </summary>
    /// <param name="strs">The strings to convert to uppercase.</param>
    /// <returns>An enumerable of strings converted to uppercase, ignoring their casing, using the invariant culture.</returns>
    public static IEnumerable<string> ToUpper(params string[] strs)
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return ToUpper(strs[i]);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings converted to uppercase, ignoring their casing, using the invariant culture.
    /// </summary>
    /// <param name="strs">The strings to convert to uppercase.</param>
    /// <returns>An enumerable of strings converted to uppercase, ignoring their casing, using the invariant culture.</returns>
    public static IEnumerable<string> ToUpper(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return ToUpper(str);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings converted to uppercase, ignoring their casing, using the invariant culture.
    /// </summary>
    /// <param name="strs">The strings to convert to uppercase.</param>
    /// <returns>An enumerable of strings converted to uppercase, ignoring their casing, using the invariant culture.</returns>
    public static IEnumerable<string> ToUpper(this IReadOnlyCollection<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return ToUpper(str);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings converted to uppercase, ignoring their casing, using the invariant culture.
    /// </summary>
    /// <param name="strs">The strings to convert to uppercase.</param>
    /// <returns>An enumerable of strings converted to uppercase, ignoring their casing, using the invariant culture.</returns>
    public static IEnumerable<string> ToUpper(this IReadOnlyList<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return ToUpper(strs[i]);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings converted to uppercase, ignoring their casing, using the invariant culture.
    /// </summary>
    /// <param name="strs">The strings to convert to uppercase.</param>
    /// <returns>An enumerable of strings converted to uppercase, ignoring their casing, using the invariant culture.</returns>
    public static IEnumerable<string> ToUpper(this IReadOnlySet<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return ToUpper(str);
        }
    }

    /// <summary>
    /// Converts all strings in the specified list of strings to uppercase, by modifying the list in-place.
    /// </summary>
    /// <param name="strs">The list of strings to convert to uppercase.</param>
    public static void ToUpperRef(this IList<string> strs)
    {
        if (strs is not null && strs.Count > 0)
        {
            for (var i = 0; i < strs.Count; i++)
            {
                strs[i] = ToUpper(strs[i]);
            }
        }
    }

    /// <summary>
    /// Converts the input string to uppercase using the invariant culture, if it is not empty or whitespace; otherwise, returns the original string.
    /// </summary>
    /// <param name="str">The string to convert to uppercase.</param>
    /// <returns>The uppercase version of the input string using the invariant culture if it is not empty or whitespace; otherwise, the original string.</returns>
    public static string ToUpperInvariant(this string str) => str.IsNotNullOrWhiteSpace() ? str.ToUpper(CultureInfo.InvariantCulture) : str;

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings converted to uppercase, ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="strs">The strings to convert to uppercase.</param>
    /// <returns>An enumerable of strings converted to uppercase, ignoring their casing, based on their Unicode values using the invariant culture.</returns>
    public static IEnumerable<string> ToUpperInvariant(params string[] strs)
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return ToUpperInvariant(strs[i]);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings converted to uppercase, ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="strs">The strings to convert to uppercase.</param>
    /// <returns>An enumerable of strings converted to uppercase, ignoring their casing, based on their Unicode values using the invariant culture.</returns>
    public static IEnumerable<string> ToUpperInvariant(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return ToUpperInvariant(str);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings converted to uppercase, ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="strs">The strings to convert to uppercase.</param>
    /// <returns>An enumerable of strings converted to uppercase, ignoring their casing, based on their Unicode values using the invariant culture.</returns>
    public static IEnumerable<string> ToUpperInvariant(this IReadOnlyCollection<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return ToUpperInvariant(str);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings converted to uppercase, ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="strs">The strings to convert to uppercase.</param>
    /// <returns>An enumerable of strings converted to uppercase, ignoring their casing, based on their Unicode values using the invariant culture.</returns>
    public static IEnumerable<string> ToUpperInvariant(this IReadOnlyList<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return ToUpperInvariant(strs[i]);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings converted to uppercase, ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="strs">The strings to convert to uppercase.</param>
    /// <returns>An enumerable of strings converted to uppercase, ignoring their casing, based on their Unicode values using the invariant culture.</returns>
    public static IEnumerable<string> ToUpperInvariant(this IReadOnlySet<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return ToUpperInvariant(str);
        }
    }

    /// <summary>
    /// Converts all strings in the specified string list to uppercase using the invariant culture, by modifying the list in-place.
    /// </summary>
    /// <param name="strs">The string list to convert to uppercase.</param>
    public static void ToUpperInvariantRef(this IList<string> strs)
    {
        if (strs is not null && strs.Count > 0)
        {
            for (var i = 0; i < strs.Count; i++)
            {
                strs[i] = ToUpperInvariant(strs[i]);
            }
        }
    }
}
