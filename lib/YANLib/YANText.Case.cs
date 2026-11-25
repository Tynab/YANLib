using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANText
{
    #region CamelCase

    /// <summary>
    /// Converts the specified string to camelCase: the first word in lower case and every other word starting with an upper-case letter, with no separator.
    /// </summary>
    /// <param name="input">The string to convert. If <c>null</c>, empty or white space, it is returned as is.</param>
    /// <returns>
    /// The camelCase form of the string ("hello world" &#8594; "helloWorld", "HTTPServer" &#8594; "httpServer", "user_id" &#8594; "userId"); the input string itself when nothing changes, an empty string when it
    /// has no letter or digit, or the input when it is <c>null</c>, empty or white space.
    /// </returns>
    /// <remarks>
    /// Words are runs of letters and decimal digits; every other character (white space, <c>_</c>, <c>-</c>, <c>.</c>, ...) separates words
    /// and is dropped, and a combining mark stays with the letter or digit before it. A new word also starts at an upper-case letter whose
    /// last letter before it in the word is lower-case or uncased, digits in between included (<c>helloWorld</c>, <c>version2Update</c>), and
    /// at the last upper-case letter of a run that is followed by a lower-case letter (<c>HTTPServer</c> is <c>HTTP</c> + <c>Server</c>,
    /// <c>HTML5Parser</c> is <c>HTML5</c> + <c>Parser</c>); digits belong to the word before them (<c>FOO123BAR</c> is one word). Letters are
    /// cased with the invariant culture; a letter with no simple invariant case mapping (such as <c>İ</c>, <c>ı</c> or <c>ß</c>) keeps its case.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    [return: NotNullIfNotNull(nameof(input))]
    public static string? CamelCase(this string? input) => input.CamelCaseImplement();

    /// <summary>
    /// Converts every string in the specified list to camelCase, as <see cref="CamelCase(string?)"/> does.
    /// </summary>
    /// <param name="input">The list to modify. If <c>null</c> or empty, no action is taken.</param>
    /// <remarks>This method modifies the list in-place; <c>null</c> elements stay <c>null</c>.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void CamelCase(this List<string?>? input) => input.CamelCaseImplement();

    /// <summary>
    /// Returns the strings of the specified collection converted to camelCase, as <see cref="CamelCase(string?)"/> does, in the input order.
    /// </summary>
    /// <param name="input">The collection to convert. If <c>null</c> or empty, returns the input collection.</param>
    /// <returns>A collection that converts every string to camelCase as it is enumerated (the first element is read at the call, to return an empty input as is); <c>null</c> elements stay <c>null</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? CamelCases(this IEnumerable<string?>? input) => input.CamelCasesImplement();

    /// <summary>
    /// Returns the strings of the specified array converted to camelCase, as <see cref="CamelCase(string?)"/> does, in the input order.
    /// </summary>
    /// <param name="input">The array to convert. If <c>null</c> or empty, returns the input array.</param>
    /// <returns>A collection that converts every string to camelCase as it is enumerated (the first element is read at the call, to return an empty input as is); <c>null</c> elements stay <c>null</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? CamelCases(params string?[]? input) => input.CamelCasesImplement();

    #endregion

    #region PascalCase

    /// <summary>
    /// Converts the specified string to PascalCase: every word starting with an upper-case letter and the rest in lower case, with no separator.
    /// </summary>
    /// <param name="input">The string to convert. If <c>null</c>, empty or white space, it is returned as is.</param>
    /// <returns>
    /// The PascalCase form of the string ("hello world" &#8594; "HelloWorld", "HTTPServer" &#8594; "HttpServer", "user_id" &#8594; "UserId"); the input string itself when nothing changes, an empty string when it
    /// has no letter or digit, or the input when it is <c>null</c>, empty or white space.
    /// </returns>
    /// <remarks>
    /// Words are runs of letters and decimal digits; every other character (white space, <c>_</c>, <c>-</c>, <c>.</c>, ...) separates words
    /// and is dropped, and a combining mark stays with the letter or digit before it. A new word also starts at an upper-case letter whose
    /// last letter before it in the word is lower-case or uncased, digits in between included (<c>helloWorld</c>, <c>version2Update</c>), and
    /// at the last upper-case letter of a run that is followed by a lower-case letter (<c>HTTPServer</c> is <c>HTTP</c> + <c>Server</c>,
    /// <c>HTML5Parser</c> is <c>HTML5</c> + <c>Parser</c>); digits belong to the word before them (<c>FOO123BAR</c> is one word). Letters are
    /// cased with the invariant culture; a letter with no simple invariant case mapping (such as <c>İ</c>, <c>ı</c> or <c>ß</c>) keeps its case.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    [return: NotNullIfNotNull(nameof(input))]
    public static string? PascalCase(this string? input) => input.PascalCaseImplement();

    /// <summary>
    /// Converts every string in the specified list to PascalCase, as <see cref="PascalCase(string?)"/> does.
    /// </summary>
    /// <param name="input">The list to modify. If <c>null</c> or empty, no action is taken.</param>
    /// <remarks>This method modifies the list in-place; <c>null</c> elements stay <c>null</c>.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void PascalCase(this List<string?>? input) => input.PascalCaseImplement();

    /// <summary>
    /// Returns the strings of the specified collection converted to PascalCase, as <see cref="PascalCase(string?)"/> does, in the input order.
    /// </summary>
    /// <param name="input">The collection to convert. If <c>null</c> or empty, returns the input collection.</param>
    /// <returns>A collection that converts every string to PascalCase as it is enumerated (the first element is read at the call, to return an empty input as is); <c>null</c> elements stay <c>null</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? PascalCases(this IEnumerable<string?>? input) => input.PascalCasesImplement();

    /// <summary>
    /// Returns the strings of the specified array converted to PascalCase, as <see cref="PascalCase(string?)"/> does, in the input order.
    /// </summary>
    /// <param name="input">The array to convert. If <c>null</c> or empty, returns the input array.</param>
    /// <returns>A collection that converts every string to PascalCase as it is enumerated (the first element is read at the call, to return an empty input as is); <c>null</c> elements stay <c>null</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? PascalCases(params string?[]? input) => input.PascalCasesImplement();

    #endregion

    #region SnakeLowerCase

    /// <summary>
    /// Converts the specified string to lower snake_case: every word in lower case, separated by an underscore.
    /// </summary>
    /// <param name="input">The string to convert. If <c>null</c>, empty or white space, it is returned as is.</param>
    /// <returns>
    /// The lower snake_case form of the string ("hello world" &#8594; "hello_world", "HTTPServer" &#8594; "http_server", "user-id" &#8594; "user_id"); the input string itself when nothing changes, an empty string when it
    /// has no letter or digit, or the input when it is <c>null</c>, empty or white space.
    /// </returns>
    /// <remarks>
    /// Words are runs of letters and decimal digits; every other character (white space, <c>_</c>, <c>-</c>, <c>.</c>, ...) separates words
    /// and is dropped, and a combining mark stays with the letter or digit before it. A new word also starts at an upper-case letter whose
    /// last letter before it in the word is lower-case or uncased, digits in between included (<c>helloWorld</c>, <c>version2Update</c>), and
    /// at the last upper-case letter of a run that is followed by a lower-case letter (<c>HTTPServer</c> is <c>HTTP</c> + <c>Server</c>,
    /// <c>HTML5Parser</c> is <c>HTML5</c> + <c>Parser</c>); digits belong to the word before them (<c>FOO123BAR</c> is one word). Letters are
    /// cased with the invariant culture; a letter with no simple invariant case mapping (such as <c>İ</c>, <c>ı</c> or <c>ß</c>) keeps its case.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    [return: NotNullIfNotNull(nameof(input))]
    public static string? SnakeLowerCase(this string? input) => input.SnakeLowerCaseImplement();

    /// <summary>
    /// Converts every string in the specified list to lower snake_case, as <see cref="SnakeLowerCase(string?)"/> does.
    /// </summary>
    /// <param name="input">The list to modify. If <c>null</c> or empty, no action is taken.</param>
    /// <remarks>This method modifies the list in-place; <c>null</c> elements stay <c>null</c>.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void SnakeLowerCase(this List<string?>? input) => input.SnakeLowerCaseImplement();

    /// <summary>
    /// Returns the strings of the specified collection converted to lower snake_case, as <see cref="SnakeLowerCase(string?)"/> does, in the input order.
    /// </summary>
    /// <param name="input">The collection to convert. If <c>null</c> or empty, returns the input collection.</param>
    /// <returns>A collection that converts every string to lower snake_case as it is enumerated (the first element is read at the call, to return an empty input as is); <c>null</c> elements stay <c>null</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? SnakeLowerCases(this IEnumerable<string?>? input) => input.SnakeLowerCasesImplement();

    /// <summary>
    /// Returns the strings of the specified array converted to lower snake_case, as <see cref="SnakeLowerCase(string?)"/> does, in the input order.
    /// </summary>
    /// <param name="input">The array to convert. If <c>null</c> or empty, returns the input array.</param>
    /// <returns>A collection that converts every string to lower snake_case as it is enumerated (the first element is read at the call, to return an empty input as is); <c>null</c> elements stay <c>null</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? SnakeLowerCases(params string?[]? input) => input.SnakeLowerCasesImplement();

    #endregion

    #region SnakeUpperCase

    /// <summary>
    /// Converts the specified string to upper SNAKE_CASE: every word in upper case, separated by an underscore.
    /// </summary>
    /// <param name="input">The string to convert. If <c>null</c>, empty or white space, it is returned as is.</param>
    /// <returns>
    /// The upper SNAKE_CASE form of the string ("hello world" &#8594; "HELLO_WORLD", "HTTPServer" &#8594; "HTTP_SERVER", "user-id" &#8594; "USER_ID"); the input string itself when nothing changes, an empty string when it
    /// has no letter or digit, or the input when it is <c>null</c>, empty or white space.
    /// </returns>
    /// <remarks>
    /// Words are runs of letters and decimal digits; every other character (white space, <c>_</c>, <c>-</c>, <c>.</c>, ...) separates words
    /// and is dropped, and a combining mark stays with the letter or digit before it. A new word also starts at an upper-case letter whose
    /// last letter before it in the word is lower-case or uncased, digits in between included (<c>helloWorld</c>, <c>version2Update</c>), and
    /// at the last upper-case letter of a run that is followed by a lower-case letter (<c>HTTPServer</c> is <c>HTTP</c> + <c>Server</c>,
    /// <c>HTML5Parser</c> is <c>HTML5</c> + <c>Parser</c>); digits belong to the word before them (<c>FOO123BAR</c> is one word). Letters are
    /// cased with the invariant culture; a letter with no simple invariant case mapping (such as <c>İ</c>, <c>ı</c> or <c>ß</c>) keeps its case.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    [return: NotNullIfNotNull(nameof(input))]
    public static string? SnakeUpperCase(this string? input) => input.SnakeUpperCaseImplement();

    /// <summary>
    /// Converts every string in the specified list to upper SNAKE_CASE, as <see cref="SnakeUpperCase(string?)"/> does.
    /// </summary>
    /// <param name="input">The list to modify. If <c>null</c> or empty, no action is taken.</param>
    /// <remarks>This method modifies the list in-place; <c>null</c> elements stay <c>null</c>.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void SnakeUpperCase(this List<string?>? input) => input.SnakeUpperCaseImplement();

    /// <summary>
    /// Returns the strings of the specified collection converted to upper SNAKE_CASE, as <see cref="SnakeUpperCase(string?)"/> does, in the input order.
    /// </summary>
    /// <param name="input">The collection to convert. If <c>null</c> or empty, returns the input collection.</param>
    /// <returns>A collection that converts every string to upper SNAKE_CASE as it is enumerated (the first element is read at the call, to return an empty input as is); <c>null</c> elements stay <c>null</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? SnakeUpperCases(this IEnumerable<string?>? input) => input.SnakeUpperCasesImplement();

    /// <summary>
    /// Returns the strings of the specified array converted to upper SNAKE_CASE, as <see cref="SnakeUpperCase(string?)"/> does, in the input order.
    /// </summary>
    /// <param name="input">The array to convert. If <c>null</c> or empty, returns the input array.</param>
    /// <returns>A collection that converts every string to upper SNAKE_CASE as it is enumerated (the first element is read at the call, to return an empty input as is); <c>null</c> elements stay <c>null</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? SnakeUpperCases(params string?[]? input) => input.SnakeUpperCasesImplement();

    #endregion

    #region KebabLowerCase

    /// <summary>
    /// Converts the specified string to lower kebab-case: every word in lower case, separated by a hyphen.
    /// </summary>
    /// <param name="input">The string to convert. If <c>null</c>, empty or white space, it is returned as is.</param>
    /// <returns>
    /// The lower kebab-case form of the string ("hello world" &#8594; "hello-world", "HTTPServer" &#8594; "http-server", "user_id" &#8594; "user-id"); the input string itself when nothing changes, an empty string when it
    /// has no letter or digit, or the input when it is <c>null</c>, empty or white space.
    /// </returns>
    /// <remarks>
    /// Words are runs of letters and decimal digits; every other character (white space, <c>_</c>, <c>-</c>, <c>.</c>, ...) separates words
    /// and is dropped, and a combining mark stays with the letter or digit before it. A new word also starts at an upper-case letter whose
    /// last letter before it in the word is lower-case or uncased, digits in between included (<c>helloWorld</c>, <c>version2Update</c>), and
    /// at the last upper-case letter of a run that is followed by a lower-case letter (<c>HTTPServer</c> is <c>HTTP</c> + <c>Server</c>,
    /// <c>HTML5Parser</c> is <c>HTML5</c> + <c>Parser</c>); digits belong to the word before them (<c>FOO123BAR</c> is one word). Letters are
    /// cased with the invariant culture; a letter with no simple invariant case mapping (such as <c>İ</c>, <c>ı</c> or <c>ß</c>) keeps its case.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    [return: NotNullIfNotNull(nameof(input))]
    public static string? KebabLowerCase(this string? input) => input.KebabLowerCaseImplement();

    /// <summary>
    /// Converts every string in the specified list to lower kebab-case, as <see cref="KebabLowerCase(string?)"/> does.
    /// </summary>
    /// <param name="input">The list to modify. If <c>null</c> or empty, no action is taken.</param>
    /// <remarks>This method modifies the list in-place; <c>null</c> elements stay <c>null</c>.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void KebabLowerCase(this List<string?>? input) => input.KebabLowerCaseImplement();

    /// <summary>
    /// Returns the strings of the specified collection converted to lower kebab-case, as <see cref="KebabLowerCase(string?)"/> does, in the input order.
    /// </summary>
    /// <param name="input">The collection to convert. If <c>null</c> or empty, returns the input collection.</param>
    /// <returns>A collection that converts every string to lower kebab-case as it is enumerated (the first element is read at the call, to return an empty input as is); <c>null</c> elements stay <c>null</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? KebabLowerCases(this IEnumerable<string?>? input) => input.KebabLowerCasesImplement();

    /// <summary>
    /// Returns the strings of the specified array converted to lower kebab-case, as <see cref="KebabLowerCase(string?)"/> does, in the input order.
    /// </summary>
    /// <param name="input">The array to convert. If <c>null</c> or empty, returns the input array.</param>
    /// <returns>A collection that converts every string to lower kebab-case as it is enumerated (the first element is read at the call, to return an empty input as is); <c>null</c> elements stay <c>null</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? KebabLowerCases(params string?[]? input) => input.KebabLowerCasesImplement();

    #endregion

    #region KebabUpperCase

    /// <summary>
    /// Converts the specified string to upper KEBAB-CASE: every word in upper case, separated by a hyphen.
    /// </summary>
    /// <param name="input">The string to convert. If <c>null</c>, empty or white space, it is returned as is.</param>
    /// <returns>
    /// The upper KEBAB-CASE form of the string ("hello world" &#8594; "HELLO-WORLD", "HTTPServer" &#8594; "HTTP-SERVER", "user_id" &#8594; "USER-ID"); the input string itself when nothing changes, an empty string when it
    /// has no letter or digit, or the input when it is <c>null</c>, empty or white space.
    /// </returns>
    /// <remarks>
    /// Words are runs of letters and decimal digits; every other character (white space, <c>_</c>, <c>-</c>, <c>.</c>, ...) separates words
    /// and is dropped, and a combining mark stays with the letter or digit before it. A new word also starts at an upper-case letter whose
    /// last letter before it in the word is lower-case or uncased, digits in between included (<c>helloWorld</c>, <c>version2Update</c>), and
    /// at the last upper-case letter of a run that is followed by a lower-case letter (<c>HTTPServer</c> is <c>HTTP</c> + <c>Server</c>,
    /// <c>HTML5Parser</c> is <c>HTML5</c> + <c>Parser</c>); digits belong to the word before them (<c>FOO123BAR</c> is one word). Letters are
    /// cased with the invariant culture; a letter with no simple invariant case mapping (such as <c>İ</c>, <c>ı</c> or <c>ß</c>) keeps its case.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    [return: NotNullIfNotNull(nameof(input))]
    public static string? KebabUpperCase(this string? input) => input.KebabUpperCaseImplement();

    /// <summary>
    /// Converts every string in the specified list to upper KEBAB-CASE, as <see cref="KebabUpperCase(string?)"/> does.
    /// </summary>
    /// <param name="input">The list to modify. If <c>null</c> or empty, no action is taken.</param>
    /// <remarks>This method modifies the list in-place; <c>null</c> elements stay <c>null</c>.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void KebabUpperCase(this List<string?>? input) => input.KebabUpperCaseImplement();

    /// <summary>
    /// Returns the strings of the specified collection converted to upper KEBAB-CASE, as <see cref="KebabUpperCase(string?)"/> does, in the input order.
    /// </summary>
    /// <param name="input">The collection to convert. If <c>null</c> or empty, returns the input collection.</param>
    /// <returns>A collection that converts every string to upper KEBAB-CASE as it is enumerated (the first element is read at the call, to return an empty input as is); <c>null</c> elements stay <c>null</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? KebabUpperCases(this IEnumerable<string?>? input) => input.KebabUpperCasesImplement();

    /// <summary>
    /// Returns the strings of the specified array converted to upper KEBAB-CASE, as <see cref="KebabUpperCase(string?)"/> does, in the input order.
    /// </summary>
    /// <param name="input">The array to convert. If <c>null</c> or empty, returns the input array.</param>
    /// <returns>A collection that converts every string to upper KEBAB-CASE as it is enumerated (the first element is read at the call, to return an empty input as is); <c>null</c> elements stay <c>null</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? KebabUpperCases(params string?[]? input) => input.KebabUpperCasesImplement();

    #endregion
}
