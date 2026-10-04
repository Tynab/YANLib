using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for parsing objects to nullable types.
/// </summary>
/// <remarks>
/// This partial class extends the functionality of <see cref="YANUnmanaged"/> to support parsing
/// to nullable types, including both nullable value types and reference types. Unlike the non-nullable
/// parsing methods, these methods return null instead of default values when parsing fails.
/// </remarks>
public static partial class YANUnmanaged
{
    /// <summary>
    /// Parses an object to the specified nullable type.
    /// </summary>
    /// <typeparam name="T">The type to parse to. Can be any type, including reference types and nullable value types.</typeparam>
    /// <param name="input">The object to parse. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>The parsed value of type <typeparamref name="T"/>, or <c>null</c> if parsing fails or the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method supports parsing to various types including strings, numeric types, <see cref="DateTime"/>, <see cref="Guid"/>, and enums.
    /// Unlike the non-nullable version, this method returns <c>null</c> instead of a default value when parsing fails.
    /// For non-nullable integral types (including <c>nint</c> and <c>nuint</c>), fractional numeric strings are rounded down, other fractional numbers are rounded to the nearest integer (ties to even), and input outside the range of <typeparamref name="T"/> returns the default value.
    /// An input that already is a <typeparamref name="T"/> is returned unchanged, so a <see cref="DateTime"/> keeps its ticks and <see cref="DateTime.Kind"/>, and an instance of a derived type parsed to its base type or <see cref="object"/> is the same instance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Parse<T>(this object? input) => input.ParseImplement<T>();
}
