using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for parsing collections of objects to collections of unmanaged types.
/// </summary>
/// <remarks>
/// This partial class contains methods specifically for working with collections, supporting both
/// generic and non-generic collections. Methods that return <see cref="IEnumerable{T}"/> are lazily evaluated
/// and preserve the input order.
/// </remarks>
public static partial class YANUnmanaged
{
    /// <summary>
    /// Parses a collection of objects to a collection of the specified unmanaged type.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to parse to.</typeparam>
    /// <param name="input">The collection of objects to parse. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <param name="defaultValue">The default value to use for elements that cannot be parsed. If <c>null</c>, uses the default value of <typeparamref name="T"/>.</param>
    /// <param name="format">The format strings to use for parsing. Used primarily for <see cref="DateTime"/> parsing.</param>
    /// <returns>A collection of parsed values of type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// The result is lazily evaluated and preserves input order.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T>? Parses<T>(this IEnumerable<object?>? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged => input.ParsesImplement<T>(defaultValue, format);

    /// <summary>
    /// Parses a collection of objects to a collection of the specified unmanaged type using the provided format strings.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to parse to.</typeparam>
    /// <param name="input">The collection of objects to parse. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <param name="defaultValue">The default value to use for elements that cannot be parsed. If <c>null</c>, uses the default value of <typeparamref name="T"/>.</param>
    /// <param name="format">The format strings to use for parsing. Used primarily for <see cref="DateTime"/> parsing.</param>
    /// <returns>A collection of parsed values of type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This overload accepts format strings as params array for convenience.
    /// The result is lazily evaluated and preserves input order.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T>? Parses<T>(this IEnumerable<object?>? input, object? defaultValue = null, params string?[]? format) where T : unmanaged => input.ParsesImplement<T>(defaultValue, format);

    /// <summary>
    /// Parses a non-generic collection of objects to a collection of the specified unmanaged type.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to parse to.</typeparam>
    /// <param name="input">The non-generic collection of objects to parse. If <c>null</c>, returns <c>null</c>.</param>
    /// <param name="defaultValue">The default value to use for elements that cannot be parsed. If <c>null</c>, uses the default value of <typeparamref name="T"/>.</param>
    /// <param name="format">The format strings to use for parsing. Used primarily for <see cref="DateTime"/> parsing.</param>
    /// <returns>A collection of parsed values of type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before parsing.
    /// The result is lazily evaluated and preserves input order.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T>? Parses<T>(this System.Collections.IEnumerable? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged => input.ParsesImplement<T>(defaultValue, format);

    /// <summary>
    /// Parses a non-generic collection of objects to a collection of the specified unmanaged type using the provided format strings.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to parse to.</typeparam>
    /// <param name="input">The non-generic collection of objects to parse. If <c>null</c>, returns <c>null</c>.</param>
    /// <param name="defaultValue">The default value to use for elements that cannot be parsed. If <c>null</c>, uses the default value of <typeparamref name="T"/>.</param>
    /// <param name="format">The format strings to use for parsing. Used primarily for <see cref="DateTime"/> parsing.</param>
    /// <returns>A collection of parsed values of type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This overload accepts format strings as params array for convenience.
    /// This method first casts the non-generic collection to a generic collection of objects before parsing.
    /// The result is lazily evaluated and preserves input order.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T>? Parses<T>(this System.Collections.IEnumerable? input, object? defaultValue = null, params string?[]? format) where T : unmanaged => input.ParsesImplement<T>(defaultValue, format);

    /// <summary>
    /// Parses a collection of objects to a collection of the specified unmanaged type with the given culture-specific format information.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to parse to.</typeparam>
    /// <param name="input">The collection of objects to parse. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <param name="provider">
    /// The culture-specific format information for every element (see <see cref="ParseWith{T}(object, IFormatProvider, object, IEnumerable{string})"/>).
    /// If <c>null</c>, the current culture of the enumerating thread is read for each element, exactly as by
    /// <see cref="Parses{T}(IEnumerable{object}, object, IEnumerable{string})"/>.
    /// </param>
    /// <param name="defaultValue">The default value to use for elements that cannot be parsed. If <c>null</c>, uses the default value of <typeparamref name="T"/>.</param>
    /// <param name="format">The exact format strings for <see cref="DateTime"/> parsing, always matched with the invariant culture.</param>
    /// <returns>A collection of parsed values of type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// Each element is parsed like <see cref="ParseWith{T}(object, IFormatProvider, object, IEnumerable{string})"/>.
    /// The result is lazily evaluated and preserves input order.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T>? ParsesWith<T>(this IEnumerable<object?>? input, IFormatProvider? provider, object? defaultValue, IEnumerable<string?>? format) where T : unmanaged
        => input.ParsesWithImplement<T>(provider, defaultValue, format);

