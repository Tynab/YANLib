using System.Diagnostics;
using YANLib.Implementation.Text;

namespace YANLib.Text;

/// <summary>
/// Provides general text extension methods for manipulating and formatting strings.
/// This includes converting to title case, capitalizing letters, cleaning and normalizing whitespace,
/// formatting names, filtering out non-alphabetic or non-numeric characters, and other utility operations.
/// </summary>
public static partial class YANText
{
    /// <summary>
    /// Converts the specified string to title case.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>The string converted to title case, or <see langword="null"/> if the input is <see langword="null"/>, empty, or consists only of white-space characters.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? Title(this string? input) => input.TitleImplement();

    /// <summary>
    /// Converts all strings in the specified list to title case.
    /// </summary>
    /// <param name="input">The list of strings to convert.</param>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void Title(this List<string?>? input) => input.TitleImplement();

    /// <summary>
    /// Converts all strings in the specified collection to title case.
    /// </summary>
    /// <param name="input">The collection of strings to convert.</param>
    /// <returns>A collection containing the title case equivalent of each string in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Titles(this IEnumerable<string?>? input) => input.TitlesImplement();

    /// <summary>
    /// Converts all strings in the specified array to title case.
    /// </summary>
    /// <param name="input">The array of strings to convert.</param>
    /// <returns>A collection containing the title case equivalent of each string in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Titles(params string?[]? input) => input.TitlesImplement();

    /// <summary>
    /// Capitalizes the first letter of the specified string and converts the rest to lowercase.
    /// </summary>
    /// <param name="input">The string to capitalize.</param>
    /// <returns>The string with the first letter capitalized and the rest in lowercase, or <see langword="null"/> if the input is <see langword="null"/>, empty, or consists only of white-space characters.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? Capitalize(this string? input) => input.CapitalizeImplement();

    /// <summary>
    /// Capitalizes the first letter of each string in the specified list and converts the rest to lowercase.
    /// </summary>
    /// <param name="input">The list of strings to capitalize.</param>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void Capitalize(this List<string?>? input) => input.CapitalizeImplement();

    /// <summary>
    /// Capitalizes the first letter of each string in the specified collection and converts the rest to lowercase.
    /// </summary>
    /// <param name="input">The collection of strings to capitalize.</param>
    /// <returns>A collection containing the capitalized equivalent of each string in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Capitalizes(this IEnumerable<string?>? input) => input.CapitalizesImplement();

    /// <summary>
    /// Capitalizes the first letter of each string in the specified array and converts the rest to lowercase.
    /// </summary>
    /// <param name="input">The array of strings to capitalize.</param>
    /// <returns>A collection containing the capitalized equivalent of each string in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Capitalizes(params string?[]? input) => input.CapitalizesImplement();

    /// <summary>
    /// Normalizes whitespace in the specified string by trimming leading and trailing whitespace and replacing consecutive whitespace characters with a single space.
    /// </summary>
    /// <param name="input">The string to clean.</param>
    /// <returns>The string with normalized whitespace, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? CleanSpace(this string? input) => input.CleanSpaceImplement();

    /// <summary>
    /// Normalizes whitespace in each string in the specified list by trimming leading and trailing whitespace and replacing consecutive whitespace characters with a single space.
    /// </summary>
    /// <param name="input">The list of strings to clean.</param>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void CleanSpace(this List<string?>? input) => input.CleanSpaceImplement();

    /// <summary>
    /// Normalizes whitespace in each string in the specified collection by trimming leading and trailing whitespace and replacing consecutive whitespace characters with a single space.
    /// </summary>
    /// <param name="input">The collection of strings to clean.</param>
    /// <returns>A collection containing the cleaned equivalent of each string in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? CleanSpaces(this IEnumerable<string?>? input) => input.CleanSpacesImplement();

    /// <summary>
    /// Normalizes whitespace in each string in the specified array by trimming leading and trailing whitespace and replacing consecutive whitespace characters with a single space.
    /// </summary>
    /// <param name="input">The array of strings to clean.</param>
    /// <returns>A collection containing the cleaned equivalent of each string in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? CleanSpaces(params string?[]? input) => input.CleanSpacesImplement();

    /// <summary>
    /// Formats the specified string as a name by capitalizing the first letter of each word, removing punctuation and numbers, and normalizing whitespace.
    /// </summary>
    /// <param name="input">The string to format as a name.</param>
    /// <returns>The formatted name, or <see langword="null"/> if the input is <see langword="null"/>, empty, or consists only of white-space characters.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? FormatName(this string? input) => input.FormatNameImplement();

