using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for collections of characters.
/// </summary>
/// <remarks>
/// This partial class extends <see cref="YANText"/> with methods for working with collections of characters.
/// It includes methods for checking if all or any characters in a collection meet certain conditions,
/// and for performing operations on all characters in a collection.
/// </remarks>
public static partial class YANText
{
    #region Empty

    /// <summary>
    /// Determines whether all characters in the specified collection are empty.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllEmpty(this IEnumerable<char>? input) => input.AllEmptyImplement();

    /// <summary>
    /// Determines whether all characters in the specified array are empty.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllEmpty(params char[] input) => input.AllEmptyImplement();

    /// <summary>
    /// Determines whether any character in the specified collection is empty.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyEmpty(this IEnumerable<char>? input) => input.AnyEmptyImplement();

    /// <summary>
    /// Determines whether any character in the specified array is empty.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyEmpty(params char[] input) => input.AnyEmptyImplement();

    /// <summary>
    /// Determines whether all characters in the specified collection are not empty.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are not empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotEmpty(this IEnumerable<char>? input) => input.AllNotEmptyImplement();

    /// <summary>
    /// Determines whether all characters in the specified array are not empty.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are not empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotEmpty(params char[] input) => input.AllNotEmptyImplement();

    /// <summary>
    /// Determines whether any character in the specified collection is not empty.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is not empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotEmpty(this IEnumerable<char>? input) => input.AnyNotEmptyImplement();

    /// <summary>
    /// Determines whether any character in the specified array is not empty.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is not empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotEmpty(params char[] input) => input.AnyNotEmptyImplement();

    #endregion

    #region WhiteSpace

    /// <summary>
    /// Determines whether all characters in the specified collection are white-space characters.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are white-space characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllWhiteSpace(this IEnumerable<char>? input) => input.AllWhiteSpaceImplement();

    /// <summary>
    /// Determines whether all characters in the specified array are white-space characters.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are white-space characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllWhiteSpace(params char[] input) => input.AllWhiteSpaceImplement();

    /// <summary>
    /// Determines whether any character in the specified collection is a white-space character.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is a white-space character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyWhiteSpace(this IEnumerable<char>? input) => input.AnyWhiteSpaceImplement();

    /// <summary>
    /// Determines whether any character in the specified array is a white-space character.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is a white-space character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyWhiteSpace(params char[] input) => input.AnyWhiteSpaceImplement();

    /// <summary>
    /// Determines whether all characters in the specified collection are not white-space characters.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are not white-space characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotWhiteSpace(this IEnumerable<char>? input) => input.AllNotWhiteSpaceImplement();

    /// <summary>
    /// Determines whether all characters in the specified array are not white-space characters.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are not white-space characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotWhiteSpace(params char[] input) => input.AllNotWhiteSpaceImplement();

    /// <summary>
    /// Determines whether any character in the specified collection is not a white-space character.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is not a white-space character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotWhiteSpace(this IEnumerable<char>? input) => input.AnyNotWhiteSpaceImplement();

    /// <summary>
    /// Determines whether any character in the specified array is not a white-space character.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is not a white-space character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotWhiteSpace(params char[] input) => input.AnyNotWhiteSpaceImplement();

    #endregion

    #region WhiteSpaceEmpty

    /// <summary>
    /// Determines whether all characters in the specified collection are empty or white-space characters.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are empty or white-space characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllWhiteSpaceEmpty(this IEnumerable<char>? input) => input.AllWhiteSpaceEmptyImplement();

    /// <summary>
    /// Determines whether all characters in the specified array are empty or white-space characters.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are empty or white-space characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllWhiteSpaceEmpty(params char[] input) => input.AllWhiteSpaceEmptyImplement();

    /// <summary>
    /// Determines whether any character in the specified collection is empty or a white-space character.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is empty or a white-space character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyWhiteSpaceEmpty(this IEnumerable<char>? input) => input.AnyWhiteSpaceEmptyImplement();

