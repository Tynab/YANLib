using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for converting collections of objects to strongly-typed collections.
/// </summary>
/// <remarks>
/// This class contains methods for converting collections of objects to arrays, lists, hash sets, dictionaries, and lookups
/// of specific types. It supports both generic and non-generic collections, as well as arrays.
/// </remarks>
public static partial class YANEnumerable
{
    /// <summary>
    /// Converts a collection of objects to an array of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The collection of objects to convert. If <c>null</c> or empty, returns an empty array.</param>
    /// <returns>An array of type <typeparamref name="T"/> containing the converted elements, or an empty array if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method attempts to parse each element in the input collection to the specified type.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T[] ToArray<T>(this IEnumerable<object?>? input) => input.ToArrayImplement<T>();

    /// <summary>
    /// Converts an array of objects to an array of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The array of objects to convert. If <c>null</c> or empty, returns an empty array.</param>
    /// <returns>An array of type <typeparamref name="T"/> containing the converted elements, or an empty array if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to convert an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T[] ToArray<T>(params object?[]? input) => input.ToArrayImplement<T>();

    /// <summary>
    /// Converts a non-generic collection to an array of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The non-generic collection to convert. If <c>null</c>, returns an empty array.</param>
    /// <returns>An array of type <typeparamref name="T"/> containing the converted elements, or an empty array if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before converting.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T[] ToArray<T>(this System.Collections.IEnumerable? input) => input.ToArrayImplement<T>();

    /// <summary>
    /// Converts a collection of objects to a list of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The collection of objects to convert. If <c>null</c> or empty, returns an empty list.</param>
    /// <returns>A list of type <typeparamref name="T"/> containing the converted elements, or an empty list if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method attempts to parse each element in the input collection to the specified type.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static List<T> ToList<T>(this IEnumerable<object?>? input) => input.ToListImplement<T>();

    /// <summary>
    /// Converts an array of objects to a list of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The array of objects to convert. If <c>null</c> or empty, returns an empty list.</param>
    /// <returns>A list of type <typeparamref name="T"/> containing the converted elements, or an empty list if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to convert an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static List<T> ToList<T>(params object?[]? input) => input.ToListImplement<T>();

    /// <summary>
    /// Converts a non-generic collection to a list of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The non-generic collection to convert. If <c>null</c>, returns an empty list.</param>
    /// <returns>A list of type <typeparamref name="T"/> containing the converted elements, or an empty list if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before converting.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static List<T> ToList<T>(this System.Collections.IEnumerable? input) => input.ToListImplement<T>();

    /// <summary>
    /// Converts a collection of objects to a hash set of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The collection of objects to convert. If <c>null</c> or empty, returns an empty hash set.</param>
    /// <returns>A hash set of type <typeparamref name="T"/> containing the converted elements, or an empty hash set if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method attempts to parse each element in the input collection to the specified type.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// Duplicate elements after conversion will be removed as hash sets only contain unique elements.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static HashSet<T> ToHashSet<T>(this IEnumerable<object?>? input) => input.ToHashSetImplement<T>();

    /// <summary>
    /// Converts an array of objects to a hash set of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The array of objects to convert. If <c>null</c> or empty, returns an empty hash set.</param>
    /// <returns>A hash set of type <typeparamref name="T"/> containing the converted elements, or an empty hash set if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to convert an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// Duplicate elements after conversion will be removed as hash sets only contain unique elements.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static HashSet<T> ToHashSet<T>(params object?[]? input) => input.ToHashSetImplement<T>();

    /// <summary>
    /// Converts a non-generic collection to a hash set of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The non-generic collection to convert. If <c>null</c>, returns an empty hash set.</param>
    /// <returns>A hash set of type <typeparamref name="T"/> containing the converted elements, or an empty hash set if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before converting.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// Duplicate elements after conversion will be removed as hash sets only contain unique elements.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static HashSet<T> ToHashSet<T>(this System.Collections.IEnumerable? input) => input.ToHashSetImplement<T>();

    /// <summary>
    /// Converts a collection of objects to a dictionary with keys and values of the specified types.
    /// </summary>
    /// <typeparam name="T">The type of elements in the input collection.</typeparam>
    /// <typeparam name="TKey">The unmanaged key type for the resulting dictionary.</typeparam>
    /// <typeparam name="TValue">The value type for the resulting dictionary.</typeparam>
    /// <typeparam name="TK">The type returned by the key selector function.</typeparam>
    /// <typeparam name="TV">The type returned by the element selector function.</typeparam>
    /// <param name="input">The collection of objects to convert. If <c>null</c> or empty, returns an empty dictionary.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="elementSelector">A function to extract a value from each element.</param>
    /// <returns>A dictionary with keys of type <typeparamref name="TKey"/> and values of type <typeparamref name="TValue"/>, or an empty dictionary if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method filters the input collection to include only elements of type <typeparamref name="T"/>.
    /// The key selector and element selector functions are applied to each element, and the results are parsed to the specified key and value types.
    /// If duplicate keys are encountered after parsing, an exception will be thrown.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static Dictionary<TKey, TValue?> ToDictionary<T, TKey, TValue, TK, TV>(this IEnumerable<object?>? input, Func<T, TK> keySelector, Func<T, TV> elementSelector) where TKey : unmanaged where TK : unmanaged
        => input.ToDictionaryImplement<T, TKey, TValue, TK, TV>(keySelector, elementSelector);

    /// <summary>
    /// Converts a collection of objects to a lookup with keys and values of the specified types.
    /// </summary>
    /// <typeparam name="T">The type of elements in the input collection.</typeparam>
    /// <typeparam name="TKey">The key type for the resulting lookup.</typeparam>
    /// <typeparam name="TElement">The element type for the resulting lookup.</typeparam>
    /// <typeparam name="TK">The type returned by the key selector function.</typeparam>
    /// <typeparam name="TE">The type returned by the element selector function.</typeparam>
    /// <param name="input">The collection of objects to convert. If <c>null</c> or empty, returns an empty lookup.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="elementSelector">A function to extract a value from each element.</param>
    /// <returns>A lookup with keys of type <typeparamref name="TKey"/> and elements of type <typeparamref name="TElement"/>, or an empty lookup if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method filters the input collection to include only elements of type <typeparamref name="T"/>.
    /// The key selector and element selector functions are applied to each element, and the results are parsed to the specified key and element types.
    /// Unlike dictionaries, lookups can contain multiple elements with the same key.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ILookup<TKey?, TElement?> ToLookup<T, TKey, TElement, TK, TE>(this IEnumerable<object?>? input, Func<T, TK> keySelector, Func<T, TE> elementSelector)
        => input.ToLookupImplement<T, TKey, TElement, TK, TE>(keySelector, elementSelector);
}
