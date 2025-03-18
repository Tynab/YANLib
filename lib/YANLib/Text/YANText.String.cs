using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using YANLib.Object;
using static System.Linq.Enumerable;
using static System.StringComparison;

namespace YANLib.Text;

public static partial class YANText
{
    /// <summary>
    /// Determines whether all strings in the specified collection are <see langword="null"/>.
    /// </summary>
    /// <param name="input">The collection of strings to check.</param>
    /// <returns><see langword="true"/> if all strings in the collection are <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool AllNull(this IEnumerable<string?> input) => !input.Any(x => x.IsNotNull());

    /// <summary>
    /// Determines whether all strings in the specified array are <see langword="null"/>.
    /// </summary>
    /// <param name="input">The array of strings to check.</param>
    /// <returns><see langword="true"/> if all strings in the array are <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool AllNull(params string?[] input) => !input.Any(x => x.IsNotNull());

    /// <summary>
    /// Determines whether any string in the specified collection is <see langword="null"/>.
    /// </summary>
    /// <param name="input">The collection of strings to check.</param>
    /// <returns><see langword="true"/> if any string in the collection is <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNull(this IEnumerable<string?> input) => input.Any(x => x.IsNull());

    /// <summary>
    /// Determines whether any string in the specified array is <see langword="null"/>.
    /// </summary>
    /// <param name="input">The array of strings to check.</param>
    /// <returns><see langword="true"/> if any string in the array is <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNull(params string?[] input) => input.Any(x => x.IsNull());

    /// <summary>
    /// Determines whether the specified string is <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <returns><see langword="true"/> if the string is <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullEmpty([NotNullWhen(false)] this string? input) => string.IsNullOrEmpty(input);

    /// <summary>
    /// Determines whether all strings in the specified collection are <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The collection of strings to check.</param>
    /// <returns><see langword="true"/> if all strings in the collection are <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    public static bool AllNullEmpty(this IEnumerable<string?> input) => !input.Any(x => x.IsNotNullEmpty());

    /// <summary>
    /// Determines whether all strings in the specified array are <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The array of strings to check.</param>
    /// <returns><see langword="true"/> if all strings in the array are <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    public static bool AllNullEmpty(params string?[] input) => !input.Any(x => x.IsNotNullEmpty());

    /// <summary>
    /// Determines whether any string in the specified collection is <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The collection of strings to check.</param>
    /// <returns><see langword="true"/> if any string in the collection is <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNullEmpty(this IEnumerable<string?> input) => input.Any(x => x.IsNullEmpty());

    /// <summary>
    /// Determines whether any string in the specified array is <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The array of strings to check.</param>
    /// <returns><see langword="true"/> if any string in the array is <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNullEmpty(params string?[] input) => input.Any(x => x.IsNullEmpty());

    /// <summary>
    /// Determines whether the specified string is <see langword="null"/>, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <returns><see langword="true"/> if the string is <see langword="null"/>, empty, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullWhiteSpace([NotNullWhen(false)] this string? input) => string.IsNullOrWhiteSpace(input);

    /// <summary>
    /// Determines whether all strings in the specified collection are <see langword="null"/>, empty, or consist only of white-space characters.
    /// </summary>
    /// <param name="input">The collection of strings to check.</param>
    /// <returns><see langword="true"/> if all strings in the collection are <see langword="null"/>, empty, or consist only of white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool AllNullWhiteSpace(this IEnumerable<string?> input) => !input.Any(x => x.IsNotNullWhiteSpace());

    /// <summary>
    /// Determines whether all strings in the specified array are <see langword="null"/>, empty, or consist only of white-space characters.
    /// </summary>
    /// <param name="input">The array of strings to check.</param>
    /// <returns><see langword="true"/> if all strings in the array are <see langword="null"/>, empty, or consist only of white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool AllNullWhiteSpace(params string?[] input) => !input.Any(x => x.IsNotNullWhiteSpace());

    /// <summary>
    /// Determines whether any string in the specified collection is <see langword="null"/>, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="input">The collection of strings to check.</param>
    /// <returns><see langword="true"/> if any string in the collection is <see langword="null"/>, empty, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNullWhiteSpace(this IEnumerable<string?> input) => input.Any(x => x.IsNullWhiteSpace());

    /// <summary>
    /// Determines whether any string in the specified array is <see langword="null"/>, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="input">The array of strings to check.</param>
    /// <returns><see langword="true"/> if any string in the array is <see langword="null"/>, empty, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNullWhiteSpace(params string?[] input) => input.Any(x => x.IsNullWhiteSpace());

