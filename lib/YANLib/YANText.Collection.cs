using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for collections of strings to perform text transformations and filtering operations.
/// </summary>
/// <remarks>
/// This class contains methods for manipulating collections of strings, including title casing, capitalization,
/// whitespace cleaning, name formatting, and filtering by character type. Methods are provided in both in-place
/// modification (for List&lt;string?&gt;) and functional (returning IEnumerable&lt;string?&gt;) variants.
/// </remarks>
public static partial class YANText
{
    /// <summary>
    /// Converts all strings in the specified list to title case.
    /// </summary>
    /// <param name="input">The list to modify. If <c>null</c> or empty, no action is taken.</param>
    /// <remarks>This method modifies the list in-place.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void Title(this List<string?>? input) => input.TitleImplement();

    /// <summary>
    /// Returns a new collection with all strings converted to title case.
    /// </summary>
    /// <param name="input">The collection to convert. If <c>null</c> or empty, returns the input collection.</param>
    /// <returns>A new collection with all strings converted to title case.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Titles(this IEnumerable<string?>? input) => input.TitlesImplement();

    /// <summary>
    /// Returns a new collection with all strings in the specified array converted to title case.
    /// </summary>
    /// <param name="input">The array to convert. If <c>null</c> or empty, returns the input array.</param>
    /// <returns>A new collection with all strings converted to title case.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Titles(params string?[]? input) => input.TitlesImplement();

    /// <summary>
    /// Capitalizes the first character of each string in the specified list.
    /// </summary>
    /// <param name="input">The list to modify. If <c>null</c> or empty, no action is taken.</param>
    /// <remarks>This method modifies the list in-place.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void Capitalize(this List<string?>? input) => input.CapitalizeImplement();

    /// <summary>
    /// Returns a new collection with the first character of each string capitalized.
    /// </summary>
    /// <param name="input">The collection to convert. If <c>null</c> or empty, returns the input collection.</param>
    /// <returns>A new collection with the first character of each string capitalized.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Capitalizes(this IEnumerable<string?>? input) => input.CapitalizesImplement();

    /// <summary>
    /// Returns a new collection with the first character of each string in the specified array capitalized.
    /// </summary>
    /// <param name="input">The array to convert. If <c>null</c> or empty, returns the input array.</param>
    /// <returns>A new collection with the first character of each string capitalized.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Capitalizes(params string?[]? input) => input.CapitalizesImplement();

    /// <summary>
    /// Removes extra whitespace from each string in the specified list.
    /// </summary>
    /// <param name="input">The list to modify. If <c>null</c> or empty, no action is taken.</param>
    /// <remarks>This method modifies the list in-place.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void CleanSpace(this List<string?>? input) => input.CleanSpaceImplement();

    /// <summary>
    /// Returns a new collection with extra whitespace removed from each string.
    /// </summary>
    /// <param name="input">The collection to clean. If <c>null</c> or empty, returns the input collection.</param>
    /// <returns>A new collection with extra whitespace removed from each string.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? CleanSpaces(this IEnumerable<string?>? input) => input.CleanSpacesImplement();

    /// <summary>
    /// Returns a new collection with extra whitespace removed from each string in the specified array.
    /// </summary>
    /// <param name="input">The array to clean. If <c>null</c> or empty, returns the input array.</param>
    /// <returns>A new collection with extra whitespace removed from each string.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? CleanSpaces(params string?[]? input) => input.CleanSpacesImplement();

    /// <summary>
    /// Formats each string in the specified list as a proper name.
    /// </summary>
    /// <param name="input">The list to modify. If <c>null</c> or empty, no action is taken.</param>
    /// <remarks>This method modifies the list in-place.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void FormatName(this List<string?>? input) => input.FormatNameImplement();

