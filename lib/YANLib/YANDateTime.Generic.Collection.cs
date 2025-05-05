using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides generic extension methods for working with collections of DateTime objects.
/// </summary>
/// <remarks>
/// This partial class contains generic methods for processing collections of objects that can be
/// converted to DateTime, with flexible return types for the results.
/// </remarks>
public static partial class YANDateTime
{
    /// <summary>
    /// Gets the week numbers of the year for a collection of objects and returns them as the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the week numbers to.</typeparam>
    /// <param name="input">The collection of objects to get the week numbers from. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection of week numbers converted to type <typeparamref name="T"/> corresponding to each input object, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method attempts to convert each object in the collection to a DateTime before calculating its week number.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? GetWeekOfYears<T>(this IEnumerable<object?>? input) => input.GetWeekOfYearsImplement<T>();

    /// <summary>
    /// Gets the week numbers of the year for an array of objects and returns them as the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the week numbers to.</typeparam>
    /// <param name="input">The array of objects to get the week numbers from. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection of week numbers converted to type <typeparamref name="T"/> corresponding to each input object, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to process an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method attempts to convert each object in the array to a DateTime before calculating its week number.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? GetWeekOfYears<T>(params object?[]? input) => input.GetWeekOfYearsImplement<T>();
}
