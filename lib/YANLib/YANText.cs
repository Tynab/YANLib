using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for text manipulation and validation.
/// </summary>
/// <remarks>
/// This class contains methods for common text operations such as formatting, case conversion, and filtering.
/// It provides a fluent API for working with strings and text data.
/// </remarks>
public static partial class YANText
{
    /// <summary>
    /// Converts the specified string to title case.
    /// </summary>
    /// <param name="input">The string to convert. If <c>null</c> or whitespace, returns the input string.</param>
    /// <returns>A new string in title case.</returns>
    /// <remarks>
    /// This method first converts the string to lowercase, then applies title casing rules according to the current culture.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? Title(this string? input) => input.TitleImplement();

    /// <summary>
    /// Capitalizes the first letter of the specified string and converts the rest to lowercase.
    /// </summary>
    /// <param name="input">The string to capitalize. If <c>null</c> or whitespace, returns the input string.</param>
    /// <returns>A new string with the first letter capitalized and the rest in lowercase.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? Capitalize(this string? input) => input.CapitalizeImplement();

    /// <summary>
    /// Removes extra whitespace from the specified string.
    /// </summary>
    /// <param name="input">The string to clean. If <c>null</c> or empty, returns the input string.</param>
    /// <returns>A new string with normalized whitespace (trimmed and with consecutive whitespace characters replaced by a single space).</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? CleanSpace(this string? input) => input.CleanSpaceImplement();

    /// <summary>
    /// Formats the specified string as a proper name.
    /// </summary>
    /// <param name="input">The string to format. If <c>null</c> or whitespace, returns the input string.</param>
    /// <returns>A new string formatted as a proper name.</returns>
    /// <remarks>
    /// This method removes punctuation, numbers, and normalizes whitespace. It also capitalizes the first letter of each word.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? FormatName(this string? input) => input.FormatNameImplement();

    /// <summary>
    /// Filters the specified string to keep only alphabetic characters.
    /// </summary>
    /// <param name="input">The string to filter. If <c>null</c> or empty, returns the input string.</param>
    /// <returns>A new string containing only alphabetic characters from the input string.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? FilterAlphabetic(this string? input) => input.FilterAlphabeticImplement();

    /// <summary>
    /// Filters the specified string to keep only numeric characters.
    /// </summary>
    /// <param name="input">The string to filter. If <c>null</c> or empty, returns the input string.</param>
    /// <returns>A new string containing only numeric characters from the input string.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? FilterNumber(this string? input) => input.FilterNumberImplement();

    /// <summary>
    /// Filters the specified string to keep only alphanumeric characters.
    /// </summary>
    /// <param name="input">The string to filter. If <c>null</c> or empty, returns the input string.</param>
    /// <returns>A new string containing only alphanumeric characters from the input string.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? FilterAlphanumeric(this string? input) => input.FilterAlphanumericImplement();
}