    /// <summary>
    /// Determines whether any character in the specified array is empty or a white-space character.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is empty or a white-space character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyWhiteSpaceEmpty(params char[] input) => input.AnyWhiteSpaceEmptyImplement();

    /// <summary>
    /// Determines whether all characters in the specified collection are not empty and not white-space characters.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are not empty and not white-space characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotWhiteSpaceEmpty(this IEnumerable<char>? input) => input.AllNotWhiteSpaceEmptyImplement();

    /// <summary>
    /// Determines whether all characters in the specified array are not empty and not white-space characters.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are not empty and not white-space characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotWhiteSpaceEmpty(params char[] input) => input.AllNotWhiteSpaceEmptyImplement();

    /// <summary>
    /// Determines whether any character in the specified collection is not empty and not a white-space character.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is not empty and not a white-space character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotWhiteSpaceEmpty(this IEnumerable<char>? input) => input.AnyNotWhiteSpaceEmptyImplement();

    /// <summary>
    /// Determines whether any character in the specified array is not empty and not a white-space character.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is not empty and not a white-space character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotWhiteSpaceEmpty(params char[] input) => input.AnyNotWhiteSpaceEmptyImplement();

    #endregion

    #region Alphabetic

    /// <summary>
    /// Determines whether all characters in the specified collection are alphabetic characters.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are alphabetic characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllAlphabetic(this IEnumerable<char>? input) => input.AllAlphabeticImplement();

    /// <summary>
    /// Determines whether all characters in the specified array are alphabetic characters.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are alphabetic characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllAlphabetic(params char[] input) => input.AllAlphabeticImplement();

    /// <summary>
    /// Determines whether any character in the specified collection is an alphabetic character.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is an alphabetic character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyAlphabetic(this IEnumerable<char>? input) => input.AnyAlphabeticImplement();

    /// <summary>
    /// Determines whether any character in the specified array is an alphabetic character.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is an alphabetic character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyAlphabetic(params char[] input) => input.AnyAlphabeticImplement();

    /// <summary>
    /// Determines whether all characters in the specified collection are not alphabetic characters.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are not alphabetic characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotAlphabetic(this IEnumerable<char>? input) => input.AllNotAlphabeticImplement();

    /// <summary>
    /// Determines whether all characters in the specified array are not alphabetic characters.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are not alphabetic characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotAlphabetic(params char[] input) => input.AllNotAlphabeticImplement();

    /// <summary>
    /// Determines whether any character in the specified collection is not an alphabetic character.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is not an alphabetic character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotAlphabetic(this IEnumerable<char>? input) => input.AnyNotAlphabeticImplement();

    /// <summary>
    /// Determines whether any character in the specified array is not an alphabetic character.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is not an alphabetic character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotAlphabetic(params char[] input) => input.AnyNotAlphabeticImplement();

    #endregion

    #region Punctuation

    /// <summary>
    /// Determines whether all characters in the specified collection are punctuation characters.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are punctuation characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPunctuation(this IEnumerable<char>? input) => input.AllPunctuationImplement();

    /// <summary>
    /// Determines whether all characters in the specified array are punctuation characters.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are punctuation characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPunctuation(params char[] input) => input.AllPunctuationImplement();

    /// <summary>
    /// Determines whether any character in the specified collection is a punctuation character.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is a punctuation character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPunctuation(this IEnumerable<char>? input) => input.AnyPunctuationImplement();

    /// <summary>
    /// Determines whether any character in the specified array is a punctuation character.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is a punctuation character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPunctuation(params char[] input) => input.AnyPunctuationImplement();

    /// <summary>
    /// Determines whether all characters in the specified collection are not punctuation characters.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are not punctuation characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotPunctuation(this IEnumerable<char>? input) => input.AllNotPunctuationImplement();

