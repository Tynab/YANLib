using System.Diagnostics;
using YANLib.Implementation.Unmanaged;

namespace YANLib.Unmanaged;

/// <summary>
/// Provides extension methods for parsing an object or a collection of objects into a specified unmanaged type.
/// This static class supports converting input values to a variety of unmanaged types such as numeric types,
/// <see cref="bool"/>, <see cref="DateTime"/>, <see cref="Guid"/>, and enumerations. It also allows specifying
/// default values and custom format strings (e.g. for date and time parsing).
/// </summary>
public static partial class YANUnmanaged
{
    /// <summary>
    /// Parses the given <paramref name="input"/> to the unmanaged type specified by the type parameter <typeparamref name="T"/>.
    /// If the conversion fails or the input is null, the method returns the specified <paramref name="defaultValue"/> (or the default value for <typeparamref name="T"/> if not provided).
    /// For <see cref="DateTime"/> types, an optional enumerable collection of formats can be provided to guide the parsing.
    /// </summary>
    /// <typeparam name="T">The unmanaged target type to convert the input into.</typeparam>
    /// <param name="input">The input object to be parsed. It may be null.</param>
    /// <param name="defaultValue">
    /// An optional default value to return if the parsing fails. If not provided and parsing fails, the default value of <typeparamref name="T"/> is returned.
    /// </param>
    /// <param name="format">
    /// An optional sequence of string formats used for parsing date/time values when <typeparamref name="T"/> is <see cref="DateTime"/>.
    /// </param>
    /// <returns>
    /// An instance of type <typeparamref name="T"/> that represents the parsed value from the input, or the default value if parsing fails.
    /// </returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T Parse<T>(this object? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged => input.ParseImplement<T>(defaultValue, format);

    /// <summary>
    /// Parses the given <paramref name="input"/> to the unmanaged type specified by the type parameter <typeparamref name="T"/>,
    /// with support for specifying custom format strings via a params array.
    /// If the input is null or the conversion fails, the specified <paramref name="defaultValue"/> (or the default value for <typeparamref name="T"/> if not provided) is returned.
    /// </summary>
    /// <typeparam name="T">The unmanaged target type to convert the input into.</typeparam>
    /// <param name="input">The input object to be parsed. It may be null.</param>
    /// <param name="defaultValue">
    /// An optional default value to return if the parsing fails. If not provided and parsing fails, the default value of <typeparamref name="T"/> is returned.
    /// </param>
    /// <param name="format">
    /// A params array of string formats used for parsing date/time values when <typeparamref name="T"/> is <see cref="DateTime"/>.
    /// </param>
    /// <returns>
    /// An instance of type <typeparamref name="T"/> representing the parsed result, or the default value if parsing fails.
    /// </returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T Parse<T>(this object? input, object? defaultValue = null, params string?[]? format) where T : unmanaged => input.ParseImplement<T>(defaultValue, format);

    /// <summary>
    /// Parses a collection of input objects into an enumerable collection of the unmanaged type <typeparamref name="T"/>.
    /// If an individual value cannot be parsed, that element is replaced with the specified default or the default value of <typeparamref name="T"/>.
    /// For <see cref="DateTime"/> types, an optional collection of formats may be provided.
    /// </summary>
    /// <typeparam name="T">The unmanaged type into which each element of the input is parsed.</typeparam>
    /// <param name="input">An enumerable collection of objects to be parsed. May be null or empty.</param>
    /// <param name="defaultValue">
    /// An optional default value to use for elements that cannot be converted. If not provided, the default value of <typeparamref name="T"/> is used.
    /// </param>
    /// <param name="format">
    /// An optional sequence of string formats to use when parsing date/time values.
    /// </param>
    /// <returns>
    /// An enumerable collection of parsed values of type <typeparamref name="T"/>, or null if the input collection is null or empty.
    /// </returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T>? Parses<T>(this IEnumerable<object?>? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged => input.ParsesImplement<T>(defaultValue, format);

    /// <summary>
    /// Parses a collection of input objects into an enumerable collection of the unmanaged type <typeparamref name="T"/>,
    /// with support for passing custom date/time parsing formats via a params array.
    /// If an individual input cannot be parsed, the corresponding element in the result is set to the specified default value or the default value of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The unmanaged target type for the conversion.</typeparam>
    /// <param name="input">An enumerable collection of objects to be parsed. Can be null or empty.</param>
    /// <param name="defaultValue">
    /// An optional default value to apply for any element that fails to parse. If omitted, the default value of <typeparamref name="T"/> is used.
    /// </param>
    /// <param name="format">
    /// A params array of string formats used for parsing date/time values.
    /// </param>
    /// <returns>
    /// An enumerable collection of values parsed as type <typeparamref name="T"/>, or null if the input collection is null or empty.
    /// </returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T>? Parses<T>(this IEnumerable<object?>? input, object? defaultValue = null, params string?[]? format) where T : unmanaged => input.ParsesImplement<T>(defaultValue, format);
}
