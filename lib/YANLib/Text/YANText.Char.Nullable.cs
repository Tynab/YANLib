using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using YANLib.Implementation.Text;

namespace YANLib.Text;

public static partial class YANText
{
    /// <summary>
    /// Determines whether the specified nullable character is <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character is <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNullEmpty([NotNullWhen(false)] this char? input) => input.IsNullEmptyImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection are <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullEmpty(this IEnumerable<char?> input) => input.AllNullEmptyImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified array are <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullEmpty(params char?[] input) => input.AllNullEmptyImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified collection is <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullEmpty(this IEnumerable<char?> input) => input.AnyNullEmptyImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified array is <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullEmpty(params char?[] input) => input.AnyNullEmptyImplement();

    /// <summary>
    /// Determines whether the specified nullable character is <see langword="null"/>, empty, or a white-space character.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character is <see langword="null"/>, empty, or a white-space character; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNullWhiteSpace([NotNullWhen(false)] this char? input) => input.IsNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection are <see langword="null"/>, empty, or white-space characters.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/>, empty, or white-space characters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullWhiteSpace(this IEnumerable<char?> input) => input.AllNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified array are <see langword="null"/>, empty, or white-space characters.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/>, empty, or white-space characters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullWhiteSpace(params char?[] input) => input.AllNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified collection is <see langword="null"/>, empty, or a white-space character.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/>, empty, or a white-space character; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullWhiteSpace(this IEnumerable<char?> input) => input.AnyNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified array is <see langword="null"/>, empty, or a white-space character.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/>, empty, or a white-space character; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullWhiteSpace(params char?[] input) => input.AnyNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether the specified nullable character has a value and is a letter.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character has a value and is a letter; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsAlphabetic([NotNullWhen(true)] this char? input) => input.IsAlphabeticImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection have values and are letters.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are letters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllAlphabetic(this IEnumerable<char?> input) => input.AllAlphabeticImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified array have values and are letters.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are letters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllAlphabetic(params char?[] input) => input.AllAlphabeticImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified collection has a value and is a letter.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is a letter; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyAlphabetic(this IEnumerable<char?> input) => input.AnyAlphabeticImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified array has a value and is a letter.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is a letter; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyAlphabetic(params char?[] input) => input.AnyAlphabeticImplement();

    /// <summary>
    /// Determines whether the specified nullable character has a value and is a punctuation mark.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character has a value and is a punctuation mark; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsPunctuation([NotNullWhen(true)] this char? input) => input.IsPunctuationImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection have values and are punctuation marks.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are punctuation marks; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPunctuation(this IEnumerable<char?> input) => input.AllPunctuationImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified array have values and are punctuation marks.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are punctuation marks; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPunctuation(params char?[] input) => input.AllPunctuationImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified collection has a value and is a punctuation mark.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is a punctuation mark; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPunctuation(this IEnumerable<char?> input) => input.AnyPunctuationImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified array has a value and is a punctuation mark.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is a punctuation mark; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPunctuation(params char?[] input) => input.AnyPunctuationImplement();

    /// <summary>
    /// Determines whether the specified nullable character has a value and is a decimal digit.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character has a value and is a decimal digit; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNumber([NotNullWhen(true)] this char? input) => input.IsNumberImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection have values and are decimal digits.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are decimal digits; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNumber(this IEnumerable<char?> input) => input.AllNumberImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified array have values and are decimal digits.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are decimal digits; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNumber(params char?[] input) => input.AllNumberImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified collection has a value and is a decimal digit.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is a decimal digit; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNumber(this IEnumerable<char?> input) => input.AnyNumberImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified array has a value and is a decimal digit.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is a decimal digit; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNumber(params char?[] input) => input.AnyNumberImplement();

    /// <summary>
    /// Determines whether the specified nullable character has a value and is a letter or a digit.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character has a value and is a letter or a digit; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsAlphanumeric(this char? input) => input.IsAlphanumericImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection have values and are letters or digits.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are letters or digits; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllAlphanumeric(this IEnumerable<char?> input) => input.AllAlphanumericImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified array have values and are letters or digits.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are letters or digits; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllAlphanumeric(params char?[] input) => input.AllAlphanumericImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified collection has a value and is a letter or a digit.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is a letter or a digit; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyAlphanumeric(this IEnumerable<char?> input) => input.AnyAlphanumericImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified array has a value and is a letter or a digit.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is a letter or a digit; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyAlphanumeric(params char?[] input) => input.AnyAlphanumericImplement();

    /// <summary>
    /// Determines whether a character and a nullable character are equal, ignoring case.
    /// </summary>
    /// <param name="input1">The character to compare.</param>
    /// <param name="input2">The nullable character to compare.</param>
    /// <returns><see langword="true"/> if the characters are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool EqualsIgnoreCase(this char input1, char? input2) => input1.EqualsIgnoreCaseImplement(input2);