    /// <summary>
    /// Determines whether all characters in the specified array are not punctuation characters.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are not punctuation characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotPunctuation(params char[] input) => input.AllNotPunctuationImplement();

    /// <summary>
    /// Determines whether any character in the specified collection is not a punctuation character.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is not a punctuation character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotPunctuation(this IEnumerable<char>? input) => input.AnyNotPunctuationImplement();

    /// <summary>
    /// Determines whether any character in the specified array is not a punctuation character.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is not a punctuation character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotPunctuation(params char[] input) => input.AnyNotPunctuationImplement();

    #endregion

    #region Number

    /// <summary>
    /// Determines whether all characters in the specified collection are numeric characters.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are numeric characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNumber(this IEnumerable<char>? input) => input.AllNumberImplement();

    /// <summary>
    /// Determines whether all characters in the specified array are numeric characters.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are numeric characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNumber(params char[] input) => input.AllNumberImplement();

    /// <summary>
    /// Determines whether any character in the specified collection is a numeric character.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is a numeric character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNumber(this IEnumerable<char>? input) => input.AnyNumberImplement();

    /// <summary>
    /// Determines whether any character in the specified array is a numeric character.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is a numeric character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNumber(params char[] input) => input.AnyNumberImplement();

    /// <summary>
    /// Determines whether all characters in the specified collection are not numeric characters.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are not numeric characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNumber(this IEnumerable<char>? input) => input.AllNotNumberImplement();

    /// <summary>
    /// Determines whether all characters in the specified array are not numeric characters.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are not numeric characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNumber(params char[] input) => input.AllNotNumberImplement();

    /// <summary>
    /// Determines whether any character in the specified collection is not a numeric character.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is not a numeric character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNumber(this IEnumerable<char>? input) => input.AnyNotNumberImplement();

    /// <summary>
    /// Determines whether any character in the specified array is not a numeric character.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is not a numeric character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNumber(params char[] input) => input.AnyNotNumberImplement();

    #endregion

    #region Alphanumeric

    /// <summary>
    /// Determines whether all characters in the specified collection are alphanumeric characters.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are alphanumeric characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllAlphanumeric(this IEnumerable<char>? input) => input.AllAlphanumericImplement();

    /// <summary>
    /// Determines whether all characters in the specified array are alphanumeric characters.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are alphanumeric characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllAlphanumeric(params char[] input) => input.AllAlphanumericImplement();

    /// <summary>
    /// Determines whether any character in the specified collection is an alphanumeric character.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is an alphanumeric character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyAlphanumeric(this IEnumerable<char>? input) => input.AnyAlphanumericImplement();

    /// <summary>
    /// Determines whether any character in the specified array is an alphanumeric character.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is an alphanumeric character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyAlphanumeric(params char[] input) => input.AnyAlphanumericImplement();

    /// <summary>
    /// Determines whether all characters in the specified collection are not alphanumeric characters.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are not alphanumeric characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotAlphanumeric(this IEnumerable<char>? input) => input.AllNotAlphanumericImplement();

    /// <summary>
    /// Determines whether all characters in the specified array are not alphanumeric characters.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are not alphanumeric characters; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotAlphanumeric(params char[] input) => input.AllNotAlphanumericImplement();

    /// <summary>
    /// Determines whether any character in the specified collection is not an alphanumeric character.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is not an alphanumeric character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotAlphanumeric(this IEnumerable<char>? input) => input.AnyNotAlphanumericImplement();

    /// <summary>
    /// Determines whether any character in the specified array is not an alphanumeric character.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is not an alphanumeric character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotAlphanumeric(params char[] input) => input.AnyNotAlphanumericImplement();

    #endregion

    #region EqualsIgnoreCase

