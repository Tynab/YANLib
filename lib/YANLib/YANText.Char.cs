using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for character operations and validation.
/// </summary>
/// <remarks>
/// This partial class extends <see cref="YANText"/> with methods for working with individual characters.
/// It includes methods for checking character types, case conversion, and comparison.
/// </remarks>
public static partial class YANText
{
    #region Empty

    /// <summary>
    /// Determines whether the specified character is empty (the default character value).
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsEmpty(this char input) => input.IsEmptyImplement();

    /// <summary>
    /// Determines whether the specified character is not empty (not the default character value).
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is not empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotEmpty(this char input) => input.IsNotEmptyImplement();

    #endregion

    #region WhiteSpace

    /// <summary>
    /// Determines whether the specified character is a white-space character.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is a white-space character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsWhiteSpace(this char input) => input.IsWhiteSpaceImplement();

    /// <summary>
    /// Determines whether the specified character is not a white-space character.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is not a white-space character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotWhiteSpace(this char input) => input.IsNotWhiteSpaceImplement();

    #endregion

    #region WhiteSpaceEmpty

    /// <summary>
    /// Determines whether the specified character is empty or a white-space character.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is empty or a white-space character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsWhiteSpaceEmpty(this char input) => input.IsWhiteSpaceEmptyImplement();

    /// <summary>
    /// Determines whether the specified character is not empty and not a white-space character.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is not empty and not a white-space character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotWhiteSpaceEmpty(this char input) => input.IsNotWhiteSpaceEmptyImplement();

    #endregion

    #region Alphabetic

    /// <summary>
    /// Determines whether the specified character is an alphabetic character.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is an alphabetic character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsAlphabetic(this char input) => input.IsAlphabeticImplement();

    /// <summary>
    /// Determines whether the specified character is not an alphabetic character.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is not an alphabetic character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotAlphabetic(this char input) => input.IsNotAlphabeticImplement();

    #endregion

    #region Punctuation

    /// <summary>
    /// Determines whether the specified character is a punctuation character.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is a punctuation character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsPunctuation(this char input) => input.IsPunctuationImplement();

    /// <summary>
    /// Determines whether the specified character is not a punctuation character.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is not a punctuation character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotPunctuation(this char input) => input.IsNotPunctuationImplement();

    #endregion

    #region Number

    /// <summary>
    /// Determines whether the specified character is a numeric character.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is a numeric character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNumber(this char input) => input.IsNumberImplement();

    /// <summary>
    /// Determines whether the specified character is not a numeric character.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is not a numeric character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNumber(this char input) => input.IsNotNumberImplement();

    #endregion

    #region Alphanumeric

    /// <summary>
    /// Determines whether the specified character is an alphanumeric character.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is an alphanumeric character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsAlphanumeric(this char input) => input.IsAlphanumericImplement();

    /// <summary>
    /// Determines whether the specified character is not an alphanumeric character.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is not an alphanumeric character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotAlphanumeric(this char input) => input.IsNotAlphanumericImplement();

    #endregion

    #region EqualsIgnoreCase

    /// <summary>
    /// Determines whether two characters are equal, ignoring case.
    /// </summary>
    /// <param name="input1">The first character to compare.</param>
    /// <param name="input2">The second character to compare.</param>
    /// <returns><c>true</c> if the characters are equal, ignoring case; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool EqualsIgnoreCase(this char input1, char input2) => input1.EqualsIgnoreCaseImplement(input2);

    /// <summary>
    /// Determines whether two characters are not equal, ignoring case.
    /// </summary>
    /// <param name="input1">The first character to compare.</param>
    /// <param name="input2">The second character to compare.</param>
    /// <returns><c>true</c> if the characters are not equal, ignoring case; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool NotEqualsIgnoreCase(this char input1, char input2) => input1.NotEqualsIgnoreCaseImplement(input2);

    #endregion

    #region Lower

    /// <summary>
    /// Converts the specified character to lowercase.
    /// </summary>
    /// <param name="input">The character to convert.</param>
    /// <returns>The lowercase equivalent of the character.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static char Lower(this char input) => input.LowerImplement();

    /// <summary>
    /// Converts the specified character to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The character to convert.</param>
    /// <returns>The lowercase equivalent of the character using the invariant culture.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static char LowerInvariant(this char input) => input.LowerInvariantImplement();

    /// <summary>
    /// Determines whether the specified character is lowercase.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is lowercase; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsLower(this char input) => input.IsLowerImplement();

    /// <summary>
    /// Determines whether the specified character is not lowercase.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is not lowercase; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotLower(this char input) => input.IsNotLowerImplement();

    #endregion

    #region Upper

    /// <summary>
    /// Converts the specified character to uppercase.
    /// </summary>
    /// <param name="input">The character to convert.</param>
    /// <returns>The uppercase equivalent of the character.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static char Upper(this char input) => input.UpperImplement();

    /// <summary>
    /// Converts the specified character to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The character to convert.</param>
    /// <returns>The uppercase equivalent of the character using the invariant culture.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static char UpperInvariant(this char input) => input.UpperInvariantImplement();

    /// <summary>
    /// Determines whether the specified character is uppercase.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is uppercase; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsUpper(this char input) => input.IsUpperImplement();

    /// <summary>
    /// Determines whether the specified character is not uppercase.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is not uppercase; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotUpper(this char input) => input.IsNotUpperImplement();

    #endregion
}
