using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for string operations including null/empty checking, case conversion, and string comparison.
/// </summary>
/// <remarks>
/// This class contains methods for common string operations such as checking if a string is null or empty,
/// converting case, and performing case-insensitive comparisons. All methods are designed to handle null values safely.
/// </remarks>
public static partial class YANText
{
    #region NullEmpty

    /// <summary>
    /// Determines whether the specified string is <c>null</c> or empty.
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <returns><c>true</c> if the string is <c>null</c> or empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNullEmpty([NotNullWhen(false)] this string? input) => input.IsNullEmptyImplement();

    /// <summary>
    /// Determines whether the specified string is not <c>null</c> and not empty.
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <returns><c>true</c> if the string is not <c>null</c> and not empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNullEmpty([NotNullWhen(true)] this string? input) => input.IsNotNullEmptyImplement();

    #endregion

    #region NullWhiteSpace

    /// <summary>
    /// Determines whether the specified string is <c>null</c>, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <returns><c>true</c> if the string is <c>null</c>, empty, or consists only of white-space characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNullWhiteSpace([NotNullWhen(false)] this string? input) => input.IsNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether the specified string is not <c>null</c>, not empty, and does not consist only of white-space characters.
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <returns><c>true</c> if the string is not <c>null</c>, not empty, and does not consist only of white-space characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNullWhiteSpace([NotNullWhen(true)] this string? input) => input.IsNotNullWhiteSpaceImplement();

    #endregion

    #region EqualsIgnoreCase

    /// <summary>
    /// Determines whether two specified strings are equal, ignoring case.
    /// </summary>
    /// <param name="input1">The first string to compare.</param>
    /// <param name="input2">The second string to compare.</param>
    /// <returns><c>true</c> if the strings are equal, ignoring case; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool EqualsIgnoreCase(this string? input1, string? input2) => input1.EqualsIgnoreCaseImplement(input2);

    /// <summary>
    /// Determines whether two specified strings are not equal, ignoring case.
    /// </summary>
    /// <param name="input1">The first string to compare.</param>
    /// <param name="input2">The second string to compare.</param>
    /// <returns><c>true</c> if the strings are not equal, ignoring case; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool NotEqualsIgnoreCase(this string? input1, string? input2) => input1.NotEqualsIgnoreCaseImplement(input2);

    #endregion

    #region Lower

    /// <summary>
    /// Converts the specified string to lowercase.
    /// </summary>
    /// <param name="input">The string to convert. If <c>null</c> or whitespace, returns the input string.</param>
    /// <returns>The lowercase equivalent of the specified string, or the original string if it is <c>null</c> or whitespace.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? Lower(this string? input) => input.LowerImplement();

    /// <summary>
    /// Converts the specified string to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The string to convert. If <c>null</c> or whitespace, returns the input string.</param>
    /// <returns>The lowercase equivalent of the specified string using the invariant culture, or the original string if it is <c>null</c> or whitespace.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? LowerInvariant(this string? input) => input.LowerInvariantImplement();

    #endregion

    #region Upper

    /// <summary>
    /// Converts the specified string to uppercase.
    /// </summary>
    /// <param name="input">The string to convert. If <c>null</c> or whitespace, returns the input string.</param>
    /// <returns>The uppercase equivalent of the specified string, or the original string if it is <c>null</c> or whitespace.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? Upper(this string? input) => input.UpperImplement();

    /// <summary>
    /// Converts the specified string to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The string to convert. If <c>null</c> or whitespace, returns the input string.</param>
    /// <returns>The uppercase equivalent of the specified string using the invariant culture, or the original string if it is <c>null</c> or whitespace.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? UpperInvariant(this string? input) => input.UpperInvariantImplement();

    #endregion
}