    /// <summary>
    /// Determines whether all characters in the specified collection are equal, ignoring case.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are equal, ignoring case; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllEqualsIgnoreCase(this IEnumerable<char>? input) => input.AllEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether all characters in the specified array are equal, ignoring case.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are equal, ignoring case; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllEqualsIgnoreCase(params char[] input) => input.AllEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether any characters in the specified collection are equal, ignoring case.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any characters are equal, ignoring case; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyEqualsIgnoreCase(this IEnumerable<char>? input) => input.AnyEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether any characters in the specified array are equal, ignoring case.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any characters are equal, ignoring case; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyEqualsIgnoreCase(params char[] input) => input.AnyEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether all characters in the specified collection are not equal, ignoring case.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are not equal, ignoring case; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotEqualsIgnoreCase(this IEnumerable<char>? input) => input.AllNotEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether all characters in the specified array are not equal, ignoring case.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are not equal, ignoring  returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are not equal, ignoring case; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotEqualsIgnoreCase(params char[] input) => input.AllNotEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether any character in the specified collection is not equal to others, ignoring case.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is not equal to others, ignoring case; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotEqualsIgnoreCase(this IEnumerable<char>? input) => input.AnyNotEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether any character in the specified array is not equal to others, ignoring case.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is not equal to others, ignoring case; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotEqualsIgnoreCase(params char[] input) => input.AnyNotEqualsIgnoreCaseImplement();

    #endregion

    #region Lower

    /// <summary>
    /// Converts all characters in the specified list to lowercase.
    /// </summary>
    /// <param name="input">The list to modify. If <c>null</c> or empty, no action is taken.</param>
    /// <remarks>This method modifies the list in-place.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void Lower(this List<char>? input) => input.LowerImplement();

    /// <summary>
    /// Returns a new collection with all characters converted to lowercase.
    /// </summary>
    /// <param name="input">The collection to convert. If <c>null</c> or empty, returns the input collection.</param>
    /// <returns>A new collection with all characters converted to lowercase.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<char>? Lowers(this IEnumerable<char>? input) => input.LowersImplement();

    /// <summary>
    /// Returns a new collection with all characters in the specified array converted to lowercase.
    /// </summary>
    /// <param name="input">The array to convert. If <c>null</c> or empty, returns the input array.</param>
    /// <returns>A new collection with all characters converted to lowercase.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<char>? Lowers(params char[]? input) => input.LowersImplement();

    /// <summary>
    /// Converts all characters in the specified list to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The list to modify. If <c>null</c> or empty, no action is taken.</param>
    /// <remarks>This method modifies the list in-place.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void LowerInvariant(this List<char>? input) => input.LowerInvariantImplement();

    /// <summary>
    /// Returns a new collection with all characters converted to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The collection to convert. If <c>null</c> or empty, returns the input collection.</param>
    /// <returns>A new collection with all characters converted to lowercase using the invariant culture.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<char>? LowerInvariants(this IEnumerable<char>? input) => input.LowerInvariantsImplement();

    /// <summary>
    /// Returns a new collection with all characters in the specified array converted to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The array to convert. If <c>null</c> or empty, returns the input array.</param>
    /// <returns>A new collection with all characters converted to lowercase using the invariant culture.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<char>? LowerInvariants(params char[]? input) => input.LowerInvariantsImplement();

    /// <summary>
    /// Determines whether all characters in the specified collection are lowercase.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are lowercase; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllLowers(this IEnumerable<char>? input) => input.AllLowersImplement();

    /// <summary>
    /// Determines whether all characters in the specified array are lowercase.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are lowercase; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllLowers(params char[] input) => input.AllLowersImplement();

    /// <summary>
    /// Determines whether any character in the specified collection is lowercase.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is lowercase; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyLowers(this IEnumerable<char>? input) => input.AnyLowersImplement();

    /// <summary>
    /// Determines whether any character in the specified array is lowercase.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is lowercase; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyLowers(params char[] input) => input.AnyLowersImplement();

    /// <summary>
    /// Determines whether all characters in the specified collection are not lowercase.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are not lowercase; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotLowers(this IEnumerable<char>? input) => input.AllNotLowersImplement();

