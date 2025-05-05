using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for parsing collections of objects to collections of nullable types.
/// </summary>
/// <remarks>
/// This partial class contains methods for converting collections of objects to collections of nullable types.
/// It supports both generic and non-generic collections, as well as arrays. For large collections,
/// these methods utilize parallel processing for improved performance.
/// </remarks>
public static partial class YANUnmanaged
{
    /// <summary>
    /// Parses a collection of objects to a collection of the specified nullable type.
    /// </summary>
    /// <typeparam name="T">The type to parse to. Can be any type, including reference types and nullable value types.</typeparam>
    /// <param name="input">The collection of objects to parse. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection of parsed values of type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// Elements that cannot be parsed will be <c>null</c> in the resulting collection.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Parses<T>(this IEnumerable<object?>? input) => input.ParsesImplement<T>();

    /// <summary>
    /// Parses an array of objects to a collection of the specified nullable type.
    /// </summary>
    /// <typeparam name="T">The type to parse to. Can be any type, including reference types and nullable value types.</typeparam>
    /// <param name="input">The array of objects to parse. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection of parsed values of type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to parse an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// Elements that cannot be parsed will be <c>null</c> in the resulting collection.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Parses<T>(params object?[]? input) => input.ParsesImplement<T>();

    /// <summary>
    /// Parses a non-generic collection of objects to a collection of the specified nullable type.
    /// </summary>
    /// <typeparam name="T">The type to parse to. Can be any type, including reference types and nullable value types.</typeparam>
    /// <param name="input">The non-generic collection of objects to parse. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>A collection of parsed values of type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before parsing.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// Elements that cannot be parsed will be <c>null</c> in the resulting collection.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Parses<T>(this System.Collections.IEnumerable? input) => input.ParsesImplement<T>();
}
