using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using YANLib.Implementation.Object;
using YANLib.Implementation.Text;

namespace YANLib.Text;

public static partial class YANText
{
    /// <summary>
    /// Determines whether all strings in the specified collection are <see langword="null"/>.
    /// </summary>
    /// <param name="input">The collection of strings to check.</param>
    /// <returns><see langword="true"/> if all strings in the collection are <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNull(this IEnumerable<string?> input) => input.AllNullImplement();

    /// <summary>
    /// Determines whether all strings in the specified array are <see langword="null"/>.
    /// </summary>
    /// <param name="input">The array of strings to check.</param>
    /// <returns><see langword="true"/> if all strings in the array are <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNull(params string?[] input) => input.AllNullImplement();

    /// <summary>
    /// Determines whether any string in the specified collection is <see langword="null"/>.
    /// </summary>
    /// <param name="input">The collection of strings to check.</param>
    /// <returns><see langword="true"/> if any string in the collection is <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNull(this IEnumerable<string?> input) => input.AnyNullImplement();

    /// <summary>
    /// Determines whether any string in the specified array is <see langword="null"/>.
    /// </summary>
    /// <param name="input">The array of strings to check.</param>
    /// <returns><see langword="true"/> if any string in the array is <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNull(params string?[] input) => input.AnyNullImplement();

    /// <summary>
    /// Determines whether the specified string is <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <returns><see langword="true"/> if the string is <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNullEmpty([NotNullWhen(false)] this string? input) => input.IsNullEmptyImplement();

    /// <summary>
    /// Determines whether all strings in the specified collection are <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The collection of strings to check.</param>
    /// <returns><see langword="true"/> if all strings in the collection are <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullEmpty(this IEnumerable<string?> input) => input.AllNullEmptyImplement();

    /// <summary>
    /// Determines whether all strings in the specified array are <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The array of strings to check.</param>
    /// <returns><see langword="true"/> if all strings in the array are <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullEmpty(params string?[] input) => input.AllNullEmptyImplement();

    /// <summary>
    /// Determines whether any string in the specified collection is <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The collection of strings to check.</param>
    /// <returns><see langword="true"/> if any string in the collection is <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullEmpty(this IEnumerable<string?> input) => input.AnyNullEmptyImplement();

    /// <summary>
    /// Determines whether any string in the specified array is <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The array of strings to check.</param>
    /// <returns><see langword="true"/> if any string in the array is <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullEmpty(params string?[] input) => input.AnyNullEmptyImplement();

    /// <summary>
    /// Determines whether the specified string is <see langword="null"/>, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <returns><see langword="true"/> if the string is <see langword="null"/>, empty, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNullWhiteSpace([NotNullWhen(false)] this string? input) => input.IsNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether all strings in the specified collection are <see langword="null"/>, empty, or consist only of white-space characters.
    /// </summary>
    /// <param name="input">The collection of strings to check.</param>
    /// <returns><see langword="true"/> if all strings in the collection are <see langword="null"/>, empty, or consist only of white-space characters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullWhiteSpace(this IEnumerable<string?> input) => input.AllNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether all strings in the specified array are <see langword="null"/>, empty, or consist only of white-space characters.
    /// </summary>
    /// <param name="input">The array of strings to check.</param>
    /// <returns><see langword="true"/> if all strings in the array are <see langword="null"/>, empty, or consist only of white-space characters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullWhiteSpace(params string?[] input) => input.AllNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether any string in the specified collection is <see langword="null"/>, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="input">The collection of strings to check.</param>
    /// <returns><see langword="true"/> if any string in the collection is <see langword="null"/>, empty, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullWhiteSpace(this IEnumerable<string?> input) => input.AnyNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether any string in the specified array is <see langword="null"/>, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="input">The array of strings to check.</param>
    /// <returns><see langword="true"/> if any string in the array is <see langword="null"/>, empty, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullWhiteSpace(params string?[] input) => input.AnyNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether two specified strings are equal, ignoring case.
    /// </summary>
    /// <param name="input1">The first string to compare.</param>
    /// <param name="input2">The second string to compare.</param>
    /// <returns><see langword="true"/> if both strings are <see langword="null"/> or if the strings are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool EqualsIgnoreCase(this string? input1, string? input2) => input1.EqualsIgnoreCaseImplement(input2);

    /// <summary>
    /// Determines whether all strings in the specified collection are equal, ignoring case.
    /// </summary>
    /// <param name="input">The collection of strings to compare.</param>
    /// <returns><see langword="true"/> if all strings in the collection are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllEqualsIgnoreCase(this IEnumerable<string?> input) => input.AllEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether all strings in the specified array are equal, ignoring case.
    /// </summary>
    /// <param name="input">The array of strings to compare.</param>
    /// <returns><see langword="true"/> if all strings in the array are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllEqualsIgnoreCase(params string?[] input) => input.AllEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether any strings in the specified collection are equal, ignoring case.
    /// </summary>
    /// <param name="input">The collection of strings to compare.</param>
    /// <returns><see langword="true"/> if any strings in the collection are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyEqualsIgnoreCase(this IEnumerable<string?> input) => input.AnyEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether any strings in the specified array are equal, ignoring case.
    /// </summary>
    /// <param name="input">The array of strings to compare.</param>
    /// <returns><see langword="true"/> if any strings in the array are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyEqualsIgnoreCase(params string?[] input) => input.AnyEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether all strings in the specified collection are not <see langword="null"/>.
    /// </summary>
    /// <param name="input">The collection of strings to check.</param>
    /// <returns><see langword="true"/> if all strings in the collection are not <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNull(this IEnumerable<string?> input) => input.AllNotNullImplement();