    /// <summary>
    /// Parses a collection of objects to a collection of the specified unmanaged type with the given culture-specific format information and the provided format strings.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to parse to.</typeparam>
    /// <param name="input">The collection of objects to parse. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <param name="provider">
    /// The culture-specific format information for every element (see <see cref="ParseWith{T}(object, IFormatProvider, object, IEnumerable{string})"/>).
    /// If <c>null</c>, the current culture of the enumerating thread is read for each element, exactly as by
    /// <see cref="Parses{T}(IEnumerable{object}, object, string[])"/>.
    /// </param>
    /// <param name="defaultValue">The default value to use for elements that cannot be parsed. If <c>null</c>, uses the default value of <typeparamref name="T"/>.</param>
    /// <param name="format">The exact format strings for <see cref="DateTime"/> parsing, always matched with the invariant culture.</param>
    /// <returns>A collection of parsed values of type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This overload accepts format strings as params array for convenience.
    /// Each element is parsed like <see cref="ParseWith{T}(object, IFormatProvider, object, string[])"/>.
    /// The result is lazily evaluated and preserves input order.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T>? ParsesWith<T>(this IEnumerable<object?>? input, IFormatProvider? provider, object? defaultValue, params string?[]? format) where T : unmanaged
        => input.ParsesWithImplement<T>(provider, defaultValue, format);

    /// <summary>
    /// Parses a non-generic collection of objects to a collection of the specified unmanaged type with the given culture-specific format information.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to parse to.</typeparam>
    /// <param name="input">The non-generic collection of objects to parse. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <param name="provider">
    /// The culture-specific format information for every element (see <see cref="ParseWith{T}(object, IFormatProvider, object, IEnumerable{string})"/>).
    /// If <c>null</c>, the current culture of the enumerating thread is read for each element, exactly as by
    /// <see cref="Parses{T}(System.Collections.IEnumerable, object, IEnumerable{string})"/>.
    /// </param>
    /// <param name="defaultValue">The default value to use for elements that cannot be parsed. If <c>null</c>, uses the default value of <typeparamref name="T"/>.</param>
    /// <param name="format">The exact format strings for <see cref="DateTime"/> parsing, always matched with the invariant culture.</param>
    /// <returns>A collection of parsed values of type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before parsing.
    /// The result is lazily evaluated and preserves input order.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T>? ParsesWith<T>(this System.Collections.IEnumerable? input, IFormatProvider? provider, object? defaultValue, IEnumerable<string?>? format) where T : unmanaged
        => input.ParsesWithImplement<T>(provider, defaultValue, format);

    /// <summary>
    /// Parses a non-generic collection of objects to a collection of the specified unmanaged type with the given culture-specific format information and the provided format strings.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to parse to.</typeparam>
    /// <param name="input">The non-generic collection of objects to parse. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <param name="provider">
    /// The culture-specific format information for every element (see <see cref="ParseWith{T}(object, IFormatProvider, object, IEnumerable{string})"/>).
    /// If <c>null</c>, the current culture of the enumerating thread is read for each element, exactly as by
    /// <see cref="Parses{T}(System.Collections.IEnumerable, object, string[])"/>.
    /// </param>
    /// <param name="defaultValue">The default value to use for elements that cannot be parsed. If <c>null</c>, uses the default value of <typeparamref name="T"/>.</param>
    /// <param name="format">The exact format strings for <see cref="DateTime"/> parsing, always matched with the invariant culture.</param>
    /// <returns>A collection of parsed values of type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This overload accepts format strings as params array for convenience.
    /// This method first casts the non-generic collection to a generic collection of objects before parsing.
    /// The result is lazily evaluated and preserves input order.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T>? ParsesWith<T>(this System.Collections.IEnumerable? input, IFormatProvider? provider, object? defaultValue, params string?[]? format) where T : unmanaged
        => input.ParsesWithImplement<T>(provider, defaultValue, format);