    /// <summary>
    /// Determines whether all characters in the specified array are not lowercase.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are not lowercase; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotLowers(params char[] input) => input.AllNotLowersImplement();

    /// <summary>
    /// Determines whether any character in the specified collection is not lowercase.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is not lowercase; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotLowers(this IEnumerable<char>? input) => input.AnyNotLowersImplement();

    /// <summary>
    /// Determines whether any character in the specified array is not lowercase.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is not lowercase; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotLowers(params char[] input) => input.AnyNotLowersImplement();

    #endregion

    #region Upper

    /// <summary>
    /// Converts all characters in the specified list to uppercase.
    /// </summary>
    /// <param name="input">The list to modify. If <c>null</c> or empty, no action is taken.</param>
    /// <remarks>This method modifies the list in-place.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void Upper(this List<char>? input) => input.UpperImplement();

    /// <summary>
    /// Returns a new collection with all characters converted to uppercase.
    /// </summary>
    /// <param name="input">The collection to convert. If <c>null</c> or empty, returns the input collection.</param>
    /// <returns>A new collection with all characters converted to uppercase.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<char>? Uppers(this IEnumerable<char>? input) => input.UppersImplement();

    /// <summary>
    /// Returns a new collection with all characters in the specified array converted to uppercase.
    /// </summary>
    /// <param name="input">The array to convert. If <c>null</c> or empty, returns the input array.</param>
    /// <returns>A new collection with all characters converted to uppercase.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<char>? Uppers(params char[]? input) => input.UppersImplement();

    /// <summary>
    /// Converts all characters in the specified list to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The list to modify. If <c>null</c> or empty, no action is taken.</param>
    /// <remarks>This method modifies the list in-place.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void UpperInvariant(this List<char>? input) => input.UpperInvariantImplement();

    /// <summary>
    /// Returns a new collection with all characters converted to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The collection to convert. If <c>null</c> or empty, returns the input collection.</param>
    /// <returns>A new collection with all characters converted to uppercase using the invariant culture.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<char>? UpperInvariants(this IEnumerable<char>? input) => input.UpperInvariantsImplement();

    /// <summary>
    /// Returns a new collection with all characters in the specified array converted to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The array to convert. If <c>null</c> or empty, returns the input array.</param>
    /// <returns>A new collection with all characters converted to uppercase using the invariant culture.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<char>? UpperInvariants(params char[]? input) => input.UpperInvariantsImplement();

    /// <summary>
    /// Determines whether all characters in the specified collection are uppercase.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are uppercase; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllUppers(this IEnumerable<char>? input) => input.AllUppersImplement();

    /// <summary>
    /// Determines whether all characters in the specified array are uppercase.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are uppercase; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllUppers(params char[] input) => input.AllUppersImplement();

    /// <summary>
    /// Determines whether any character in the specified collection is uppercase.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is uppercase; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyUppers(this IEnumerable<char>? input) => input.AnyUppersImplement();

    /// <summary>
    /// Determines whether any character in the specified array is uppercase.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is uppercase; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyUppers(params char[] input) => input.AnyUppersImplement();

    /// <summary>
    /// Determines whether all characters in the specified collection are not uppercase.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are not uppercase; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotUppers(this IEnumerable<char>? input) => input.AllNotUppersImplement();

    /// <summary>
    /// Determines whether all characters in the specified array are not uppercase.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all characters are not uppercase; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotUppers(params char[] input) => input.AllNotUppersImplement();

    /// <summary>
    /// Determines whether any character in the specified collection is not uppercase.
    /// </summary>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is not uppercase; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotUppers(this IEnumerable<char>? input) => input.AnyNotUppersImplement();

    /// <summary>
    /// Determines whether any character in the specified array is not uppercase.
    /// </summary>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any character is not uppercase; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotUppers(params char[] input) => input.AnyNotUppersImplement();

    #endregion
}
