using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for collections of strings to perform bulk string operations and collection-wide checks.
/// </summary>
/// <remarks>
/// This class contains methods for working with collections of strings, including checking if all or any strings
/// meet certain conditions (null, empty, whitespace), comparing strings within collections, and performing case
/// conversions on all strings in a collection. Methods are optimized to use parallel processing for large collections.
/// </remarks>
public static partial class YANText
{
    #region Null

    /// <summary>
    /// Determines whether all strings in the specified collection are <c>null</c>.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all strings are <c>null</c>; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNull(this IEnumerable<string?>? input) => input.AllNullImplement();

    /// <summary>
    /// Determines whether all strings in the specified array are <c>null</c>.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all strings are <c>null</c>; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNull(params string?[] input) => input.AllNullImplement();

    /// <summary>
    /// Determines whether any string in the specified collection is <c>null</c>.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any string is <c>null</c>; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNull(this IEnumerable<string?>? input) => input.AnyNullImplement();

    /// <summary>
    /// Determines whether any string in the specified array is <c>null</c>.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any string is <c>null</c>; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNull(params string?[] input) => input.AnyNullImplement();

    /// <summary>
    /// Determines whether all strings in the specified collection are not <c>null</c>.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all strings are not <c>null</c>; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNull(this IEnumerable<string?>? input) => input.AllNotNullImplement();

    /// <summary>
    /// Determines whether all strings in the specified array are not <c>null</c>.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all strings are not <c>null</c>; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNull(params string?[] input) => input.AllNotNullImplement();

    /// <summary>
    /// Determines whether any string in the specified collection is not <c>null</c>.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any string is not <c>null</c>; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNull(this IEnumerable<string?>? input) => input.AnyNotNullImplement();

    /// <summary>
    /// Determines whether any string in the specified array is not <c>null</c>.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any string is not <c>null</c>; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNull(params string?[] input) => input.AnyNotNullImplement();

    #endregion

    #region NullEmpty

    /// <summary>
    /// Determines whether all strings in the specified collection are <c>null</c> or empty.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all strings are <c>null</c> or empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullEmpty(this IEnumerable<string?>? input) => input.AllNullEmptyImplement();

    /// <summary>
    /// Determines whether all strings in the specified array are <c>null</c> or empty.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all strings are <c>null</c> or empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullEmpty(params string?[]? input) => input.AllNullEmptyImplement();

    /// <summary>
    /// Determines whether any string in the specified collection is <c>null</c> or empty.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any string is <c>null</c> or empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullEmpty(this IEnumerable<string?>? input) => input.AnyNullEmptyImplement();

    /// <summary>
    /// Determines whether any string in the specified array is <c>null</c> or empty.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any string is <c>null</c> or empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullEmpty(params string?[]? input) => input.AnyNullEmptyImplement();

    /// <summary>
    /// Determines whether all strings in the specified collection are not <c>null</c> and not empty.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all strings are not <c>null</c> and not empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullEmpty(this IEnumerable<string?>? input) => input.AllNotNullEmptyImplement();

    /// <summary>
    /// Determines whether all strings in the specified array are not <c>null</c> and not empty.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all strings are not <c>null</c> and not empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullEmpty(params string?[]? input) => input.AllNotNullEmptyImplement();

    /// <summary>
    /// Determines whether any string in the specified collection is not <c>null</c> and not empty.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any string is not <c>null</c> and not empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullEmpty(this IEnumerable<string?>? input) => input.AnyNotNullEmptyImplement();

    /// <summary>
    /// Determines whether any string in the specified array is not <c>null</c> and not empty.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any string is not <c>null</c> and not empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullEmpty(params string?[]? input) => input.AnyNotNullEmptyImplement();

    #endregion

    #region NullWhiteSpace

    /// <summary>
    /// Determines whether all strings in the specified collection are <c>null</c>, empty, or consist only of white-space characters.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all strings are <c>null</c>, empty, or consist only of white-space characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullWhiteSpace(this IEnumerable<string?>? input) => input.AllNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether all strings in the specified array are <c>null</c>, empty, or consist only of white-space characters.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all strings are <c>null</c>, empty, or consist only of white-space characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullWhiteSpace(params string?[] input) => input.AllNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether any string in the specified collection is <c>null</c>, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any string is <c>null</c>, empty, or consists only of white-space characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullWhiteSpace(this IEnumerable<string?>? input) => input.AnyNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether any string in the specified array is <c>null</c>, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any string is <c>null</c>, empty, or consists only of white-space characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullWhiteSpace(params string?[] input) => input.AnyNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether all strings in the specified collection are not <c>null</c>, not empty, and do not consist only of white-space characters.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all strings are not <c>null</c>, not empty, and do not consist only of white-space characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullWhiteSpace(this IEnumerable<string?>? input) => input.AllNotNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether all strings in the specified array are not <c>null</c>, not empty, and do not consist only of white-space characters.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all strings are not <c>null</c>, not empty, and do not consist only of white-space characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullWhiteSpace(params string?[] input) => input.AllNotNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether any string in the specified collection is not <c>null</c>, not empty, and does not consist only of white-space characters.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any string is not <c>null</c>, not empty, and does not consist only of white-space characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullWhiteSpace(this IEnumerable<string?>? input) => input.AnyNotNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether any string in the specified array is not <c>null</c>, not empty, and does not consist only of white-space characters.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any string is not <c>null</c>, not empty, and does not consist only of white-space characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullWhiteSpace(params string?[] input) => input.AnyNotNullWhiteSpaceImplement();