    /// <summary>
    /// Determines whether all nullable characters in the specified collection are equal, ignoring case.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllEqualsIgnoreCase(this IEnumerable<char?> input) => input.AllEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified array are equal, ignoring case.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllEqualsIgnoreCase(params char?[] input) => input.AllEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether any nullable characters in the specified collection are equal, ignoring case.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if any characters are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyEqualsIgnoreCase(this IEnumerable<char?> input) => input.AnyEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether any nullable characters in the specified array are equal, ignoring case.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if any characters are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyEqualsIgnoreCase(params char?[] input) => input.AnyEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether the specified nullable character has a value and is not empty.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character has a value and is not empty; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNullEmpty([NotNullWhen(true)] this char? input) => input.IsNotNullEmptyImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection have values and are not empty.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are not empty; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullEmpty(this IEnumerable<char?> input) => input.AllNotNullEmptyImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified array have values and are not empty.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are not empty; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullEmpty(params char?[] input) => input.AllNotNullEmptyImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified collection has a value and is not empty.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is not empty; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullEmpty(this IEnumerable<char?> input) => input.AnyNotNullEmptyImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified array has a value and is not empty.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is not empty; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullEmpty(params char?[] input) => input.AnyNotNullEmptyImplement();

    /// <summary>
    /// Determines whether the specified nullable character has a value, is not empty, and is not a white-space character.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character has a value, is not empty, and is not a white-space character; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNullWhiteSpace([NotNullWhen(true)] this char? input) => input.IsNotNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection have values, are not empty, and are not white-space characters.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values, are not empty, and are not white-space characters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullWhiteSpace(this IEnumerable<char?> input) => input.AllNotNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified array have values, are not empty, and are not white-space characters.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values, are not empty, and are not white-space characters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullWhiteSpace(params char?[] input) => input.AllNotNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified collection has a value, is not empty, and is not a white-space character.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value, is not empty, and is not a white-space character; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullWhiteSpace(this IEnumerable<char?> input) => input.AnyNotNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified array has a value, is not empty, and is not a white-space character.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value, is not empty, and is not a white-space character; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullWhiteSpace(params char?[] input) => input.AnyNotNullWhiteSpaceImplement();

    /// <summary>
    /// Determines whether the specified nullable character is <see langword="null"/> or not a letter.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character is <see langword="null"/> or not a letter; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotAlphabetic(this char? input) => input.IsNotAlphabeticImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection are <see langword="null"/> or not letters.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or not letters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotAlphabetic(this IEnumerable<char?> input) => input.AllNotAlphabeticImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified array are <see langword="null"/> or not letters.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or not letters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotAlphabetic(params char?[] input) => input.AllNotAlphabeticImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified collection is <see langword="null"/> or not a letter.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or not a letter; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotAlphabetic(this IEnumerable<char?> input) => input.AnyNotAlphabeticImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified array is <see langword="null"/> or not a letter.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or not a letter; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotAlphabetic(params char?[] input) => input.AnyNotAlphabeticImplement();

    /// <summary>
    /// Determines whether the specified nullable character is <see langword="null"/> or not a punctuation mark.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character is <see langword="null"/> or not a punctuation mark; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotPunctuation(this char? input) => input.IsNotPunctuationImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection are <see langword="null"/> or not punctuation marks.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or not punctuation marks; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotPunctuation(this IEnumerable<char?> input) => input.AllNotPunctuationImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified array are <see langword="null"/> or not punctuation marks.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or not punctuation marks; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotPunctuation(params char?[] input) => input.AllNotPunctuationImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified collection is <see langword="null"/> or not a punctuation mark.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or not a punctuation mark; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotPunctuation(this IEnumerable<char?> input) => input.AnyNotPunctuationImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified array is <see langword="null"/> or not a punctuation mark.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or not a punctuation mark; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotPunctuation(params char?[] input) => input.AnyNotPunctuationImplement();

    /// <summary>
    /// Determines whether the specified nullable character is <see langword="null"/> or not a decimal digit.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character is <see langword="null"/> or not a decimal digit; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNumber(this char? input) => input.IsNotNumberImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection are <see langword="null"/> or not decimal digits.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or not decimal digits; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNumber(this IEnumerable<char?> input) => input.AllNotNumberImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified array are <see langword="null"/> or not decimal digits.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or not decimal digits; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNumber(params char?[] input) => input.AllNotNumberImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified collection is <see langword="null"/> or not a decimal digit.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or not a decimal digit; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNumber(this IEnumerable<char?> input) => input.AnyNotNumberImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified array is <see langword="null"/> or not a decimal digit.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or not a decimal digit; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNumber(params char?[] input) => input.AnyNotNumberImplement();

