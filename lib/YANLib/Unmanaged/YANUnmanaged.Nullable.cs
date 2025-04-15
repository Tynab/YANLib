using System.Diagnostics;
using YANLib.Implementation.Unmanaged;

namespace YANLib.Unmanaged;

/// <summary>
/// Provides extension methods for parsing an object or collection of objects into a specified nullable type.
/// These methods are intended for use with reference types and nullable value types, allowing the conversion
/// to yield null when the input is null or the conversion fails.
/// </summary>
public static partial class YANUnmanaged
{
    /// <summary>
    /// Parses the given <paramref name="input"/> to the nullable type specified by <typeparamref name="T"/>.
    /// If the input is null or if the conversion fails, the method returns null.
    /// </summary>
    /// <typeparam name="T">
    /// The target nullable type for the conversion. This can be any reference type or nullable value type.
    /// </typeparam>
    /// <param name="input">The object to be parsed. May be null.</param>
    /// <returns>
    /// An instance of type <typeparamref name="T"/> converted from the input, or null if the conversion fails or the input is null.
    /// </returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Parse<T>(this object? input) => input.ParseImplement<T>();

    /// <summary>
    /// Parses a collection of objects into an enumerable collection of the nullable type <typeparamref name="T"/>.
    /// If an element cannot be parsed, it is represented as null in the resulting collection.
    /// </summary>
    /// <typeparam name="T">
    /// The nullable target type for conversion. This can be any reference type or nullable value type.
    /// </typeparam>
    /// <param name="input">An enumerable collection of objects to parse. May be null or empty.</param>
    /// <returns>
    /// An enumerable collection of type <typeparamref name="T"/> with parsed values, or null if the input collection is null or empty.
    /// </returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Parses<T>(this IEnumerable<object?>? input) => input.ParsesImplement<T>();

    /// <summary>
    /// Parses a params array of objects into an enumerable collection of the nullable type <typeparamref name="T"/>.
    /// Each object in the provided array is parsed, with any conversion failure represented as null.
    /// </summary>
    /// <typeparam name="T">
    /// The nullable target type for the parsing operation. This applies to both reference types and nullable value types.
    /// </typeparam>
    /// <param name="input">A params array of objects to parse. May be null.</param>
    /// <returns>
    /// An enumerable collection of parsed values of type <typeparamref name="T"/>, or null if the input array is null or empty.
    /// </returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Parses<T>(params object?[]? input) => input.ParsesImplement<T>();
}
