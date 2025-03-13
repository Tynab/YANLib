using System.Text;
using YANLib.Object;
using static System.Globalization.CultureInfo;

namespace YANLib.Text;

public static partial class YANText
{
    /// <summary>
    /// Converts the specified string to title case.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>The string converted to title case, or <see langword="null"/> if the input is <see langword="null"/>, empty, or consists only of white-space characters.</returns>
    public static string? Title(this string? input) => input.IsNullWhiteSpace() ? input : CurrentCulture.TextInfo.ToTitleCase(input.Lower()!);

    /// <summary>
    /// Converts all strings in the specified list to title case.
    /// </summary>
    /// <param name="input">The list of strings to convert.</param>
    public static void Title(this List<string?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        for (var i = 0; i < input.Count; i++)
        {
            input[i] = input[i].Title();
        }
    }

    /// <summary>
    /// Converts all strings in the specified collection to title case.
    /// </summary>
    /// <param name="input">The collection of strings to convert.</param>
    /// <returns>A collection containing the title case equivalent of each string in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? Titles(this IEnumerable<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.Title());

    /// <summary>
    /// Converts all strings in the specified array to title case.
    /// </summary>
    /// <param name="input">The array of strings to convert.</param>
    /// <returns>A collection containing the title case equivalent of each string in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? Titles(params string?[]? input) => input.IsNullEmpty() ? input : input.Select(x => x.Title());

    /// <summary>
    /// Capitalizes the first letter of the specified string and converts the rest to lowercase.
    /// </summary>
    /// <param name="input">The string to capitalize.</param>
    /// <returns>The string with the first letter capitalized and the rest in lowercase, or <see langword="null"/> if the input is <see langword="null"/>, empty, or consists only of white-space characters.</returns>
    public static string? Capitalize(this string? input)
    {
        if (input.IsNullWhiteSpace())
        {
            return input;
        }

        var sb = new StringBuilder(input);
        var isFirstChar = true;

        for (var i = 0; i < sb.Length; i++)
        {
            if (isFirstChar && sb[i].IsAlphabetic())
            {
                sb[i] = sb[i].Upper();
                isFirstChar = false;
            }
            else
            {
                sb[i] = sb[i].Lower();
            }
        }

        return sb.ToString();
    }

    /// <summary>
    /// Capitalizes the first letter of each string in the specified list and converts the rest to lowercase.
    /// </summary>
    /// <param name="input">The list of strings to capitalize.</param>
    public static void Capitalize(this List<string?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        for (var i = 0; i < input.Count; i++)
        {
            input[i] = input[i].Capitalize();
        }
    }

    /// <summary>
    /// Capitalizes the first letter of each string in the specified collection and converts the rest to lowercase.
    /// </summary>
    /// <param name="input">The collection of strings to capitalize.</param>
    /// <returns>A collection containing the capitalized equivalent of each string in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? Capitalizes(this IEnumerable<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.Capitalize());

    /// <summary>
    /// Capitalizes the first letter of each string in the specified array and converts the rest to lowercase.
    /// </summary>
    /// <param name="input">The array of strings to capitalize.</param>
    /// <returns>A collection containing the capitalized equivalent of each string in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? Capitalizes(params string?[]? input) => input.IsNullEmpty() ? input : input.Select(x => x.Capitalize());

    /// <summary>
    /// Normalizes whitespace in the specified string by trimming leading and trailing whitespace and replacing consecutive whitespace characters with a single space.
    /// </summary>
    /// <param name="input">The string to clean.</param>
    /// <returns>The string with normalized whitespace, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static string? CleanSpace(this string? input)
    {
        if (input.IsNullEmpty())
        {
            return input;
        }

        input = input.Trim();

        if (input.IsNullEmpty())
        {
            return input;
        }

        var sb = new StringBuilder(input.Length);
        var isWhiteSpace = false;

        for (var i = 0; i < input.Length; i++)
        {
            if (input[i].IsWhiteSpace())
            {
                if (!isWhiteSpace)
                {
                    _ = sb.Append(' ');
                    isWhiteSpace = true;
                }
            }
            else
            {
                _ = sb.Append(input[i]);
                isWhiteSpace = false;
            }
        }

        return sb.ToString();
    }