    /// <summary>
    /// Determines whether the specified nullable character is <see langword="null"/> or not a letter or a digit.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character is <see langword="null"/> or not a letter or a digit; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotAlphanumeric(this char? input) => input.IsNotAlphanumericImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection are <see langword="null"/> or not letters or digits.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or not letters or digits; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotAlphanumeric(this IEnumerable<char?> input) => input.AllNotAlphanumericImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified array are <see langword="null"/> or not letters or digits.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or not letters or digits; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotAlphanumeric(params char?[] input) => input.AllNotAlphanumericImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified collection is <see langword="null"/> or not a letter or a digit.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or not a letter or a digit; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotAlphanumeric(this IEnumerable<char?> input) => input.AnyNotAlphanumericImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified array is <see langword="null"/> or not a letter or a digit.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or not a letter or a digit; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotAlphanumeric(params char?[] input) => input.AnyNotAlphanumericImplement();

    /// <summary>
    /// Determines whether two nullable characters are not equal, ignoring case.
    /// </summary>
    /// <param name="input1">The first nullable character to compare.</param>
    /// <param name="input2">The second nullable character to compare.</param>
    /// <returns><see langword="true"/> if the characters are not equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool NotEqualsIgnoreCase(this char? input1, char? input2) => input1.NotEqualsIgnoreCaseImplement(input2);

    /// <summary>
    /// Determines whether all nullable characters in the specified collection are different from each other, ignoring case.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are different from each other, ignoring case; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotEqualsIgnoreCase(this IEnumerable<char?> input) => input.AllNotEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified array are different from each other, ignoring case.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are different from each other, ignoring case; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotEqualsIgnoreCase(params char?[] input) => input.AllNotEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether any nullable characters in the specified collection are not equal to each other, ignoring case.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is not equal to another, ignoring case; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotEqualsIgnoreCase(this IEnumerable<char?> input) => input.AnyNotEqualsIgnoreCaseImplement();

    /// <summary>
    /// Determines whether any nullable characters in the specified array are not equal to each other, ignoring case.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is not equal to another, ignoring case; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotEqualsIgnoreCase(params char?[] input) => input.AnyNotEqualsIgnoreCaseImplement();

    /// <summary>
    /// Converts the specified nullable character to lowercase.
    /// </summary>
    /// <param name="input">The nullable character to convert.</param>
    /// <returns>The lowercase equivalent of the specified character, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static char? Lower(this char? input) => input.LowerImplement();

    /// <summary>
    /// Converts all nullable characters in the specified list to lowercase.
    /// </summary>
    /// <param name="input">The list of nullable characters to convert.</param>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void Lower(this List<char?>? input) => input.LowerImplement();

    /// <summary>
    /// Converts all nullable characters in the specified collection to lowercase.
    /// </summary>
    /// <param name="input">The collection of nullable characters to convert.</param>
    /// <returns>A collection containing the lowercase equivalent of each character in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<char?>? Lowers(this IEnumerable<char?>? input) => input.LowersImplement();

    /// <summary>
    /// Converts all nullable characters in the specified array to lowercase.
    /// </summary>
    /// <param name="input">The array of nullable characters to convert.</param>
    /// <returns>A collection containing the lowercase equivalent of each character in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<char?>? Lowers(params char?[]? input) => input.LowersImplement();

    /// <summary>
    /// Converts the specified nullable character to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The nullable character to convert.</param>
    /// <returns>The lowercase equivalent of the specified character, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static char? LowerInvariant(this char? input) => input.LowerInvariantImplement();

    /// <summary>
    /// Converts all nullable characters in the specified list to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The list of nullable characters to convert.</param>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void LowerInvariant(this List<char?>? input) => input.LowerInvariantImplement();

    /// <summary>
    /// Converts all nullable characters in the specified collection to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The collection of nullable characters to convert.</param>
    /// <returns>A collection containing the lowercase equivalent of each character in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<char?>? LowerInvariants(this IEnumerable<char?>? input) => input.LowerInvariantsImplement();

    /// <summary>
    /// Converts all nullable characters in the specified array to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The array of nullable characters to convert.</param>
    /// <returns>A collection containing the lowercase equivalent of each character in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<char?>? LowerInvariants(params char?[]? input) => input.LowerInvariantsImplement();

    /// <summary>
    /// Converts the specified nullable character to uppercase.
    /// </summary>
    /// <param name="input">The nullable character to convert.</param>
    /// <returns>The uppercase equivalent of the specified character, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static char? Upper(this char? input) => input.UpperImplement();

    /// <summary>
    /// Converts all nullable characters in the specified list to uppercase.
    /// </summary>
    /// <param name="input">The list of nullable characters to convert.</param>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void Upper(this List<char?>? input) => input.UpperImplement();