    /// <summary>
    /// Determines whether two specified strings are equal, ignoring case.
    /// </summary>
    /// <param name="input1">The first string to compare.</param>
    /// <param name="input2">The second string to compare.</param>
    /// <returns><see langword="true"/> if both strings are <see langword="null"/> or if the strings are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool EqualsIgnoreCase(this string? input1, string? input2) => AllNull(input1, input2) || input1.IsNotNull() && input1.IsNotNull() && string.Equals(input1, input2, OrdinalIgnoreCase);

    /// <summary>
    /// Determines whether all strings in the specified collection are equal, ignoring case.
    /// </summary>
    /// <param name="input">The collection of strings to compare.</param>
    /// <returns><see langword="true"/> if all strings in the collection are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool AllEqualsIgnoreCase(this IEnumerable<string?> input) => !input.Any(x => x.NotEqualsIgnoreCase(input.First()));

    /// <summary>
    /// Determines whether all strings in the specified array are equal, ignoring case.
    /// </summary>
    /// <param name="input">The array of strings to compare.</param>
    /// <returns><see langword="true"/> if all strings in the array are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool AllEqualsIgnoreCase(params string?[] input) => !input.Any(x => x.NotEqualsIgnoreCase(input[0]));

    /// <summary>
    /// Determines whether any strings in the specified collection are equal, ignoring case.
    /// </summary>
    /// <param name="input">The collection of strings to compare.</param>
    /// <returns><see langword="true"/> if any strings in the collection are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool AnyEqualsIgnoreCase(this IEnumerable<string?> input) => !input.AllNotEqualsIgnoreCase();

    /// <summary>
    /// Determines whether any strings in the specified array are equal, ignoring case.
    /// </summary>
    /// <param name="input">The array of strings to compare.</param>
    /// <returns><see langword="true"/> if any strings in the array are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool AnyEqualsIgnoreCase(params string?[] input) => !input.AllNotEqualsIgnoreCase();

    /// <summary>
    /// Determines whether all strings in the specified collection are not <see langword="null"/>.
    /// </summary>
    /// <param name="input">The collection of strings to check.</param>
    /// <returns><see langword="true"/> if all strings in the collection are not <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotNull(this IEnumerable<string?> input) => !input.Any(x => x.IsNull());

    /// <summary>
    /// Determines whether all strings in the specified array are not <see langword="null"/>.
    /// </summary>
    /// <param name="input">The array of strings to check.</param>
    /// <returns><see langword="true"/> if all strings in the array are not <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotNull(params string?[] input) => !input.Any(x => x.IsNull());

    /// <summary>
    /// Determines whether any string in the specified collection is not <see langword="null"/>.
    /// </summary>
    /// <param name="input">The collection of strings to check.</param>
    /// <returns><see langword="true"/> if any string in the collection is not <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotNull(this IEnumerable<string?> input) => input.Any(x => x.IsNotNull());

    /// <summary>
    /// Determines whether any string in the specified array is not <see langword="null"/>.
    /// </summary>
    /// <param name="input">The array of strings to check.</param>
    /// <returns><see langword="true"/> if any string in the array is not <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotNull(params string?[] input) => input.Any(x => x.IsNotNull());

    /// <summary>
    /// Determines whether the specified string is not <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <returns><see langword="true"/> if the string is not <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNullEmpty([NotNullWhen(true)] this string? input) => !string.IsNullOrEmpty(input);

    /// <summary>
    /// Determines whether all strings in the specified collection are not <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The collection of strings to check.</param>
    /// <returns><see langword="true"/> if all strings in the collection are not <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotNullEmpty(this IEnumerable<string?> input) => !input.Any(x => x.IsNullEmpty());

    /// <summary>
    /// Determines whether all strings in the specified array are not <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The array of strings to check.</param>
    /// <returns><see langword="true"/> if all strings in the array are not <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotNullEmpty(params string?[] input) => !input.Any(x => x.IsNullEmpty());

    /// <summary>
    /// Determines whether any string in the specified collection is not <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The collection of strings to check.</param>
    /// <returns><see langword="true"/> if any string in the collection is not <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotNullEmpty(this IEnumerable<string?> input) => input.Any(x => x.IsNotNullEmpty());