    /// <summary>
    /// Returns a new collection with each string formatted as a proper name.
    /// </summary>
    /// <param name="input">The collection to format. If <c>null</c> or empty, returns the input collection.</param>
    /// <returns>A new collection with each string formatted as a proper name.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? FormatNames(this IEnumerable<string?>? input) => input.FormatNamesImplement();

    /// <summary>
    /// Returns a new collection with each string in the specified array formatted as a proper name.
    /// </summary>
    /// <param name="input">The array to format. If <c>null</c> or empty, returns the input array.</param>
    /// <returns>A new collection with each string formatted as a proper name.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? FormatNames(params string?[]? input) => input.FormatNamesImplement();

    /// <summary>
    /// Filters each string in the specified list to keep only alphabetic characters.
    /// </summary>
    /// <param name="input">The list to modify. If <c>null</c> or empty, no action is taken.</param>
    /// <remarks>This method modifies the list in-place.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void FilterAlphabetic(this List<string?>? input) => input.FilterAlphabeticImplement();

    /// <summary>
    /// Returns a new collection with each string filtered to keep only alphabetic characters.
    /// </summary>
    /// <param name="input">The collection to filter. If <c>null</c> or empty, returns the input collection.</param>
    /// <returns>A new collection with each string filtered to keep only alphabetic characters.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? FilterAlphabetics(this IEnumerable<string?>? input) => input.FilterAlphabeticsImplement();

    /// <summary>
    /// Returns a new collection with each string in the specified array filtered to keep only alphabetic characters.
    /// </summary>
    /// <param name="input">The array to filter. If <c>null</c> or empty, returns the input array.</param>
    /// <returns>A new collection with each string filtered to keep only alphabetic characters.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? FilterAlphabetics(params string?[]? input) => input.FilterAlphabeticsImplement();

    /// <summary>
    /// Filters each string in the specified list to keep only numeric characters.
    /// </summary>
    /// <param name="input">The list to modify. If <c>null</c> or empty, no action is taken.</param>
    /// <remarks>This method modifies the list in-place.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void FilterNumber(this List<string?>? input) => input.FilterNumberImplement();

    /// <summary>
    /// Returns a new collection with each string filtered to keep only numeric characters.
    /// </summary>
    /// <param name="input">The collection to filter. If <c>null</c> or empty, returns the input collection.</param>
    /// <returns>A new collection with each string filtered to keep only numeric characters.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? FilterNumbers(this IEnumerable<string?>? input) => input.FilterNumbersImplement();

    /// <summary>
    /// Returns a new collection with each string in the specified array filtered to keep only numeric characters.
    /// </summary>
    /// <param name="input">The array to filter. If <c>null</c> or empty, returns the input array.</param>
    /// <returns>A new collection with each string filtered to keep only numeric characters.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? FilterNumbers(params string?[]? input) => input.FilterNumbersImplement();

    /// <summary>
    /// Filters each string in the specified list to keep only alphanumeric characters.
    /// </summary>
    /// <param name="input">The list to modify. If <c>null</c> or empty, no action is taken.</param>
    /// <remarks>This method modifies the list in-place.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void FilterAlphanumeric(this List<string?>? input) => input.FilterAlphanumericImplement();

    /// <summary>
    /// Returns a new collection with each string filtered to keep only alphanumeric characters.
    /// </summary>
    /// <param name="input">The collection to filter. If <c>null</c> or empty, returns the input collection.</param>
    /// <returns>A new collection with each string filtered to keep only alphanumeric characters.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? FilterAlphanumerics(this IEnumerable<string?>? input) => input.FilterAlphanumericsImplement();

    /// <summary>
    /// Returns a new collection with each string in the specified array filtered to keep only alphanumeric characters.
    /// </summary>
    /// <param name="input">The array to filter. If <c>null</c> or empty, returns the input array.</param>
    /// <returns>A new collection with each string filtered to keep only alphanumeric characters.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? FilterAlphanumerics(params string?[]? input) => input.FilterAlphanumericsImplement();
}
