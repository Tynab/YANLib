using System.Globalization;
using System.Text;

namespace YANLib;

public static partial class YANText
{
    /// <summary>
    /// Converts the string to title case using the current culture's text info, if it is not empty or whitespace; otherwise, returns the original string.
    /// </summary>
    /// <param name="str">The string to convert to title case.</param>
    /// <returns>The title case version of the string using the current culture's text info if it is not empty or whitespace; otherwise, the original string.</returns>
    public static string ToTitle(this string str) => str.IsNullOrWhiteSpace() ? str : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings converted to title case using the current culture's text info.
    /// </summary>
    /// <param name="strs">The strings to convert to title case.</param>
    /// <returns>An enumerable of strings converted to title case using the current culture's text info.</returns>
    public static IEnumerable<string> ToTitle(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.ToTitle();
        }
    }

    /// <summary>
    /// Converts all strings in the specified list to title case using the current culture's text info, by modifying the list in-place.
    /// </summary>
    /// <param name="strs">The list of strings to convert to title case.</param>
    public static void ToTitleRef(this IList<string> strs)
    {
        if (strs is not null && strs.Count > 0)
        {
            for (var i = 0; i < strs.Count; i++)
            {
                strs[i] = strs[i].ToTitle();
            }
        }
    }

    /// <summary>
    /// Converts the first character of each word in the input string to uppercase, and the remaining characters to lowercase, using the current culture's text info.
    /// </summary>
    /// <param name="str">The string to capitalize.</param>
    /// <returns>The capitalized version of the input string.</returns>
    public static string ToCapitalize(this string str)
    {
        if (str.IsNullOrWhiteSpace())
        {
            return str;
        }
        var sb = new StringBuilder(str);
        var is1stChar = true;
        for (var i = 0; i < sb.Length; i++)
        {
            if (is1stChar && sb[i].IsAlphabetic())
            {
                sb[i] = sb[i].ToUpper();
                is1stChar = false;
            }
            else
            {
                sb[i] = sb[i].ToLower();
            }
        }
        return sb.ToString();
    }

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings with the first character of each word capitalized and the remaining characters in lowercase, based on the current culture's text info.
    /// </summary>
    /// <param name="strs">The strings to capitalize.</param>
    /// <returns>An enumerable of strings with the first character of each word capitalized and the remaining characters in lowercase, based on the current culture's text info.</returns>
    public static IEnumerable<string> ToCapitalize(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.ToCapitalize();
        }
    }

    /// <summary>
    /// Converts all strings in the specified string list to capitalize form, by modifying the list in-place.
    /// The first character of each word is capitalized and the remaining characters are converted to lowercase, based on the current culture's text info.
    /// </summary>
    /// <param name="strs">The string list to convert to capitalize form.</param>
    public static void ToCapitalizeRef(this IList<string> strs)
    {
        if (strs is not null && strs.Count > 0)
        {
            for (var i = 0; i < strs.Count; i++)
            {
                strs[i] = strs[i].ToCapitalize();
            }
        }
    }

    /// <summary>
    /// Removes excess whitespace characters from the beginning, end, and within the specified string.
    /// Consecutive whitespace characters are reduced to a single space character.
    /// If the input string is null or empty, it is returned unchanged.
    /// </summary>
    /// <param name="str">The string to clean up.</param>
    /// <returns>A string with excess whitespace characters removed and consecutive whitespace characters reduced to a single space character.</returns>
    public static string CleanSpace(this string str)
    {
        if (str.IsNullOrEmpty())
        {
            return str;
        }
        str = str.Trim();
        var sb = new StringBuilder();
        var isWhtSp = false;
        for (var i = 0; i < str.Length; i++)
        {
            if (str[i].IsWhiteSpace())
            {
                if (!isWhtSp)
                {
                    _ = sb.Append(str[i]);
                    isWhtSp = true;
                }
            }
            else
            {
                _ = sb.Append(str[i]);
                isWhtSp = false;
            }
        }
        return sb.ToString();
    }

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings with excess whitespace characters removed from the beginning, end, and within each string.
    /// Consecutive whitespace characters are reduced to a single space character.
    /// </summary>
    /// <param name="strs">The strings to clean up.</param>
    /// <returns>An enumerable of strings with excess whitespace characters removed.</returns>
    public static IEnumerable<string> CleanSpace(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.CleanSpace();
        }
    }

    /// <summary>
    /// Removes excess whitespace characters from the beginning, end, and within each string in the specified list of strings, by modifying the list in-place.
    /// Consecutive whitespace characters are reduced to a single space character.
    /// </summary>
    /// <param name="strs">The list of strings to clean up.</param>
    public static void CleanSpaceRef(this IList<string> strs)
    {
        if (strs is not null && strs.Count > 0)
        {
            for (var i = 0; i < strs.Count; i++)
            {
                strs[i] = strs[i].CleanSpace();
            }
        }
    }

    /// <summary>
    /// Formats the input string as a name by capitalizing the first letter of each word and converting the rest to lowercase, while ignoring punctuation, numbers, and consecutive whitespace characters.
    /// If the input string is empty or consists of only whitespace, it is returned unchanged.
    /// </summary>
    /// <param name="str">The string to format as a name.</param>
    /// <returns>The formatted name string.</returns>
    public static string FormatName(this string str)
    {
        if (str.IsNullOrEmpty())
        {
            return str;
        }
        str = str.Trim();
        var sb = new StringBuilder();
        var isPrevCharWhtSp = true;
        for (var i = 0; i < str.Length; i++)
        {
            if (str[i].IsPunctuation() || str[i].IsNumber() || isPrevCharWhtSp && str[i].IsWhiteSpace())
            {
                continue;
            }
            _ = isPrevCharWhtSp ? sb.Append(str[i].ToUpper()) : sb.Append(str[i].ToLower());
            isPrevCharWhtSp = str[i].IsWhiteSpace();
        }
        return sb.ToString();
    }

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings with each string formatted by filtering out non-alphabetic characters and converting the remaining characters to uppercase, ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="strs">The strings to format by filtering out non-alphabetic characters and converting the remaining characters to uppercase.</param>
    /// <returns>An enumerable of strings with each string formatted by filtering out non-alphabetic characters and converting the remaining characters to uppercase, ignoring their casing, based on their Unicode values using the invariant culture.</returns>
    public static IEnumerable<string> FormatName(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.FormatName();
        }
    }

    /// <summary>
    /// Formats a list of strings in place by filtering out non-alphabetic characters and converting the remaining characters to uppercase, ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="strs">The list of strings to format by filtering out non-alphabetic characters and converting the remaining characters to uppercase.</param>
    public static void FormatNameRef(this IList<string> strs)
    {
        if (strs is not null && strs.Count > 0)
        {
            for (var i = 0; i < strs.Count; i++)
            {
                strs[i] = strs[i].FormatName();
            }
        }
    }

    /// <summary>
    /// Filters out non-alphabetic characters from a string by creating a new string containing only the alphabetic characters, and returns the result.
    /// Empty or null strings are returned as is.
    /// </summary>
    /// <param name="str">The string to filter out non-alphabetic characters from.</param>
    /// <returns>A new string containing only the alphabetic characters from the input string, or the original string if it is empty or null.</returns>
    public static string FilterAlphabetic(this string str)
    {
        if (str.IsNullOrEmpty())
        {
            return str;
        }
        str = str.Trim();
        var sb = new StringBuilder();
        for (var i = 0; i < str.Length; i++)
        {
            if (str[i].IsAlphabetic())
            {
                _ = sb.Append(str[i]);
            }
        }
        return sb.ToString();
    }

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings with all non-alphabetic characters filtered out, based on their Unicode values.
    /// Empty or null strings are returned as is.
    /// </summary>
    /// <param name="strs">The strings to filter out non-alphabetic characters from.</param>
    /// <returns>An enumerable of strings with all non-alphabetic characters filtered out, based on their Unicode values.</returns>
    public static IEnumerable<string> FilterAlphabetic(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.FilterAlphabetic();
        }
    }

    /// <summary>
    /// Filters out all non-alphabetic characters from the strings in the specified list based on their Unicode values.
    /// </summary>
    /// <param name="strs">The list of strings to filter out non-alphabetic characters from.</param>
    public static void FilterAlphabeticRef(this IList<string> strs)
    {
        if (strs is not null && strs.Count > 0)
        {
            for (var i = 0; i < strs.Count; i++)
            {
                strs[i] = strs[i].FilterAlphabetic();
            }
        }
    }

    /// <summary>
    /// Filters out all numeric characters from the string and returns a new string containing only non-numeric characters.
    /// </summary>
    /// <param name="str">The string to filter out numeric characters from.</param>
    /// <returns>A new string containing only non-numeric characters from the original string.</returns>
    public static string FilterNumber(this string str)
    {
        if (str.IsNullOrEmpty())
        {
            return str;
        }
        str = str.Trim();
        var sb = new StringBuilder();
        for (var i = 0; i < str.Length; i++)
        {
            if (str[i].IsNumber())
            {
                _ = sb.Append(str[i]);
            }
        }
        return sb.ToString();
    }

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings with all numeric characters filtered out, based on their Unicode values.
    /// If a string is empty or whitespace, it is returned as-is.
    /// </summary>
    /// <param name="strs">The strings to filter out numeric characters from.</param>
    /// <returns>An enumerable of strings with all numeric characters filtered out, based on their Unicode values.</returns>
    public static IEnumerable<string> FilterNumber(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.FilterNumber();
        }
    }

    /// <summary>
    /// Filters out all numeric characters from the strings in the specified list, based on their Unicode values.
    /// If a string in the list is empty or whitespace, it is left unchanged.
    /// </summary>
    /// <param name="strs">The list of strings to filter out numeric characters from.</param>
    public static void FilterNumberRef(this IList<string> strs)
    {
        if (strs is not null && strs.Count > 0)
        {
            for (var i = 0; i < strs.Count; i++)
            {
                strs[i] = strs[i].FilterNumber();
            }
        }
    }

    /// <summary>
    /// Filters out all non-alphanumeric characters (i.e., characters that are not numbers or letters) from the string, and returns the filtered string.
    /// </summary>
    /// <param name="str">The string to filter out non-alphanumeric characters from.</param>
    /// <returns>The filtered string with only alphanumeric characters.</returns>
    public static string FilterAlphanumeric(this string str)
    {
        if (str.IsNullOrEmpty())
        {
            return str;
        }
        str = str.Trim();
        var sb = new StringBuilder();
        for (var i = 0; i < str.Length; i++)
        {
            if (str[i].IsNumber() || str[i].IsAlphabetic())
            {
                _ = sb.Append(str[i]);
            }
        }
        return sb.ToString();
    }

    /// <summary>
    /// Enumerates through an enumerable of strings and returns a new enumerable of strings with all non-alphanumeric characters (i.e., characters that are not numbers or letters) filtered out.
    /// </summary>
    /// <param name="strs">The strings to filter out non-alphanumeric characters from.</param>
    /// <returns>An enumerable of strings with all non-alphanumeric characters filtered out.</returns>
    public static IEnumerable<string> FilterAlphanumeric(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.FilterAlphanumeric();
        }
    }

    /// <summary>
    /// Modifies the strings in the specified list by filtering out all non-alphanumeric characters (i.e., characters that are not numbers or letters).
    /// </summary>
    /// <param name="strs">The list of strings to filter out non-alphanumeric characters from.</param>
    public static void FilterAlphanumericRef(this IList<string> strs)
    {
        if (strs is not null && strs.Count > 0)
        {
            for (var i = 0; i < strs.Count; i++)
            {
                strs[i] = strs[i].FilterAlphanumeric();
            }
        }
    }
}