    /// <summary>
    /// Converts all nullable characters in the specified collection to uppercase.
    /// </summary>
    /// <param name="input">The collection of nullable characters to convert.</param>
    /// <returns>A collection containing the uppercase equivalent of each character in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<char?>? Uppers(this IEnumerable<char?>? input) => input.UppersImplement();

    /// <summary>
    /// Converts all nullable characters in the specified array to uppercase.
    /// </summary>
    /// <param name="input">The array of nullable characters to convert.</param>
    /// <returns>A collection containing the uppercase equivalent of each character in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<char?>? Uppers(params char?[]? input) => input.UppersImplement();

    /// <summary>
    /// Converts the specified nullable character to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The nullable character to convert.</param>
    /// <returns>The uppercase equivalent of the specified character, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static char? UpperInvariant(this char? input) => input.UpperInvariantImplement();

    /// <summary>
    /// Converts all nullable characters in the specified list to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The list of nullable characters to convert.</param>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void UpperInvariant(this List<char?>? input) => input.UpperInvariantImplement();

    /// <summary>
    /// Converts all nullable characters in the specified collection to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The collection of nullable characters to convert.</param>
    /// <returns>A collection containing the uppercase equivalent of each character in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<char?>? UpperInvariants(this IEnumerable<char?>? input) => input.UpperInvariantsImplement();

    /// <summary>
    /// Converts all nullable characters in the specified array to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The array of nullable characters to convert.</param>
    /// <returns>A collection containing the uppercase equivalent of each character in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<char?>? UpperInvariants(params char?[]? input) => input.UpperInvariantsImplement();

    /// <summary>
    /// Determines whether the specified nullable character has a value and is a lowercase letter.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character has a value and is a lowercase letter; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsLower(this char? input) => input.IsLowerImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection have values and are lowercase letters.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are lowercase letters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllLowers(this IEnumerable<char?> input) => input.AllLowersImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified array have values and are lowercase letters.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are lowercase letters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllLowers(params char?[] input) => input.AllLowersImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified collection has a value and is a lowercase letter.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is a lowercase letter; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyLowers(this IEnumerable<char?> input) => input.AnyLowersImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified array has a value and is a lowercase letter.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is a lowercase letter; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyLowers(params char?[] input) => input.AnyLowersImplement();

    /// <summary>
    /// Determines whether the specified nullable character is <see langword="null"/> or not a lowercase letter.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character is <see langword="null"/> or not a lowercase letter; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotLower(this char? input) => input.IsNotLowerImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection are <see langword="null"/> or not lowercase letters.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or not lowercase letters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotLowers(this IEnumerable<char?> input) => input.AllNotLowersImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified array are <see langword="null"/> or not lowercase letters.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or not lowercase letters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotLowers(params char?[] input) => input.AllNotLowersImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified collection is <see langword="null"/> or not a lowercase letter.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or not a lowercase letter; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotLowers(this IEnumerable<char?> input) => input.AnyNotLowersImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified array is <see langword="null"/> or not a lowercase letter.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or not a lowercase letter; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotLowers(params char?[] input) => input.AnyNotLowersImplement();

    /// <summary>
    /// Determines whether the specified nullable character has a value and is an uppercase letter.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character has a value and is an uppercase letter; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsUpper(this char? input) => input.IsUpperImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection have values and are uppercase letters.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are uppercase letters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllUppers(this IEnumerable<char?> input) => input.AllUppersImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified array have values and are uppercase letters.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are uppercase letters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllUppers(params char?[] input) => input.AllUppersImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified collection has a value and is an uppercase letter.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is an uppercase letter; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyUppers(this IEnumerable<char?> input) => input.AnyUppersImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified array has a value and is an uppercase letter.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is an uppercase letter; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyUppers(params char?[] input) => input.AnyUppersImplement();

    /// <summary>
    /// Determines whether the specified nullable character is <see langword="null"/> or not an uppercase letter.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character is <see langword="null"/> or not an uppercase letter; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotUpper(this char? input) => input.IsNotUpperImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection are <see langword="null"/> or not uppercase letters.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or not uppercase letters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotUppers(this IEnumerable<char?> input) => input.AllNotUppersImplement();

    /// <summary>
    /// Determines whether all nullable characters in the specified array are <see langword="null"/> or not uppercase letters.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or not uppercase letters; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotUppers(params char?[] input) => input.AllNotUppersImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified collection is <see langword="null"/> or not an uppercase letter.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or not an uppercase letter; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotUppers(this IEnumerable<char?> input) => input.AnyNotUppersImplement();

    /// <summary>
    /// Determines whether any nullable character in the specified array is <see langword="null"/> or not an uppercase letter.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or not an uppercase letter; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotUppers(params char?[] input) => input.AnyNotUppersImplement();
}