    /// <summary>
    /// Normalizes whitespace in each string in the specified list by trimming leading and trailing whitespace and replacing consecutive whitespace characters with a single space.
    /// </summary>
    /// <param name="input">The list of strings to clean.</param>
    public static void CleanSpace(this List<string?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        for (var i = 0; i < input.Count; i++)
        {
            input[i] = input[i].CleanSpace();
        }
    }

    /// <summary>
    /// Normalizes whitespace in each string in the specified collection by trimming leading and trailing whitespace and replacing consecutive whitespace characters with a single space.
    /// </summary>
    /// <param name="input">The collection of strings to clean.</param>
    /// <returns>A collection containing the cleaned equivalent of each string in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? CleanSpaces(this IEnumerable<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.CleanSpace());

    /// <summary>
    /// Normalizes whitespace in each string in the specified array by trimming leading and trailing whitespace and replacing consecutive whitespace characters with a single space.
    /// </summary>
    /// <param name="input">The array of strings to clean.</param>
    /// <returns>A collection containing the cleaned equivalent of each string in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? CleanSpaces(params string?[]? input) => input.IsNullEmpty() ? input : input.Select(x => x.CleanSpace());

    /// <summary>
    /// Formats the specified string as a name by capitalizing the first letter of each word, removing punctuation and numbers, and normalizing whitespace.
    /// </summary>
    /// <param name="input">The string to format as a name.</param>
    /// <returns>The formatted name, or <see langword="null"/> if the input is <see langword="null"/>, empty, or consists only of white-space characters.</returns>
    public static string? FormatName(this string? input)
    {
        if (input.IsNullWhiteSpace())
        {
            return input;
        }

        input = input.Trim();

        var sb = new StringBuilder(input.Length);
        var isPreviousCharWhiteSpace = true;

        for (var i = 0; i < input.Length; i++)
        {
            if (input[i].IsPunctuation())
            {
                _ = sb.Append(' ');
                isPreviousCharWhiteSpace = true;

                continue;
            }

            if (input[i].IsNumber() || isPreviousCharWhiteSpace && input[i].IsWhiteSpace())
            {
                continue;
            }

            _ = isPreviousCharWhiteSpace ? sb.Append(input[i].Upper()) : sb.Append(input[i].Lower());
            isPreviousCharWhiteSpace = input[i].IsWhiteSpace();
        }

        return sb.ToString();
    }

    /// <summary>
    /// Formats each string in the specified list as a name by capitalizing the first letter of each word, removing punctuation and numbers, and normalizing whitespace.
    /// </summary>
    /// <param name="input">The list of strings to format as names.</param>
    public static void FormatName(this List<string?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        for (var i = 0; i < input.Count; i++)
        {
            input[i] = input[i].FormatName();
        }
    }

    /// <summary>
    /// Formats each string in the specified collection as a name by capitalizing the first letter of each word, removing punctuation and numbers, and normalizing whitespace.
    /// </summary>
    /// <param name="input">The collection of strings to format as names.</param>
    /// <returns>A collection containing the formatted name equivalent of each string in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? FormatNames(this IEnumerable<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.FormatName());

    /// <summary>
    /// Formats each string in the specified array as a name by capitalizing the first letter of each word, removing punctuation and numbers, and normalizing whitespace.
    /// </summary>
    /// <param name="input">The array of strings to format as names.</param>
    /// <returns>A collection containing the formatted name equivalent of each string in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? FormatNames(params string?[]? input) => input.IsNullEmpty() ? input : input.Select(x => x.FormatName());

    /// <summary>
    /// Removes all non-alphabetic characters from the specified string.
    /// </summary>
    /// <param name="input">The string to filter.</param>
    /// <returns>The string with only alphabetic characters, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static string? FilterAlphabetic(this string? input)
    {
        if (input.IsNullEmpty())
        {
            return input;
        }

        input = input.Trim();

        if (input.IsNullEmpty())
        {
            return input;
        }

        var sb = new StringBuilder(input.Length);

        for (var i = 0; i < input.Length; i++)
        {
            if (input[i].IsAlphabetic())
            {
                _ = sb.Append(input[i]);
            }
        }

        return sb.ToString();
    }

