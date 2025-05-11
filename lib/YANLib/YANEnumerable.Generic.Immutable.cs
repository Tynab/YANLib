using System.Collections.Immutable;
using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for converting collections of objects to immutable collections.
/// </summary>
/// <remarks>
/// This partial class extends <see cref="YANEnumerable"/> with methods for converting collections of objects to immutable arrays,
/// lists, hash sets, dictionaries, stacks, queues, sorted sets, and sorted dictionaries of specific types.
/// It supports both generic and non-generic collections, as well as arrays.
/// </remarks>
public static partial class YANEnumerable
{
    /// <summary>
    /// Converts a collection of objects to an immutable array of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The collection of objects to convert. If <c>null</c> or empty, returns an empty immutable array.</param>
    /// <returns>An immutable array of type <typeparamref name="T"/> containing the converted elements, or an empty immutable array if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method attempts to parse each element in the input collection to the specified type.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ImmutableArray<T> ToImmutableArray<T>(this IEnumerable<object?>? input) => input.ToImmutableArrayImplement<T>();

    /// <summary>
    /// Converts an array of objects to an immutable array of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The array of objects to convert. If <c>null</c> or empty, returns an empty immutable array.</param>
    /// <returns>An immutable array of type <typeparamref name="T"/> containing the converted elements, or an empty immutable array if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to convert an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ImmutableArray<T> ToImmutableArray<T>(params object?[]? input) => input.ToImmutableArrayImplement<T>();

    /// <summary>
    /// Converts a non-generic collection to an immutable array of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The non-generic collection to convert. If <c>null</c>, returns an empty immutable array.</param>
    /// <returns>An immutable array of type <typeparamref name="T"/> containing the converted elements, or an empty immutable array if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before converting.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ImmutableArray<T> ToImmutableArray<T>(this System.Collections.IEnumerable? input) => input.ToImmutableArrayImplement<T>();

    /// <summary>
    /// Converts a collection of objects to an immutable list of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The collection of objects to convert. If <c>null</c> or empty, returns an empty immutable list.</param>
    /// <returns>An immutable list of type <typeparamref name="T"/> containing the converted elements, or an empty immutable list if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method attempts to parse each element in the input collection to the specified type.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ImmutableList<T> ToImmutableList<T>(this IEnumerable<object?>? input) => input.ToImmutableListImplement<T>();

    /// <summary>
    /// Converts an array of objects to an immutable list of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The array of objects to convert. If <c>null</c> or empty, returns an empty immutable list.</param>
    /// <returns>An immutable list of type <typeparamref name="T"/> containing the converted elements, or an empty immutable list if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to convert an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ImmutableList<T> ToImmutableList<T>(params object?[]? input) => input.ToImmutableListImplement<T>();

    /// <summary>
    /// Converts a non-generic collection to an immutable list of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The non-generic collection to convert. If <c>null</c>, returns an empty immutable list.</param>
    /// <returns>An immutable list of type <typeparamref name="T"/> containing the converted elements, or an empty immutable list if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before converting.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ImmutableList<T> ToImmutableList<T>(this System.Collections.IEnumerable? input) => input.ToImmutableListImplement<T>();

    /// <summary>
    /// Converts a collection of objects to an immutable hash set of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The collection of objects to convert. If <c>null</c> or empty, returns an empty immutable hash set.</param>
    /// <returns>An immutable hash set of type <typeparamref name="T"/> containing the converted elements, or an empty immutable hash set if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method attempts to parse each element in the input collection to the specified type.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// Duplicate elements after conversion will be removed as hash sets only contain unique elements.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ImmutableHashSet<T> ToImmutableHashSet<T>(this IEnumerable<object?>? input) => input.ToImmutableHashSetImplement<T>();

    /// <summary>
    /// Converts an array of objects to an immutable hash set of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The array of objects to convert. If <c>null</c> or empty, returns an empty immutable hash set.</param>
    /// <returns>An immutable hash set of type <typeparamref name="T"/> containing the converted elements, or an empty immutable hash set if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to convert an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// Duplicate elements after conversion will be removed as hash sets only contain unique elements.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ImmutableHashSet<T> ToImmutableHashSet<T>(params object?[]? input) => input.ToImmutableHashSetImplement<T>();

