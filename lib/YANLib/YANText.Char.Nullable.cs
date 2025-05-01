using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for nullable character operations and validation.
/// </summary>
/// <remarks>
/// This partial class extends <see cref="YANText"/> with methods for working with nullable characters.
/// It includes methods for checking character types, case conversion, and comparison that handle null values.
/// </remarks>
public static partial class YANText
{
    #region NullEmpty

    /// <summary>
    /// Determines whether the specified nullable character is <c>null</c> or empty.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><c>true</c> if the character is <c>null</c> or empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNullEmpty([NotNullWhen(false)] this char? input) => input.IsNullEmptyImplement();

    /// <summary>
    /// Determines whether the specified nullable character is not <c>null</c> and not empty.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><c>true</c> if the character is not <c>null</c> and not empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNullEmpty([NotNullWhen(true)] this char? input) => input.IsNotNullEmptyImplement();

    #endregion

    #region NullWhiteSpace

    /// <summary>
    /// Determines whether the specified nullable character is <c>null</c>, empty, or a white-space character.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><c>true</c> if the character is <c>null</c>, empty, or a white-space character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNullWhiteSpace([NotNullWhen(false)] this char? input) => input.IsNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether the specified nullable character is not <c>null</c>, not empty, and not a white-space character.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><c>true</c> if the character is not <c>null</c>, not empty, and not a white-space character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNullWhiteSpace([NotNullWhen(true)] this char? input) => input.IsNotNullWhiteSpaceImplement();

    #endregion

    #region Alphabetic

    /// <summary>
    /// Determines whether the specified nullable character is an alphabetic character.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is not null and is an alphabetic character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsAlphabetic([NotNullWhen(true)] this char? input) => input.IsAlphabeticImplement();

    /// <summary>
    /// Determines whether the specified nullable character is not an alphabetic character.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is null or is not an alphabetic character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotAlphabetic(this char? input) => input.IsNotAlphabeticImplement();

    #endregion

    #region Punctuation

    /// <summary>
    /// Determines whether the specified nullable character is a punctuation character.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is not null and is a punctuation character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsPunctuation([NotNullWhen(true)] this char? input) => input.IsPunctuationImplement();

    /// <summary>
    /// Determines whether the specified nullable character is not a punctuation character.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is null or is not a punctuation character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotPunctuation(this char? input) => input.IsNotPunctuationImplement();

    #endregion

    #region Number

    /// <summary>
    /// Determines whether the specified nullable character is a numeric character.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is not null and is a numeric character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNumber([NotNullWhen(true)] this char? input) => input.IsNumberImplement();

    /// <summary>
    /// Determines whether the specified nullable character is not a numeric character.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is null or is not a numeric character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNumber(this char? input) => input.IsNotNumberImplement();

    #endregion

    #region Alphanumeric

    /// <summary>
    /// Determines whether the specified nullable character is an alphanumeric character.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is not null and is an alphanumeric character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsAlphanumeric(this char? input) => input.IsAlphanumericImplement();

    /// <summary>
    /// Determines whether the specified nullable character is not an alphanumeric character.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is null or is not an alphanumeric character; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotAlphanumeric(this char? input) => input.IsNotAlphanumericImplement();

    #endregion

    #region EqualsIgnoreCase

    /// <summary>
    /// Determines whether the specified nullable character is equal to another character, ignoring case.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <param name="other">The character to compare with.</param>
    /// <returns><c>true</c> if the characters are equal, ignoring case; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool EqualsIgnoreCase(this char? input1, char? input2) => input1.EqualsIgnoreCaseImplement(input2);

    /// <summary>
    /// Determines whether the specified nullable character is not equal to another character, ignoring case.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <param name="other">The character to compare with.</param>
    /// <returns><c>true</c> if the characters are not equal, ignoring case; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool NotEqualsIgnoreCase(this char? input1, char? input2) => input1.NotEqualsIgnoreCaseImplement(input2);

    #endregion

    #region Lower

    /// <summary>
    /// Converts the specified nullable character to lowercase.
    /// </summary>
    /// <param name="input">The character to convert.</param>
    /// <returns>The lowercase equivalent of the specified character, or <c>null</c> if the character is <c>null</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static char? Lower(this char? input) => input.LowerImplement();

    /// <summary>
    /// Converts the specified nullable character to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The character to convert.</param>
    /// <returns>The lowercase equivalent of the specified character using the invariant culture, or <c>null</c> if the character is <c>null</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static char? LowerInvariant(this char? input) => input.LowerInvariantImplement();

    /// <summary>
    /// Determines whether the specified nullable character is lowercase.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is not null and is lowercase; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsLower(this char? input) => input.IsLowerImplement();

    /// <summary>
    /// Determines whether the specified nullable character is not lowercase.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is null or is not lowercase; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotLower(this char? input) => input.IsNotLowerImplement();

    #endregion

    #region Upper

    /// <summary>
    /// Converts the specified nullable character to uppercase.
    /// </summary>
    /// <param name="input">The character to convert.</param>
    /// <returns>The uppercase equivalent of the specified character, or <c>null</c> if the character is <c>null</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static char? Upper(this char? input) => input.UpperImplement();

    /// <summary>
    /// Converts the specified nullable character to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The character to convert.</param>
    /// <returns>The uppercase equivalent of the specified character using the invariant culture, or <c>null</c> if the character is <c>null</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static char? UpperInvariant(this char? input) => input.UpperInvariantImplement();

    /// <summary>
    /// Determines whether the specified nullable character is uppercase.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is not null and is uppercase; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsUpper(this char? input) => input.IsUpperImplement();

    /// <summary>
    /// Determines whether the specified nullable character is not uppercase.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><c>true</c> if the character is null or is not uppercase; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotUpper(this char? input) => input.IsNotUpperImplement();

    #endregion
}