    /// <summary>
    /// Removes all non-alphabetic characters from each string in the specified list.
    /// </summary>
    /// <param name="input">The list of strings to filter.</param>
    public static void FilterAlphabetic(this List<string?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        for (var i = 0; i < input.Count; i++)
        {
            input[i] = input[i].FilterAlphabetic();
        }
    }

    /// <summary>
    /// Removes all non-alphabetic characters from each string in the specified collection.
    /// </summary>
    /// <param name="input">The collection of strings to filter.</param>
    /// <returns>A collection containing the filtered equivalent of each string in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? FilterAlphabetics(this IEnumerable<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.FilterAlphabetic());

    /// <summary>
    /// Removes all non-alphabetic characters from each string in the specified array.
    /// </summary>
    /// <param name="input">The array of strings to filter.</param>
    /// <returns>A collection containing the filtered equivalent of each string in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? FilterAlphabetics(params string?[]? input) => input.IsNullEmpty() ? input : input.Select(x => x.FilterAlphabetic());

    /// <summary>
    /// Removes all non-numeric characters from the specified string.
    /// </summary>
    /// <param name="input">The string to filter.</param>
    /// <returns>The string with only numeric characters, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static string? FilterNumber(this string? input)
    {
        if (input.IsNullEmpty())
        {
            return input;
        }

        input = input.Trim();

        if (input.IsNullEmpty())
        {
            return input;
        }

        var sb = new StringBuilder(input.Length);

        for (var i = 0; i < input.Length; i++)
        {
            if (input[i].IsNumber())
            {
                _ = sb.Append(input[i]);
            }
        }

        return sb.ToString();
    }

    /// <summary>
    /// Removes all non-numeric characters from each string in the specified list.
    /// </summary>
    /// <param name="input">The list of strings to filter.</param>
    public static void FilterNumber(this List<string?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        for (var i = 0; i < input.Count; i++)
        {
            input[i] = input[i].FilterNumber();
        }
    }

    /// <summary>
    /// Removes all non-numeric characters from each string in the specified collection.
    /// </summary>
    /// <param name="input">The collection of strings to filter.</param>
    /// <returns>A collection containing the filtered equivalent of each string in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? FilterNumbers(this IEnumerable<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.FilterNumber());

    /// <summary>
    /// Removes all non-numeric characters from each string in the specified array.
    /// </summary>
    /// <param name="input">The array of strings to filter.</param>
    /// <returns>A collection containing the filtered equivalent of each string in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? FilterNumbers(params string?[]? input) => input.IsNullEmpty() ? input : input.Select(x => x.FilterNumber());

    /// <summary>
    /// Removes all non-alphanumeric characters from the specified string.
    /// </summary>
    /// <param name="input">The string to filter.</param>
    /// <returns>The string with only alphanumeric characters, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static string? FilterAlphanumeric(this string? input)
    {
        if (input.IsNullEmpty())
        {
            return input;
        }

        input = input.Trim();

        if (input.IsNullEmpty())
        {
            return input;
        }

        var sb = new StringBuilder(input.Length);

        for (var i = 0; i < input.Length; i++)
        {
            if (input[i].IsAlphanumeric())
            {
                _ = sb.Append(input[i]);
            }
        }

        return sb.ToString();
    }

    /// <summary>
    /// Removes all non-alphanumeric characters from each string in the specified list.
    /// </summary>
    /// <param name="input">The list of strings to filter.</param>
    public static void FilterAlphanumeric(this List<string?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        for (var i = 0; i < input.Count; i++)
        {
            input[i] = input[i].FilterAlphanumeric();
        }
    }

    /// <summary>
    /// Removes all non-alphanumeric characters from each string in the specified collection.
    /// </summary>
    /// <param name="input">The collection of strings to filter.</param>
    /// <returns>A collection containing the filtered equivalent of each string in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? FilterAlphanumerics(this IEnumerable<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.FilterAlphanumeric());

    /// <summary>
    /// Removes all non-alphanumeric characters from each string in the specified array.
    /// </summary>
    /// <param name="input">The array of strings to filter.</param>
    /// <returns>A collection containing the filtered equivalent of each string in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? FilterAlphanumerics(params string?[]? input) => input.IsNullEmpty() ? input : input.Select(x => x.FilterAlphanumeric());
}