    /// <summary>
    /// Converts a non-generic collection to an immutable hash set of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The non-generic collection to convert. If <c>null</c>, returns an empty immutable hash set.</param>
    /// <returns>An immutable hash set of type <typeparamref name="T"/> containing the converted elements, or an empty immutable hash set if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before converting.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// Duplicate elements after conversion will be removed as hash sets only contain unique elements.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ImmutableHashSet<T> ToImmutableHashSet<T>(this System.Collections.IEnumerable? input) => input.ToImmutableHashSetImplement<T>();

    /// <summary>
    /// Converts a collection of objects to an immutable dictionary with keys and values of the specified types.
    /// </summary>
    /// <typeparam name="T">The type of elements in the input collection.</typeparam>
    /// <typeparam name="TKey">The unmanaged key type for the resulting immutable dictionary.</typeparam>
    /// <typeparam name="TValue">The value type for the resulting immutable dictionary.</typeparam>
    /// <typeparam name="TK">The type returned by the key selector function.</typeparam>
    /// <typeparam name="TV">The type returned by the element selector function.</typeparam>
    /// <param name="input">The collection of objects to convert. If <c>null</c> or empty, returns an empty immutable dictionary.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="elementSelector">A function to extract a value from each element.</param>
    /// <returns>An immutable dictionary with keys of type <typeparamref name="TKey"/> and values of type <typeparamref name="TValue"/>, or an empty immutable dictionary if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method filters the input collection to include only elements of type <typeparamref name="T"/>.
    /// The key selector and element selector functions are applied to each element, and the results are parsed to the specified key and value types.
    /// If duplicate keys are encountered after parsing, an exception will be thrown.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ImmutableDictionary<TKey, TValue?> ToImmutableDictionary<T, TKey, TValue, TK, TV>(this IEnumerable<object?>? input, Func<T, TK> keySelector, Func<T, TV> elementSelector) where TKey : unmanaged where TK : unmanaged
        => input.ToImmutableDictionaryImplement<T, TKey, TValue, TK, TV>(keySelector, elementSelector);

    /// <summary>
    /// Converts a collection of objects to an immutable stack of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The collection of objects to convert. If <c>null</c> or empty, returns an empty immutable stack.</param>
    /// <returns>An immutable stack of type <typeparamref name="T"/> containing the converted elements, or an empty immutable stack if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method attempts to parse each element in the input collection to the specified type.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// The order of elements in the stack will be the reverse of the order in the input collection (last in, first out).
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ImmutableStack<T> ToImmutableStack<T>(this IEnumerable<object?>? input) => input.ToImmutableStackImplement<T>();

    /// <summary>
    /// Converts an array of objects to an immutable stack of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The array of objects to convert. If <c>null</c> or empty, returns an empty immutable stack.</param>
    /// <returns>An immutable stack of type <typeparamref name="T"/> containing the converted elements, or an empty immutable stack if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to convert an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// The order of elements in the stack will be the reverse of the order in the input array (last in, first out).
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ImmutableStack<T> ToImmutableStack<T>(params object?[]? input) => input.ToImmutableStackImplement<T>();

    /// <summary>
    /// Converts a non-generic collection to an immutable stack of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The non-generic collection to convert. If <c>null</c>, returns an empty immutable stack.</param>
    /// <returns>An immutable stack of type <typeparamref name="T"/> containing the converted elements, or an empty immutable stack if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before converting.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// The order of elements in the stack will be the reverse of the order in the input collection (last in, first out).
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ImmutableStack<T> ToImmutableStack<T>(this System.Collections.IEnumerable? input) => input.ToImmutableStackImplement<T>();

    /// <summary>
    /// Converts a collection of objects to an immutable queue of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The collection of objects to convert. If <c>null</c> or empty, returns an empty immutable queue.</param>
    /// <returns>An immutable queue of type <typeparamref name="T"/> containing the converted elements, or an empty immutable queue if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method attempts to parse each element in the input collection to the specified type.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// The order of elements in the queue will be the same as the order in the input collection (first in, first out).
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ImmutableQueue<T> ToImmutableQueue<T>(this IEnumerable<object?>? input) => input.ToImmutableQueueImplement<T>();

    /// <summary>
    /// Converts an array of objects to an immutable queue of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The array of objects to convert. If <c>null</c> or empty, returns an empty immutable queue.</param>
    /// <returns>An immutable queue of type <typeparamref name="T"/> containing the converted elements, or an empty immutable queue if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to convert an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// The order of elements in the queue will be the same as the order in the input array (first in, first out).
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ImmutableQueue<T> ToImmutableQueue<T>(params object?[]? input) => input.ToImmutableQueueImplement<T>();