    /// <summary>
    /// Formats each string in the specified list as a name by capitalizing the first letter of each word, removing punctuation and numbers, and normalizing whitespace.
    /// </summary>
    /// <param name="input">The list of strings to format as names.</param>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void FormatName(this List<string?>? input) => input.FormatNameImplement();

    /// <summary>
    /// Formats each string in the specified collection as a name by capitalizing the first letter of each word, removing punctuation and numbers, and normalizing whitespace.
    /// </summary>
    /// <param name="input">The collection of strings to format as names.</param>
    /// <returns>A collection containing the formatted name equivalent of each string in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? FormatNames(this IEnumerable<string?>? input) => input.FormatNamesImplement();

    /// <summary>
    /// Formats each string in the specified array as a name by capitalizing the first letter of each word, removing punctuation and numbers, and normalizing whitespace.
    /// </summary>
    /// <param name="input">The array of strings to format as names.</param>
    /// <returns>A collection containing the formatted name equivalent of each string in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? FormatNames(params string?[]? input) => input.FormatNamesImplement();

    /// <summary>
    /// Removes all non-alphabetic characters from the specified string.
    /// </summary>
    /// <param name="input">The string to filter.</param>
    /// <returns>The string with only alphabetic characters, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? FilterAlphabetic(this string? input) => input.FilterAlphabeticImplement();

    /// <summary>
    /// Removes all non-alphabetic characters from each string in the specified list.
    /// </summary>
    /// <param name="input">The list of strings to filter.</param>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void FilterAlphabetic(this List<string?>? input) => input.FilterAlphabeticImplement();

    /// <summary>
    /// Removes all non-alphabetic characters from each string in the specified collection.
    /// </summary>
    /// <param name="input">The collection of strings to filter.</param>
    /// <returns>A collection containing the filtered equivalent of each string in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? FilterAlphabetics(this IEnumerable<string?>? input) => input.FilterAlphabeticsImplement();

    /// <summary>
    /// Removes all non-alphabetic characters from each string in the specified array.
    /// </summary>
    /// <param name="input">The array of strings to filter.</param>
    /// <returns>A collection containing the filtered equivalent of each string in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? FilterAlphabetics(params string?[]? input) => input.FilterAlphabeticsImplement();

    /// <summary>
    /// Removes all non-numeric characters from the specified string.
    /// </summary>
    /// <param name="input">The string to filter.</param>
    /// <returns>The string with only numeric characters, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? FilterNumber(this string? input) => input.FilterNumberImplement();

    /// <summary>
    /// Removes all non-numeric characters from each string in the specified list.
    /// </summary>
    /// <param name="input">The list of strings to filter.</param>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void FilterNumber(this List<string?>? input) => input.FilterNumberImplement();

    /// <summary>
    /// Removes all non-numeric characters from each string in the specified collection.
    /// </summary>
    /// <param name="input">The collection of strings to filter.</param>
    /// <returns>A collection containing the filtered equivalent of each string in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? FilterNumbers(this IEnumerable<string?>? input) => input.FilterNumbersImplement();

    /// <summary>
    /// Removes all non-numeric characters from each string in the specified array.
    /// </summary>
    /// <param name="input">The array of strings to filter.</param>
    /// <returns>A collection containing the filtered equivalent of each string in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? FilterNumbers(params string?[]? input) => input.FilterNumbersImplement();

    /// <summary>
    /// Removes all non-alphanumeric characters from the specified string.
    /// </summary>
    /// <param name="input">The string to filter.</param>
    /// <returns>The string with only alphanumeric characters, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? FilterAlphanumeric(this string? input) => input.FilterAlphanumericImplement();

    /// <summary>
    /// Removes all non-alphanumeric characters from each string in the specified list.
    /// </summary>
    /// <param name="input">The list of strings to filter.</param>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void FilterAlphanumeric(this List<string?>? input) => input.FilterAlphanumericImplement();

    /// <summary>
    /// Removes all non-alphanumeric characters from each string in the specified collection.
    /// </summary>
    /// <param name="input">The collection of strings to filter.</param>
    /// <returns>A collection containing the filtered equivalent of each string in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? FilterAlphanumerics(this IEnumerable<string?>? input) => input.FilterAlphanumericsImplement();

    /// <summary>
    /// Removes all non-alphanumeric characters from each string in the specified array.
    /// </summary>
    /// <param name="input">The array of strings to filter.</param>
    /// <returns>A collection containing the filtered equivalent of each string in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? FilterAlphanumerics(params string?[]? input) => input.FilterAlphanumericsImplement();
}