    /// <summary>
    /// Determines whether any string in the specified array is not <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The array of strings to check.</param>
    /// <returns><see langword="true"/> if any string in the array is not <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotNullEmpty(params string?[] input) => input.Any(x => x.IsNotNullEmpty());

    /// <summary>
    /// Determines whether the specified string is not <see langword="null"/>, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <returns><see langword="true"/> if the string is not <see langword="null"/>, empty, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNullWhiteSpace([NotNullWhen(true)] this string? input) => !string.IsNullOrWhiteSpace(input);

    /// <summary>
    /// Determines whether all strings in the specified collection are not <see langword="null"/>, empty, or consist only of white-space characters.
    /// </summary>
    /// <param name="input">The collection of strings to check.</param>
    /// <returns><see langword="true"/> if all strings in the collection are not <see langword="null"/>, empty, or consist only of white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotNullWhiteSpace(this IEnumerable<string?> input) => !input.Any(x => x.IsNullWhiteSpace());

    /// <summary>
    /// Determines whether all strings in the specified array are not <see langword="null"/>, empty, or consist only of white-space characters.
    /// </summary>
    /// <param name="input">The array of strings to check.</param>
    /// <returns><see langword="true"/> if all strings in the array are not <see langword="null"/>, empty, or consist only of white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotNullWhiteSpace(params string?[] input) => !input.Any(x => x.IsNullWhiteSpace());

    /// <summary>
    /// Determines whether any string in the specified collection is not <see langword="null"/>, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="input">The collection of strings to check.</param>
    /// <returns><see langword="true"/> if any string in the collection is not <see langword="null"/>, empty, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotNullWhiteSpace(this IEnumerable<string?> input) => input.Any(x => x.IsNotNullWhiteSpace());

    /// <summary>
    /// Determines whether any string in the specified array is not <see langword="null"/>, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="input">The array of strings to check.</param>
    /// <returns><see langword="true"/> if any string in the array is not <see langword="null"/>, empty, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotNullWhiteSpace(params string?[] input) => input.Any(x => x.IsNotNullWhiteSpace());

    /// <summary>
    /// Determines whether two specified strings are not equal, ignoring case.
    /// </summary>
    /// <param name="input1">The first string to compare.</param>
    /// <param name="input2">The second string to compare.</param>
    /// <returns><see langword="true"/> if both strings are not <see langword="null"/> and are not equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool NotEqualsIgnoreCase(this string? input1, string? input2) => AllNotNull(input1, input2) && !string.Equals(input1, input2, OrdinalIgnoreCase);