    /// <summary>
    /// Converts a non-generic collection to an immutable queue of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The non-generic collection to convert. If <c>null</c>, returns an empty immutable queue.</param>
    /// <returns>An immutable queue of type <typeparamref name="T"/> containing the converted elements, or an empty immutable queue if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before converting.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// The order of elements in the queue will be the same as the order in the input collection (first in, first out).
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ImmutableQueue<T> ToImmutableQueue<T>(this System.Collections.IEnumerable? input) => input.ToImmutableQueueImplement<T>();

    /// <summary>
    /// Converts a collection of objects to an immutable sorted set of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The collection of objects to convert. If <c>null</c> or empty, returns an empty immutable sorted set.</param>
    /// <returns>An immutable sorted set of type <typeparamref name="T"/> containing the converted elements, or an empty immutable sorted set if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method attempts to parse each element in the input collection to the specified type.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// Duplicate elements after conversion will be removed as sorted sets only contain unique elements.
    /// The elements will be sorted according to the default comparer for type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ImmutableSortedSet<T> ToImmutableSortedSet<T>(this IEnumerable<object?>? input) => input.ToImmutableSortedSetImplement<T>();

    /// <summary>
    /// Converts an array of objects to an immutable sorted set of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The array of objects to convert. If <c>null</c> or empty, returns an empty immutable sorted set.</param>
    /// <returns>An immutable sorted set of type <typeparamref name="T"/> containing the converted elements, or an empty immutable sorted set if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to convert an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// Duplicate elements after conversion will be removed as sorted sets only contain unique elements.
    /// The elements will be sorted according to the default comparer for type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ImmutableSortedSet<T> ToImmutableSortedSet<T>(params object?[]? input) => input.ToImmutableSortedSetImplement<T>();

    /// <summary>
    /// Converts a non-generic collection to an immutable sorted set of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to.</typeparam>
    /// <param name="input">The non-generic collection to convert. If <c>null</c>, returns an empty immutable sorted set.</param>
    /// <returns>An immutable sorted set of type <typeparamref name="T"/> containing the converted elements, or an empty immutable sorted set if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before converting.
    /// Elements that cannot be parsed will use the default value of <typeparamref name="T"/>.
    /// Duplicate elements after conversion will be removed as sorted sets only contain unique elements.
    /// The elements will be sorted according to the default comparer for type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ImmutableSortedSet<T> ToImmutableSortedSet<T>(this System.Collections.IEnumerable? input) => input.ToImmutableSortedSetImplement<T>();

    /// <summary>
    /// Converts a collection of objects to an immutable sorted dictionary with keys and values of the specified types.
    /// </summary>
    /// <typeparam name="T">The type of elements in the input collection.</typeparam>
    /// <typeparam name="TKey">The unmanaged key type for the resulting immutable sorted dictionary.</typeparam>
    /// <typeparam name="TValue">The value type for the resulting immutable sorted dictionary.</typeparam>
    /// <typeparam name="TK">The type returned by the key selector function.</typeparam>
    /// <typeparam name="TV">The type returned by the element selector function.</typeparam>
    /// <param name="input">The collection of objects to convert. If <c>null</c> or empty, returns an empty immutable sorted dictionary.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="elementSelector">A function to extract a value from each element.</param>
    /// <returns>An immutable sorted dictionary with keys of type <typeparamref name="TKey"/> and values of type <typeparamref name="TValue"/>, or an empty immutable sorted dictionary if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method filters the input collection to include only elements of type <typeparamref name="T"/>.
    /// The key selector and element selector functions are applied to each element, and the results are parsed to the specified key and value types.
    /// If duplicate keys are encountered after parsing, an exception will be thrown.
    /// The keys will be sorted according to the default comparer for type <typeparamref name="TKey"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ImmutableSortedDictionary<TKey, TValue?> ToImmutableSortedDictionary<T, TKey, TValue, TK, TV>(this IEnumerable<object?>? input, Func<T, TK> keySelector, Func<T, TV> elementSelector) where TKey : unmanaged where TK : unmanaged
        => input.ToImmutableSortedDictionaryImplement<T, TKey, TValue, TK, TV>(keySelector, elementSelector);
}