    /// <summary>
    /// Determines whether all strings in the specified array are not <see langword="null"/>.
    /// </summary>
    /// <param name="input">The array of strings to check.</param>
    /// <returns><see langword="true"/> if all strings in the array are not <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNull(params string?[] input) => input.AllNotNullImplement();

    /// <summary>
    /// Determines whether any string in the specified collection is not <see langword="null"/>.
    /// </summary>
    /// <param name="input">The collection of strings to check.</param>
    /// <returns><see langword="true"/> if any string in the collection is not <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNull(this IEnumerable<string?> input) => input.AnyNotNullImplement();

    /// <summary>
    /// Determines whether any string in the specified array is not <see langword="null"/>.
    /// </summary>
    /// <param name="input">The array of strings to check.</param>
    /// <returns><see langword="true"/> if any string in the array is not <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNull(params string?[] input) => input.AnyNotNullImplement();

    /// <summary>
    /// Determines whether the specified string is not <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <returns><see langword="true"/> if the string is not <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNullEmpty([NotNullWhen(true)] this string? input) => input.IsNotNullEmptyImplement();

    /// <summary>
    /// Determines whether all strings in the specified collection are not <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The collection of strings to check.</param>
    /// <returns><see langword="true"/> if all strings in the collection are not <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullEmpty(this IEnumerable<string?> input) => input.AllNotNullEmptyImplement();

    /// <summary>
    /// Determines whether all strings in the specified array are not <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The array of strings to check.</param>
    /// <returns><see langword="true"/> if all strings in the array are not <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullEmpty(params string?[] input) => input.AllNotNullEmptyImplement();

    /// <summary>
    /// Determines whether any string in the specified collection is not <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The collection of strings to check.</param>
    /// <returns><see langword="true"/> if any string in the collection is not <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullEmpty(this IEnumerable<string?> input) => input.AnyNotNullEmptyImplement();

    /// <summary>
    /// Determines whether any string in the specified array is not <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The array of strings to check.</param>
    /// <returns><see langword="true"/> if any string in the array is not <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullEmpty(params string?[] input) => input.AnyNotNullEmptyImplement();

    /// <summary>
    /// Determines whether the specified string is not <see langword="null"/>, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <returns><see langword="true"/> if the string is not <see langword="null"/>, empty, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNullWhiteSpace([NotNullWhen(true)] this string? input) => input.IsNotNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether all strings in the specified collection are not <see langword="null"/>, empty, or consist only of white-space characters.
    /// </summary>
    /// <param name="input">The collection of strings to check.</param>
    /// <returns><see langword="true"/> if all strings in the collection are not <see langword="null"/>, empty, or consist only of white-space characters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullWhiteSpace(this IEnumerable<string?> input) => input.AllNotNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether all strings in the specified array are not <see langword="null"/>, empty, or consist only of white-space characters.
    /// </summary>
    /// <param name="input">The array of strings to check.</param>
    /// <returns><see langword="true"/> if all strings in the array are not <see langword="null"/>, empty, or consist only of white-space characters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullWhiteSpace(params string?[] input) => input.AllNotNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether any string in the specified collection is not <see langword="null"/>, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="input">The collection of strings to check.</param>
    /// <returns><see langword="true"/> if any string in the collection is not <see langword="null"/>, empty, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullWhiteSpace(this IEnumerable<string?> input) => input.AnyNotNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether any string in the specified array is not <see langword="null"/>, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="input">The array of strings to check.</param>
    /// <returns><see langword="true"/> if any string in the array is not <see langword="null"/>, empty, or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullWhiteSpace(params string?[] input) => input.AnyNotNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether two specified strings are not equal, ignoring case.
    /// </summary>
    /// <param name="input1">The first string to compare.</param>
    /// <param name="input2">The second string to compare.</param>
    /// <returns><see langword="true"/> if both strings are not <see langword="null"/> and are not equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool NotEqualsIgnoreCase(this string? input1, string? input2) => input1.NotEqualsIgnoreCaseImplement(input2);