    /// <summary>
    /// Determines whether all strings in the specified collection are not equal to each other, ignoring case.
    /// </summary>
    /// <param name="input">The collection of strings to compare.</param>
    /// <returns><see langword="true"/> if all strings in the collection are not equal to each other, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotEqualsIgnoreCase(this IEnumerable<string?> input)
    {
        var set = new HashSet<string?>(input.Count(), StringComparer.OrdinalIgnoreCase);

        foreach (var str in input)
        {
            if (!set.Add(str))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Determines whether all strings in the specified array are not equal to each other, ignoring case.
    /// </summary>
    /// <param name="input">The array of strings to compare.</param>
    /// <returns><see langword="true"/> if all strings in the array are not equal to each other, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotEqualsIgnoreCase(params string?[] input)
    {
        var set = new HashSet<string?>(StringComparer.OrdinalIgnoreCase);

        for (var i = 0; i < input.Length; i++)
        {
            if (!set.Add(input[i]))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Determines whether any strings in the specified collection are not equal to each other, ignoring case.
    /// </summary>
    /// <param name="input">The collection of strings to compare.</param>
    /// <returns><see langword="true"/> if any strings in the collection are not equal to each other, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotEqualsIgnoreCase(this IEnumerable<string?> input) => !input.AllEqualsIgnoreCase();

    /// <summary>
    /// Determines whether any strings in the specified array are not equal to each other, ignoring case.
    /// </summary>
    /// <param name="input">The array of strings to compare.</param>
    /// <returns><see langword="true"/> if any strings in the array are not equal to each other, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotEqualsIgnoreCase(params string?[] input) => !input.AllEqualsIgnoreCase();

    /// <summary>
    /// Converts the specified string to lowercase.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>The lowercase equivalent of the specified string, or <see langword="null"/> if the input is <see langword="null"/>, empty, or consists only of white-space characters.</returns>
    public static string? Lower(this string? input) => input.IsNullWhiteSpace() ? input : input.ToLower();

    /// <summary>
    /// Converts all strings in the specified list to lowercase.
    /// </summary>
    /// <param name="input">The list of strings to convert.</param>
    public static void Lower(this List<string?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        for (var i = 0; i < input.Count; i++)
        {
            input[i] = input[i].Lower();
        }
    }

    /// <summary>
    /// Converts all strings in the specified collection to lowercase.
    /// </summary>
    /// <param name="input">The collection of strings to convert.</param>
    /// <returns>A collection containing the lowercase equivalent of each string in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? Lowers(this IEnumerable<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.Lower());

    /// <summary>
    /// Converts all strings in the specified array to lowercase.
    /// </summary>
    /// <param name="input">The array of strings to convert.</param>
    /// <returns>A collection containing the lowercase equivalent of each string in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? Lowers(params string?[]? input) => input.IsNullEmpty() ? input : input.Select(x => x.Lower());

    /// <summary>
    /// Converts the specified string to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>The lowercase equivalent of the specified string using the invariant culture, or <see langword="null"/> if the input is <see langword="null"/>, empty, or consists only of white-space characters.</returns>
    public static string? LowerInvariant(this string? input) => input.IsNullWhiteSpace() ? input : input.ToLower(CultureInfo.InvariantCulture);

    /// <summary>
    /// Converts all strings in the specified list to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The list of strings to convert.</param>
    public static void LowerInvariant(this List<string?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        for (var i = 0; i < input.Count; i++)
        {
            input[i] = input[i].LowerInvariant();
        }
    }

    /// <summary>
    /// Converts all strings in the specified collection to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The collection of strings to convert.</param>
    /// <returns>A collection containing the lowercase equivalent of each string in the input collection using the invariant culture, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? LowerInvariants(this IEnumerable<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.LowerInvariant());

    /// <summary>
    /// Converts all strings in the specified array to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The array of strings to convert.</param>
    /// <returns>A collection containing the lowercase equivalent of each string in the input array using the invariant culture, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? LowerInvariants(params string?[]? input) => input.IsNullEmpty() ? input : input.Select(x => x.LowerInvariant());

    /// <summary>
    /// Converts the specified string to uppercase.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>The uppercase equivalent of the specified string, or <see langword="null"/> if the input is <see langword="null"/>, empty, or consists only of white-space characters.</returns>
    public static string? Upper(this string? input) => input.IsNullWhiteSpace() ? input : input.ToUpper();

    /// <summary>
    /// Converts all strings in the specified list to uppercase.
    /// </summary>
    /// <param name="input">The list of strings to convert.</param>
    public static void Upper(this List<string?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        for (var i = 0; i < input.Count; i++)
        {
            input[i] = input[i].Upper();
        }
    }

    /// <summary>
    /// Converts all strings in the specified collection to uppercase.
    /// </summary>
    /// <param name="input">The collection of strings to convert.</param>
    /// <returns>A collection containing the uppercase equivalent of each string in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? Uppers(this IEnumerable<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.Upper());

    /// <summary>
    /// Converts all strings in the specified array to uppercase.
    /// </summary>
    /// <param name="input">The array of strings to convert.</param>
    /// <returns>A collection containing the uppercase equivalent of each string in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? Uppers(params string?[]? input) => input.IsNullEmpty() ? input : input.Select(x => x.Upper());

    /// <summary>
    /// Converts the specified string to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>The uppercase equivalent of the specified string using the invariant culture, or <see langword="null"/> if the input is <see langword="null"/>, empty, or consists only of white-space characters.</returns>
    public static string? UpperInvariant(this string? input) => input.IsNullWhiteSpace() ? input : input.ToUpper(CultureInfo.InvariantCulture);

    /// <summary>
    /// Converts all strings in the specified list to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The list of strings to convert.</param>
    public static void UpperInvariant(this List<string?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        for (var i = 0; i < input.Count; i++)
        {
            input[i] = input[i].UpperInvariant();
        }
    }

    /// <summary>
    /// Converts all strings in the specified collection to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The collection of strings to convert.</param>
    /// <returns>A collection containing the uppercase equivalent of each string in the input collection using the invariant culture, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? UpperInvariants(this IEnumerable<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.UpperInvariant());

    /// <summary>
    /// Converts all strings in the specified array to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The array of strings to convert.</param>
    /// <returns>A collection containing the uppercase equivalent of each string in the input array using the invariant culture, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? UpperInvariants(params string?[]? input) => input.IsNullEmpty() ? input : input.Select(x => x.UpperInvariant());
}