    /// <summary>
    /// Parses a dictionary of objects to a dictionary with keys of the specified unmanaged type and values of the specified nullable type.
    /// </summary>
    /// <typeparam name="TKey">The unmanaged key type to parse to.</typeparam>
    /// <typeparam name="TValue">The value type to parse to. Can be any type, including reference types and nullable value types.</typeparam>
    /// <param name="input">The dictionary of objects to parse. If <c>null</c> or empty, returns an empty dictionary.</param>
    /// <returns>A dictionary with keys of type <typeparamref name="TKey"/> and values of type <typeparamref name="TValue"/>, or an empty dictionary if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method parses both the keys and values of the input dictionary to the specified types.
    /// Keys that cannot be parsed will use the default value of <typeparamref name="TKey"/>.
    /// Values that cannot be parsed will be the default value of <typeparamref name="TValue"/> in the resulting dictionary: <c>null</c> for a
    /// reference type or a nullable value type, otherwise <c>default(TValue)</c> (for example <c>0</c> for <see cref="int"/>).
    /// If two keys parse to the same value (<c>"1"</c> and <c>1</c>, or <c>"3.2"</c> and <c>"3.7"</c>, which are both floored to 3 for <see cref="int"/>
    /// under a culture whose decimal separator is <c>.</c>), an <see cref="ArgumentException"/> is thrown;
    /// <see cref="Parses{TKey, TValue}(IDictionary{object, object}, Func{TValue, TValue, TValue})"/> lets the caller choose the value instead.
    /// </remarks>
    /// <exception cref="ArgumentException">Thrown when two keys of <paramref name="input"/> parse to the same <typeparamref name="TKey"/> value.</exception>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static Dictionary<TKey, TValue?> Parses<TKey, TValue>(this IDictionary<object, object?>? input) where TKey : unmanaged => input.ParsesImplement<TKey, TValue>();

    /// <summary>
    /// Parses a dictionary of objects to a dictionary with keys of the specified unmanaged type and values of the specified nullable type,
    /// resolving keys that parse to the same value with <paramref name="onDuplicate"/>.
    /// </summary>
    /// <typeparam name="TKey">The unmanaged key type to parse to.</typeparam>
    /// <typeparam name="TValue">The value type to parse to. Can be any type, including reference types and nullable value types.</typeparam>
    /// <param name="input">The dictionary of objects to parse. If <c>null</c> or empty, returns an empty dictionary.</param>
    /// <param name="onDuplicate">
    /// Called when a key parses to a value that is already in the result, with the value stored for it and the parsed value of the new entry;
    /// its result is stored. <c>(stored, incoming) =&gt; stored</c> keeps the first value, <c>(stored, incoming) =&gt; incoming</c> the last one.
    /// </param>
    /// <returns>A dictionary with keys of type <typeparamref name="TKey"/> and values of type <typeparamref name="TValue"/>, or an empty dictionary if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// Keys and values are parsed as by <see cref="Parses{TKey, TValue}(IDictionary{object, object})"/>, in the enumeration order of <paramref name="input"/>,
    /// which decides what "first" and "last" mean (insertion order for a <see cref="Dictionary{TKey, TValue}"/> without removals).
    /// <paramref name="onDuplicate"/> is not called when no two keys collide, and an exception it throws propagates.
    /// The entries of <paramref name="input"/> are read once, before any key is parsed, and are not re-keyed under another comparer, so keys that the
    /// comparer of <paramref name="input"/> keeps apart (two distinct <c>"1"</c> strings, or two boxes of the same value, under
    /// <see cref="ReferenceEqualityComparer"/>) reach <paramref name="onDuplicate"/> when they parse to the same value. A <c>null</c> key, which only a
    /// custom <see cref="IDictionary{TKey, TValue}"/> can hold, is parsed like any other key that cannot be parsed.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="onDuplicate"/> is <c>null</c> (also for a <c>null</c> or empty <paramref name="input"/>).</exception>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static Dictionary<TKey, TValue?> Parses<TKey, TValue>(this IDictionary<object, object?>? input, Func<TValue?, TValue?, TValue?> onDuplicate) where TKey : unmanaged
        => input.ParsesImplement<TKey, TValue>(onDuplicate);
}