    /// <summary>
    /// Determines whether all strings in the specified collection are not equal to each other, ignoring case.
    /// </summary>
    /// <param name="input">The collection of strings to compare.</param>
    /// <returns><see langword="true"/> if all strings in the collection are not equal to each other, ignoring case; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotEqualsIgnoreCase(this IEnumerable<string?> input) => input.AllNotEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether all strings in the specified array are not equal to each other, ignoring case.
    /// </summary>
    /// <param name="input">The array of strings to compare.</param>
    /// <returns><see langword="true"/> if all strings in the array are not equal to each other, ignoring case; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotEqualsIgnoreCase(params string?[] input) => input.AllNotEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether any strings in the specified collection are not equal to each other, ignoring case.
    /// </summary>
    /// <param name="input">The collection of strings to compare.</param>
    /// <returns><see langword="true"/> if any strings in the collection are not equal to each other, ignoring case; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotEqualsIgnoreCase(this IEnumerable<string?> input) => input.AnyNotEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether any strings in the specified array are not equal to each other, ignoring case.
    /// </summary>
    /// <param name="input">The array of strings to compare.</param>
    /// <returns><see langword="true"/> if any strings in the array are not equal to each other, ignoring case; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotEqualsIgnoreCase(params string?[] input) => input.AnyNotEqualsIgnoreCaseImplement();

    /// <summary>
    /// Converts the specified string to lowercase.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>The lowercase equivalent of the specified string, or <see langword="null"/> if the input is <see langword="null"/>, empty, or consists only of white-space characters.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? Lower(this string? input) => input.LowerImplement();

    /// <summary>
    /// Converts all strings in the specified list to lowercase.
    /// </summary>
    /// <param name="input">The list of strings to convert.</param>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void Lower(this List<string?>? input) => input.LowerImplement();

    /// <summary>
    /// Converts all strings in the specified collection to lowercase.
    /// </summary>
    /// <param name="input">The collection of strings to convert.</param>
    /// <returns>A collection containing the lowercase equivalent of each string in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Lowers(this IEnumerable<string?>? input) => input.LowersImplement();

    /// <summary>
    /// Converts all strings in the specified array to lowercase.
    /// </summary>
    /// <param name="input">The array of strings to convert.</param>
    /// <returns>A collection containing the lowercase equivalent of each string in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Lowers(params string?[]? input) => input.LowersImplement();

    /// <summary>
    /// Converts the specified string to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>The lowercase equivalent of the specified string using the invariant culture, or <see langword="null"/> if the input is <see langword="null"/>, empty, or consists only of white-space characters.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? LowerInvariant(this string? input) => input.LowerInvariantImplement();

    /// <summary>
    /// Converts all strings in the specified list to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The list of strings to convert.</param>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void LowerInvariant(this List<string?>? input) => input.LowerInvariantImplement();

    /// <summary>
    /// Converts all strings in the specified collection to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The collection of strings to convert.</param>
    /// <returns>A collection containing the lowercase equivalent of each string in the input collection using the invariant culture, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? LowerInvariants(this IEnumerable<string?>? input) => input.LowerInvariantsImplement();

    /// <summary>
    /// Converts all strings in the specified array to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The array of strings to convert.</param>
    /// <returns>A collection containing the lowercase equivalent of each string in the input array using the invariant culture, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? LowerInvariants(params string?[]? input) => input.LowerInvariantsImplement();

    /// <summary>
    /// Converts the specified string to uppercase.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>The uppercase equivalent of the specified string, or <see langword="null"/> if the input is <see langword="null"/>, empty, or consists only of white-space characters.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? Upper(this string? input) => input.UpperImplement();

    /// <summary>
    /// Converts all strings in the specified list to uppercase.
    /// </summary>
    /// <param name="input">The list of strings to convert.</param>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void Upper(this List<string?>? input) => input.UpperImplement();

    /// <summary>
    /// Converts all strings in the specified collection to uppercase.
    /// </summary>
    /// <param name="input">The collection of strings to convert.</param>
    /// <returns>A collection containing the uppercase equivalent of each string in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Uppers(this IEnumerable<string?>? input) => input.UppersImplement();

    /// <summary>
    /// Converts all strings in the specified array to uppercase.
    /// </summary>
    /// <param name="input">The array of strings to convert.</param>
    /// <returns>A collection containing the uppercase equivalent of each string in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Uppers(params string?[]? input) => input.UppersImplement();

    /// <summary>
    /// Converts the specified string to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>The uppercase equivalent of the specified string using the invariant culture, or <see langword="null"/> if the input is <see langword="null"/>, empty, or consists only of white-space characters.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? UpperInvariant(this string? input) => input.UpperInvariantImplement();

    /// <summary>
    /// Converts all strings in the specified list to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The list of strings to convert.</param>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void UpperInvariant(this List<string?>? input) => input.UpperInvariantImplement();

    /// <summary>
    /// Converts all strings in the specified collection to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The collection of strings to convert.</param>
    /// <returns>A collection containing the uppercase equivalent of each string in the input collection using the invariant culture, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? UpperInvariants(this IEnumerable<string?>? input) => input.UpperInvariantsImplement();

    /// <summary>
    /// Converts all strings in the specified array to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The array of strings to convert.</param>
    /// <returns>A collection containing the uppercase equivalent of each string in the input array using the invariant culture, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? UpperInvariants(params string?[]? input) => input.UpperInvariantsImplement();
}