    #endregion

    #region EqualsIgnoreCase

    /// <summary>
    /// Determines whether all strings in the specified collection are equal, ignoring case.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all strings are equal, ignoring case; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllEqualsIgnoreCase(this IEnumerable<string?>? input) => input.AllEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether all strings in the specified array are equal, ignoring case.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all strings are equal, ignoring case; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllEqualsIgnoreCase(params string?[] input) => input.AllEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether any strings in the specified collection are equal, ignoring case.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any strings are equal, ignoring case; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyEqualsIgnoreCase(this IEnumerable<string?>? input) => input.AnyEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether any strings in the specified array are equal, ignoring case.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any strings are equal, ignoring case; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyEqualsIgnoreCase(params string?[] input) => input.AnyEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether all strings in the specified collection are not equal, ignoring case.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all strings are not equal, ignoring case; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotEqualsIgnoreCase(this IEnumerable<string?>? input) => input.AllNotEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether all strings in the specified array are not equal, ignoring case.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all strings are not equal, ignoring case; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotEqualsIgnoreCase(params string?[] input) => input.AllNotEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether any string in the specified collection is not equal to others, ignoring case.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any string is not equal to others, ignoring case; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotEqualsIgnoreCase(this IEnumerable<string?>? input) => input.AnyNotEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether any string in the specified array is not equal to others, ignoring case.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any string is not equal to others, ignoring case; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotEqualsIgnoreCase(params string?[] input) => input.AnyNotEqualsIgnoreCaseImplement();

    #endregion

    #region Lower

    /// <summary>
    /// Converts all strings in the specified list to lowercase.
    /// </summary>
    /// <param name="input">The list to modify. If <c>null</c> or empty, no action is taken.</param>
    /// <remarks>This method modifies the list in-place.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void Lower(this List<string?>? input) => input.LowerImplement();

    /// <summary>
    /// Returns a new collection with all strings converted to lowercase.
    /// </summary>
    /// <param name="input">The collection to convert. If <c>null</c> or empty, returns the input collection.</param>
    /// <returns>A new collection with all strings converted to lowercase.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Lowers(this IEnumerable<string?>? input) => input.LowersImplement();

    /// <summary>
    /// Returns a new collection with all strings in the specified array converted to lowercase.
    /// </summary>
    /// <param name="input">The array to convert. If <c>null</c> or empty, returns the input array.</param>
    /// <returns>A new collection with all strings converted to lowercase.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Lowers(params string?[]? input) => input.LowersImplement();

    /// <summary>
    /// Converts all strings in the specified list to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The list to modify. If <c>null</c> or empty, no action is taken.</param>
    /// <remarks>This method modifies the list in-place.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void LowerInvariant(this List<string?>? input) => input.LowerInvariantImplement();

    /// <summary>
    /// Returns a new collection with all strings converted to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The collection to convert. If <c>null</c> or empty, returns the input collection.</param>
    /// <returns>A new collection with all strings converted to lowercase using the invariant culture.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? LowerInvariants(this IEnumerable<string?>? input) => input.LowerInvariantsImplement();

    /// <summary>
    /// Returns a new collection with all strings in the specified array converted to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The array to convert. If <c>null</c> or empty, returns the input array.</param>
    /// <returns>A new collection with all strings converted to lowercase using the invariant culture.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? LowerInvariants(params string?[]? input) => input.LowerInvariantsImplement();

    #endregion

    #region Upper

    /// <summary>
    /// Converts all strings in the specified list to uppercase.
    /// </summary>
    /// <param name="input">The list to modify. If <c>null</c> or empty, no action is taken.</param>
    /// <remarks>This method modifies the list in-place.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void Upper(this List<string?>? input) => input.UpperImplement();

    /// <summary>
    /// Returns a new collection with all strings converted to uppercase.
    /// </summary>
    /// <param name="input">The collection to convert. If <c>null</c> or empty, returns the input collection.</param>
    /// <returns>A new collection with all strings converted to uppercase.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Uppers(this IEnumerable<string?>? input) => input.UppersImplement();

    /// <summary>
    /// Returns a new collection with all strings in the specified array converted to uppercase.
    /// </summary>
    /// <param name="input">The array to convert. If <c>null</c> or empty, returns the input array.</param>
    /// <returns>A new collection with all strings converted to uppercase.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Uppers(params string?[]? input) => input.UppersImplement();

    /// <summary>
    /// Converts all strings in the specified list to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The list to modify. If <c>null</c> or empty, no action is taken.</param>
    /// <remarks>This method modifies the list in-place.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void UpperInvariant(this List<string?>? input) => input.UpperInvariantImplement();

    /// <summary>
    /// Returns a new collection with all strings converted to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The collection to convert. If <c>null</c> or empty, returns the input collection.</param>
    /// <returns>A new collection with all strings converted to uppercase using the invariant culture.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? UpperInvariants(this IEnumerable<string?>? input) => input.UpperInvariantsImplement();

    /// <summary>
    /// Returns a new collection with all strings in the specified array converted to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The array to convert. If <c>null</c> or empty, returns the input array.</param>
    /// <returns>A new collection with all strings converted to uppercase using the invariant culture.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? UpperInvariants(params string?[]? input) => input.UpperInvariantsImplement();

    #endregion
}
